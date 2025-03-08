using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace aspnetMVCProject.Models
{
    public class user
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int Age { get; set; }

        public List<user> users { get; set; }

        public user() { }

        public user(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = id;
        }
    }
}
