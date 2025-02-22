using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async209
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
                   label1.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                await Task.Delay(10);

            }
            return sum+50;
        }

        int total = 0;
        private void Button1_Click(object sender, EventArgs e)
        {
            // 非同期でタスクを実行
            // UI スレッドを占有しない
            //Task.Run<int>(onWork)
            //    .ContinueWith(t =>
            //   {
            //       // 結果を表示
            //       int sum = t.Result;
            //       this.Invoke(new Action(() =>
            //            label2.Text = $"合計値: {sum}"
            //       ));
            //   });
            total++;
            while (total>1)
            {
                continue;       
            }
            Task.Run<int>(onWork).ContinueWith(a =>
            {
                int b = a.Result;
                this.Invoke(new Action(() => label2.Text = $"{b}" + "------" + $"{total}"
                )); ;
            });
        }
    }
}
