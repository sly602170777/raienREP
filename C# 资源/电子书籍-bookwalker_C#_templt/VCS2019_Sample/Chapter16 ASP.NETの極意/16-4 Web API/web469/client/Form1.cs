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
            var uri = new Uri(textBox1.Text);
            var cl = new HttpClient();
            var book = new Book()
            {
                ID = int.Parse(textBox2.Text),
                Title = textBox3.Text,
                Price = int.Parse(textBox4.Text),
                Pages = int.Parse(textBox5.Text),
            };
            var json = JsonConvert.SerializeObject(book);
            var content = new StringContent(json);
            content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json");
            var res = await cl.PostAsync(uri, content);
            textBox6.Text = await res.Content.ReadAsStringAsync();
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
