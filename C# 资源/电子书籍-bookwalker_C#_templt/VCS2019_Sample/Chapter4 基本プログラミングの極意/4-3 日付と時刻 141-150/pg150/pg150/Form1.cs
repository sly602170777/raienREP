using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg150
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;                      // 現在の日時を取得
            label1.Text = dt.ToString();                
            label2.Text = dt.ToShortDateString();
            label3.Text = dt.ToString("yyyy年MM月dd日(ddd)");
            label9.Text = dt.ToString("yyyy-MM-dd(ddd)");
        }
    }
}
