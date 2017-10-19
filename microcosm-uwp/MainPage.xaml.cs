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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace microcosm
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AstroCalc calc;
        ConfigData config;
        SettingData[] setting = new SettingData[10];

        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            MainInit();
        }

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

            calc = new AstroCalc(this);
//            calc.PositionCalc(9.0);

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

            if (await systemFolder.TryGetItemAsync("config.csm") == null)
            {
                var configFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/config.csm")).AsTask().ConfigureAwait(false);
                await configFile.CopyAsync(systemFolder, "config.csm", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting0.csm") == null)
            {
                var setting0File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting0.csm")).AsTask().ConfigureAwait(false);
                await setting0File.CopyAsync(systemFolder, "setting0.csm", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting1.csm") == null)
            {
                var setting1File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting1.csm")).AsTask().ConfigureAwait(false);
                await setting1File.CopyAsync(systemFolder, "setting1.csm", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting2.csm") == null)
            {
                var setting2File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting2.csm")).AsTask().ConfigureAwait(false);
                await setting2File.CopyAsync(systemFolder, "setting2.csm", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting3.csm") == null)
            {
                var setting3File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting3.csm")).AsTask().ConfigureAwait(false);
                await setting3File.CopyAsync(systemFolder, "setting3.csm", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting4.csm") == null)
            {
                var setting4File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting4.csm")).AsTask().ConfigureAwait(false);
                await setting4File.CopyAsync(systemFolder, "setting4.csm", NameCollisionOption.FailIfExists);
            }

            if (await systemFolder.TryGetItemAsync("setting5.csm") == null)
            {
                var setting5File = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/setting5.csm")).AsTask().ConfigureAwait(false);
                await setting5File.CopyAsync(systemFolder, "setting5.csm", NameCollisionOption.FailIfExists);
            }

            var cfg = await systemFolder.GetFileAsync("config.csm");

            config = ConfigFromXml.GetConfigFromXml(cfg.Path);

            //            UserData udata = UserXml.GetUserDataFromXml(cfg.Path);

            for (int i = 0; i < 3; i++)
            {
                var set = await systemFolder.GetFileAsync("setting" + i.ToString() + ".csm");
                setting[i] = SettingFromXml.GetSettingFromXml(set.Path, i);
            }


            return true;
        }

        private async void MainInit()
        {
            List<Task<bool>> arrayTask = new List<Task<bool>>();
            Task<bool> swissTask = Task<bool>.Run(CreateSwiss);
            arrayTask.Add(swissTask);
            Task<bool> configTask = Task<bool>.Run(CreateConfig);
            arrayTask.Add(configTask);

            

//            await Task.WhenAll(arrayTask);
        }

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

        private void Copyright_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CopyrightPage));
        }
    }
}
