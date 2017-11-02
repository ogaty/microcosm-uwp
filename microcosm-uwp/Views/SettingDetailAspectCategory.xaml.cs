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
    public sealed partial class SettingDetailAspectCategory : Page
    {
        public SettingData[] settings;
        public int settingIndex = 0;

        public SettingDetailAspectCategory()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            settings = CommonInstance.getInstance().settings;

            base.OnNavigatedTo(e);
            SettingInit();
        }

        private void SettingInit()
        {
            settingDisp11.IsOn = settings[settingIndex].dispAspect[0, 0];
            settingDisp22.IsOn = settings[settingIndex].dispAspect[1, 1];
            settingDisp33.IsOn = settings[settingIndex].dispAspect[2, 2];
        }

    }
}
