using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CsvToOral_Demo
{
    internal class Program
    {
        public static void Main()
        {
            string path = @"D:\file\CSV\Product.csv";
            //配列からリストに格納する
            List<string> colNameLists = new List<string>();

            // 读取CSV文件 到 DataTable 对象
            DataTable dataTable = CSVInput.ReadCsvWithCsvHelper(path);

            try
            {
                using (OracleConnection conn = new OracleConnection())
                {
                    conn.ConnectionString =
                        "User ID=testuser; Password=123456; Data Source=localhost:1521/ORCL";
                    conn.Open();
                    Console.WriteLine("DBに接続しました。");
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        //STAP1 トランザクションの開始 Table Clomn Nameの取得
                        List<string> columnNames = oraHelp.GetColumnNames("PRODUCT", "SYS", conn);
                        Console.WriteLine("Table Clomn Name:");

                        //STAP2 table clomn name と CSV file clomn nameの比較　一致の場合は挿入、不一致の場合はエラー
                        foreach (string colName in columnNames)
                        {
                            Console.WriteLine(colName);
                            colNameLists.Add(colName);
                        }
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            if (!colNameLists.Contains(col.ColumnName.ToUpper()))
                            {
                                throw new Exception(
                                    $"CSVファイルの列名がテーブルの列名と一致しません: {col.ColumnName}"
                                );
                            }
                        }

                        //STAP4 CSV file 存在のClomn ONLY を挿入
                        oraHelp.InsertRowsDynamically(dataTable, "PRODUCT", "SYS", conn);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
