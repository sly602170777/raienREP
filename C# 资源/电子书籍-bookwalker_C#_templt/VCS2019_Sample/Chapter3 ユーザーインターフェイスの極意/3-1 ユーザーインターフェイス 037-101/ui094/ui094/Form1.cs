using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui094
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont =
                    new Font("MS ゴシック", 14, FontStyle.Italic);
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                if (richTextBox1.SelectionColor != Color.Red) //文字色が赤でない場合、
                {
                    richTextBox1.SelectionColor = Color.Red; //文字色を赤に設定
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Black; //文字色を黒に設定
                }
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font myFont = richTextBox1.SelectionFont;
                FontStyle myFS;

                if (richTextBox1.SelectionFont.Bold == false) //太字でない場合、
                {
                    myFS = FontStyle.Bold;
                }
                else
                {
                    myFS = FontStyle.Regular;
                }
                richTextBox1.SelectionFont =
                   new Font(myFont.FontFamily, myFont.Size, myFS);
            }

        }
    }
}
