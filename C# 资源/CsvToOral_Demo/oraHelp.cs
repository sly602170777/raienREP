using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CsvToOral_Demo
{
    public class oraHelp
    {
        public static List<string> GetColumnNames(
            string tableName,
            string owner,
            OracleConnection conn
        )
        {
            var columnNames = new List<string>();
            string query =
                @"SELECT COLUMN_NAME 
                         FROM ALL_TAB_COLUMNS 
                         WHERE OWNER = :owner 
                         AND TABLE_NAME = :tableName 
                         ORDER BY COLUMN_ID";

            //var conn = new OracleConnection(connStr);
            var cmd = new OracleCommand(query, conn);
            cmd.Parameters.Add(":owner", OracleDbType.Varchar2).Value = owner.ToUpper();
            cmd.Parameters.Add(":tableName", OracleDbType.Varchar2).Value = tableName.ToUpper();

            //conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                columnNames.Add(reader.GetString(0));
            }

            return columnNames;
        }

        public static void InsertRowsDynamically(
            DataTable dataTable,
            string tableName,
            string owner,
            OracleConnection conn
        )
        {
            var columnNames = GetColumnNames(tableName, owner, conn);
            //step1 dataTable の列名を大文字に変換してリスト化
            var dataTableColumns = dataTable
                .Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName.ToUpper())
                .ToList();
            //step2 tableの列名とdataTableの列名を比較して、存在する列名のみを抽出
            columnNames = columnNames.Where(c => dataTableColumns.Contains(c)).ToList();

            //step3 INSERT文の動的生成
            string insertSql =
                $"INSERT INTO {owner}. {tableName} ({string.Join(",", columnNames)}) "
                + $"VALUES ({string.Join(",", columnNames.Select(c => ":" + c))})";

            string deleteSql = $"DELETE FROM {owner}.{tableName} WHERE {columnNames[0]} = :key"; // 假设第一个字段是主キー

            foreach (DataRow row in dataTable.Rows)
            {
                var cmd = new OracleCommand(insertSql, conn);
                foreach (var col in columnNames)
                {
                    var value = row[col];
                    var param = new OracleParameter(":" + col, value ?? DBNull.Value);
                    cmd.Parameters.Add(param);
                }

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    // 一意制約エラー発生場合は　レコードを削除し再インストールする
                    if (ex.Number == 1) // ORA-00001 一意制約違反
                    {
                        Console.WriteLine($"⚠️ 主キー重複: {row[columnNames[0]]} → 削除して再挿入");

                        // DELETE
                        var delCmd = new OracleCommand(deleteSql, conn);
                        //
                        //delCmd.Transaction = transaction;
                        delCmd.Parameters.Add(new OracleParameter(":key", row[columnNames[0]]));
                        delCmd.ExecuteNonQuery();

                        // 再 INSERT
                        cmd.Parameters.Clear();
                        foreach (var col in columnNames)
                        {
                            var value = row[col];
                            cmd.Parameters.Add(
                                new OracleParameter(":" + col, value ?? DBNull.Value)
                            );
                        }
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //insert sql 文
                        cmd.Parameters.Clear();
                        Console.WriteLine($"insertSql文: {insertSql}");
                        Console.WriteLine(
                            $"❌ Oracleエラー: {ex.Message} 行: {string.Join(",", columnNames.Select(c => row[c]))}"
                        );
                    }
                }
            }

            //transaction.Commit();
            Console.WriteLine("✅ 全行挿入完了");
        }
    }
}
