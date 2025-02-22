using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file256
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
            if ( System.IO.Directory.Exists( fname ) == false )
            {
                MessageBox.Show($"{fname}が見つかりませんでした。");
                return;
            }
            listBox1.Items.Clear();
            foreach ( var it in System.IO.Directory.GetFiles(fname))
            {
                listBox1.Items.Add(it);
            }
        }
    }
}
