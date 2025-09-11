using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBatchProcessingProject.Business;
using MyBatchProcessingProject.Configuration;
using MyBatchProcessingProject.Data;
using MyBatchProcessingProject.Interfaces;

namespace MyBatchProcessingProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 获取配置信息
            var config = AppConfiguration.Instance;
            var csvFilePath = config.CsvFilePath;
            var connectionString = config.ConnectionString;

            // 创建依赖对象
            ICsvReader csvReader = new CsvReader();
            IOracleRepository oracleRepository = new OracleRepository(connectionString);
            var dataProcessor = new DataProcessor(csvReader, oracleRepository);

            // 处理数据
            dataProcessor.ProcessData(csvFilePath);

            Console.WriteLine("Data processing completed.");
        }
    }
}
