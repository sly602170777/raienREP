using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui052
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form2 newForm = new Form2(); //追加行　フォームのインスタンス作成
            newForm.ShowDialog();        //追加行　フォームを開く

            Application.Run(new Form1());
        }
    }
}
