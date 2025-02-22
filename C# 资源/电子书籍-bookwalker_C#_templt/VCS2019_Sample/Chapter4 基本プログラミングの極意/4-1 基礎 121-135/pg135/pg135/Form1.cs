using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg135
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var a = ("masuda", 51, "Itabashi");

            textBox1.Text = a.Item1;
            textBox2.Text = a.Item2.ToString();
            textBox3.Text = a.Item3;
            label2.Text = a.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var a = (name: "masuda", age: 51, addrsss: "Itabashi");
            textBox1.Text = a.name;
            textBox2.Text = a.age.ToString();
            textBox3.Text = a.addrsss;
            label2.Text = a.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ab = "masuda";
            int k = 51;
            string abc = "Itabashi";
            var a = (name: ab, age: k, addrsss: abc);
            textBox1.Text = a.name;
            textBox2.Text = a.age.ToString();
            textBox3.Text = a.addrsss;
            label2.Text = a.ToString();
        }
    }
}
