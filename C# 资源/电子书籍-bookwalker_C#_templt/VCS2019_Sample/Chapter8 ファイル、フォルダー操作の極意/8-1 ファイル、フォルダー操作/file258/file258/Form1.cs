using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file258
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if ( System.IO.File.Exists(path) == false )
            {
                return;
            }
            var attr = System.IO.File.GetAttributes(path);
            checkBox1.Checked =
                (attr & System.IO.FileAttributes.ReadOnly) != 0;
            checkBox2.Checked =
                (attr & System.IO.FileAttributes.Hidden) != 0;
            checkBox3.Checked =
                (attr & System.IO.FileAttributes.Compressed) != 0;
            checkBox4.Checked =
                (attr & System.IO.FileAttributes.System) != 0;
        }
    }
}
