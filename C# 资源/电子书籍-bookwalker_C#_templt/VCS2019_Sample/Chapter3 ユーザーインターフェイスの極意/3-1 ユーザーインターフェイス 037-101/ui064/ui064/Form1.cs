using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui064
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int a1, a2, a3;

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //チェックが付いていれば変数a1に1000を代入し、
            //チェックが付いていなければ、変数a1に0を代入する
            if (checkBox1.Checked)
            {
                a1 = 1000;
            }
            else
            {
                a1 = 0;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                a2 = 800;
            }
            else
            {
                a2 = 0;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                a3 = 500;
            }
            else
            {
                a3 = 0;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {   
            label1.Text = (a1 + a2 + a3).ToString("#,##0円");
        }

 
    }
}
