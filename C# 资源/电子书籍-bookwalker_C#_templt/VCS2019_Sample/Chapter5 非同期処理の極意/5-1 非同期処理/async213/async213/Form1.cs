using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async213
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Threading.CancellationTokenSource cts;

        private async void Button1_Click(object sender, EventArgs e)
        {
            cts = new System.Threading.CancellationTokenSource();

            var reuslt = await Task.Run<bool>( async () =>
            {
                var end = DateTime.Now.AddSeconds(5);
                while (DateTime.Now < end)
                {
                    if ( cts.Token.IsCancellationRequested )
                    {
                        return false;
                    }
                    this.Invoke(new Action(() =>
                       label1.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                    await Task.Delay(100);
                }
                return true;
                //Token 方法 取得CancellationTokenSource的属性
            }, cts.Token );

            label1.Text = $"タスク結果：{reuslt}";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // タスクをキャンセルする
            cts.Cancel();
        }
    }
}
