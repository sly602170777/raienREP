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
            var uri = new Uri(textBox1.Text);
            var cl = new HttpClient();
            cl.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));
            var res = await cl.GetAsync(uri);
            var st = await res.Content.ReadAsStreamAsync();
            var doc = XDocument.Load(st);
            textBox6.Text = doc.ToString();
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
