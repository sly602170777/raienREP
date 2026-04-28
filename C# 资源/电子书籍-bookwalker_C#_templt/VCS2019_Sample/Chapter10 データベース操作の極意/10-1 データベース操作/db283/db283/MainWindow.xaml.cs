using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace db283
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

        MainViewModel _vm;

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new MainViewModel();
            this.DataContext = _vm;
        }
        sampledbEntities _ent = new sampledbEntities();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.Items = new ObservableCollection<Person>(_ent.Person.ToList());
        }


        /// <summary>
        /// 項目を追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickAdd(object sender, RoutedEventArgs e)
        {
            var pa = new Person()
            {
                Name = _vm.Name,
                Age = _vm.Age,
                Address =  _vm.Address,
            };
            _ent.Person.Add(pa);
            _ent.SaveChanges();
        }
        /// <summary>
        /// 項目を更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickUpdate(object sender, RoutedEventArgs e)
        {
            _vm.Item.Name = _vm.Name;
            _vm.Item.Age = _vm.Age;
            _vm.Item.Address = _vm.Address;
            _ent.SaveChanges();
        }

        private void clickDelete(object sender, RoutedEventArgs e)
        {
            if (_vm.Item == null)
                return;
            var it = _ent.Person.FirstOrDefault(t => t.ID == _vm.Item.ID);
            _ent.Person.Remove(it);
            _ent.SaveChanges();
            // 再検索
        }
    }

    public class MainViewModel : ObservableObject
    {
        private Person _Item;
        private ObservableCollection<Person> _Items;
        
        public Person Item {
            get => _Item;
            set
            {
                if ( _Item != value )
                {
                    _Item = value;
                    OnPropertyChanged(nameof(Item));
                    if ( _Item != null )
                    {
                        this.Name = _Item.Name;
                        this.Age = _Item.Age;
                        this.Address = _Item.Address;
                    }
                }
            }
        }
        public ObservableCollection<Person> Items {
            get => _Items;
            set
            {
                this.Item = null;
                SetProperty(ref _Items, value, nameof(Items));
            }
        }

        public string _Name;
        public int _Age;
        public string _Address;
        public string Name { get => _Name; set => SetProperty(ref _Name, value, nameof(Name)); }
        public int Age { get => _Age; set => SetProperty(ref _Age, value, nameof(Age)); }
        public string Address { get => _Address; set => SetProperty(ref _Address, value, nameof(Address)); }

    }

    public class ObservableObject : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
