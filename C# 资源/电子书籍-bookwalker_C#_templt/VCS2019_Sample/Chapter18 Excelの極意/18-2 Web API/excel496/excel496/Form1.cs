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

namespace excel496
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = "http://my.redmine.jp/demo/projects.xml";
            var hc = new HttpClient();
            var xml = await hc.GetStringAsync(url);
            textBox1.Text = xml;
            var doc = XDocument.Load(new System.IO.StringReader(xml));

            var xapp = new Excel.Application();
            var wb = xapp.Workbooks.Add();
            var sh = wb.ActiveSheet as Excel.Worksheet;
            // タイトルを出力
            sh.Range["A1"].Value = "ID";
            sh.Range["B1"].Value = "タグ";
            sh.Range["C1"].Value = "プロジェクト名";
            sh.Range["D1"].Value = "内容";

            // 内容を出力
            int r = 2;
            foreach (var it in doc.Root.Elements())
            {
                var id = it.Element(XName.Get("id")).Value;
                var tag = it.Element(XName.Get("identifier")).Value;
                var name = it.Element(XName.Get("name")).Value;
                var desc = it.Element(XName.Get("description")).Value;
                desc = desc.Replace("\n", "");
                System.Diagnostics.Debug.WriteLine($"{id} {tag} {name} {desc}");
                sh.Cells[r, 1].Value = id;
                sh.Cells[r, 2].Value = tag;
                sh.Cells[r, 3].Value = name;
                sh.Cells[r, 4].Value = desc;
                r++;
            }
            xapp.Visible = true;
            xapp.Quit();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var url = "http://my.redmine.jp/demo/projects.json";
            var hc = new HttpClient();
            var json = await hc.GetStringAsync(url);
            textBox1.Text = json;
            var js = new JsonSerializer();
            var jr = new JsonTextReader(new System.IO.StringReader(json));
            var projects = JObject.ReadFrom(jr)["projects"] as JArray;

            var xapp = new Excel.Application();
            var wb = xapp.Workbooks.Add();
            var sh = wb.ActiveSheet as Excel.Worksheet;
            // タイトルを出力
            sh.Range["A1"].Value = "ID";
            sh.Range["B1"].Value = "タグ";
            sh.Range["C1"].Value = "プロジェクト名";
            sh.Range["D1"].Value = "内容";

            // 内容を出力
            int r = 2;

            foreach (var it in projects)
            {
                var id = it["id"].Value<int>();
                var tag = it["identifier"].Value<string>();
                var name = it["name"].Value<string>();
                var desc = it["description"].Value<string>();
                desc = desc.Replace("\r\n", "");
                System.Diagnostics.Debug.WriteLine($"{id} {tag} {name} {desc}");
                sh.Cells[r, 1].Value = id;
                sh.Cells[r, 2].Value = tag;
                sh.Cells[r, 3].Value = name;
                sh.Cells[r, 4].Value = desc;
                r++;
            }
            xapp.Visible = true;
            xapp.Quit();
        }
    }
    public class ProjectItem
    {
        public int id { get; set; }
        public string identifier { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
