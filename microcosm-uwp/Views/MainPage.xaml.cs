using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;

using Windows.Storage;
using Windows.Storage.Streams;
using System.Threading.Tasks;

using microcosm.Calc;
using microcosm.User;
using microcosm.Config;
using Windows.UI.Core;
using microcosm.ViewModels;
using microcosm.Models;
using microcosm.Common;
using System.Collections.ObjectModel;
using Windows.UI.ViewManagement;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace microcosm.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<MenuItems> MenuList = new ObservableCollection<MenuItems>();

        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

//            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(1200, 760));
            ApplicationView.GetForCurrentView().TryResizeView(new Size(1120, 660));

            MainInit();
        }

        /// <summary>
        /// swissEph関連ファイルの作成
        /// </summary>
        /// <returns>true</returns>
        private async Task<bool> CreateSwiss()
        {
            var root = Windows.Storage.ApplicationData.Current.LocalFolder;
            var ephe = await root.TryGetItemAsync("ephe");

            if (ephe == null)
            {
                ephe = await root.CreateFolderAsync("ephe");
            }

            StorageFolder epheFolder = await root.GetFolderAsync("ephe");

            if (await epheFolder.TryGetItemAsync("semo_18.se1") == null)
            {
                var semo = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/semo_18.se1")).AsTask().ConfigureAwait(false);
                await semo.CopyAsync(epheFolder, "semo_18.se1", NameCollisionOption.FailIfExists);
            }

            if (await epheFolder.TryGetItemAsync("seas_18.se1") == null)
            {
                var seas = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/seas_18.se1")).AsTask().ConfigureAwait(false);
                await seas.CopyAsync(epheFolder, "seas_18.se1", NameCollisionOption.FailIfExists);
            }

            if (await epheFolder.TryGetItemAsync("sepl_18.se1") == null)
            {
                var sepl = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/sepl_18.se1")).AsTask().ConfigureAwait(false);
                await sepl.CopyAsync(epheFolder, "sepl_18.se1", NameCollisionOption.FailIfExists);
            }

            if (await epheFolder.TryGetItemAsync("se90377s.se1") == null)
            {
                var se90377s = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/se90377s.se1")).AsTask().ConfigureAwait(false);
                await se90377s.CopyAsync(epheFolder, "se90377s.se1", NameCollisionOption.FailIfExists);
            }

            if (await epheFolder.TryGetItemAsync("s136108s.se1") == null)
            {
                var s136108s = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/s136108s.se1")).AsTask().ConfigureAwait(false);
                await s136108s.CopyAsync(epheFolder, "s136108s.se1", NameCollisionOption.FailIfExists);
            }

            if (await epheFolder.TryGetItemAsync("s136199s.se1") == null)
            {
                var s136199s = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/s136199s.se1")).AsTask().ConfigureAwait(false);
                await s136199s.CopyAsync(epheFolder, "s136199s.se1", NameCollisionOption.FailIfExists);
            }

            if (await epheFolder.TryGetItemAsync("s136472s.se1") == null)
            {
                var s136472s = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/s136472s.se1")).AsTask().ConfigureAwait(false);
                await s136472s.CopyAsync(epheFolder, "s136472s.se1", NameCollisionOption.FailIfExists);
            }

            if (await epheFolder.TryGetItemAsync("seleapsec.txt") == null)
            {
                var seleapsec = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/seleapsec.txt")).AsTask().ConfigureAwait(false);
                await seleapsec.CopyAsync(epheFolder, "seleapsec.txt", NameCollisionOption.FailIfExists);
            }

            CommonInstance.getInstance().calc = new AstroCalc(this);
            return true;
        }

        private async Task<bool> CreateConfig()
        {
            var root = Windows.Storage.ApplicationData.Current.LocalFolder;
            var system = await root.TryGetItemAsync("system");

            if (system == null)
            {
                system = await root.CreateFolderAsync("system");
            }

            StorageFolder systemFolder = await root.GetFolderAsync("system");

            if (await systemFolder.TryGetItemAsync("config.json") == null)
            {
                var configFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/config.json")).AsTask().ConfigureAwait(false);
                await configFile.CopyAsync(systemFolder, "config.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting0.json") == null)
            {
                var setting0File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting0.json")).AsTask().ConfigureAwait(false);
                await setting0File.CopyAsync(systemFolder, "setting0.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting1.json") == null)
            {
                var setting1File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting1.json")).AsTask().ConfigureAwait(false);
                await setting1File.CopyAsync(systemFolder, "setting1.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting2.json") == null)
            {
                var setting2File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting2.json")).AsTask().ConfigureAwait(false);
                await setting2File.CopyAsync(systemFolder, "setting2.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting3.json") == null)
            {
                var setting3File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting3.json")).AsTask().ConfigureAwait(false);
                await setting3File.CopyAsync(systemFolder, "setting3.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting4.json") == null)
            {
                var setting4File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting4.json")).AsTask().ConfigureAwait(false);
                await setting4File.CopyAsync(systemFolder, "setting4.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting5.json") == null)
            {
                var setting5File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting5.json")).AsTask().ConfigureAwait(false);
                await setting5File.CopyAsync(systemFolder, "setting5.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting6.json") == null)
            {
                var setting6File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting6.json")).AsTask().ConfigureAwait(false);
                await setting6File.CopyAsync(systemFolder, "setting6.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting7.json") == null)
            {
                var setting7File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting7.json")).AsTask().ConfigureAwait(false);
                await setting7File.CopyAsync(systemFolder, "setting7.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting8.json") == null)
            {
                var setting8File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting8.json")).AsTask().ConfigureAwait(false);
                await setting8File.CopyAsync(systemFolder, "setting8.json", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting9.json") == null)
            {
                var setting9File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting9.json")).AsTask().ConfigureAwait(false);
                await setting9File.CopyAsync(systemFolder, "setting9.json", NameCollisionOption.FailIfExists);
            }

            /*
            if (await systemFolder.TryGetItemAsync("canvas.html") == null)
            {
                var canvasFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/canvas.html")).AsTask().ConfigureAwait(false);
                await canvasFile.CopyAsync(systemFolder, "canvas.html", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("datetime.html") == null)
            {
                var canvasFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/datetime.html")).AsTask().ConfigureAwait(false);
                await canvasFile.CopyAsync(systemFolder, "datetime.html", NameCollisionOption.FailIfExists);
            }
            */

            // data作成
            var dataDir = await root.TryGetItemAsync("data");

            if (dataDir == null)
            {
                await root.CreateFolderAsync("data");
            }

            // config読み込み
            ConfigFromJson configGetter = new ConfigFromJson();
            await configGetter.GetConfigDataFromJson("config.json");


            //config = ConfigFromXml.GetConfigFromXml(cfg.Path);

            //            UserData udata = UserXml.GetUserDataFromXml(cfg.Path);

            // setting読み込み
            SettingFromJson settingGetter = new SettingFromJson();

            for (int i = 0; i < 10; i++)
            {
                await settingGetter.GetSettingDataFromJson(String.Format("setting{0}.json", i), i);
            }

            return true;
        }

        /// <summary>
        /// main部初期化
        /// </summary>
        private async void MainInit()
        {
            List<Task<bool>> arrayTask = new List<Task<bool>>();
            Task<bool> swissTask = Task<bool>.Run(CreateSwiss);
            arrayTask.Add(swissTask);
            Task<bool> configTask = Task<bool>.Run(CreateConfig);
            arrayTask.Add(configTask);

            await Task.WhenAll(arrayTask);

            MenuList.Add(new MenuItems { text = "Home", icon = FontAwesome.UWP.FontAwesomeIcon.Circle, PageType = typeof(MainContentPage) });
            MenuList.Add(new MenuItems { text = "データベース", icon = FontAwesome.UWP.FontAwesomeIcon.Database, PageType = typeof(DatabasePage) });
            MenuList.Add(new MenuItems { text = "設定", icon = FontAwesome.UWP.FontAwesomeIcon.Gear, PageType = typeof(SettingPage) });
            hamburgerMenuControl.DataContext = MenuList;


            ContentFrame.Navigate(typeof(MainContentPage));
        }

        /*
        private async void FilePick()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".txt");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            Debug.WriteLine(file.Path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilePick();
        }
        */

        private void AppBarSettingButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void hamburgerMenuControl_OptionsItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void hamburgerMenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItems;
            ContentFrame.Navigate(menuItem.PageType);
        }
    }

}
