using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace debug351
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var tLis = new TextWriterTraceListener(@"C:\C#2019\Debug.txt");
            Debug.Listeners.Add(tLis); // 出力先を追加する
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine($"{i}回目");
            }
            Debug.Flush(); // 出力バッファをフラッシュ
            MessageBox.Show("ファイルに出力しました。", "通知");
        }
    }
}
