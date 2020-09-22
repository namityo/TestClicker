using System;
using System.Collections.Generic;

namespace TestClicker.Models
{
    public enum Items
    {
        Item1,
        Item2,
        Item3,
        Item4,
        Item5,
    }

    public static class ItemsExtension
    {
        public static IEnumerable<Items> GetEnumerable()
        {
            yield return Items.Item1;
            yield return Items.Item2;
            yield return Items.Item3;
            yield return Items.Item4;
            yield return Items.Item5;
        }
    }
}
