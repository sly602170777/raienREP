using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg144
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Today;   //今日の日付を取得

            DayOfWeek w = dt.DayOfWeek;
            label1.Text = w.ToString();
            var lst = new List<string>()
            {
                "日曜日", "月曜日", "火曜日", "水曜日",
                "木曜日", "金曜日", "土曜日"
            };
            label2.Text = lst[(int)w].Substring(0, 1);
        }
    }
}
