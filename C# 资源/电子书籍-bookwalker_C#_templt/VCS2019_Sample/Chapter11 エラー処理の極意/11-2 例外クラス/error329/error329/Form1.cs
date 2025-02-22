using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace error329
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
            try
            {
                // ファイル名を指定する
                foreach ( var it in System.IO.Directory.GetFiles(path))
                {
                    System.Diagnostics.Debug.WriteLine(it);
                }
            } 
            catch ( System.IO.IOException ex )
            {
                MessageBox.Show(ex.Message, "エラー発生");
            }
        }
    }
}
