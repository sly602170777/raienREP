using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net425
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // HTTPサーバーへ接続する
            var client = new HttpClient();
            try
            {
                // HTTPサーバーへ接続しストリームを取得する
                var stream = await client.GetStreamAsync(textBox1.Text);
                // テキストボックスへ結果を書き出す
                var reader = new System.IO.StreamReader(stream);
                textBox2.Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                // URLが不正の場合は例外が発生する
                MessageBox.Show(ex.Message);
            }
        }
    }
}
