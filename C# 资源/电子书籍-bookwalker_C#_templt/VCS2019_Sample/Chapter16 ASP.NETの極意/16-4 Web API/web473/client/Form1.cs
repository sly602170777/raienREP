using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var doc = new XElement("Book",
                new XElement("ID", textBox1.Text),
                new XElement("Title", textBox2.Text),
                new XElement("Price", textBox3.Text),
                new XElement("Page", textBox4.Text));
            var xml = doc.ToString();
            var cl = new HttpClient();
            var cont = new StringContent(xml);
            cont.Headers.ContentType =
                new MediaTypeHeaderValue("application/xml");
            var res = await cl.PostAsync($"http://localhost:5000/api/Books", cont);
            var text = await res.Content.ReadAsStringAsync();
            textBox5.Text = text;
        }
    }
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }
}
