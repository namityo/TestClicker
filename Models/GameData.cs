using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestClicker.Models
{
    class GameData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            CallChangedProperty(propertyName);
        }

        private void CallChangedProperty(string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }


        private decimal _totalCookies;

        public decimal TotalCookies
        {
            get
            {
                return _totalCookies;
            }
            set
            {
                SetProperty(ref _totalCookies, value);
            }
        }

        public int Item1Count { get; set; }
        public int Item2Count { get; set; }
        public int Item3Count { get; set; }
        public int Item4Count { get; set; }
        public int Item5Count { get; set; }


        public void AddItemCount(Items item, int addCount = 1)
        {
            switch (item)
            {
                case Items.Item1:
                    Item1Count += addCount;
                    CallChangedProperty("Item1Count");
                    break;

                case Items.Item2:
                    Item2Count += addCount;
                    CallChangedProperty("Item2Count");
                    break;

                case Items.Item3:
                    Item3Count += addCount;
                    CallChangedProperty("Item3Count");
                    break;

                case Items.Item4:
                    Item4Count += addCount;
                    CallChangedProperty("Item4Count");
                    break;

                case Items.Item5:
                    Item5Count += addCount;
                    CallChangedProperty("Item5Count");
                    break;

                default:
                    break;
            }
        }

        public int GetItemCount(Items item)
        {
            switch (item)
            {
                case Items.Item1: return Item1Count;
                case Items.Item2: return Item2Count;
                case Items.Item3: return Item3Count;
                case Items.Item4: return Item4Count;
                case Items.Item5: return Item5Count;
                default: return 0;
            }
        }
    }
}
