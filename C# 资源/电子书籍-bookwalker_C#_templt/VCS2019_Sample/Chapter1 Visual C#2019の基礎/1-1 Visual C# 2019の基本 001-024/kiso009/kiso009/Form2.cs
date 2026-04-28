using System;
using System.Windows.Forms;

namespace kiso009
{
    public partial class Form2 : Form
    {
        public Form2 ()
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


        }

        private void Button2_Click (object sender, EventArgs e)
        {

        }
    }
}
