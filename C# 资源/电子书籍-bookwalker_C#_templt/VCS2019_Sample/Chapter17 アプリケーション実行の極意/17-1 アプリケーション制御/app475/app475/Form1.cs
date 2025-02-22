using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app475
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var proc = new System.Diagnostics.Process();
            // メモ帳を起動する
            proc.StartInfo.FileName = "notepad.exe";
            // アプリケーションの終了を待つ
            proc.EnableRaisingEvents = true;
            proc.Exited += (s, _) => {
                // 終了のイベントを取得する
                MessageBox.Show("メモ帳を終了しました");
            };
            proc.Start();
        }
    }
}
