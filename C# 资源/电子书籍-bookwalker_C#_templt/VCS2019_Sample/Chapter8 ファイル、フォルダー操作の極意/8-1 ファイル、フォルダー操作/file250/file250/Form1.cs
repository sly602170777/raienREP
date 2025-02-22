using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file250
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string fname1 = textBox1.Text;
            string fname2 = textBox2.Text;
            // コピー元ファイル無し、あるいはコピー先ファイルあり
            // または、コピー先がフォルダーならば終了する
            if ( System.IO.File.Exists( fname1 ) == false )
            {
                textBox3.Text = "コピー元のファイルがありません。";
            }
            else if ( System.IO.File.Exists( fname2 ) == true )
            {
                textBox3.Text = "コピー先のファイルがあります。";
            }
            else if ( System.IO.Directory.Exists( 
                System.IO.Path.GetDirectoryName( fname2 )) == false )
            {
                textBox3.Text = "コピー先はディレクトリです。";
            }
            else
            {
                System.IO.File.Copy(fname1, fname2);
                textBox3.Text = $"{fname2}にコピーしました。";
            }
        }
    }
}
