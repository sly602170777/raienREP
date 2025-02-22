using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace db302
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ent = new sampledbEntities();
            var q = from b in ent.Book
                    select b;
            dg.ItemsSource = q.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ent = new sampledbEntities();
            /// 最後にマッチした要素を表示
            var it = ent.Book.ToList().LastOrDefault(t => t.Title.Contains("入門"));
            if ( it == null )
            {
                MessageBox.Show("要素は見つかりませんでした");
            }
            else
            {
                MessageBox.Show($"最後のタイトル: {it.Title}");
            }
        }
    }
}
