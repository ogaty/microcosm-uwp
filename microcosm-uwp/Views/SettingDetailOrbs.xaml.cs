using microcosm.Common;
using microcosm.Config;
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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace microcosm.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SettingDetailOrbs : Page
    {
        public SettingData[] settings;
        public int settingIndex = 0;

        public SettingDetailOrbs()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            settings = CommonInstance.getInstance().settings;
            settingIndex = (int)e.Parameter;

            SettingInit();
        }

        private void SettingInit()
        {
            SettingData[] settings = CommonInstance.getInstance().settings;
            int currentSetting = settingIndex;

            SunHard1.Text = settings[currentSetting].orbs[0][OrbKind.SUN_HARD_1ST].ToString();
            SunHard2.Text = settings[currentSetting].orbs[0][OrbKind.SUN_HARD_2ND].ToString();
            SunHard150.Text = settings[currentSetting].orbs[0][OrbKind.SUN_HARD_150].ToString();
            SunSoft1.Text = settings[currentSetting].orbs[0][OrbKind.SUN_SOFT_1ST].ToString();
            SunSoft2.Text = settings[currentSetting].orbs[0][OrbKind.SUN_SOFT_2ND].ToString();
            SunSoft150.Text = settings[currentSetting].orbs[0][OrbKind.SUN_SOFT_150].ToString();

            MoonHard1.Text = settings[currentSetting].orbs[0][OrbKind.MOON_HARD_1ST].ToString();
            MoonHard2.Text = settings[currentSetting].orbs[0][OrbKind.MOON_HARD_2ND].ToString();
            MoonHard150.Text = settings[currentSetting].orbs[0][OrbKind.MOON_HARD_150].ToString();
            MoonSoft1.Text = settings[currentSetting].orbs[0][OrbKind.MOON_SOFT_1ST].ToString();
            MoonSoft2.Text = settings[currentSetting].orbs[0][OrbKind.MOON_SOFT_2ND].ToString();
            MoonSoft150.Text = settings[currentSetting].orbs[0][OrbKind.MOON_SOFT_150].ToString();

            OtherHard1.Text = settings[currentSetting].orbs[0][OrbKind.OTHER_HARD_1ST].ToString();
            OtherHard2.Text = settings[currentSetting].orbs[0][OrbKind.OTHER_HARD_2ND].ToString();
            OtherHard150.Text = settings[currentSetting].orbs[0][OrbKind.OTHER_HARD_150].ToString();
            OtherSoft1.Text = settings[currentSetting].orbs[0][OrbKind.OTHER_SOFT_1ST].ToString();
            OtherSoft2.Text = settings[currentSetting].orbs[0][OrbKind.OTHER_SOFT_2ND].ToString();
            OtherSoft150.Text = settings[currentSetting].orbs[0][OrbKind.OTHER_SOFT_150].ToString();

        }

        private void OrbUpdate_Click(object sender, RoutedEventArgs e)
        {
            //SettingToXml.SaveXml(settingIndex, settings[settingIndex]);
        }
    }
}
