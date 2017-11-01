using microcosm.Models;
using microcosm.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace microcosm.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class DatabasePage : Page
    {
        public UserDbViewModel vm;
        public UserDbDirListViewModel dirVM;
        public DirectoryInfo dataDir;

        public DatabasePage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible; ;
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true;
                }
            };

            SetVM();
        }

        private async void SetVM()
        {
            await getDataDir();
            UserDirTree treeDir = new UserDirTree();
            dirVM = new UserDbDirListViewModel();
            List<TreeViewItem2> tree = new List<TreeViewItem2>();
            tree.Add(new TreeViewItem2() { name = "data", isDir = true, Header = "data", icon = "D" });

            foreach (var directory in dataDir.GetDirectories())
            {
                tree.Add(new TreeViewItem2() { name = directory.Name, isDir = true, Header = directory.Name, icon = "D" });
            }

            foreach (var file in dataDir.GetFiles())
            {
                // ファイル
                string trimName = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                tree.Add(new TreeViewItem2() { name = file.Name, isDir = false, Header = file.Name, icon = "F" });
            }

            dirVM.DirTree2 = tree;
            UserDirTree.DataContext = dirVM;
            UserDirTree.ItemsSource = dirVM.DirTree2;

            vm = new UserDbViewModel();
            vm.userData = new List<UserEventData>();
            UserEventData udata = new UserEventData();
            udata.name = "サンプル";
            vm.userData.Add(udata);
            UserDataTable.DataContext = vm;
            UserDataTable.ItemsSource = vm.userData;
        }

        private async Task<bool> getDataDir()
        {
            var root = Windows.Storage.ApplicationData.Current.LocalFolder;
            var dataStorage = await root.TryGetItemAsync("data");
            dataDir = new DirectoryInfo(dataStorage.Path);

            return true;
        }

        private void UserDirTree_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeViewItem2 item = (TreeViewItem2)e.ClickedItem;
            if (item != null && item.isDir)
            {
                Debug.WriteLine(item.name);
            }
        }
    }
}
