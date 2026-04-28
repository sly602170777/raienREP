using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg185
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            var text = "";
            var lst = new List<int>
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //ForEach���\�b�h�Ń����_����g�p
            lst.ForEach(x => text += $"{x * x}," );
            label1.Text = text;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            var text = "";
            var lst = new List<int>
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            //foreach�X�e�[�g�����g�ŌJ��Ԃ�����
            foreach ( var x in lst )
            {
                text += $"{x * x},";
            }
            label1.Text = text;
        }
    }
}
