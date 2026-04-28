using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net420
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ホスト名を取得する
            string hostname = Dns.GetHostName();
            // IPアドレスを取得する
            var ipentry = Dns.GetHostEntry(hostname);
            // 最初のアドレスを取得
            foreach (var ipa in ipentry.AddressList)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    // IPAddress Ver 4 のアドレスを表示
                    textBox1.Text = ipa.ToString();
                }
            }
        }
    }
}
