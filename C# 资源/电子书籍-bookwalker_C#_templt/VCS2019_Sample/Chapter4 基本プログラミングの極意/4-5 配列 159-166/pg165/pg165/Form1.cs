using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg165
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] ary = { "東京", "名古屋", "大阪" };
            label1.Text = $"ary[0]={ary[0]}, ary[1]={ary[1]}, ary[2]={ary[2]}";
            Array.Clear(ary, 0, ary.Length);
            label2.Text = $"ary[0]={ary[0]}, ary[1]={ary[1]}, ary[2]={ary[2]}";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string[] ary = { "東京", "名古屋", "大阪" };
            label1.Text = $"ary[0]={ary[0]}, ary[1]={ary[1]}, ary[2]={ary[2]}";
            Array.Clear(ary, 1, 2);         //最後の2つの要素をクリア
            label2.Text = $"ary[0]={ary[0]}, ary[1]={ary[1]}, ary[2]={ary[2]}";
        }
    }
}
