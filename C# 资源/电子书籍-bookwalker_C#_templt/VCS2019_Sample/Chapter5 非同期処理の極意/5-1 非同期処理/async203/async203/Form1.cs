using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async203
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Task _task;

        private void Button1_Click(object sender, EventArgs e)
        {
            _task = new Task(async () =>
            {
                var end = DateTime.Now.AddSeconds(5);
                while (DateTime.Now < end)
                {
                    this.Invoke(new Action(() =>
               label1.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                    await Task.Delay(50);
                }
            });
            _task.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _task = new Task(onWork);
            _task.Start();
        }

        async void onWork()
        {
            var end = DateTime.Now.AddSeconds(5);
            while (DateTime.Now < end)
            {
                this.Invoke(new Action(() =>
                    label1.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                this.Invoke(new Action(() => { label1.Text = DateTime.Now.ToString("HH:MM:ss.fff"); }
                    ));
                await Task.Delay(50);
            }
        }
    }
}
