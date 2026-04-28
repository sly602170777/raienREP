using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel487
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xapp = new Microsoft.Office.Interop.Excel.Application();
            var wb = xapp.Workbooks.Open(@"C:\C#2019\data\Book2.xlsx");
            var sh = wb.Sheets[1] as Microsoft.Office.Interop.Excel.Worksheet;
            int r = 2;
            var items = new List<Data>();
            while (sh.Cells[r, 1].Text != "")
            {
                var data = new Data()
                {
                    ID = (int)sh.Cells[r, 1].Value,
                    Title = sh.Cells[r, 2].Value,
                    Price = (int)sh.Cells[r, 3].Value
                };
                items.Add(data);
                r++;
            }
            dataGridView1.DataSource = items;
            xapp.Quit();
        }
    }
    public class Data
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
