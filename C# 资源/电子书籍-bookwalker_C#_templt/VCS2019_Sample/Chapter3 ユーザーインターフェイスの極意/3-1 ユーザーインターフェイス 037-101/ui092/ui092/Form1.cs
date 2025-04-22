using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui092
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string myPath = @"C:\C#2019"; //画像のフォルダーを指定

            //指定したフォルダー内のjpgファイルを取得
            string[] imgFile = System.IO.Directory.GetFiles(myPath, "*.jpg");

            //imgFileに格納された画像ファイルをImageListに追加し、
            //listViewに表示する
            for (int i = 0; i < imgFile.Length; i++)
            {
                Image myImg = Bitmap.FromFile(imgFile[i]);
                imageList1.Images.Add(myImg);
                listView1.Items.Add(imgFile[i], i);
                myImg.Dispose();
            }

        }
    }
}
