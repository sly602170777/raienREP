using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ref214
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var pis = typeof(SampleClass).GetProperties();
            listBox1.Items.Clear();
            foreach ( var pi in pis )
            {
                listBox1.Items.Add($"{pi.Name} : {pi.PropertyType.ToString()}");
            }
        }
    }
    public class SampleClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
        public void ChangeName( string name )
        {
            this.Name = name;
        }
    }
}
