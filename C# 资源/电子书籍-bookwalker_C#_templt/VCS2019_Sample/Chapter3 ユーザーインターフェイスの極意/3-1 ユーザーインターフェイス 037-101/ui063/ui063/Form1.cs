using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui063
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime myDate;
            if (maskedTextBox1.MaskCompleted)
            {
                if (DateTime.TryParse(maskedTextBox1.Text, out myDate))
                {
                    label2.Text = maskedTextBox1.Text;
                }
                else
                {
                    label2.Text = "正確な日付を入力してください";
                }
            }
            else
            {
                label2.Text = "最後まで入力してください";
            }
        }
    }
}
