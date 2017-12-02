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
        public UserDirGridViewModel vm;
        public UserDbViewModel TableVm;
        private DirectoryInfo dataDir;
        private string dataStoragePath;

        public ObservableCollection<TreeViewItem2> DirTree;

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

            InitVM();
        }

        private async void InitVM()
        {
            await getDataDir();
            DirTree = new ObservableCollection<TreeViewItem2>();
            PathCrumbParent.Text = "data";
            SetVM();
        }

        /// <summary>
        /// dataDirをもとにディレクトリを読み込み
        /// </summary>
        private void SetVM()
        {
//            UserDirTree treeDir = new UserDirTree();
//            DirTree3.Add(new TreeViewItem2() { Name = "data", IsDir = true, Header = "data", Icon = "D", FullPath = dataDir.FullName });

            foreach (var directory in dataDir.GetDirectories())
            {
                DirTree.Add(new TreeViewItem2()
                {
                    Name = directory.Name,
                    IsDir = true,
                    Header = directory.Name,
                    Icon = FontAwesome.UWP.FontAwesomeIcon.Folder,
                    FullPath = directory.FullName,
                    NoFile = false
                });
            }

            foreach (var file in dataDir.GetFiles())
            {
                // ファイル
                string trimName = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                DirTree.Add(new TreeViewItem2()
                {
                    Name = file.Name,
                    IsDir = false,
                    Header = file.Name,
                    Icon = FontAwesome.UWP.FontAwesomeIcon.File,
                    FullPath = file.FullName,
                    NoFile = false
                });
            }

            if (DirTree.Count == 0)
            {
                DirTree.Add(new TreeViewItem2()
                {
                    Name = "ファイルがありません",
                    IsDir = false,
                    Header = "ファイルがありません",
                    Icon = FontAwesome.UWP.FontAwesomeIcon.File,
                    FullPath = dataDir.FullName,
                    NoFile = true
                });
            }

            //            dirVM.DirTree2 = tree;
            //UserDirTree.DataContext = DirTree3;
            //            UserDirTree.ItemsSource = dirVM.DirTree2;

            vm = new UserDirGridViewModel();
            vm.DirTrees = DirTree;
            UserDirTree.ItemsSource = vm.DirTrees;
            UserDirTree.DataContext = vm;
            /*
            UserEventData udata = new UserEventData();
            udata.name = "サンプル";
            vm.userData.Add(udata);
            UserDataTable.DataContext = vm;
            UserDataTable.ItemsSource = vm.userData;
            */
        }

        private async Task<bool> getDataDir()
        {
            var root = ApplicationData.Current.LocalFolder;
            var dataStorage = await root.TryGetItemAsync("data");
            dataStoragePath = dataStorage.Path;
            dataDir = new DirectoryInfo(dataStorage.Path);

            return true;
        }

        /// <summary>
        /// TreeView Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UserDirTree_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeViewItem2 item = (TreeViewItem2)e.ClickedItem;

            if (item.IsDir)
            {
                ReSet(item);
            }
            else
            {
                if (!File.Exists(item.FullPath))
                {
                    return;
                }
                StorageFile file = await AwaitGetStorageFile(item.FullPath);

                UserData udata = await UserXml.GetUserDataFromXml(file);

                SetEventTable(udata);
            }
        }

        private async Task<StorageFile> AwaitGetStorageFile(string path)
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync(path);
            return file;
        }

        /// <summary>
        /// TreeViewItemを元にディレクトリを再読み込み
        /// </summary>
        /// <param name="item"></param>
        private void ReSet(TreeViewItem2 item)
        {
            vm.DirTrees.Clear();
            vm.DirTrees.Add(new TreeViewItem2()
            {
                Name = "..",
                IsDir = false,
                Header = "..",
                Icon = FontAwesome.UWP.FontAwesomeIcon.File,
                FullPath = ""
            });

            if (item != null && item.IsDir)
            {
                vm.DirTrees.Clear();
                //                List<TreeViewItem2> tree = new List<TreeViewItem2>();

                DirectoryInfo dir = new DirectoryInfo(item.FullPath);
                foreach (var directory in dir.GetDirectories())
                {
                    vm.DirTrees.Add(new TreeViewItem2()
                    {
                        Name = directory.Name,
                        IsDir = true,
                        Header = directory.Name,
                        Icon = FontAwesome.UWP.FontAwesomeIcon.Folder,
                        FullPath = directory.FullName
                    });
                }

                foreach (var file in dir.GetFiles())
                {
                    // ファイル
                    string trimName = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                    vm.DirTrees.Add(new TreeViewItem2()
                    {
                        Name = file.Name,
                        IsDir = false,
                        Header = file.Name,
                        Icon = FontAwesome.UWP.FontAwesomeIcon.File,
                        FullPath = file.FullName
                    });
                }

                if (DirTree.Count == 0)
                {
                    vm.DirTrees.Add(new TreeViewItem2()
                    {
                        Name = "ファイルがありません",
                        IsDir = false,
                        Header = "ファイルがありません",
                        Icon = FontAwesome.UWP.FontAwesomeIcon.File,
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

            PathCrumbParent.Text = item.Name;
            dataDir = new DirectoryInfo(item.FullPath);
        }

        private void UpIcon_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (dataDir.FullName != dataStoragePath)
            {
                dataDir = dataDir.Parent;
                DirTree.Clear();
                PathCrumbParent.Text = dataDir.Name;
                SetVM();
            }
        }

        private void SetEventTable(UserData udata)
        {
            TableVm = new UserDbViewModel(udata);
            UserDataTable.DataContext = TableVm;
            UserDataTable.ItemsSource = TableVm.userData;
        }
    }
}
