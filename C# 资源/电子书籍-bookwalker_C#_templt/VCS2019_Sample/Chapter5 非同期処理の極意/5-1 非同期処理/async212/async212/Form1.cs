using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async212
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Threading.ManualResetEvent mre;

        private async void Button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                //Mutex  互斥性  アプリケーションの多重起動を禁止するために使用します
                //从处于无信号状态（即传递给构造函数）的ManualResetEvent开始false
                mre = new System.Threading.ManualResetEvent(false);
                for ( int i=0; i<10; i++ )
                {
                    if ( i == 5 )
                    {
                        // 10秒後にイベント待ちになる
                        this.Invoke(new Action(() => {
                            label1.Text = "解除イベント待ち";
                        }));
                        //Reset方法并启动另一个线程  调用其Reset方法
                        mre.Reset();
                        //调用WaitOne方法时不会阻塞，而是运行到完成
                        mre.WaitOne();
                    }
                    this.Invoke(new Action(() =>
                    {
                        label1.Text = $"{i} 秒経過";
                    }));
                    System.Threading.Thread.Sleep(1000);
                }
            });
            label1.Text = "タスク終了";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // イベント待ちを解除  ，按下Enter键时  Set该方法将释放所有线程。
            mre.Set();
        }
    }
}
