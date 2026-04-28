using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace CsvToOral_Demo
{
    public class CSVInput
    {
        public static DataTable ReadCsvWithCsvHelper(string csvPath)
        {
            //var delimiter = ","; // 先定义分隔符
            //var quoteChar = '"'; // 默认引号字符
            //var singleChar = '\'';

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.ASCII,
                HasHeaderRecord = true,
                Delimiter = ",",
                Quote = '"', // 明确指定引号字符
                MissingFieldFound = null,
            };

            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, config))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);
                    //return dt;
                    // 全列で重複を削除
                    var uniqueRows = dt.AsEnumerable()
                        //.GroupBy(row => string.Join(",", row.ItemArray))
                        .GroupBy(row =>
                            string.Join(",", row.ItemArray.Select(x => x.ToString().Trim()))
                        )
                        .Select(g => g.First())
                        .CopyToDataTable();

                    //可将 string.Join 替换为 string.Join(",", row.ItemArray.Select(x => x.ToString().Trim())) 以增强一致性

                    return uniqueRows;
                }
            }
        }
    }
}
