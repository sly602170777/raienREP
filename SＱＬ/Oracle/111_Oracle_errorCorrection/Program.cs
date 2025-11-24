using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace _111_Oracle_errorCorrection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //①：CMD --->> lsnrctl status   でリスナーの状態を確認してください。
            //②： tnsnames.ora   ファイルが正しい場所にあり、正しいエントリが含まれていることを確認してください。
            //③：Oracle クライアントが正しくインストールされ、環境変数が設定されていることを確認してください。
            //④：ファイアウォール設定が Oracle ポート（通常は 1521）をブロックしていないことを確認してください。
            //⑤：Oracle サービスが実行中であることを確認してください。
            //⑥：接続文字列が正しいことを確認してください。
            //⑦：tnsping コマンドを使用して、TNS エイリアスに接続できるか確認してください。
            //⑧：Oracle クライアントのバージョンがデータベースサーバーと互換性があることを確認してください。
            //⑨：必要に応じて、Oracle クライアントを再インストールまたは更新してください。
            //⑩：Oracle のドキュメントやサポートリソースを参照して、特定のエラーコードに関する追加情報を取得してください。

            string connString = "User Id=seki;Password=123456;Data Source=ORCL";

            try
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();
                    Console.WriteLine("连接成功！");
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Oracle エラー: {ex.Message}");

                // OracleException には 'Number' プロパティが存在しないため、エラーコードを取得する方法を変更します。
                // OracleException の場合、Message プロパティにエラーコードが含まれていることが多いので、正規表現で抽出します。
                int errorCode = ExtractOracleErrorCode(ex.Message);

                switch (errorCode)
                {
                    case 12154: // ORA-12154: TNS:could not resolve the connect identifier specified
                        Console.WriteLine("解決手順：");
                        Console.WriteLine(
                            "1. 接続文字列または tnsnames.ora のサービス名が正しいか確認してください。"
                        );
                        Console.WriteLine(
                            "2. TNS_ADMIN 環境変数が正しいディレクトリを指しているか確認してください。"
                        );
                        Console.WriteLine(
                            "3. sqlplus を使用して同じサービス名で接続できるか確認してください。"
                        );
                        Console.WriteLine(
                            "4. それでも失敗する場合、完全な host:port/service_name 接続文字列を試してください。"
                        );
                        break;

                    case 12514: // ORA-12514: TNS:listener does not currently know of service requested
                        Console.WriteLine("解決手順：");
                        Console.WriteLine(
                            "1. データベースサーバーで lsnrctl status を実行し、リスナーがターゲットサービス名を登録しているか確認してください。"
                        );
                        Console.WriteLine(
                            "2. listener.ora の設定を確認し、サービス名がデータベースインスタンスと一致していることを確認してください。"
                        );
                        Console.WriteLine(
                            "3. データベースインスタンスが起動しており、サービス名がリスナーに正しく登録されていることを確認してください。"
                        );
                        Console.WriteLine(
                            "4. 動的サービス名の場合、リスナーを再起動してみてください：lsnrctl stop / lsnrctl start。"
                        );
                        break;

                    case 12541: // ORA-12541: TNS:no listener
                        Console.WriteLine("解決手順：");
                        Console.WriteLine(
                            "1. データベースサーバーでリスナープロセスが実行中であることを確認してください：lsnrctl status。"
                        );
                        Console.WriteLine(
                            "2. listener.ora のポート番号が 1521 または正しく設定されていることを確認してください。"
                        );
                        Console.WriteLine(
                            "3. クライアントで telnet <hostname> 1521 を使用してポートの接続性をテストしてください。"
                        );
                        Console.WriteLine(
                            "4. リスナーが起動していない場合は、lsnrctl start を実行してリスナーを起動してください。"
                        );
                        break;

                    default:
                        Console.WriteLine("解決手順：");
                        Console.WriteLine(
                            "1. エラー番号に対応する ORA ドキュメントを参照してください。"
                        );
                        Console.WriteLine(
                            "2. ネットワーク接続性を確認してください（ping、telnet）。"
                        );
                        Console.WriteLine(
                            "3. tnsnames.ora、listener.ora、sqlnet.ora の設定を確認してください。"
                        );
                        Console.WriteLine(
                            "4. データベースの alert.log と listener.log を確認して、詳細情報を取得してください。"
                        );
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"一般エラー: {ex.Message}");
            }
        }

        // Oracle エラーコードをメッセージから抽出するヘルパーメソッド
        private static int ExtractOracleErrorCode(string message)
        {
            var match = System.Text.RegularExpressions.Regex.Match(message, @"ORA-(\d+)");
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }
    }
}
