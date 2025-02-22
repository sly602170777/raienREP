using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui116
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button myButton = new Button();
            //ボタンの設定をしてフォームに追加
            myButton.Text = "マイボタン";
            myButton.Size = new Size(90, 40);
            myButton.Location = new Point(90, 85);
            this.Controls.Add(myButton);

            //Clickイベントハンドラーとイベントハンドラーの関連付け
            myButton.Click += new EventHandler(myHandler);
        }

        private void myHandler(object sender,EventArgs e)
        {
            MessageBox.Show("マイボタンがクリックされました","結果");
        }
    }
}
