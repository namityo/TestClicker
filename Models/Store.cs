using System;
using System.Collections.Generic;
using System.Linq;

namespace TestClicker.Models
{
    class Store
    {
        private GameParameter _gameParameter;

        public Store(GameData gameData, GameParameter gameParameter)
        {
            gameData.PropertyChanged += (obj, arg) =>
            {
                var data = obj as GameData;
                if (data != null)
                {
                    UpdatePrice(data, _gameParameter);
                    UpdateIsBuy(data, _gameParameter);
                }
            };

            _gameParameter = gameParameter;
        }

        public StoreItem Item1 { get; set; } = new StoreItem(Items.Item1);

        public StoreItem Item2 { get; set; } = new StoreItem(Items.Item2);

        public StoreItem Item3 { get; set; } = new StoreItem(Items.Item3);

        public StoreItem Item4 { get; set; } = new StoreItem(Items.Item4);

        public StoreItem Item5 { get; set; } = new StoreItem(Items.Item5);

        public IEnumerable<StoreItem> StoreItems
        {
            get
            {
                yield return Item1;
                yield return Item2;
                yield return Item3;
                yield return Item4;
                yield return Item5;
            }
        }

        public void UpdatePrice(GameData data, GameParameter parameter)
        {
            // TODO アイテムの価格を決定する
            var query = StoreItems
                        .Join(parameter.GetParameters(), i => i.Type, p => p.Type, (i, p) => new { Store = i, Param = p })
                        .Select(v => new { Store = v.Store, Param = v.Param, Count = data.GetItemCount(v.Store.Type) })
                        .Select(v => new { Store = v.Store, Price = v.Param.SellPriceBase * (v.Count + 1) });

            foreach (var q in query)
            {
                q.Store.Price = q.Price;
            }
        }

        public void UpdateIsBuy(GameData data, GameParameter parameter)
        {
            // TODO アイテムが購入できるか決定する
            var query = StoreItems
                        .Select(i => new { Item = i, IsBuy = (data.TotalCookies >= i.Price) });

            foreach (var q in query)
            {
                q.Item.IsBuy = q.IsBuy;
            }
        }
    }
}
