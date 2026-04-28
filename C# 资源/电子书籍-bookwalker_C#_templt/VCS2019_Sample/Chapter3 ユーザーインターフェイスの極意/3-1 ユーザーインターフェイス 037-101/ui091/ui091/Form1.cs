using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui091
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           listView1.Clear();
            listView1.View = View.Details;  //リストビューを詳細表示に設定
            listView1.Columns.Add("ファイル名", 120); //列ヘッダー作成
            listView1.Columns.Add("サイズ", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("更新日", 120);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dirInfo;
            System.IO.FileInfo[] fList;

            listView1.Items.Clear(); //リストビューの一覧削除
            //指定したフォルダーの存在確認
            if (System.IO.Directory.Exists(textBox1.Text) == false)
            {
                MessageBox.Show("フォルダーが存在しません", "通知");
                return;
            }
            //フォルダーのファイル情報を取得
            dirInfo = new System.IO.DirectoryInfo(textBox1.Text);
            fList = dirInfo.GetFiles(); //フォルダー内のファイルを取得
            foreach (System.IO.FileInfo fInfo in fList)
            {
                ListViewItem fItem = new ListViewItem(fInfo.Name);
                fItem.SubItems.Add(fInfo.Length.ToString());
                fItem.SubItems.Add(fInfo.LastWriteTime.ToShortDateString());
                listView1.Items.Add(fItem);
            }
        }
    }
}
