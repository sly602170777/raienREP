using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui054
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = "秀和システムのWebサイトを開きます";
            //リンク文字列の指定とリンク先設定
            linkLabel1.Links.Add(0, 6, "www.shuwasystem.co.jp");
        }

        private void LinkLabel1_LinkClicked(object sender, 
            LinkLabelLinkClickedEventArgs e)
        {
            string linkTarget;
            linkTarget = linkLabel1.Links[0].LinkData.ToString();
            System.Diagnostics.Process.Start(linkTarget);

            //訪問済みとしてテキストの色を変更
            linkLabel1.LinkVisited = true;

        }
    }
}
