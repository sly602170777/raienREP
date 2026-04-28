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

namespace excel494
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xapp = new Excel.Application();
            var wb = xapp.Workbooks.Open(@"C:\C#2019\data\Book1.xlsx");
            var sh = wb.ActiveSheet as Excel.Worksheet;
            sh.ExportAsFixedFormat(
                Excel.XlFixedFormatType.xlTypePDF, @"C:\C#2019\data\Book1.pdf");
            xapp.Quit();
            MessageBox.Show("PDFƒtƒ@ƒCƒ‹‚É•Û‘¶‚µ‚Ü‚µ‚½");
        }
    }
}
