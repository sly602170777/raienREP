using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net428
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
                var content = new MultipartFormDataContent();


                // 指定URLへファイルをアップロードする
                var path = @"c:\C#2019\test.zip";
                var fileCont = new StreamContent(
                    System.IO.File.OpenRead(path));
                fileCont.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = System.IO.Path.GetFileName(path)
                };
                content.Add(fileCont);
                await client.PostAsync("http://localhost/upload.php", content);
                textBox1.Text = "ファイルをアップロードしました";
            }
            catch (Exception ex)
            {
                // アップロードが異常の場合は例外が発生する
                MessageBox.Show(ex.Message);
            }
        }
    }
}
