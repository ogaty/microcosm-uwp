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

namespace microcosm
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SettingsConfigPage : Page
    {
        ConfigData config;

        public SettingsConfigPage()
        {
            this.InitializeComponent();
            SettingInit();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            config = (ConfigData)e.Parameter;

            base.OnNavigatedTo(e);

        }

        private void SettingInit()
        {
            if (config.houseCalc == EHouseCalc.PLACIDUS)
            {
                PlacidusRadio.IsChecked = true;
            } else if (config.houseCalc == EHouseCalc.KOCH)
            {
                KochRadio.IsChecked = true;
            }
            else if (config.houseCalc == EHouseCalc.CAMPANUS)
            {
                CampanusRadio.IsChecked = true;
            }
            else if (config.houseCalc == EHouseCalc.EQUAL)
            {
                EqualRadio.IsChecked = true;
            }
            else if (config.houseCalc == EHouseCalc.PORPHYRY)
            {
                PorphyryRadio.IsChecked = true;
            }
            else if (config.houseCalc == EHouseCalc.REGIOMONTANUS)
            {
                RegiomontanusRadio.IsChecked = true;
            }
        }

    }
}
