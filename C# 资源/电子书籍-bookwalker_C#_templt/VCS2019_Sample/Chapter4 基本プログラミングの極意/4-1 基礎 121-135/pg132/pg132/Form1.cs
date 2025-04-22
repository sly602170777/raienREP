using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg132
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

            label3.Text = $"{s1} と {s2}";
            label4.Text = $"{{{s1}}} の文字数は {s1.Length} です";
            //label4.Text = $"{0} の文字数は {1} です,s1,s1.Length";
        }
    }
}
