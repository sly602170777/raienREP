using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Fukaya_scada_data
{
    internal class FlexscheResultScada
    {
        public const string STATUS_MS = "MS";
        public const string STATUS_MF = "MF";
        public const string CREATE_STATUS_MF = "生産完了";

        LoggerWrapper log = new LoggerWrapper();
        /// <summary>新規登録用のSQL文</summary>
        /// <remarks>SQL文中に、<see cref="CreateParamsForInsert"/>を用いて指定可能なパラメーターを使用している</remarks>
        public static string InsertSql => $@"
INSERT INTO  {DataAccess.SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA( 
      OPERATION_CODE 
    , ""ORDER""
    , RESOURCES
    , TYPE
    , COLLECTION
    , MANU_END
    , RESOURCES_PLAN
) 
VALUES ( 
      :OPERATION_CODE 
    , :ORDERS
    , :RESOURCES
    , :TYPE
    , :COLLECTION
    , :MANU_END
    , :RESOURCES_PLAN
) 
";
        /// <summary>新規登録用のパラメーターを作成する</summary>
        /// <param name="dr">登録元となるSCADAデータ</param>
        /// <returns>パラメーターのリスト</returns>
        public List<OracleParameter> CreateParamsForInsert(DataRow dr)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();

            string operation_code = dr.Field<string>("PROCORDER_CODE");
            string order = dr.Field<string>("INSTRUCT_CODE");
            string type = "R";
            DateTime collection = dr.Field<DateTime>("NewCollection");
            string resource_code = dr.Field<string>("RESOUCE_CODE");
            DateTime? manu_end = dr.Field<DateTime?>("PTIME");
            string order_change_flag = dr.Field<string>("ORDER_CHANGE_FLAG");
            string resources_plan = dr.Field<string>("PRIMARY_RESOURCE");

            if ("1".Equals(order_change_flag))
            {
                paramList.Add(new OracleParameter("MANU_END", manu_end));
            }
            else if ("0".Equals(order_change_flag) || string.IsNullOrEmpty(order_change_flag))
            {
                paramList.Add(new OracleParameter("MANU_END", DBNull.Value));
            }

            log.DebugLogFormat("CreateResultData paramList OPERATION_CODE：", operation_code);
            log.DebugLogFormat("CreateResultData paramList ORDERS：", order);
            log.DebugLogFormat("CreateResultData paramList RESOURCES：", resource_code);
            log.DebugLogFormat("CreateResultData paramList TYPE：", type);
            log.DebugLogFormat("CreateResultData paramList COLLECTION：" + collection);
            log.DebugLogFormat("CreateResultData paramList MANU_END：" + manu_end);
            log.DebugLogFormat("CreateResultData paramList RESOURCES_PLAN：", resources_plan);

            paramList.Add(new OracleParameter("OPERATION_CODE", operation_code));
            paramList.Add(new OracleParameter("ORDERS", order));
            paramList.Add(new OracleParameter("RESOURCES", resource_code));
            paramList.Add(new OracleParameter("TYPE", type));
            paramList.Add(new OracleParameter("COLLECTION", collection));

            paramList.Add(new OracleParameter("RESOURCES_PLAN", resources_plan));


            return paramList;
        }


        /// <summary>実績生産開始日時更新</summary>
        /// <remarks>SQL文中に、<see cref="CreateParamsForUpdateResource"/>を用いて指定可能なパラメーターを使用している</remarks>
        public static string UpdateResourceSql => $@"
UPDATE {DataAccess.SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA
SET
      MANU_START = :MANU_START
WHERE
    OPERATION_CODE = :PROCORDER_CODE
";
        /// <summary>実績生産開始日時更新のパラメーターを作成する</summary>
        /// <param name="dr">登録元となるデータ</param>
        /// <returns>パラメーターのリスト</returns>
        public List<OracleParameter> CreateParamsForUpdateResource(DataRow dr)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();

            DateTime? manu_start = dr.Field<DateTime?>("PTIME");
            string procorder_code = dr.Field<string>("PROCORDER_CODE");

            paramList.Add(new OracleParameter("MANU_START", manu_start));
            paramList.Add(new OracleParameter("PROCORDER_CODE", procorder_code));

            return paramList;
        }

        public static string UpdateLinksSql => $@"
UPDATE {DataAccess.SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA
SET
    LINKS = :LINKS
WHERE
    OPERATION_CODE = :OPERATION_CODE
";


        /// <summary>
        /// 生産数量の件数パラメータ追加
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public List<OracleParameter> CreateLinksParamForUpdate(DataRow dr)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();

            long links = 0; // 默认值

            object value = dr["PRODUCTION_COUNT_SDS"]; 
            Type valueType = value.GetType(); 
            log.DebugLogFormat("CreateResultData paramList Type ：" + valueType);

            if (!dr.IsNull("PRODUCTION_COUNT_SDS"))
            {
                // links = dr.Field<long>("PRODUCTION_COUNT_SDS"); // 使用 nullable long
                links = Convert.ToInt64(dr["PRODUCTION_COUNT_SDS"]);
            }
            log.DebugLogFormat("CreateResultData paramList PRODUCTION_COUNT_SDS" +links);
            // long links = dr.Field<long>("PRODUCTION_COUNT_SDS");
            string operation_code = dr.Field<string>("SDS1_PROORDER_CODE");

            paramList.Add(new OracleParameter("LINKS", links));
            paramList.Add(new OracleParameter("OPERATION_CODE", operation_code));

            return paramList;
        }


        public static string UpdateManuendSql => $@"
UPDATE {DataAccess.SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA
SET
    MANU_END = :MANU_END
WHERE
    OPERATION_CODE = :OPERATION_CODE
";


        /// <summary>
        /// 実績作業完了日時パラメータ追加
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public List<OracleParameter> UpdateManuendResultData(DataRow dr)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();

            string operation_code = dr.Field<string>("PROCORDER_CODE");
            DateTime manu_end = dr.Field<DateTime>("PTIME");

            paramList.Add(new OracleParameter("OPERATION_CODE", operation_code));
            paramList.Add(new OracleParameter("MANU_END", manu_end));

            return paramList;
        }

        /// <summary>作業実績データ更新用のSQL文</summary>
        /// <remarks>SQL文中に、<see cref="CreateStatusParamForUpdate"/>を用いて指定可能なパラメーターを使用している</remarks>
        public static string UpdateStatusSql => $@"
UPDATE {DataAccess.SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA
SET
      STATUS = :STATUS
WHERE
    OPERATION_CODE = :OPERATION_CODE
";
        /// <summary>作業実績データ更新用のパラメーターを作成する</summary>
        /// <param name="dr">登録元となるデータ</param>
        /// <returns>パラメーターのリスト</returns>
        public List<OracleParameter> CreateStatusParamForUpdate(DataRow dr)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();

            DateTime? manu_start = dr.Field<DateTime?>("MANU_START");
            DateTime? manu_end = dr.Field<DateTime?>("MANU_END");
            string operation_code = dr.Field<string>("OPERATION_CODE");
        

            if (!manu_start.HasValue && !manu_end.HasValue)
            {
                paramList.Add(new OracleParameter("STATUS", DBNull.Value));
            }
            else if (manu_start.HasValue && !manu_end.HasValue)
            {
                paramList.Add(new OracleParameter("STATUS", STATUS_MS));
            }
            else if (manu_start.HasValue && manu_end.HasValue)
            {
                paramList.Add(new OracleParameter("STATUS", STATUS_MF));
            }


            paramList.Add(new OracleParameter("MANU_START", manu_start));
            paramList.Add(new OracleParameter("MANU_END", manu_end));
            
            paramList.Add(new OracleParameter("OPERATION_CODE", operation_code));

            return paramList;
        }
        

        /// <summary>削除用のSQL文</summary>
        /// <remarks>SQL文中に、<see cref="CreateParamsForDelete"/>を用いて指定可能なパラメーターを使用している</remarks>
        public static string DeleteSql => $@"
DELETE FROM  {DataAccess.SchemaName}.FLEXSCHE_RESULT_SCADA_FUKAYA
WHERE
    OPERATION_CODE = :OPERATION_CODE
";
        /// <summary><see cref="DeleteSql"/>中で使用しているパラメーターを作成する</summary>
        /// <param name="dr">削除対象の計画データ</param>
        /// <returns>パラメーターのリスト</returns>
        public List<OracleParameter> CreateParamsForDelete(DataRow dr)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();

            string operation_code = dr.Field<string>("PROCORDER_CODE");

            paramList.Add(new OracleParameter("OPERATION_CODE", operation_code));


            return paramList;
        }

    }
}
