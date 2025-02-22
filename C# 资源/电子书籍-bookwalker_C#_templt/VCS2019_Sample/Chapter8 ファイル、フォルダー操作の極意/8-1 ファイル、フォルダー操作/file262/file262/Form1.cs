using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file262
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach ( System.IO.DriveInfo info in 
                System.IO.DriveInfo.GetDrives())
            {
                listBox1.Items.Add($"{info.Name}\t{info.DriveType}");
            }
        }
    }
}
