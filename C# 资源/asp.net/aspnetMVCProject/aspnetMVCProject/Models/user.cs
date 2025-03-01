using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnetMVCProject.Models
{
    public class user
    {
        public string Name { get; set; }
        public string Id { get; set; }
        //public int MyProperty { get; set; }

        public user()
        {
        }
        public user (string id, string name)
        {

            Name = name;
            Id = id;
        }
         
    }
}