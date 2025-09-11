using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBatchProcessingProject.Interfaces;

namespace MyBatchProcessingProject.Business
{
    public class DataProcessor
    {
        private readonly ICsvReader _csvReader;
        private readonly IOracleRepository _oracleRepository;

        public DataProcessor(ICsvReader csvReader, IOracleRepository oracleRepository)
        {
            _csvReader = csvReader;
            _oracleRepository = oracleRepository;
        }

        public void ProcessData(string csvFilePath)
        {
            var data = _csvReader.ReadCsv(csvFilePath);
            foreach (var item in data)
            {
                _oracleRepository.InsertData(item);
            }
        }
    }
}
