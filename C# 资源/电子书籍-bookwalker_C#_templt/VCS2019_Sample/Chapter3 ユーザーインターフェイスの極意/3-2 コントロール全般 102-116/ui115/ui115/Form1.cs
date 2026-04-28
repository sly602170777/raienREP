using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui115
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //LabelとTextBoxのインスタンスの作成
        Label myLabel = new Label();
        TextBox myTextBox = new TextBox();

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false; //コントロールの削除ボタン非表示
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //追加するLabelの設定
            myLabel.Text = "今日の日付";
            myLabel.Location = new Point(25, 50);
            //追加するTextBoxの設定
            myTextBox.Text = DateTime.Now.ToShortDateString();
            myTextBox.Location = new Point(25, 80);
            myTextBox.Size = new Size(200, 20);

            //labelとTextBoxをフォームに追加
            this.Controls.Add(myLabel);
            this.Controls.Add(myTextBox);
            button1.Visible = false; //追加ボタンの非表示
            button2.Visible = true;　//削除ボタンの表示

            bool flag=this.Controls.Contains(myLabel);
            myLabel.Text = myLabel.Text+ flag;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(myLabel);
            this.Controls.Remove(myTextBox);
            button1.Visible = true;  //追加ボタンの表示
            button2.Visible = false; //削除ボタンの非表示
        }
    }
}
