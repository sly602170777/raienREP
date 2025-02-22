using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net421
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TCP/IP接続を行う
            var client = new System.Net.Sockets.TcpClient();
            try
            {
                client.Connect("localhost", 80);
                // 正常に接続できた場合
                textBox1.Text = "正常に接続できました";
                client.Close();
            }
            catch (Exception ex)
            {
                // 接続できなかった場合
                textBox1.Text = ex.Message;
            }
        }
    }
}
