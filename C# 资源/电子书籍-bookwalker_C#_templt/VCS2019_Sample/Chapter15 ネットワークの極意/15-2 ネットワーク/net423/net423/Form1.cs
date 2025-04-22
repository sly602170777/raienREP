using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net423
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new TcpClient();
            try
            {
                // TCP/IP接続を行う
                client.Connect("localhost", 80);
                // ストリームを取得する
                NetworkStream stream = client.GetStream();
                byte[] buffer = System.Text.Encoding.ASCII.GetBytes(
                    "GET /start.html HTTP/1.0\r\n\r\n");
                stream.Write(buffer, 0, buffer.Length);
                byte[] data = new byte[1001];
                stream.Read(data, 0, data.Length);
                // 正常に受信できた場合
                textBox1.Text = System.Text.Encoding.ASCII.GetString(data);
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
