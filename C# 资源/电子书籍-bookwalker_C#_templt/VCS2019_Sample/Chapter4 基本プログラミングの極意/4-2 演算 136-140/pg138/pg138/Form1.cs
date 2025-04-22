using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg138
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool ret = checkBox1.Checked && checkBox2.Checked&&checkBox3.Checked;
            textBox1.Text = $"&&演算子の結果：{ret}";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool ret = checkBox1.Checked || checkBox2.Checked||checkBox3.Checked;
            textBox1.Text = $"||演算子の結果：{ret}";
        }
    }
}
