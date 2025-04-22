using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel489
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
            var wb = xapp.Workbooks.Open(@"C:\C#2019\data\Book1.xlsx");
            var sh = wb.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            var rg = sh.Range["A1", "C1"];
            rg.Interior.Color = System.Drawing.Color.FromArgb(100, 255, 100).ToArgb();
            wb.SaveAs(@"C:\C#2019\data\BookSave.xlsx");
            MessageBox.Show("•Û‘¶‚µ‚Ü‚µ‚½");
            xapp.Quit();
        }
    }
}
