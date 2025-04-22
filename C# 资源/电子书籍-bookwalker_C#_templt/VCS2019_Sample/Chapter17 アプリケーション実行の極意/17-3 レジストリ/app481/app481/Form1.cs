using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app481
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // レジストリから読み込む
            RegistryKey key = Registry.CurrentUser;
            key = key.OpenSubKey(@"software\逆引き大全C#2019");
            string data = (string)key.GetValue("sample");
            key.Close();
            // 結果を出力する
            textBox1.Text = data;
        }
    }
}
