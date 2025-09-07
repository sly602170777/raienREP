using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToOral_Demo
{
    public class Logger
    {
        private string _message;

        // Removed 'static' keyword as static constructors cannot have access modifiers.
        static Logger()
        {
            Console.WriteLine("这是一个空的无参构造");
        }

        public Logger(string message)
        {
            this._message = message;
            Console.WriteLine($"[LOG] {DateTime.Now}: {_message}");
        }
    }
}
