using microcosm.Common;
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
            User1Set(CommonInstance.getInstance().udata1);
            User2Set(CommonInstance.getInstance().udata2);
            Event1Set(CommonInstance.getInstance().edata1);
            Event2Set(CommonInstance.getInstance().edata2);
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
                UserFromJson userFromJson = new UserFromJson();
                UserJson json = await userFromJson.GetUserDataFromJson("a.json");

//                StorageFile file = await AwaitGetStorageFile(item.FullPath);

//                UserData udata = await UserXml.GetUserDataFromXml(file);

                SetEventTable(new UserData(json));
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

        private void File_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            DatabaseUserFrame.Navigate(typeof(DatabaseNewUser), (object)this);
        }

        private void Folder_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            DatabaseUserFrame.Navigate(typeof(DatabaseNewDirectory), (object)this);
        }

        public void NewFolder(string name)
        {
            dataDir.CreateSubdirectory(name);
        }

        public void NewFile(string name, UserData udata)
        {
            //SaveJson("a", name, udata);
            var file = new FileInfo(Path.Combine(dataDir.FullName, "file.txt"));
            if (!file.Exists) // you may not want to overwrite existing files
            {
                using (Stream stream = file.OpenWrite())
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("some text");
                }
            }
        }

        public void NewUser(string fileName, UserData udata)
        {
            DatabaseNavigateParam param = new DatabaseNavigateParam()
            {
                mainPage = this,
                udata = udata
            };
            //NewFile(, fileName, udata);
            DatabaseUserFrame.Navigate(typeof(DatabaseUserData), (object)param);
        }

        private void SetEventTable(UserData udata)
        {
            DatabaseNavigateParam param = new DatabaseNavigateParam()
            {
                mainPage = this,
                udata = udata
            };
            DatabaseUserFrame.Navigate(typeof(DatabaseUserData), (object)param);
            //TableVm = new UserDbViewModel(udata);
            //UserDataTable.DataContext = TableVm;
            //UserDataTable.ItemsSource = TableVm.userData;
        }

        public void User1Set(UserData udata)
        {
            User1Name.Text = udata.name;
            User1Birthday.Text = udata.birthdayFullStr;
            User1Place.Text = udata.birth_place;

            CommonInstance.getInstance().udata1 = udata;
        }

        public void User2Set(UserData udata)
        {
            User2Name.Text = udata.name;
            User2Birthday.Text = udata.birthdayFullStr;
            User2Place.Text = udata.birth_place;

            CommonInstance.getInstance().udata2 = udata;
        }

        public void Event1Set(UserData udata)
        {
            Event1Name.Text = udata.name;
            Event1Birthday.Text = udata.birthdayFullStr;
            Event1Place.Text = udata.birth_place;

            CommonInstance.getInstance().edata1 = udata;
        }

        public void Event2Set(UserData udata)
        {
            Event2Name.Text = udata.name;
            Event2Birthday.Text = udata.birthdayFullStr;
            Event2Place.Text = udata.birth_place;

            CommonInstance.getInstance().edata2 = udata;
        }

    }
}
