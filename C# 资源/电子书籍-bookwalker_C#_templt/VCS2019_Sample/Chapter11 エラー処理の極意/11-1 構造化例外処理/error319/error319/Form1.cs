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

namespace error319
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
            // カンマ区切りで分割
            var ary = text.Split(',');
            try
            {

                // 11番目の要素を取得
                string n = ary[4]; 
            }
            catch ( IndexOutOfRangeException ex )
            {
                MessageBox.Show(ex.Message, "エラー発生");
            }
        }
    }
}
