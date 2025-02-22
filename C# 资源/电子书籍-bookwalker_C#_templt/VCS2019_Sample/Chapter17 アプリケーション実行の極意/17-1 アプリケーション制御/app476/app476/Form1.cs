using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app476
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ミューテックス
        /// </summary>
        private System.Threading.Mutex objMutex;
        private void Form1_Load(object sender, EventArgs e)
        {
            // 二重起動を防止する
            objMutex = new System.Threading.Mutex(false, "app463");
            if (objMutex.WaitOne(0, false) == false)
            {
                MessageBox.Show("すでにアプリケーションが起動しています");
                this.Close();
            }
        }
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // フォームを閉じるときにミューテックスを解放する
            objMutex.Close();
        }
    }
}
