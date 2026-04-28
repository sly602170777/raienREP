using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg179
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        void nowtime( out DateTime dt, out string s )
        {
            dt = DateTime.Now;
            s = dt.ToString("yyyy�NMM��dd�� hh��mm��ss�b");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            string s;
            nowtime(out dt, out s);
            label1.Text = dt.ToString();
            label2.Text = s;
        }

        /// �N���X�𗘗p����ꍇ
        class NowTime
        {
            private DateTime _dt = DateTime.Now;
            public DateTime Date => _dt;
            public string Str => 
                _dt.ToString("yyyy�NMM��dd�� hh��mm��ss�b");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            NowTime now = new NowTime();
            label1.Text = now.Date.ToString();
            label2.Text = now.Str;
        }
    }
}
