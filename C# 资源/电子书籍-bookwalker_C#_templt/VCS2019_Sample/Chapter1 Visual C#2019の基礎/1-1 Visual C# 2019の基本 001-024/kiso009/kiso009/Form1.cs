using System;
using System.Windows.Forms;

namespace kiso009
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            //Windowサイズを変更しないように
            FormBorderStyle = FormBorderStyle.FixedToolWindow;

            if (MaximizeBox & MinimizeBox)
            {
                MaximizeBox = false;
                MinimizeBox = false;
            }
            else
            {
                MaximizeBox = true;
                MinimizeBox = true;
            }

            InitializeComponent ();
        }

        private void Button1_Click (object sender, EventArgs e)
        {

            label1.Text = "Visual C# 2019をはじめよう！";
            //using linq
            MessageBox.Show ("这是form2", "这是form2 ShowDialog");
            Form2 form2 = new Form2 ();
            //不允许选择其他form
            form2.ShowDialog ();

        }

        private void Button2_Click (object sender, EventArgs e)
        {
            MessageBox.Show ("这是form2", "这是form2 Show");
            Form2 form2 = new Form2 ();
            //允许选择其他form
            form2.Show ();
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            MessageBox.Show ("on load ", " on load 処理");
        }
    }
}
