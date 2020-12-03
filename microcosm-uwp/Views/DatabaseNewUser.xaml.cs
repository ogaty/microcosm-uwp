﻿using microcosm.User;
using System;
using System.Collections.Generic;
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
using microcosm.Common;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace microcosm.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class DatabaseNewUser : Page
    {
        private DatabasePage d;

        public DatabaseNewUser()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            d = (DatabasePage)e.Parameter;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            UserData uData = new UserData()
            {
                name = UserName.Text,
                furigana = UserKana.Text,
                userevent = new List<UserEvent>(),
            };
            d.NewUser(FileName.Text, uData);
        }

        private void UserBirthCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (ComboBox)sender;

            Userlat.Text = CommonData.latitudeMap[((ComboBoxItem)c.SelectedValue).Content.ToString()].ToString();
            Userlng.Text = CommonData.longitudeMap[((ComboBoxItem)c.SelectedValue).Content.ToString()].ToString();
        }
    }
}
