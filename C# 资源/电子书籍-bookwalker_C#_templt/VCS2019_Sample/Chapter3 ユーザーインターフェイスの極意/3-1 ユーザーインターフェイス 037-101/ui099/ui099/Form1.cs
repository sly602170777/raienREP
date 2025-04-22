using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui099
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 10;     //最小値の設定
            trackBar1.Maximum = 30;     //最大値の設定
            trackBar1.Value = 10;         //現在値の設置
            trackBar1.TickFrequency = 1;  //目盛の間隔を設定
            trackBar1.SmallChange = 1;   //ドラッグによる増減値の設定
            trackBar1.LargeChange = 5;    //クリックによる増減値の設定
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            Font myFont = label1.Font;
            label1.Font =
                new Font(myFont.FontFamily, trackBar1.Value);
        }
    }
}
