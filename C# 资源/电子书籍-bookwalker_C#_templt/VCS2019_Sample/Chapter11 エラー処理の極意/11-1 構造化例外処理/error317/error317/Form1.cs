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

namespace error317
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
            int a = 0;
            try
            {
                a = int.Parse(text);
                a += 10;
                // 正常の場合は関数を抜ける
                return;
            }
            catch ( FormatException ex )
            {
                MessageBox.Show(ex.Message, "エラー発生");
            }
            finally
            {
                MessageBox.Show("finallyブロックの処理");
            }
        }
    }
}
