using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj031
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

            //フォームを開く前に処理を実行する
            MessageBox.Show("フォームを表示します","メッセージ");

            //フォームを表示する
            Application.Run(new Form1());
        }
    }
}
