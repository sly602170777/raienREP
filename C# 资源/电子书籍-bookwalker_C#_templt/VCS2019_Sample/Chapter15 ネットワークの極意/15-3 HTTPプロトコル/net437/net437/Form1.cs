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

namespace net437
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var cl = new HttpClient();
            /// User-Agent ‚ðŽw’è‚·‚é
            cl.DefaultRequestHeaders.Add("User-Agent", "Gokui-App");
            var uri = new Uri("http://localhost:5000/api/Sample");
            var obj = new { 
                Name = "MASUDA", 
                Age = 51, 
                Address = "Itabshi" };
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json);
            content.Headers.ContentType =
                new MediaTypeHeaderValue("application/json");
            var res = await cl.PostAsync(uri, content);
            textBox1.Text = await res.Content.ReadAsStringAsync();
        }
    }
}
