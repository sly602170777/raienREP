using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui044
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //フォームを画面左上に表示する
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = new Point(0, 0); //左上の位置を指定
            newForm.Show(); //フォームを開く
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //フォームを画面中央に表示する
            newForm.StartPosition = FormStartPosition.CenterScreen;
            newForm.Show(); //フォームを開く        }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //フォームをWindowsの既定位置に表示する
            newForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            newForm.Show(); //フォームを開く        }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //フォームをWindowsの既定位置に表示し、既定の境界線を持つ
            newForm.StartPosition = FormStartPosition.WindowsDefaultBounds;
            newForm.Show(); //フォームを開く        }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //フォームを親フォームの境界内で中央に表示する
            newForm.StartPosition = FormStartPosition.CenterParent;
            newForm.Show(); //フォームを開く        }

        }
    }
}
