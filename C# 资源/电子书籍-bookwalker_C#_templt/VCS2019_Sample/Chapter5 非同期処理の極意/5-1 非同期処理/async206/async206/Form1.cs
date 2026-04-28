using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async206
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task onWork( Label label )
        {
            var end = DateTime.Now.AddSeconds(10);
            while (DateTime.Now < end)
            {
                this.Invoke(new Action(() =>
                   label.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                await Task.Delay(100);
            }
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            // 順番にタスクを実行
            await Task.Run(() => onWork(label1));
            await Task.Run(() => onWork(label2));
            await Task.Run(() => onWork(label5));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 同時にタスクを実行
            Task.Run(() => onWork(label1));
            Task.Run(() => onWork(label2));
        }
    }
}
