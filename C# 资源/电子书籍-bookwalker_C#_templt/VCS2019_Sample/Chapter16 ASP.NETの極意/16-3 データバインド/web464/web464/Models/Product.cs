using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web464.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(100, 1000, ErrorMessage = "{0}‚Í{1}‚©‚ç{2}‚Ü‚Å‚ÌŠÔ‚ÅŽw’è‚µ‚Ä‚­‚¾‚³‚¢")]
        public int Price { get; set; }
    }
}
