using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async208
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task<int> onWork()
        {
            int sum = 0;
            for ( int i=1; i<=100; i++ )
            {
                sum += i;
                this.Invoke(new Action(() =>
                   label1.Text = DateTime.Now.ToString("HH:MM:ss.ffffff")));
                await Task.Delay(50);
            }
            return sum;
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            // 非同期でタスクを実行
            // UI スレッドを占有しない   不占用线程
            int sum = await Task.Run<int>(onWork);
            // 結果を表示
            label2.Text = $"合計値: {sum}";
        }
    }
}
