using System;
using System.Collections.Generic;

namespace TestClicker.Models
{
    class GameParameter
    {
        private Dictionary<Items, ItemParameter> _parameters = new Dictionary<Items, ItemParameter>();

        public GameParameter()
        {
            SetParameter(new ItemParameter()
            {
                Type = Items.Item1,
                SellPriceBase = 10,
                CountOfClick = 0.1M,
                CountOfAutomatic = 0.01M,
            });
            SetParameter(new ItemParameter()
            {
                Type = Items.Item2,
                SellPriceBase = 100,
                CountOfClick = 0.5M,
                CountOfAutomatic = 0.05M,
            });
            SetParameter(new ItemParameter()
            {
                Type = Items.Item3,
                SellPriceBase = 1000,
                CountOfClick = 1M,
                CountOfAutomatic = 0.01M,
            });
            SetParameter(new ItemParameter()
            {
                Type = Items.Item4,
                SellPriceBase = 10000,
                CountOfClick = 2M,
                CountOfAutomatic = 0.02M,
            });
            SetParameter(new ItemParameter()
            {
                Type = Items.Item5,
                SellPriceBase = 100000,
                CountOfClick = 5M,
                CountOfAutomatic = 0.5M,
            });
        }

        public IEnumerable<ItemParameter> GetParameters()
        {
            return _parameters.Values;
        }

        private void SetParameter(ItemParameter parameter)
        {
            _parameters[parameter.Type] = parameter;
        }

        public long AutomaticTimerMillsecond { get; set; } = 33;
    }
}
