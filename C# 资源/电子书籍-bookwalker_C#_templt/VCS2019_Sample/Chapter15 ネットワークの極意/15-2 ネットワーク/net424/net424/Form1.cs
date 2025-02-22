using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net424
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// サーバー開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => DoWork());
        }

        /// <summary>
        /// サーバー停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.server.Stop();
        }

        // ワーカースレッド
        private TcpListener server;
        public void DoWork()
        {
            // リスナーを作成する
            server = new TcpListener(IPAddress.Loopback, 9000);
            // リスナーを開始する
            server.Start();
            Invoke(new Action(() =>
            {
                textBox1.Text = "サーバー開始";
            }));
            try
            {
                while (true)
                {
                    // クライアントからの接続を受け付ける
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    // 受信データの読み出し
                    byte[] data = new byte[101];
                    int len = stream.Read(data, 0, data.Length);
                    string str = System.Text.Encoding.ASCII.GetString(data, 0, len);
                    Invoke(new Action(() =>
                    {
                        textBox1.Text = "受信データ:" + str;
                    }));
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    textBox1.Text = "サーバー終了";
                }));
            }
        }
    }
}
