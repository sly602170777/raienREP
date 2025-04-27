using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace Fukaya_scada_data
{
    internal class DataAccess
    {
        #region プロパティ

        #region DB接続情報
        /// <summary>DB接続情報（ユーザID）</summary>
        public static string DBUserID => ConfigurationManager.AppSettings["UID"].ToString();

        /// <summary>DB接続情報（パスワード）</summary>
        public static string DBPassword => ConfigurationManager.AppSettings["PWD"].ToString();

        /// <summary>DB接続情報（DataSource）</summary>
        public static string DataSource => ConfigurationManager.AppSettings["SVN"].ToString();

        /// <summary>OracleDataAccess用DB接続文字列</summary>
        public static string OdaConnStrings =>
            $"Data Source={DataSource};User ID={DBUserID};Password={DBPassword}";
        #endregion

        /// <summary>SCADAデータ取得元</summary>
        public static DbConnectionConfigCollection SourceConnections
        {
            get
            {
                DbConnectionConfigSection section =
                    ConfigurationManager.GetSection("scada.servers") as DbConnectionConfigSection;
                return section?.Collection;
            }
        }

        /// <summary>スキーマ名</summary>
        public static string SchemaName =>
            ConfigurationManager.AppSettings["SCHEMANAME"].ToString();

        #region ログファイル
        /// <summary>ログファイル（パス）</summary>
        public static string LogFilePath =>
            ConfigurationManager.AppSettings["LOGFILEPATH"].ToString();

        /// <summary>ログファイル（名）</summary>
        public static string LogFileName =>
            ConfigurationManager.AppSettings["LOGFILENAME"].ToString();
        #endregion

        #region エラーログファイル
        /// <summary>エラーログファイル（パス）</summary>
        public static string ErrLogFilePath =>
            ConfigurationManager.AppSettings["ERRLOGFILEPATH"].ToString();

        /// <summary>エラーログファイル（名）</summary>
        public static string ErrLogFileName =>
            ConfigurationManager.AppSettings["ERRLOGFILENAME"].ToString();
        #endregion

        /// <summary>実行日時</summary>
        public DateTime StartTime { get; set; }

        LoggerWrapper log = new LoggerWrapper();

        #endregion

        /// <summary>投入するデータの取得、編集加工のメイン処理</summary>
        public void EditDataMain()
        {
            using (OracleConnection cn = new OracleConnection(OdaConnStrings))
            {
                OracleTransaction trans = null;
                //コネクションOPEN
                cn.Open();
                cn.CommandTimeout = 300; // 300秒に設定
                StartTime = DateTime.Now;
                log.DebugLogFormat("バッチ起動時刻：" + StartTime);

                //トランザクション開始
                trans = cn.BeginTransaction();

                //データ作成
                log.DebugLogFormat("[START]データ作成");
                CreateData(cn, ref trans);
                log.DebugLogFormat("[END]データ作成");

                //データの加工編集
                // log.DebugLogFormat("[START]データの加工編集");
                // UpdateData(cn, ref trans);
                // log.DebugLogFormat("[END]データの加工編集");


                //エラーがあればロールバック、なければコミット
                if (ProcessMain.blnErrFLG)
                {
                    //ロールバック
                    log.DebugLogFormat("ロールバックします。");
                    trans.Rollback();
                }
                else
                {
                    //コミット
                    log.DebugLogFormat("コミットします。");
                    trans.Commit();
                }
            }
        }

        /// <summary>データを作成する</summary>
        private void CreateData(OracleConnection cn, ref OracleTransaction trans)
        {
            //sys2_data,PRODUCT_ITEM_INFO_HTTP3
            //1.　SCADAデータの取得と、（SCADA_DATA_SNAPSHOT）データ登録処理の呼び出しを行う
            //1.2　一意制約エラー　FLEXSCHE_RESULT_SCADA_FUKAYA　データ削除
            //1.3　前回登録したデータが存在しない(今回が初登録の)場合、変更あり
            //1.3.1前回作成データの注番切り替えフラグ更新 SCADA_DATA_SNAPSHOT
            //1.3.2注番切り替えフラグ更新 SCADA_DATA_SNAPSHOT　（postges）
            CreateScadaData(cn, ref trans);
            //2.計画データ更新処理　（SCADA_DATA_SNAPSHOT）更新
            UpdateScadaData(cn, ref trans);
            //▲▲3.計画データ登録処理（FLEXSCHE_RESULT_SCADA_FUKAYA）新規登録
            //3.1　SELECT SCADA_DATA_SNAPSHOT
            //3.2　INSERT FLEXSCHE_RESULT_SCADA_FUKAYA
            CreateResultData(cn, ref trans);
            //4.実績生産開始日時更新　（FLEXSCHE_RESULT_SCADA_FUKAYA）
            UpdateResource(cn, ref trans);
            //5.生産数量の件数カウンター処理（FLEXSCHE_RESULT_SCADA_FUKAYA）
            CreateLinksResultData(cn, ref trans);
            //6.作業実績データのステータス更新（FLEXSCHE_RESULT_SCADA_FUKAYA）
            CreateStatusResultData(cn, ref trans);
            //7.生産終了日時更新（FLEXSCHE_RESULT_SCADA_FUKAYA）
            UpdateManuendResultData(cn, ref trans);
        }

        /// <summary>SCADAデータの取得と、データ登録処理の呼び出しを行う</summary>
        // 定义一个私有方法，用于创建或更新SCADA数据快照
        // 参数：
        //   - cn: Oracle数据库连接对象
        //   - trans: 引用传递的Oracle事务对象，用于保证数据操作的原子性
        private void CreateScadaData(OracleConnection cn, ref OracleTransaction trans)
        {
            int count = 0;
            log.DebugLogFormat("[START] ", "インサート", "テーブル名：SCADA_DATA_SNAPSHOT");
            string sql =
                $@"
WITH sys AS (
    SELECT
          ptime
        , ""生産時間""
        , ""生産中停止""
        , ""段取調整ロス""
        , ""速度低下ロス""
        , ""チョコ停ロス""
        , ""故障ロス""
        , ""刃具交換ロス""
        , ""不良手直しロス""
        , ""立上りロス""
        , ""sdロス""
        , ""生産数""
        , ""規定数""
        , ""生産速度""
        , ""注番1""
        , ""注番2""
        , ""注番3""
    FROM
        sys2_data
    ORDER BY 
        ptime DESC 
    LIMIT 1
)
,pih AS (
    SELECT
          piih.ptime
        , piih.sgyshj_no
        , piih.jch_no
    FROM
        PRODUCT_ITEM_INFO_HTTP3 piih
    INNER JOIN 
        (
            SELECT 
                * 
            FROM 
                sys2_data 
            ORDER BY 
                ptime DESC 
            LIMIT 1
        ) sys2
    ON 
        sys2.""注番1"" = piih.jch_no
)
SELECT
      sys.ptime
    , sys.""生産時間""
    , sys.""生産中停止""
    , sys.""段取調整ロス""
    , sys.""速度低下ロス""
    , sys.""チョコ停ロス""
    , sys.""故障ロス""
    , sys.""刃具交換ロス""
    , sys.""不良手直しロス""
    , sys.""立上りロス""
    , sys.""sdロス""
    , sys.""生産数""
    , sys.""規定数""
    , sys.""生産速度""
    , sys.""注番1""
    , sys.""注番2""
    , sys.""注番3""
    , pih.ptime as ptime2
    , pih.sgyshj_no
    , pih.jch_no
    , @serverName as serverName
FROM
    sys
INNER JOIN
    pih
ON 
    sys.""注番1"" = pih.jch_no
ORDER BY 
    pih.ptime DESC 
LIMIT 1
";
            // 遍历所有数据源配置
            foreach (DbConnectionConfig sourceConfig in SourceConnections)
            {
                try
                {
                    //// 使用Npgsql连接PostgreSQL数据源
                    using (
                        NpgsqlConnection srcCn = new NpgsqlConnection(sourceConfig.ConnectionString)
                    )
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, srcCn))
                    {
                        log.DebugLogFormat(
                            "CreateScadaData　NpgsqlConnection :" + sourceConfig.ConnectionString
                        );
                        // 添加服务器名称参数
                        cmd.Parameters.AddWithValue("serverName", sourceConfig.Name);
                        // 使用数据适配器获取数据
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))

                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            if (cn.State == ConnectionState.Open)
                            {
                                log.DebugLogFormat(
                                    "CreateScadaData　OracleConnection 既にオープンしました。"
                                );
                            }
                            if (srcCn.State == ConnectionState.Open)
                            {
                                log.DebugLogFormat(
                                    "CreateScadaData　NpgsqlConnection 既にオープンしました。"
                                );
                            }

                            // 准备插入语句（具体实现隐藏在ScadaDataSnapshot类中）
                            string insertSql = "";
                            // 遍历查询结果
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                // 获取当前行数据
                                DataRow dr = ds.Tables[0].Rows[i];

                                ScadaDataSnapshot scadaDataSnapshot = new ScadaDataSnapshot();
                                // 获取插入SQL（工厂模式实现）
                                insertSql = ScadaDataSnapshot.InsertSql;
                                log.DebugLogFormat("CreateData insertSql", insertSql);
                                log.DebugLogFormat("SelectData Sql", sql);
                                // 生成参数列表（具体转换逻辑在CreateParamsForInsert方法）
                                List<OracleParameter> insertParamList =
                                    scadaDataSnapshot.CreateParamsForInsert(dr);
                                // 执行数据注册（插入操作）
                                count += RegisterData(
                                    cn,
                                    ref trans,
                                    dr,
                                    RegisterType.INSERT_SCADA_DATA_SNAPSHOT,
                                    insertSql,
                                    insertParamList
                                );

                                if (scadaDataSnapshot.IsChangedInstructCode(dr, cn))
                                {
                                    RegisterData(
                                        cn,
                                        ref trans,
                                        dr,
                                        RegisterType.UPDATE_SCADA_DATA_SNAPSHOT,
                                        ScadaDataSnapshot.UpdateLastOrderChangeFlagSql,
                                        scadaDataSnapshot.CreateParamsForUpdateLastOrderChangeFlag(
                                            dr
                                        )
                                    );
                                    RegisterData(
                                        cn,
                                        ref trans,
                                        dr,
                                        RegisterType.UPDATE_SCADA_DATA_SNAPSHOT,
                                        ScadaDataSnapshot.UpdateOrderChangeFlagSql,
                                        scadaDataSnapshot.CreateParamsForUpdateOrderChangeFlag(dr)
                                    );
                                }
                            }
                        }
                        if (srcCn.State == ConnectionState.Open)
                        {
                            log.DebugLogFormat(
                                "CreateScadaData　NpgsqlConnection 既にクローズしました。"
                            );
                            srcCn.Close();
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    log.ErrLogFormat(ex.Message, $"{sourceConfig.Name}からのデータ取得に失敗");
                    log.ErrLogFormat(ex.ToString());
                    log.ErrLogFormat(ex.ToString());
                    log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                    log.ErrLogFormat($"Error Code: {ex.HResult}");
                    log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                    log.ErrLogFormat($"Source: {ex.Source}");
                    log.ErrLogFormat($"Target Site: {ex.TargetSite}");
                }
                catch (Exception ex)
                {
                    log.ErrLogFormat(ex.Message, $"{sourceConfig.Name}からのデータ取得に失敗");
                    log.ErrLogFormat(ex.ToString());
                    log.ErrLogFormat(ex.ToString());
                    log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                    log.ErrLogFormat($"Error Code: {ex.HResult}");
                    log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                    log.ErrLogFormat($"Source: {ex.Source}");
                    log.ErrLogFormat($"Target Site: {ex.TargetSite}");
                }
                finally
                {
                    log.DebugLogFormat(
                        "[END] ",
                        "インサート",
                        $"テーブル名：SCADA_DATA_SNAPSHOT 処理件数：{count}"
                    );
                }
            }
        }

        /// <summary>計画データ更新処理の呼び出しを行う</summary>
        private void UpdateScadaData(OracleConnection cn, ref OracleTransaction trans)
        {
            int i = 0;
            log.DebugLogFormat("[START] ", "アップデート", "テーブル名：SCADA_DATA_SNAPSHOT");
            string sql =
                $@"
SELECT DISTINCT 
      WIT.PROCORDER_CODE 
    , WIT.WORK_PROCESS_CODE
    , WIT.WORK_PROCESS_NAME
    , SDS.PTIME
    , SDS.RESOUCE_CODE
FROM 
    {SchemaName}.WORK_INSTRUCTION WIT
INNER JOIN 
    (
        SELECT 
            MAX(PTIME) AS PTIME,RESOUCE_CODE
            ,SGYSHJ_NO 
        FROM 
            {SchemaName}.SCADA_DATA_SNAPSHOT 
        GROUP BY 
            RESOUCE_CODE
            ,SGYSHJ_NO
    ) SDS
ON 
    WIT.WORK_ORDER_NUMBER = SDS.SGYSHJ_NO
";

            try
            {
                using (OracleCommand com = new OracleCommand(sql, cn))
                using (OracleDataAdapter da = new OracleDataAdapter(com))
                using (DataSet ds = new DataSet())
                {
                    da.Fill(ds);

                    string updateSql = "";

                    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];

                        ScadaDataSnapshot scadaDataSnapshot = new ScadaDataSnapshot();

                        updateSql = ScadaDataSnapshot.updateSql;
                        List<OracleParameter> ParamList = scadaDataSnapshot.CreateParamsForUpdate(
                            dr
                        );
                        log.DebugLogFormat("UpdateScadaData sql", sql);
                        log.DebugLogFormat("UpdateScadaData updateSql", updateSql);
                        ParamList.ForEach(param =>
                            log.DebugLogFormat("UpdateScadaData param", param.ToString())
                        );
                        RegisterData(
                            cn,
                            ref trans,
                            dr,
                            RegisterType.UPDATE_SCADA_DATA_SNAPSHOT,
                            updateSql,
                            ParamList
                        );
                        ParamList.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrLogFormat(ex.Message, $"UpdateScadaData error 発生しました");
                log.ErrLogFormat(ex.ToString());
                log.ErrLogFormat(ex.ToString());
                log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                log.ErrLogFormat($"Error Code: {ex.HResult}");
                log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                log.ErrLogFormat($"Source: {ex.Source}");
                log.ErrLogFormat($"Target Site: {ex.TargetSite}");

                throw;
            }
            finally
            {
                //コネクションを閉じる
                if (cn.State == ConnectionState.Open)
                {
                    log.DebugLogFormat(
                        "[END] ",
                        "アップデート",
                        $"SCADA_DATA_SNAPSHOT 処理件数：{i}"
                    );
                }
            }
        }

        /// <summary>計画データ登録処理</summary>
        private void CreateResultData(OracleConnection cn, ref OracleTransaction trans)
        {
            int i = 0;
            log.DebugLogFormat(
                "[START] ",
                "インサート",
                "テーブル名：FLEXSCHE_RESULT_SCADA_FUKAYA"
            );
            string sql =
                $@"
SELECT DISTINCT
      sds.PROCORDER_CODE
    , sds.INSTRUCT_CODE
    , sds.RESOUCE_CODE
    , :StartTime AS NewCollection　　//バッチ処理の開始時刻
    , sds.ORDER_CHANGE_FLAG
    , sds.PTIME
    , opr.PRIMARY_RESOURCE
FROM 
    (
        SELECT 
            * 
        FROM 
            {SchemaName}.SCADA_DATA_SNAPSHOT 
        WHERE 
            PROCORDER_CODE IS NOT NULL 
        AND 
            (
                ORDER_CHANGE_FLAG IS NULL 
                OR 
                ORDER_CHANGE_FLAG IN ('0', '1')
            ) 
        AND 
            PTIME >= :StartTime
    ) sds
LEFT JOIN
    {SchemaName}.OPERATION opr
ON 
    sds.PROCORDER_CODE = opr.CODE
";

            try
            {
                using (OracleCommand com = new OracleCommand(sql, cn))
                {
                    com.Parameters.Add(new OracleParameter("StartTime", StartTime));
                    log.DebugLogFormat("CreateResultData実行時刻：" + DateTime.Now);
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);

                        string insertSql = "";

                        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];

                            FlexscheResultScada flexscheResultScada = new FlexscheResultScada();

                            insertSql = FlexscheResultScada.InsertSql;
                            log.DebugLogFormat("CreateResultData sql", sql);
                            log.DebugLogFormat("CreateResultData insertSql", insertSql);
                            List<OracleParameter> insertParamList =
                                flexscheResultScada.CreateParamsForInsert(dr);
                            insertParamList.ForEach(param =>
                                log.DebugLogFormat("CreateResultData param", param.ToString())
                            );
                            RegisterData(
                                cn,
                                ref trans,
                                dr,
                                RegisterType.INSERT_FLEXSCHE_RESULT_SCADA,
                                insertSql,
                                insertParamList
                            );
                            insertParamList.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrLogFormat(ex.Message, $"CreateResultData error 発生しました");
                log.ErrLogFormat(ex.ToString());
                log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                log.ErrLogFormat($"Error Code: {ex.HResult}");
                log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                log.ErrLogFormat($"Source: {ex.Source}");
                log.ErrLogFormat($"Target Site: {ex.TargetSite}");

                throw;
            }
            finally
            {
                //コネクションを閉じる
                if (cn.State == ConnectionState.Open)
                {
                    log.DebugLogFormat(
                        "[END] ",
                        "インサート",
                        $"FLEXSCHE_RESULT_SCADA_FUKAYA 処理件数：{i}"
                    );
                }
            }
        }

        /// <summary>実績生産開始日時更新</summary>
        private void UpdateResource(OracleConnection cn, ref OracleTransaction trans)
        {
            int i = 0;
            log.DebugLogFormat(
                "[START] ",
                "アップデート",
                "テーブル名：FLEXSCHE_RESULT_SCADA_FUKAYA"
            );

            string sql =
                $@"
SELECT
    SDS2.PTIME,
    SDS1.PROCORDER_CODE
FROM 
    (SELECT * FROM {SchemaName}.SCADA_DATA_SNAPSHOT WHERE (ORDER_CHANGE_FLAG IS NULL OR ORDER_CHANGE_FLAG IN ('0', '1')) AND PTIME >= :StartTime AND PROCORDER_CODE IS NOT NULL) SDS1
INNER JOIN
    (SELECT RESOUCE_CODE,INSTRUCT_CODE,SGYSHJ_NO,PTIME FROM {SchemaName}.SCADA_DATA_SNAPSHOT SDS4
     WHERE  ORDER_CHANGE_FLAG = '0' 
     AND    PTIME = (SELECT MAX(PTIME) 
                     FROM {SchemaName}.SCADA_DATA_SNAPSHOT SDS3
                     WHERE SDS3.RESOUCE_CODE  = SDS4.RESOUCE_CODE
                     AND   SDS3.INSTRUCT_CODE = SDS4.INSTRUCT_CODE
                     AND   SDS3.SGYSHJ_NO     = SDS4.SGYSHJ_NO
                     AND   SDS3.ORDER_CHANGE_FLAG = '0')) SDS2
ON  SDS1.RESOUCE_CODE  = SDS2.RESOUCE_CODE
AND SDS1.INSTRUCT_CODE = SDS2.INSTRUCT_CODE
AND SDS1.SGYSHJ_NO     = SDS2.SGYSHJ_NO
";
            try
            {
                using (OracleCommand com = new OracleCommand(sql, cn))
                {
                    com.Parameters.Add(new OracleParameter("StartTime", StartTime));
                    log.DebugLogFormat("UpdateResource実行時刻：" + DateTime.Now);
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);

                        string updateSql = "";

                        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];

                            FlexscheResultScada flexscheResultScada = new FlexscheResultScada();

                            updateSql = FlexscheResultScada.UpdateResourceSql;
                            log.DebugLogFormat("UpdateResource sql", sql);
                            log.DebugLogFormat("UpdateResource updateSql", updateSql);
                            List<OracleParameter> updateParamList =
                                flexscheResultScada.CreateParamsForUpdateResource(dr);
                            updateParamList.ForEach(param =>
                                log.DebugLogFormat("UpdateResource param", param.ToString())
                            );
                            RegisterData(
                                cn,
                                ref trans,
                                dr,
                                RegisterType.UPDATE_FLEXSCHE_RESULT_SCADA,
                                updateSql,
                                updateParamList
                            );
                            updateParamList.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrLogFormat(ex.Message, $"UpdateResource error 発生しました");
                log.ErrLogFormat(ex.ToString());
                log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                log.ErrLogFormat($"Error Code: {ex.HResult}");
                log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                log.ErrLogFormat($"Source: {ex.Source}");
                log.ErrLogFormat($"Target Site: {ex.TargetSite}");
                throw;
            }
            finally
            {
                //コネクションを閉じる
                if (cn.State == ConnectionState.Open)
                {
                    log.DebugLogFormat(
                        "[END] ",
                        "アップデート",
                        $"FLEXSCHE_RESULT_SCADA_FUKAYA 処理件数：{i}"
                    );
                }
            }
        }

        /// <summary>生産数量の件数カウンター処理</summary>
        private void CreateLinksResultData(OracleConnection cn, ref OracleTransaction trans)
        {
            int i = 0;
            log.DebugLogFormat("[START] ", "アップデート", "テーブル名：");
            string sql =
                $@"
WITH
SDS_COUNT AS (
    SELECT
          sds2.*
        , sds1.PROCORDER_CODE AS SDS1_PROORDER_CODE
        , COUNT(*) OVER() AS COUNTSDS
        , ROW_NUMBER() OVER(ORDER BY sds2.PTIME) AS RN
    FROM 
        (SELECT * FROM {SchemaName}.SCADA_DATA_SNAPSHOT 
         WHERE (ORDER_CHANGE_FLAG IN ('0', '1') OR ORDER_CHANGE_FLAG IS NULL) 
         AND PTIME >= :StartTime 
         AND PROCORDER_CODE IS NOT NULL) sds1
    INNER JOIN
        (SELECT * FROM {SchemaName}.SCADA_DATA_SNAPSHOT 
         WHERE PRODUCTION_FLAG = '1') sds2
    ON  sds1.RESOUCE_CODE = sds2.RESOUCE_CODE 
    AND sds1.INSTRUCT_CODE = sds2.INSTRUCT_CODE 
    AND sds1.SGYSHJ_NO = sds2.SGYSHJ_NO
)
SELECT
    CASE
        WHEN MAX(COUNTSDS) <= 2 THEN 0
        ELSE MAX(CASE WHEN RN > 2 THEN PRODUCTION_COUNT END)
    END AS PRODUCTION_COUNT_SDS
    ,SDS1_PROORDER_CODE
FROM
    SDS_COUNT
GROUP BY SDS1_PROORDER_CODE
";

            try
            {
                using (OracleCommand com = new OracleCommand(sql, cn))
                {
                    com.Parameters.Add(new OracleParameter("StartTime", StartTime));
                    log.DebugLogFormat("CreateLinksResultData実行時刻：" + DateTime.Now);
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);

                        string updateSql = "";

                        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];

                            FlexscheResultScada flexscheResultScada = new FlexscheResultScada();

                            updateSql = FlexscheResultScada.UpdateLinksSql;
                            log.DebugLogFormat("CreateLinksResultData sql", sql);
                            log.DebugLogFormat("CreateLinksResultData updateSql", updateSql);
                            List<OracleParameter> updateParamList =
                                flexscheResultScada.CreateLinksParamForUpdate(dr);
                            updateParamList.ForEach(param =>
                                log.DebugLogFormat("CreateLinksResultData param", param.ToString())
                            );
                            RegisterData(
                                cn,
                                ref trans,
                                dr,
                                RegisterType.UPDATE_FLEXSCHE_RESULT_SCADA,
                                updateSql,
                                updateParamList
                            );
                            updateParamList.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrLogFormat(ex.Message, $"CreateLinksResultData error 発生しました");
                log.ErrLogFormat(ex.ToString());
                log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                log.ErrLogFormat($"Error Code: {ex.HResult}");
                log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                log.ErrLogFormat($"Source: {ex.Source}");
                log.ErrLogFormat($"Target Site: {ex.TargetSite}");

                throw;
            }
            finally
            {
                //コネクションを閉じる
                if (cn.State == ConnectionState.Open)
                {
                    log.DebugLogFormat(
                        "[END] ",
                        "アップデート",
                        $"FLEXSCHE_RESULT_SCADA_FUKAYA 処理件数：{i}"
                    );
                }
            }
        }

        //作業実績データのステータス更新
        private void CreateStatusResultData(OracleConnection cn, ref OracleTransaction trans)
        {
            int i = 0;
            log.DebugLogFormat("[START] ", "アップデート", "テーブル名：");
            string sql =
                $@"
SELECT
    MANU_START,
    MANU_END,
    OPERATION_CODE,
    COLLECTION
FROM
    {SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA
WHERE
    COLLECTION = (SELECT MAX(COLLECTION) FROM {SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA)
";

            try
            {
                using (OracleCommand com = new OracleCommand(sql, cn))
                {
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);

                        string updateSql = "";

                        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];

                            FlexscheResultScada flexscheResultScada = new FlexscheResultScada();

                            updateSql = FlexscheResultScada.UpdateStatusSql;
                            log.DebugLogFormat("CreateStatusResultData sql", sql);
                            log.DebugLogFormat("CreateStatusResultData updateSql", updateSql);
                            List<OracleParameter> updateParamList =
                                flexscheResultScada.CreateStatusParamForUpdate(dr);
                            updateParamList.ForEach(param =>
                                log.DebugLogFormat("CreateStatusResultData param", param.ToString())
                            );
                            RegisterData(
                                cn,
                                ref trans,
                                dr,
                                RegisterType.UPDATE_FLEXSCHE_RESULT_SCADA,
                                updateSql,
                                updateParamList
                            );
                            updateParamList.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrLogFormat(ex.Message, $"CreateStatusResultData error 発生しました");
                log.ErrLogFormat(ex.ToString());
                log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                log.ErrLogFormat($"Error Code: {ex.HResult}");
                log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                log.ErrLogFormat($"Source: {ex.Source}");
                log.ErrLogFormat($"Target Site: {ex.TargetSite}");

                throw;
            }
            finally
            {
                //コネクションを閉じる
                if (cn.State == ConnectionState.Open)
                {
                    log.DebugLogFormat(
                        "[END] ",
                        "アップデート",
                        $"FLEXSCHE_RESULT_SCADA_FUKAYA 処理件数：{i}"
                    );
                }
            }
        }

        private void UpdateManuendResultData(OracleConnection cn, ref OracleTransaction trans)
        {
            int i = 0;
            log.DebugLogFormat(
                "[START] ",
                "アップデート",
                "テーブル名：FLEXSCHE_RESULT_SCADA_FUKAYA"
            );
            string sql =
                $@"
SELECT
    PROCORDER_CODE,
    PTIME
FROM
    {SchemaName}.SCADA_DATA_SNAPSHOT
WHERE
    ORDER_CHANGE_FLAG = '1'
";

            try
            {
                using (OracleCommand com = new OracleCommand(sql, cn))
                {
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);

                        string updateSql = "";

                        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];

                            FlexscheResultScada flexscheResultScada = new FlexscheResultScada();

                            updateSql = FlexscheResultScada.UpdateManuendSql;
                            log.DebugLogFormat("UpdateManuendResultData sql", sql);
                            log.DebugLogFormat("UpdateManuendResultData updateSql", updateSql);
                            List<OracleParameter> updateParamList =
                                flexscheResultScada.UpdateManuendResultData(dr);
                            updateParamList.ForEach(param =>
                                log.DebugLogFormat(
                                    "UpdateManuendResultData param",
                                    param.ToString()
                                )
                            );
                            RegisterData(
                                cn,
                                ref trans,
                                dr,
                                RegisterType.UPDATE_FLEXSCHE_RESULT_SCADA,
                                updateSql,
                                updateParamList
                            );
                            updateParamList.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrLogFormat(ex.Message, $"CreateStatusResultData error 発生しました");
                log.ErrLogFormat(ex.ToString());
                log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                log.ErrLogFormat($"Error Code: {ex.HResult}");
                log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                log.ErrLogFormat($"Source: {ex.Source}");
                log.ErrLogFormat($"Target Site: {ex.TargetSite}");

                throw;
            }
            finally
            {
                //コネクションを閉じる
                if (cn.State == ConnectionState.Open)
                {
                    log.DebugLogFormat(
                        "[END] ",
                        "アップデート",
                        $"FLEXSCHE_RESULT_SCADA_FUKAYA 処理件数：{i}"
                    );
                }
            }
        }

        /// <summaryデータ作成対象フラグの更新を行う</summary>
        // private void UpdateTargetFlag(OracleConnection cn, ref OracleTransaction trans)
        // {
        //     int i = 0;
        //     log.DebugLogFormat("[START] ", "アップデート", "テーブル名：SCADA_DATA_SNAPSHOT");

        //     ScadaDataSnapshot scadaDataSnapshot = new ScadaDataSnapshot();

        //     string updateSql = ScadaDataSnapshot.UpdateResultTargetFlagSql;
        //     List<OracleParameter> paramList = scadaDataSnapshot.CreateParamsForUpdateResultTargetFlag();

        //     i = RegisterData(cn, ref trans, null, RegisterType.UPDATE_SCADA_DATA_SNAPSHOT, updateSql, paramList);

        //     log.DebugLogFormat("[END] ", "アップデート", $"SCADA_DATA_SNAPSHOT 処理件数：{i}");
        // }

        /// <summary>登録処理の種類</summary>
        private enum RegisterType
        {
            /// <summary>SCADA_DATA_SNAPSHOT テーブルへの INSERT</summary>
            INSERT_SCADA_DATA_SNAPSHOT,

            /// <summary>SCADA_DATA_SNAPSHOT テーブルへの UPDATE/summary>
            UPDATE_SCADA_DATA_SNAPSHOT,

            /// <summary>FLEXSCHE_RESULT_SCADA テーブルへの INSERT</summary>
            INSERT_FLEXSCHE_RESULT_SCADA,

            /// <summary>FLEXSCHE_RESULT_SCADA テーブルへの UPDATE/summary>
            UPDATE_FLEXSCHE_RESULT_SCADA,
        }

        /// <summary>データを登録する</summary>
        /// <remarks>
        /// <para>INSERT、UPDATE、DELETEの実行部分</para>
        /// <para>INSERT実行時に一意制約エラーが発生した場合、登録済みのデータを削除して再度登録処理を行う</para>
        /// </remarks>
        /// <returns>処理が行われた件数</returns>
        private int RegisterData(
            OracleConnection cn,
            ref OracleTransaction trans,
            DataRow dr,
            RegisterType type,
            string sql,
            List<OracleParameter> paramList
        )
        {
            //SQL文が作成できていなければ終了
            if (string.IsNullOrEmpty(sql))
            {
                return 0;
            }

            using (OracleCommand cmd = new OracleCommand(sql, cn))
            {
                cmd.AppendParameters(paramList);
                log.DebugLogFormat(
                    $@"
RegisterData処理内容 = {type.ToString()}
SQL文 = {sql}
{GetBindParamStr(paramList)}"
                );
                string exMessage = "";
                try
                {
                    //インサート実行
                    return cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    // 一意制約エラーの場合
                    if (ex.Number == 1)
                    {
                        log.DebugLogFormat("一意制約エラーが発生しました,type:", type.ToString());
                        string sqlDelete = "";
                        List<OracleParameter> deleteParamList = new List<OracleParameter>();
                        #region DELETESQL文
                        switch (type)
                        {
                            case RegisterType.INSERT_SCADA_DATA_SNAPSHOT:
                                ScadaDataSnapshot scadaDataSnapshot = new ScadaDataSnapshot();

                                sqlDelete = ScadaDataSnapshot.DeleteSql;
                                log.DebugLogFormat("AssociateData sqlDelete", sqlDelete);
                                deleteParamList = scadaDataSnapshot.CreateParamsForDelete(dr);

                                exMessage = "";

                                break;

                            case RegisterType.INSERT_FLEXSCHE_RESULT_SCADA:
                                FlexscheResultScada flexscheResultScada = new FlexscheResultScada();
                                sqlDelete = FlexscheResultScada.DeleteSql;
                                log.DebugLogFormat("AssociateData sqlDelete", sqlDelete);
                                deleteParamList = flexscheResultScada.CreateParamsForDelete(dr);

                                exMessage = "";

                                break;
                        }
                        #endregion

                        using (OracleCommand delcmd = new OracleCommand(sqlDelete, cn))
                        {
                            log.DebugLogFormat("RETURN NONQUERY   START");
                            delcmd.AppendParameters(deleteParamList);
                            delcmd.ExecuteNonQuery();
                            log.DebugLogFormat("RETURN NONQUERY   END");
                        }
                        return cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // 一意制約エラー以外のエラーの場合
                        log.DebugLogFormat("ロールバックします。");
                        trans.Rollback();
                        log.ErrLogFormat($"InvalidCastException: {ex.Message}");
                        log.ErrLogFormat($"Error Code: {ex.HResult}");
                        log.ErrLogFormat($"Stack Trace: {ex.StackTrace}");
                        log.ErrLogFormat($"Source: {ex.Source}");
                        log.ErrLogFormat($"Target Site: {ex.TargetSite}");
                        log.ErrLogFormat(
                            ex.Number.ToString(),
                            ex.Message,
                            $@"
処理内容 = {type.ToString()}
{exMessage}
SQL文 = {sql}
{GetBindParamStr(paramList)}"
                        );
                        throw;
                    }
                }
            }
        }

        /// <summary>説明：エラーログ用バインド変数値文字列作成</summary>
        /// <param name="paramList">[IN] バインド変数格納リスト</param>
        /// <returns>バインド変数値文字列</returns>
        private string GetBindParamStr(List<OracleParameter> paramList)
        {
            // バインド変数がない場合、空文字を返す
            if (paramList == null || paramList.Count == 0)
            {
                return "";
            }

            // バインド変数の値を連結
            StringBuilder strBindParam = new StringBuilder();
            foreach (OracleParameter param in paramList)
            {
                if (0 < strBindParam.Length)
                {
                    strBindParam.Append(", ");
                }
                strBindParam.AppendFormat("{0}={1}", param.ParameterName, param.Value);
            }
            strBindParam.AppendLine();

            return strBindParam.ToString();
        }
    }
}
