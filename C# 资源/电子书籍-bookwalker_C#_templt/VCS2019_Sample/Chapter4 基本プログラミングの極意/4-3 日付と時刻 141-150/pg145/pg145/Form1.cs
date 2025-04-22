using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg145
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;                     //現在の日時を取得
            label1.Text = dt.ToString();
            label2.Text = dt.AddHours(-5).ToString();  //5時間前の日時を取得
            label3.Text = dt.AddDays(10).ToString();   //10日後の日時を取得
            label7.Text = dt.AddMonths(-1).ToString();   //10日後の日時を取得
        }


    }
}
