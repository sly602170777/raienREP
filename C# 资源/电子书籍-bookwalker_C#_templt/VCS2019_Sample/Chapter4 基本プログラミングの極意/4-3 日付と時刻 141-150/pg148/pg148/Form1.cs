using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg148
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dt1 = new DateTime(2019, 9, 25);
            var dt2 = new DateTime(2019, 10, 1, 12, 34, 56);

            label1.Text = dt1.ToString();
            label2.Text = dt2.ToString();
        }
    }
}
