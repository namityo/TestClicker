using System;

namespace TestClicker.Models
{
    class ItemParameter
    {
        public Items Type { get; set; }

        public decimal SellPriceBase { get; set; }

        public decimal CountOfClick { get; set; }

        public decimal CountOfAutomatic { get; set; }
    }
}