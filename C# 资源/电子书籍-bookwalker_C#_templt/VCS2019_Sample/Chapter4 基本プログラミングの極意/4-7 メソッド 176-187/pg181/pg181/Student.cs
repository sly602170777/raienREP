using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg181
{
   public class Student
    {
        public string name;
        public int age;
        public string hobby;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Hobby { get => hobby; set => hobby = value; }

        public Student(string name, int age, string hobby)
        {
            this.name = name;
            this.age = age;
            this.hobby = hobby;
        
        }
    }
}
