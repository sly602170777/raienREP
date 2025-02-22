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

namespace db303
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
            dg.ItemsSource = ent.Book.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // カーソル行を得る
            var item = dg.SelectedItem as Book;
            if (item == null)
                return;
            // カーソル行の要素を再度検索する
            var ent = new sampledbEntities();
            var it = ent.Book.FirstOrDefault(t => t.ID == item.ID);
            if (it == null)
                return;
            // 要素を削除する
            ent.Book.Remove(it);
            ent.SaveChanges();
            // 再び検索して表示
            dg.ItemsSource = ent.Book.ToList();
        }
    }
}
