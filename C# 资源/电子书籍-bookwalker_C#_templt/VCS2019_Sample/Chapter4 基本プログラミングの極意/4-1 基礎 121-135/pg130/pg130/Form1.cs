using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg130
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s1 = "ワイン";
            string s2 = "チーズ";

            label3.Text = "D:\\C#\\2019\\Sample.txt";
          //  label4.Text = s1 + "\n" + s2;
            label4.Text = s1 + "\n\t" + s2;
        }
    }
}
