using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string237
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if ( string.IsNullOrEmpty( text ) )
            {
                return;
            }

            label1.Text = "「" + text.Trim() + "」";
            label2.Text = "「" + text.TrimStart() + "」";
            label3.Text = "「" + text.TrimEnd() + "」";
        }
    }
}
