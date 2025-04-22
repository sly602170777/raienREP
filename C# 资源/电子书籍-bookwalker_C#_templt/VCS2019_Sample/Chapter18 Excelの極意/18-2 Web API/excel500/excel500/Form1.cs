using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Xml.Linq;
using System.IO;

namespace excel500
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = "http://www.shuwasystem.co.jp/products/7980html/5002.html";
            var hc = new HttpClient();
            var html = await hc.GetStringAsync(url);
            var hdoc = new HtmlAgilityPack.HtmlDocument();
            hdoc.LoadHtml(html);

            var title = hdoc.DocumentNode.SelectSingleNode("//h1[@class='titleType1']").InnerText.Trim();
            var div = hdoc.DocumentNode.SelectSingleNode("//div[@class='right']");
            var table = div.SelectSingleNode(".//table");
            var items = table.SelectNodes("*/tr/td");
            var author = items[0].InnerText.Trim();
            var isbn = items[3].InnerText.Trim();
            var date = items[2].InnerText.Trim();

            var text = $"タイトル {title}\r\n著者: {author}\r\nISBN: {isbn}\r\n発売日: {date}\r\n";
            textBox1.Text = text;

            // excel に出力
            var xapp = new Excel.Application();
            var wb = xapp.Workbooks.Add();
            var sh = wb.ActiveSheet as Excel.Worksheet;
            sh.Cells[1, 1].Value = "タイトル";
            sh.Cells[2, 1].Value = "著者";
            sh.Cells[3, 1].Value = "ISBN";
            sh.Cells[4, 1].Value = "発売日";

            sh.Cells[1, 2].Value = title;
            sh.Cells[2, 2].Value = author;
            sh.Cells[3, 2].Value = isbn;
            sh.Cells[4, 2].Value = date;

            xapp.Visible = true;
            xapp.Quit();
        }
    }
}
