using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui046
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("[OK]ボタンがクリックされました");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("[キャンセル]ボタンがクリックされました");
        }
    }
}
