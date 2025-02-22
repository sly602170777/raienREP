using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg180
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        void nextyear( ref DateTime dt, ref string s )
        {
            dt = dt.AddYears(1);
            s += dt.ToString("yyyy年MM月dd日");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string s = "来年は ";
            nextyear(ref dt, ref s);
            label1.Text = dt.ToString();
            label2.Text = s;
        }

        /// クラスを利用する場合
        class NextYear
        {
            private DateTime _dt;
            public NextYear( DateTime dt )
            {
                _dt = dt.AddYears(1);
            }
            public DateTime Date => _dt;
            public string Str( string s ) =>
                s + _dt.ToString("yyyy年MM月dd日");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            NextYear next = new NextYear(DateTime.Now);
            label1.Text = next.Date.ToString();
            label2.Text = next.Str("来年は ");
        }
    }
}
