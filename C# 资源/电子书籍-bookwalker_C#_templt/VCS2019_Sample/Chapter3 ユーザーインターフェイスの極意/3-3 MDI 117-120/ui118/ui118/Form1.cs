using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui118
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 新規ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form myFm = new Form();  //子フォームの作成

            //リッチテキストボックスの作成と設定
            RichTextBox myRT = new RichTextBox();
            myRT.Dock = DockStyle.Fill;

            //子フォームの設定
            myFm.MdiParent = this;  //親フォームを設定
            myFm.Text = "文書" + MdiChildren.Length; //タイトルバーの設定
            myFm.Size = new Size(200, 200); //フォームのサイズを設定
            myFm.Controls.Add(myRT); //リッチテキストボックスの追加
            myFm.Show(); //フォームを開く
        }
    }
}
