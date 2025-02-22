using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace wpf418
{

    public class ViewModel : ObservableObject
    {
        private Person _Item; 
        public Person Item { get => _Item; set => SetProperty(ref _Item, value, nameof(Item)); }

        private string _Message = "";
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value, nameof(Message)); }
        }

        private ObservableCollection<Person> _Items = new ObservableCollection<Person>();
        public ObservableCollection<Person> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value, nameof(Items)); }
        }

        sampledbEntities _ent = new sampledbEntities();
        public ViewModel()
        {
            Items = new ObservableCollection<Person>(_ent.Person.ToList());
        }
        public void Save( Person pa )
        {
            _ent.Person.Add(pa);
            _ent.SaveChanges();
            this.Items.Add(pa);
        }
    }

    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        /// <param name="backingStore">Backing store.</param>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="onChanged">On changed.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
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

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 値クラスを内部に持つViewModelを作る場合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="backingStorePropertyName"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <param name="onChanged"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(
            object backingStore,
            string backingStorePropertyName,
            T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            var pi = backingStore.GetType().GetProperty(backingStorePropertyName);
            if (pi == null) return false;
            if (pi.PropertyType != value.GetType()) return false;
            pi.SetMethod.Invoke(backingStore, new object[] { value });
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        /// <summary>
        /// 値クラスを内部に持つViewModelを作る場合
        /// プロパティ名が内部のModelクラスのものと同一の場合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="backingStorePropertyName"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <param name="onChanged"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(
            object backingStore,
            T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            return SetProperty<T>(backingStore, propertyName, value, propertyName, onChanged);
        }
    }
}
