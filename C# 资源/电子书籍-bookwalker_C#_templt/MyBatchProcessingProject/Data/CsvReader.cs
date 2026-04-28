using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBatchProcessingProject.Interfaces;
using MyBatchProcessingProject.Models;

namespace MyBatchProcessingProject.Data
{
    public class CsvReader : ICsvReader
    {
        public List<DataModel> ReadCsv(string filePath)
        {
            var data = new List<DataModel>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length == 3)
                        {
                            int id = int.Parse(values[0]);
                            string name = values[1];
                            string value = values[2];

                            data.Add(new DataModel(id, name, value));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return data;
        }
    }
}
