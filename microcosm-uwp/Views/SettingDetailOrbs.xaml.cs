﻿using microcosm.Common;
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
            int currentSetting = settingIndex;

            SunHard1.Text = settings[currentSetting].orbs[currentSetting][OrbKind.SUN_HARD_1ST].ToString();
            SunHard2.Text = settings[currentSetting].orbs[currentSetting][OrbKind.SUN_HARD_2ND].ToString();
            SunHard150.Text = settings[currentSetting].orbs[currentSetting][OrbKind.SUN_HARD_150].ToString();
            SunSoft1.Text = settings[currentSetting].orbs[currentSetting][OrbKind.SUN_SOFT_1ST].ToString();
            SunSoft2.Text = settings[currentSetting].orbs[currentSetting][OrbKind.SUN_SOFT_2ND].ToString();
            SunSoft150.Text = settings[currentSetting].orbs[currentSetting][OrbKind.SUN_SOFT_150].ToString();

            MoonHard1.Text = settings[currentSetting].orbs[currentSetting][OrbKind.MOON_HARD_1ST].ToString();
            MoonHard2.Text = settings[currentSetting].orbs[currentSetting][OrbKind.MOON_HARD_2ND].ToString();
            MoonHard150.Text = settings[currentSetting].orbs[currentSetting][OrbKind.MOON_HARD_150].ToString();
            MoonSoft1.Text = settings[currentSetting].orbs[currentSetting][OrbKind.MOON_SOFT_1ST].ToString();
            MoonSoft2.Text = settings[currentSetting].orbs[currentSetting][OrbKind.MOON_SOFT_2ND].ToString();
            MoonSoft150.Text = settings[currentSetting].orbs[currentSetting][OrbKind.MOON_SOFT_150].ToString();

            OtherHard1.Text = settings[currentSetting].orbs[currentSetting][OrbKind.OTHER_HARD_1ST].ToString();
            OtherHard2.Text = settings[currentSetting].orbs[currentSetting][OrbKind.OTHER_HARD_2ND].ToString();
            OtherHard150.Text = settings[currentSetting].orbs[currentSetting][OrbKind.OTHER_HARD_150].ToString();
            OtherSoft1.Text = settings[currentSetting].orbs[currentSetting][OrbKind.OTHER_SOFT_1ST].ToString();
            OtherSoft2.Text = settings[currentSetting].orbs[currentSetting][OrbKind.OTHER_SOFT_2ND].ToString();
            OtherSoft150.Text = settings[currentSetting].orbs[currentSetting][OrbKind.OTHER_SOFT_150].ToString();

        }

        private void OrbUpdate_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                settings[settingIndex].orbs[i][OrbKind.SUN_HARD_1ST] = double.Parse(SunHard1.Text);
                settings[settingIndex].orbs[i][OrbKind.SUN_SOFT_1ST] = double.Parse(SunSoft1.Text);
                settings[settingIndex].orbs[i][OrbKind.SUN_HARD_2ND] = double.Parse(SunHard2.Text);
                settings[settingIndex].orbs[i][OrbKind.SUN_SOFT_2ND] = double.Parse(SunSoft2.Text);
                settings[settingIndex].orbs[i][OrbKind.SUN_HARD_150] = double.Parse(SunHard150.Text);
                settings[settingIndex].orbs[i][OrbKind.SUN_SOFT_150] = double.Parse(SunSoft150.Text);

                settings[settingIndex].orbs[i][OrbKind.MOON_HARD_1ST] = double.Parse(MoonHard1.Text);
                settings[settingIndex].orbs[i][OrbKind.MOON_SOFT_1ST] = double.Parse(MoonSoft1.Text);
                settings[settingIndex].orbs[i][OrbKind.MOON_HARD_2ND] = double.Parse(MoonHard2.Text);
                settings[settingIndex].orbs[i][OrbKind.MOON_SOFT_2ND] = double.Parse(MoonSoft2.Text);
                settings[settingIndex].orbs[i][OrbKind.MOON_HARD_150] = double.Parse(MoonHard150.Text);
                settings[settingIndex].orbs[i][OrbKind.MOON_SOFT_150] = double.Parse(MoonSoft150.Text);

                settings[settingIndex].orbs[i][OrbKind.OTHER_HARD_1ST] = double.Parse(OtherHard1.Text);
                settings[settingIndex].orbs[i][OrbKind.OTHER_SOFT_1ST] = double.Parse(OtherSoft1.Text);
                settings[settingIndex].orbs[i][OrbKind.OTHER_HARD_2ND] = double.Parse(OtherHard2.Text);
                settings[settingIndex].orbs[i][OrbKind.OTHER_SOFT_2ND] = double.Parse(OtherSoft2.Text);
                settings[settingIndex].orbs[i][OrbKind.OTHER_HARD_150] = double.Parse(OtherHard150.Text);
                settings[settingIndex].orbs[i][OrbKind.OTHER_SOFT_150] = double.Parse(OtherSoft150.Text);
            }
            CommonInstance.getInstance().settings = settings;
            SettingToJson.SaveJson(settingIndex, settings[settingIndex]);

            //SettingToXml.SaveXml(settingIndex, settings[settingIndex]);
        }

        private string BoolsToString(bool[] bools)
        {
            return string.Join(',', bools);
        }

        private void AspectCategoryUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
