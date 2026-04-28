using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async210
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            // 完了フラグ
            bool complete = false;
            // 進捗率
            int raito = 0;
            // タスクバーを更新する
            var task = new Task(async () => {
                while ( complete == false)
                {
                    //Invoke  调用
                    this.Invoke(new Action(() =>
                    {
                        label1.Text = $"進捗率：{raito*10} %";
                        progressBar1.Value = raito;
                    }));
                    await Task.Delay(10);
                }
            });
            // 显示进度条
            task.Start();

            // 計算タスク   thread ＝スレッド= 线程　　
            var result = await Task.Run<int>(async () =>
            {
                int sum = 0;
                for (int i = 1; i <= 10; i++)
                {
                    raito = i;
                    sum += i;
                    await Task.Delay(10);
                }
                complete = true;
                return sum;
            });
            label2.Text = $"合計値: {result}";





        }
    }
}
