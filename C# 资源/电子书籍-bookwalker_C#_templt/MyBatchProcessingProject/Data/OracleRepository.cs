using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBatchProcessingProject.Interfaces;
using MyBatchProcessingProject.Models;
using Oracle.ManagedDataAccess.Client;

namespace MyBatchProcessingProject.Data
{
    public class OracleRepository : IOracleRepository
    {
        private readonly string _connectionString;

        public OracleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertData(DataModel data)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                        "INSERT INTO your_table (id, name, value) VALUES (:id, :name, :value)";
                    command.Parameters.Add(new OracleParameter("id", data.Id));
                    command.Parameters.Add(new OracleParameter("name", data.Name));
                    command.Parameters.Add(new OracleParameter("value", data.Value));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting data into Oracle: {ex.Message}");
                }
            }
        }

        public List<DataModel> GetData()
        {
            var data = new List<DataModel>();

            using (var connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, name, value FROM your_table";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string value = reader.GetString(2);

                            data.Add(new DataModel(id, name, value));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading data from Oracle: {ex.Message}");
                }
            }

            return data;
        }
    }
}
