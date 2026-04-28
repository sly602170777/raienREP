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
using Newtonsoft.Json;

namespace net433
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
            var uri = new Uri("http://localhost/api/json.php");
            var dic = new Dictionary<string, string>();
            dic.Add("name", textBox1.Text);
            dic.Add("age", textBox2.Text);
            var content = new FormUrlEncodedContent(dic);
            var res = await cl.PostAsync(uri, content);
            var json = await res.Content.ReadAsStringAsync();
            dynamic obj = JsonConvert.DeserializeObject(json);
            textBox3.Text = obj.Name;
            textBox4.Text = obj.Age.ToString();
        }
    }
}
