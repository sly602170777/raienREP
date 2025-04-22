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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf406
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
            var rnd = new Random();
            for ( int i=0; i<100; i++ )
            {
                var rc = new Rectangle()
                {
                    Stroke = new SolidColorBrush(Colors.Blue),
                    StrokeThickness = 2,
                    Width = 50,
                    Height = 50,
                };
                int x = rnd.Next(0, 300);
                int y = rnd.Next(0, 300);

                Canvas.SetLeft(rc, x);
                Canvas.SetTop(rc, y);
                canv.Children.Add(rc);
            }
        }
    }
}
