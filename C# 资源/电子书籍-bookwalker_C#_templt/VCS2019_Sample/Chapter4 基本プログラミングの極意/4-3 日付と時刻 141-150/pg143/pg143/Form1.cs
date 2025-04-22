using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg143
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;                 //システム日付を取得
            label1.Text = dt.Hour.ToString();      //時を取得して表示
            label2.Text = dt.Minute.ToString();    //分を取得して表示
            label3.Text = dt.Second.ToString();    //秒を取得して表示
        }
    }
}
