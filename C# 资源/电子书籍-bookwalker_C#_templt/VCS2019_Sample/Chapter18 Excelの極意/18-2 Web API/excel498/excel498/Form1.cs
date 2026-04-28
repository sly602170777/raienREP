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

namespace excel498
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var urlmax = $"http://www.data.jma.go.jp/obd/stats/data/mdrr/tem_rct/alltable/mxtemsadext00_rct.csv";
            var urlmin = $"http://www.data.jma.go.jp/obd/stats/data/mdrr/tem_rct/alltable/mntemsadext00_rct.csv";
            var hc = new HttpClient();

            var enc = Encoding.GetEncoding("shift_jis");
            var st = await hc.GetStreamAsync(urlmax);
            var tr = new StreamReader(st, enc, false) as TextReader;
            var csvmax = await tr.ReadToEndAsync();

            st = await hc.GetStreamAsync(urlmin);
            tr = new StreamReader(st, enc, false) as TextReader;
            var csvmin = await tr.ReadToEndAsync();

            var data = new List<Data>();
            // 最高気温CSVをパースする
            var lst = csvmax.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            // 先頭行は削除する
            lst.RemoveAt(0);
            foreach (string line in lst)
            {
                var vals = line.Split(new string[] { "," }, StringSplitOptions.None);
                if (vals.Count() > 13)
                {
                    // 観測番号, 都道府県, 地点, 最高気温, 最高気温(時), 最高気温(分) を取得
                    try
                    {
                        var d = new Data()
                        {
                            Id = int.Parse(vals[0]),
                            Place1 = vals[1],
                            Place2 = vals[2],
                            TemperatureMax = double.Parse(vals[9]),
                            MaxHour = int.Parse(vals[11]),
                            MinMinitue = int.Parse(vals[12])
                        };
                        data.Add(d);
                    }
                    catch { }
                }
            }
            // 最低気温CSVをパースする
            lst = csvmin.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            lst.RemoveAt(0);
            foreach (string line in lst)
            {
                var vals = line.Split(new string[] { "," }, StringSplitOptions.None);
                if (vals.Count() > 13)
                {
                    // 観測番号, 都道府県, 地点, 最低気温, 最低気温(時), 最低気温(分) を取得
                    try
                    {

                        var id = int.Parse(vals[0]);
                        var temp = double.Parse(vals[9]);
                        var hour = int.Parse(vals[11]);
                        var min = int.Parse(vals[12]);
                        var d = data.First(x => x.Id == id);
                        if (d != null)
                        {
                            d.TemperatureMin = temp;
                            d.MinHour = hour;
                            d.MinMinitue = min;
                        }
                    }
                    catch { }
                }
            }
            textBox1.Text = "取得完了";

            // Excel に出力する
            var xapp = new Excel.Application();
            var wb = xapp.Workbooks.Add();
            var sh = wb.ActiveSheet as Excel.Worksheet;
            sh.Cells[1, 1].Value = "観測番号";
            sh.Cells[1, 2].Value = "都道府県";
            sh.Cells[1, 3].Value = "地点";
            sh.Cells[1, 4].Value = "最低気温";
            sh.Cells[1, 5].Value = "時分";
            sh.Cells[1, 6].Value = "最高気温";
            sh.Cells[1, 7].Value = "時分";

            int r = 2;
            xapp.Visible = true;
            foreach (var d in data)
            {
                sh.Cells[r, 1].Value = d.Id;
                sh.Cells[r, 2].Value = d.Place1;
                sh.Cells[r, 3].Value = d.Place1;
                sh.Cells[r, 4].Value = d.TemperatureMax;
                sh.Cells[r, 5].Value = $"{d.MaxHour}:{d.MaxMinitue}";
                sh.Cells[r, 6].Value = d.TemperatureMin;
                sh.Cells[r, 7].Value = $"{d.MinHour}:{d.MinMinitue}";
                r++;
            }
            xapp.Quit();
        }
    }
    public class Data
    {
        public int Id { get; set; }
        public string Place1 { get; set; }
        public string Place2 { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }
        public int MaxHour { get; set; }
        public int MaxMinitue { get; set; }
        public int MinHour { get; set; }
        public int MinMinitue { get; set; }
    }
}
