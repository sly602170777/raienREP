using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file251
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
            if ( System.IO.Directory.Exists( fname ) == true )
            {
                textBox2.Text = System.IO.Directory.GetCreationTime(fname).ToString();
            }
            else if ( System.IO.File.Exists( fname ) == true )
            {
                textBox2.Text = System.IO.File.GetCreationTime(fname).ToString();
            }
            else
            {
                textBox2.Text = $"{fname}が見つかりませんでした。";
            }
        }
    }
}
