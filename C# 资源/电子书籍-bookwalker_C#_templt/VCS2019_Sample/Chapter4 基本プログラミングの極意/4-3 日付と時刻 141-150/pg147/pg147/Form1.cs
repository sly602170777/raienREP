using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg147
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var ts1 = new TimeSpan(20, 10, 5);       //20時間10分5秒
            var ts2 = new TimeSpan(0, 25, 20, 15);   //0日25時間20分15秒
            var ts3 = new TimeSpan(0, 0, 0, 0, 1001);//0秒1001ミリ秒

            label1.Text = ts1.ToString();
            label2.Text = ts2.ToString();
            label3.Text = ts3.ToString();
        }
    }
}
