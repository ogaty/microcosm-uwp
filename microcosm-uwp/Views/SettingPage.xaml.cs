﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using microcosm.Config;
using Windows.UI;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace microcosm.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
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

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
            this.SettingFrame.Navigate(typeof(SettingsConfigPage));

        }

        private void DisplaySettingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CommonSettingMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            DisplaySettingMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 192));
            VersionMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.SettingFrame.Navigate(typeof(SettingSettingsPage));
        }

        private void CommonSettingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CommonSettingMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 192));
            DisplaySettingMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            VersionMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.SettingFrame.Navigate(typeof(SettingsConfigPage));
        }

        private void VersionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CommonSettingMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            DisplaySettingMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            VersionMenuBar.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 192));
            this.SettingFrame.Navigate(typeof(SettingVersion));
        }
    }
}
