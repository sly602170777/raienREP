using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBatchProcessingProject.Models;

namespace MyBatchProcessingProject.Interfaces
{
    public interface ICsvReader
    {
        List<DataModel> ReadCsv(string filePath);
    }
}
