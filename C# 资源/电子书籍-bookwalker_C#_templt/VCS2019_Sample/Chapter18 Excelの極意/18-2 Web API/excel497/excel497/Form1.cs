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

namespace excel497
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int city = 130010; // 東京
            var url = $"http://weather.livedoor.com/forecast/webservice/json/v1?city={city}";
            var hc = new HttpClient();
            var json = await hc.GetStringAsync(url);
            textBox1.Text = json;
            var jr = new JsonTextReader(new System.IO.StringReader(json));
            var root = JObject.ReadFrom(jr);
            var title = root["title"].Value<string>();
            var forecasts = root["forecasts"] as JArray;
            // 明日の天気
            var yesterday = forecasts[1];
            var date = yesterday["date"].Value<string>();
            var dateLabel = yesterday["dateLabel"].Value<string>();
            var telop = yesterday["telop"].Value<string>();
            var min = yesterday["temperature"]["min"]["celsius"].Value<string>();
            var max = yesterday["temperature"]["max"]["celsius"].Value<string>();

            // excel に出力
            var xapp = new Excel.Application();
            var wb = xapp.Workbooks.Add();
            var sh = wb.ActiveSheet as Excel.Worksheet;
            sh.Cells[1, 1].Value = "場所";
            sh.Cells[2, 1].Value = "日付";
            sh.Cells[3, 1].Value = "予報";
            sh.Cells[4, 1].Value = "最低気温（予想）";
            sh.Cells[5, 1].Value = "最高気温（予想）";
            sh.Cells[1, 2].Value = title;
            sh.Cells[2, 2].Value = date;
            sh.Cells[2, 3].Value = dateLabel;
            sh.Cells[3, 2].Value = telop;
            sh.Cells[4, 2].Value = min;
            sh.Cells[5, 2].Value = max;
            xapp.Visible = true;
            xapp.Quit();
        }
    }
}
