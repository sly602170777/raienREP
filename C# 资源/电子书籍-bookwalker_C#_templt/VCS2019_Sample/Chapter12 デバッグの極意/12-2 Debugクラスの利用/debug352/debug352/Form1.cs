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
namespace debug352
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var tLis = new TextWriterTraceListener(@"C:\C#2019\DebugAuto.txt");
            Debug.Listeners.Add(tLis); // 出力先を追加する
            Debug.AutoFlush = true;  // 自動的に出力する
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine($"{i}回目");

            }
            MessageBox.Show("ファイルに出力しました。", "通知");
        }
    }
}
