using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace db309
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
        sampledbEntities ent = new sampledbEntities();
        ObservableCollection<Person> items;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            items = new ObservableCollection<Person>(ent.Person.ToList());
            dg.ItemsSource = items;
        }
    }
}
