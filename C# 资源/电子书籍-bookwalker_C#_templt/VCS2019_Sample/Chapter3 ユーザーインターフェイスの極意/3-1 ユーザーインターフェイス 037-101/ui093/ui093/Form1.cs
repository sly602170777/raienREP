using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui093
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = richTextBox1.UndoActionName;
            DialogResult ans;
            ans = MessageBox.Show("処理を戻しますか？", "確認",
                  MessageBoxButtons.YesNo);
            if (ans == DialogResult.Yes)
            {
                richTextBox1.Undo(); //直前の処理を元に戻す
                label1.Text = "";
            }
        }
    }
}
