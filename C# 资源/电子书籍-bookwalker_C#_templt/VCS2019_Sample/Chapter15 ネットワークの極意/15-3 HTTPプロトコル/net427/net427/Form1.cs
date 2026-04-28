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

namespace net427
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                // 指定URLのファイルをダウンロードする
                var data = await client.GetByteArrayAsync("http://localhost/test.zip");
                var fs = System.IO.File.OpenWrite(@"c:\C#2019\test.lzh");
                fs.Write(data, 0, data.Length);
                fs.Close();
                MessageBox.Show("ダウンロードが完了しました");
            }
            catch (Exception ex)
            {
                // URLが不正の場合は例外が発生する
                MessageBox.Show(ex.Message);
            }
        }
    }
}
