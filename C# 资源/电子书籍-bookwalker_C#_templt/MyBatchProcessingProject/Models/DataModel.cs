using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatchProcessingProject.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public DataModel(int id, string name, string value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
