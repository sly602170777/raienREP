using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async207
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random _rnd = new Random();

        private async Task onWork( Label label )
        {
            var text = "";
            this.Invoke(new Action(() => label.Text = text));
            for ( int  i=0; i<5; i++ )
            {
                text += "★";
                this.Invoke(new Action(() => label.Text = text));
                // 500 msec までランダムに待つ
                await Task.Delay(_rnd.Next(5000));
            }
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            label6.Text = "開始!!!";
            await Task.Run(() =>
            {
                var lst = new List<Task>();
                // 5つのタスクを同時実行する
                lst.Add(Task.Run(() => onWork(label1)));
                lst.Add(Task.Run(() => onWork(label2)));
                lst.Add(Task.Run(() => onWork(label3)));
                lst.Add(Task.Run(() => onWork(label4)));
                lst.Add(Task.Run(() => onWork(label5)));
                Task.WaitAll(lst.ToArray());
            });
            label6.Text = "すべて完了";
        }
    }
}
