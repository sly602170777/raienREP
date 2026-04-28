using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg142
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;             //現在の日付を取得
            label1.Text = dt.Year.ToString();  //年を取得して表示
            label2.Text = dt.Month.ToString(); //月を取得して表示
            label3.Text = dt.Day.ToString();   //日を取得して表示
        }
    }
}
