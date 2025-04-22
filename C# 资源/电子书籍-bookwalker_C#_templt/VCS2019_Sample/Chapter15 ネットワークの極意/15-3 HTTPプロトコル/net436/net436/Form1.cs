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
using Newtonsoft.Json;

namespace net436
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string _cookie;
        /// <summary>
        /// 自前でCookieを指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            var cl = new HttpClient();
            var uri = new Uri("http://localhost:5000/api/Sample");
            var obj = new { 
                Name = "MASUDA", 
                Age = 51, 
                Address = "Itabshi" };
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json);
            content.Headers.ContentType =
                new MediaTypeHeaderValue("application/json");
            /// クッキーを設定する
            if (_cookie != null)
                content.Headers.Add("Cookie", _cookie);
            var res = await cl.PostAsync(uri, content);
            /// クッキーを取得する
            _cookie = res.Headers.GetValues("Set-Cookie").First();
            textBox1.Text = await res.Content.ReadAsStringAsync();
        }


        HttpClient _cl;
        /// <summary>
        /// 自動でCookieを指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            if ( _cl != null )
            {
                _cl = new HttpClient(
                    new HttpClientHandler() { UseCookies = true });
            }
            var uri = new Uri("http://localhost:5000/api/Sample");
            var obj = new
            {
                Name = "MASUDA",
                Age = 51,
                Address = "Itabshi"
            };
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json);
            content.Headers.ContentType =
                new MediaTypeHeaderValue("application/json");
            var res = await _cl.PostAsync(uri, content);
            textBox1.Text = await res.Content.ReadAsStringAsync();
        }
    }
}
