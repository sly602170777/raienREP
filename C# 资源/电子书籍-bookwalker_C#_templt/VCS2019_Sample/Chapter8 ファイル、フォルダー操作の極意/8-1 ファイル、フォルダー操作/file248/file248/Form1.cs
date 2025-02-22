using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file248
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
            if ( System.IO.Directory.Exists(fname) == true )
            {
                System.IO.Directory.Delete(fname);
                textBox2.Text = $"{fname}を削除しました";
            }
            else if ( System.IO.File.Exists(fname) == true )
            {
                System.IO.File.Delete(fname);
                textBox2.Text = $"{fname}を削除しました";
            }
            else
            {
                textBox2.Text = $"{fname}が見つかりませんでした";
            }
        }
    }
}
