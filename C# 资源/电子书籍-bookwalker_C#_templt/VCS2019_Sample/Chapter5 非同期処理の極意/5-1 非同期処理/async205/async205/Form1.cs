using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async205
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            var ret = await Task.Run<string>(async () =>
           {
               var end = DateTime.Now.AddSeconds(10);
               while (DateTime.Now < end)
               {
                   this.Invoke(new Action(() =>
                       label1.Text = DateTime.Now.ToString("HH:MM:ss.fff")));
                   await Task.Delay(100);
               }
               return DateTime.Now.ToString() + " に完了";
           });
            label2.Text = ret;
        }
    }
}
