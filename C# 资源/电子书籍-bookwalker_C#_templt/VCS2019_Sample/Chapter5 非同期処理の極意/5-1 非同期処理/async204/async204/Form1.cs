using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async204
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      //  Task _task;

        private void Button1_Click(object sender, EventArgs e)
        {
        var  _task = Task.Run(async () =>
            {
                var end = DateTime.Now.AddSeconds(10);
                while (DateTime.Now < end)
                {
                    this.Invoke(new Action(() =>
               label1.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                    await Task.Delay(100);
                }
            });
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            var task = new Task(async () =>
            {
                var end = DateTime.Now.AddSeconds(10);
                while (DateTime.Now < end)
                {
                    this.Invoke(new Action(() =>
                        label1.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                    await Task.Delay(100);
                }
            });
            await Task.Delay(5000);
            task.Start();
        }
    }
}
