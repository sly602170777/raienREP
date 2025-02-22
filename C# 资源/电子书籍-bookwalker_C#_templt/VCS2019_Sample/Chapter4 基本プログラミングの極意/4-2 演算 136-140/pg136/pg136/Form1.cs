using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg136
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int x = 100;

            label1.Text = (x / 20).ToString(); //100÷20
            x = (int)Math.Pow(2,3);                    //立方的计算
            label2.Text = x.ToString();
        }
    }
}
