using microcosm.Models;
using microcosm.User;
using microcosm.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        public DirectoryInfo dataDir;

        public ObservableCollection<TreeViewItem2> DirTree3;

        public DatabasePage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed; ;
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
            DirTree3 = new ObservableCollection<TreeViewItem2>();
//            DirTree3.Add(new TreeViewItem2() { Name = "data", IsDir = true, Header = "data", Icon = "D", FullPath = dataDir.FullName });
            PathCrumbParent.Text = "data";

            foreach (var directory in dataDir.GetDirectories())
            {
                DirTree3.Add(new TreeViewItem2()
                {
                    Name = directory.Name,
                    IsDir = true,
                    Header = directory.Name,
                    Icon = "D",
                    FullPath = directory.FullName,
                    NoFile = false
                });
            }

            foreach (var file in dataDir.GetFiles())
            {
                // ファイル
                string trimName = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                DirTree3.Add(new TreeViewItem2()
                {
                    Name = file.Name,
                    IsDir = false,
                    Header = file.Name,
                    Icon = "F",
                    FullPath = file.FullName,
                    NoFile = false
                });
            }

            if (DirTree3.Count == 0)
            {
                DirTree3.Add(new TreeViewItem2()
                {
                    Name = "ファイルがありません",
                    IsDir = false,
                    Header = "ファイルがありません",
                    Icon = "F",
                    FullPath = dataDir.FullName,
                    NoFile = true
                });
            }

            //            dirVM.DirTree2 = tree;
            UserDirTree.DataContext = DirTree3;
//            UserDirTree.ItemsSource = dirVM.DirTree2;

            vm = new UserDbViewModel();
            vm.userData = new ObservableCollection<UserEventData>();
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

        /// <summary>
        /// TreeView Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserDirTree_ItemClick(object sender, ItemClickEventArgs e)
        {
            DirTree3.Clear();
            DirTree3.Add(new TreeViewItem2()
            {
                Name = "..",
                IsDir = false,
                Header = "..",
                Icon = "F",
                FullPath = ""
            });

            TreeViewItem2 item = (TreeViewItem2)e.ClickedItem;
            if (item != null && item.IsDir)
            {
                DirTree3.Clear();
//                List<TreeViewItem2> tree = new List<TreeViewItem2>();

                DirectoryInfo dir = new DirectoryInfo(item.FullPath);
                foreach (var directory in dir.GetDirectories())
                {
                    DirTree3.Add(new TreeViewItem2()
                    {
                        Name = directory.Name,
                        IsDir = true,
                        Header = directory.Name,
                        Icon = "D",
                        FullPath = directory.FullName
                    });
                }

                foreach (var file in dir.GetFiles())
                {
                    // ファイル
                    string trimName = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                    DirTree3.Add(new TreeViewItem2()
                    {
                        Name = file.Name,
                        IsDir = false,
                        Header = file.Name,
                        Icon = "F",
                        FullPath = file.FullName
                    });
                }

                if (DirTree3.Count == 0)
                {
                    DirTree3.Add(new TreeViewItem2()
                    {
                        Name = "ファイルがありません",
                        IsDir = false,
                        Header = "ファイルがありません",
                        Icon = "F",
                        FullPath = dir.Parent.FullName,
                        NoFile = true
                    });
                }

//                dirVM.DirTree2 = tree;
            }
            else if (item != null && !item.IsDir)
            {
//                UserData udata = UserXml.GetUserDataFromXml(item.FullPath);
            }
        }

        private async void FilePick()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".csm");
            picker.FileTypeFilter.Add(".mcsm");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                Debug.WriteLine(file.Path);



                UserData udata = await UserXml.GetUserDataFromXml(file);
                vm.userData.Clear();
                vm.userData.Add(udata.ToUserEventData());
                UserDataTable.ItemsSource = vm.userData;
                UserDataTable.DataContext = vm;
            }
        }

        private void FilePickButton_Click(object sender, RoutedEventArgs e)
        {
            FilePick();
        }
    }
}
