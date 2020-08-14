using microcosm.Models;
using microcosm.User;
using microcosm.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class DatabaseUserData : Page
    {
        DatabasePage mainPage;
        private UserData udata;
        private UserDbViewModel TableVm;


        public DatabaseUserData()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DatabaseNavigateParam param = (DatabaseNavigateParam)e.Parameter;
            mainPage = param.mainPage;
            udata = param.udata;
            TableVm = new UserDbViewModel(udata);
            UserDataTable.DataContext = TableVm;
            UserDataTable.ItemsSource = TableVm.userCollection;

        }

        private void U1Set_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            int index = (int)b.Tag;
            ObservableCollection<UserEventData> eventList = (ObservableCollection < UserEventData > )UserDataTable.ItemsSource;
            UserData udata = new UserData(eventList[index]);
            mainPage.User1Set(udata);
        }

        private void U2Set_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            int index = (int)b.Tag;
            ObservableCollection<UserEventData> eventList = (ObservableCollection<UserEventData>)UserDataTable.ItemsSource;
            UserData udata = new UserData(eventList[index]);
            mainPage.User2Set(udata);
        }

        private void E1Set_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            int index = (int)b.Tag;
            ObservableCollection<UserEventData> eventList = (ObservableCollection<UserEventData>)UserDataTable.ItemsSource;
            UserData udata = new UserData(eventList[index]);
            mainPage.Event1Set(udata);
        }

        private void E2Set_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            int index = (int)b.Tag;
            ObservableCollection<UserEventData> eventList = (ObservableCollection<UserEventData>)UserDataTable.ItemsSource;
            UserData udata = new UserData(eventList[index]);
            mainPage.Event2Set(udata);
        }
    }
}
