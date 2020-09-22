using System;
using System.Linq;

namespace TestClicker.Models
{
    class Cookies
    {
        private GameParameter _gameParameter;

        public Cookies(GameData gameData, GameParameter gameParameter)
        {
            _gameParameter = gameParameter;
            
            gameData.PropertyChanged += (obj, arg) =>
            {
                var data = obj as GameData;
                if (data != null)
                {
                    UpdateCountOfClick(data, _gameParameter);
                    UpdateCountOfAutomatic(data, _gameParameter);
                }
            };
        }

        public decimal CountOfClick { get; private set; }

        public decimal CountOfAutomatic { get; private set; }

        public void UpdateCountOfClick(GameData data, GameParameter parameter) =>
            // TODO クリックして得られるクッキーの数を更新する
            CountOfClick = ItemsExtension.GetEnumerable()
                           .Select(i => new { Type = i, Count = data.GetItemCount(i) })
                           .Join(parameter.GetParameters(), v => v.Type, p => p.Type, (v, p) => v.Count * p.CountOfClick)
                           .Append(1M)
                           .Sum();

        public void UpdateCountOfAutomatic(GameData data, GameParameter parameter) =>
            // 自動で取得できるクッキーの数を更新する
            CountOfAutomatic = ItemsExtension.GetEnumerable()
                               .Select(i => new { Type = i, Count = data.GetItemCount(i) })
                               .Join(parameter.GetParameters(), v => v.Type, p => p.Type, (v, p) => v.Count * p.CountOfAutomatic)
                               .Sum();
    }
}
