using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg153
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            num = int.Parse(textBox1.Text);

            int x = (num < 0 || num > 100) ? -1 : num;

            /* 以下と同じ
            int x = 0;
            if ( num < 0 || num > 100 )
            {
                x = -1;
            }
            else
            {
                x = num;
            }
            */

            label1.Text = $"入力した数値は {num} です。";
            label2.Text = $"補正した数値は {x} です。";
        }
    }
}
