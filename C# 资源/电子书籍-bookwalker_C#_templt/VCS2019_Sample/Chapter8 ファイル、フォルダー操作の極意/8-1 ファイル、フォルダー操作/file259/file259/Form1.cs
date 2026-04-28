using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file259
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
            System.IO.File.SetAttributes(path,
                System.IO.FileAttributes.ReadOnly);
            MessageBox.Show($"{path}Çì«Ç›éÊÇËêÍópÇ…ê›íËÇµÇ‹ÇµÇΩÅB");
        }
    }
}
