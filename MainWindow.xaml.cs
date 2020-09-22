using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TestClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();

        private Models.GameData _gameData = new Models.GameData();

        private Models.GameParameter _gameParameter = new Models.GameParameter();

        private Models.Cookies _cookies = null;

        private Models.Store _store = null;

        public MainWindow()
        {
            InitializeComponent();

            // リソースからイメージを取得してボタンに張り付け
            btnImage.Source = LoadResourceImage("TestClicker.resources.cookie.png");

            // データ用インスタンス生成
            _cookies = new Models.Cookies(_gameData, _gameParameter);
            _store = new Models.Store(_gameData, _gameParameter);

            // Bindingの設定
            this.DataContext = _gameData;
            this.pnlStore.DataContext = _store;

            // タイマーの設定
            _timer.Interval = new TimeSpan(_gameParameter.AutomaticTimerMillsecond * 10000);
            _timer.Tick += (sender, arg) =>
            {
                _gameData.TotalCookies += _cookies.CountOfAutomatic;
            };
            _timer.Start();
        }

        protected void Window_Closed(object sender, EventArgs e)
        {
            _timer.Stop();
        }

        public void OnClickCookies(object sender, RoutedEventArgs e) => _gameData.TotalCookies += _cookies.CountOfClick;

        public void OnClickItem(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
            if (button == null) return;

            // 押されたボタンからStoreのアイテムを特定
            Models.StoreItem storeItem = null;
            switch (button.Name)
            {
                case "btnItem1":
                    storeItem = _store.Item1;
                    break;
                case "btnItem2":
                    storeItem = _store.Item2;
                    break;
                case "btnItem3":
                    storeItem = _store.Item3;
                    break;
                case "btnItem4":
                    storeItem = _store.Item4;
                    break;
                case "btnItem5":
                    storeItem = _store.Item5;
                    break;
                default:
                    break;
            }

            // Storeのアイテム購入処理
            if (storeItem != null)
            {
                _gameData.TotalCookies -= storeItem.Price;
                _gameData.AddItemCount(storeItem.Type);
            }
        }

        private BitmapImage LoadResourceImage(string name)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream(name))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();

                return bitmap;
            }
        }
    }
}
