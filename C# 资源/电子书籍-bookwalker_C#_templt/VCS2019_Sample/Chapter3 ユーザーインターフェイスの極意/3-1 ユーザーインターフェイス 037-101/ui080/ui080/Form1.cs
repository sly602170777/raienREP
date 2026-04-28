using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui080
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TimeSpan stTime = new TimeSpan(0, 0, 0);
        TimeSpan addSecond = new TimeSpan(0, 0, 1);

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            stTime = new TimeSpan(0, 0, 0);
            label1.Text = stTime.ToString();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            stTime = stTime + addSecond;
            label1.Text = stTime.ToString();
            if (stTime == new TimeSpan(0, 1, 0))
            {
                timer1.Stop();
                MessageBox.Show("1分経過");
                label1.Text = new TimeSpan(0, 0, 0).ToString();
            }
        }
    }
}
