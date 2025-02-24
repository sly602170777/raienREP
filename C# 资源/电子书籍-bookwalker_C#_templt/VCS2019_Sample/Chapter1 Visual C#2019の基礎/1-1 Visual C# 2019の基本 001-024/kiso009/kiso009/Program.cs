using System;
using System.Windows.Forms;

namespace kiso009
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles ();
            //此方法设置应用程序的文本渲染方式。false 参数表示使用GDI+文本渲染引擎，它提供高质量的文本显示效果。
            //虽然GDI+的文本渲染质量较高，但在某些情况下可能会影响性能。
            Application.SetCompatibleTextRenderingDefault (false);
            //此方法启动应用程序的主消息循环，并显示指定的窗体。new Form1()
            //创建了一个名为 Form1 的窗体实例，这是应用程序的主窗口。
            //Application.Run() 方法会一直运行，直到应用程序关闭
            // Show (string text,
            // string caption,
            // MessageBoxButtons buttons,
            // MessageBoxIcon icon,
            // MessageBoxDefaultButton defaultButton,
            // MessageBoxOptions options,
            // bool displayHelpButton)

            // メッセージボックスを表示
            DialogResult result = MessageBox.Show (
                text: "ファイルを保存しますか？", // メッセージテキスト
                caption: "確認", // タイトル
                buttons: MessageBoxButtons.YesNoCancel, // ボタンの種類
                icon: MessageBoxIcon.Question, // アイコン
                defaultButton: MessageBoxDefaultButton.Button1, // デフォルトボタン
                options: MessageBoxOptions.ServiceNotification, // ServiceNotification を削除
                displayHelpButton: false
            );

            // ユーザーの選択結果を処理
            switch (result)
            {
                case DialogResult.Yes:
                    Console.WriteLine ("「はい」が選択されました。");
                    break;
                case DialogResult.No:
                    Console.WriteLine ("「いいえ」が選択されました。");
                    break;
                case DialogResult.Cancel:
                    Console.WriteLine ("「キャンセル」が選択されました。");
                    break;
            }
            Application.Run (new Form1 ());
        }
    }
}
