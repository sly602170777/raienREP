using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app479
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// テキストをペースト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // テキスト形式でペーストする
            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                textBox1.Text = text;
            }
        }

        /// <summary>
        /// 画像をペースト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // 画像形式でペーストする
            if (Clipboard.ContainsImage())
            {
                var image = Clipboard.GetImage();
                pictureBox1.Image = image;
            }
        }
    }
}
