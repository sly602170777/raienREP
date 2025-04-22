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

namespace error316
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
            }
            catch ( ArgumentException ex )
            {
                MessageBox.Show("引数が無効です", "エラー発生");
            }
            catch ( Exception ex )
            {
                MessageBox.Show("予期しないエラーが発生しました", "エラー発生");
            }
        }
    }
}
