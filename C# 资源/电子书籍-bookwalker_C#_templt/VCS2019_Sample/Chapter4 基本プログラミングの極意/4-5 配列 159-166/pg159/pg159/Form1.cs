using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg159
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var ary = new int[5];
            string s = "";
            for( int i=0; i<ary.Length; i++ )
            {
                ary[i] = i * 2;
                s += $"ary[{i}] = {ary[i]}\r\n";
            }
            textBox1.Text = s;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var ary = new int[2, 3];
            string s = "";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ary[i, j] = i + j;
                    s += $"ary[{i}, {j}] = {ary[i, j]}\r\n";
                }
            }
            textBox1.Text = s;
        }
    }
}
