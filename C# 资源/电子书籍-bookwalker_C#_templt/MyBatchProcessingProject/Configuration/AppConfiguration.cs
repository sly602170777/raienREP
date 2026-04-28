using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatchProcessingProject.Configuration
{
    public class AppConfiguration
    {
        private static readonly AppConfiguration _instance = new AppConfiguration();

        public string CsvFilePath { get; private set; }
        public string ConnectionString { get; private set; }

        private AppConfiguration()
        {
            // 读取配置文件中的信息
            CsvFilePath = ConfigurationManager.AppSettings["CsvFilePath"];
            ConnectionString = ConfigurationManager
                .ConnectionStrings["OracleConnection"]
                .ConnectionString;

            // 检查配置信息是否有效
            if (string.IsNullOrEmpty(CsvFilePath))
            {
                throw new ConfigurationErrorsException("CsvFilePath is not configured correctly.");
            }

            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "ConnectionString is not configured correctly."
                );
            }
        }

        public static AppConfiguration Instance
        {
            get { return _instance; }
        }
    }
}
