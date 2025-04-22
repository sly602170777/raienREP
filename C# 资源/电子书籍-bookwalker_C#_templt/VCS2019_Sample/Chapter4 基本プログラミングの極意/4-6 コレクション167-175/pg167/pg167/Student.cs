using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg167
{
    public class Student
    {
        public string name { get; set; }
        public int age { get; set; }
        public string className { get; set; }
        public Student(string className, string name,int age)
        {
            this.className = className;
            this.name = name;
            this.age = age;
        }
    }
}
