using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string234
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            int ret = text1.CompareTo(text2);       //比較
            if (ret == 0)
            {
                textBox3.Text = "同じです。";
            }
            else if (ret < 0)
            {
                textBox3.Text = text1 + "の方が小さいです。";
            }
            else
            {
                textBox3.Text = text1 + "の方が大きいです。";
            }
        }
    }
}
