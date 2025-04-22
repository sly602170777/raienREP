using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file254
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            if ( fname == string.Empty )
            {
                return;
            }
            System.IO.Directory.CreateDirectory(fname);
            textBox2.Text = $"{fname}ÇçÏê¨ÇµÇ‹ÇµÇΩÅB";
        }
    }
}
