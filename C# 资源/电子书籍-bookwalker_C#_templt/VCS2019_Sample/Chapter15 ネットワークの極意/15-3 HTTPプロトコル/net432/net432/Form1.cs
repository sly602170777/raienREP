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

namespace net432
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
            var uri = new Uri("http://localhost:5000/api/Sample2");
            var dic = new Dictionary<string, string>();
            dic.Add("name", textBox1.Text);
            dic.Add("age", textBox2.Text);
            var content = new FormUrlEncodedContent(dic);
            var res = await cl.PostAsync(uri, content);
            var doc = System.Xml.Linq.XDocument.Load(await res.Content.ReadAsStreamAsync());
            textBox3.Text = doc.Document.Element("person").Element("name").Value;
            textBox4.Text = doc.Document.Element("person").Element("age").Value;
        }
    }
}
