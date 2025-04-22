using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace debug342
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var pa = new Person
            {
                Name = "ëùìcíqñæ",
                Age = 45,
                City = "î¬ã¥ãÊ"
            };
            pa.Xml = new XElement(
                "person",
                new XElement("Name", "ëùìcíqñæ"),
                new XElement("Age", "51"),
                new XElement("City", "î¬ã¥ãÊ"));

            textBox1.Text = pa.ToString();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public XElement Xml;
    }
}
