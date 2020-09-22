using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestClicker.Models
{
    class StoreItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;

            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

        public Items Type { get; set; }

        private bool _isBuy;

        public bool IsBuy
        {
            get
            {
                return _isBuy;
            }
            set
            {
                SetProperty(ref _isBuy, value);
            }
        }

        private decimal _price;

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                SetProperty(ref _price, value);
            }
        }

        public StoreItem(Items type)
        {
            Type = type;
        }
    }
}