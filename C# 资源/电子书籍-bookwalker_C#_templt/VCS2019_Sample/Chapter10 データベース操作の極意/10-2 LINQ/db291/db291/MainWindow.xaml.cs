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

namespace db291
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ent = new sampledbEntities();
            dg.ItemsSource =
                ent.Book
                .ToList();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(text1.Text);
            var ent = new sampledbEntities();
            var item = ent.Book.ToList()[n];
            MessageBox.Show($"{item.Title} を選択しました");
        }
    }
}
