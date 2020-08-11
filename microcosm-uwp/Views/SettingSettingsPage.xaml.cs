using microcosm.Common;
using microcosm.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class SettingSettingsPage : Page
    {
        public SettingData[] settings;
        public int display;

        public SettingSettingsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            settings = CommonInstance.getInstance().settings;

            base.OnNavigatedTo(e);
            this.SettingDetailFrame.Navigate(typeof(SettingDetailPlanet), (object)0);

            ResetCombo();
        }

        public void ResetCombo()
        {
            settings = CommonInstance.getInstance().settings;
            SettingCombo.Items.Clear();
            foreach (SettingData setting in settings)
            {
                SettingCombo.Items.Add(setting.dispName);
            }
            SettingCombo.SelectedIndex = 0;
        }

        private void SettingCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (display)
            {
                case 0:
                    SettingDetailFrame.Navigate(typeof(SettingDetailPlanet), (object)SettingCombo.SelectedIndex);
                    break;

                case 1:
                    SettingDetailFrame.Navigate(typeof(SettingDetailAspectCategory), (object)SettingCombo.SelectedIndex);
                    break;

                case 2:
                    SettingDetailFrame.Navigate(typeof(SettingDetailPlanetAspect), (object)SettingCombo.SelectedIndex);
                    break;

                case 3:
                    SettingDetailFrame.Navigate(typeof(SettingDetailOrbs), (object)SettingCombo.SelectedIndex);
                    break;

            }
        }

        private void DispPlanetSetting_Click(object sender, RoutedEventArgs e)
        {
            display = 0;
            DispPlanetSetting.Background = new SolidColorBrush(Colors.LemonChiffon);
            DispAspectCategorySetting.Background = new SolidColorBrush(Colors.White);
            DispAspectPlanetSetting.Background = new SolidColorBrush(Colors.White);
            OrbsSetting.Background = new SolidColorBrush(Colors.White);
            DispNameSetting.Background = new SolidColorBrush(Colors.White);
            SettingDetailFrame.Navigate(typeof(SettingDetailPlanet), (object)SettingCombo.SelectedIndex);
        }

        private void DispAspectCategorySetting_Click(object sender, RoutedEventArgs e)
        {
            display = 1;
            DispPlanetSetting.Background = new SolidColorBrush(Colors.White);
            DispAspectCategorySetting.Background = new SolidColorBrush(Colors.LemonChiffon);
            DispAspectPlanetSetting.Background = new SolidColorBrush(Colors.White);
            OrbsSetting.Background = new SolidColorBrush(Colors.White);
            DispNameSetting.Background = new SolidColorBrush(Colors.White);
            SettingDetailFrame.Navigate(typeof(SettingDetailAspectCategory), (object)SettingCombo.SelectedIndex);
        }

        private void DispAspectPlanetSetting_Click(object sender, RoutedEventArgs e)
        {
            display = 2;
            DispPlanetSetting.Background = new SolidColorBrush(Colors.White);
            DispAspectCategorySetting.Background = new SolidColorBrush(Colors.White);
            DispAspectPlanetSetting.Background = new SolidColorBrush(Colors.LemonChiffon);
            OrbsSetting.Background = new SolidColorBrush(Colors.White);
            DispNameSetting.Background = new SolidColorBrush(Colors.White);
            SettingDetailFrame.Navigate(typeof(SettingDetailPlanetAspect), (object)SettingCombo.SelectedIndex);
        }

        private void OrbsSetting_Click(object sender, RoutedEventArgs e)
        {
            display = 3;
            DispPlanetSetting.Background = new SolidColorBrush(Colors.White);
            DispAspectCategorySetting.Background = new SolidColorBrush(Colors.White);
            DispAspectPlanetSetting.Background = new SolidColorBrush(Colors.White);
            OrbsSetting.Background = new SolidColorBrush(Colors.LemonChiffon);
            DispNameSetting.Background = new SolidColorBrush(Colors.White);
            SettingDetailFrame.Navigate(typeof(SettingDetailOrbs), (object)SettingCombo.SelectedIndex);
        }

        private void DispNameSetting_Click(object sender, RoutedEventArgs e)
        {
            display = 4;
            DispPlanetSetting.Background = new SolidColorBrush(Colors.White);
            DispAspectCategorySetting.Background = new SolidColorBrush(Colors.White);
            DispAspectPlanetSetting.Background = new SolidColorBrush(Colors.White);
            OrbsSetting.Background = new SolidColorBrush(Colors.White);
            DispNameSetting.Background = new SolidColorBrush(Colors.LemonChiffon);
            SettingDetailFrame.Navigate(typeof(SettingDispName), (object)this);
        }
    }
}
