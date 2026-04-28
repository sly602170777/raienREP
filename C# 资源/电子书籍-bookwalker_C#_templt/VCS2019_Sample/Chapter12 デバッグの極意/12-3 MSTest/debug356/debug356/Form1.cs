using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace debug356
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            var t = new TargetClass();
            int ans = t.add(a, b);
            textBox3.Text = ans.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            var t = new TargetClass();
            string ans = t.add(a, b);
            textBox3.Text = ans;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            var t = new TargetClass();
            var obj = t.CreatePointer(a, b);
            textBox3.Text = obj.ToString();

        }
    }
}
