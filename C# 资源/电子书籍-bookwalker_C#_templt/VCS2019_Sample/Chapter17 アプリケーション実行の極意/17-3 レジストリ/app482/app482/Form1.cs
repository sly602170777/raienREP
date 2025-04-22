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

namespace app482
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
            key = key.CreateSubKey(@"software\逆引き大全C#2019");
            key.SetValue("sample", textBox1.Text);
            key.Close();
            MessageBox.Show("レジストリへ書き込みました");
        }
    }
}
