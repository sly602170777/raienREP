using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web463.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0}‚Í•K{€–Ú‚Å‚·")]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
