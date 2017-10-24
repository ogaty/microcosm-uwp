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
    public sealed partial class SettingsConfigPage : Page
    {
        ConfigData config;

        public SettingsConfigPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            config = (ConfigData)e.Parameter;

            base.OnNavigatedTo(e);

            SettingInit();
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

        private void HouseDivideChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (PlacidusRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.PLACIDUS;
            }
            else if (KochRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.KOCH;
            }
            else if (CampanusRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.CAMPANUS;
            }
            else if (EqualRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.EQUAL;
            }
            else if (PorphyryRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.PORPHYRY;
            }
            else if (RegiomontanusRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.REGIOMONTANUS;
            }
        }

        private void ProgressionsChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (PlacidusRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.PLACIDUS;
            }
            else if (KochRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.KOCH;
            }
            else if (CampanusRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.CAMPANUS;
            }
            else if (EqualRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.EQUAL;
            }
            else if (PorphyryRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.PORPHYRY;
            }
            else if (RegiomontanusRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.REGIOMONTANUS;
            }
            else if (SolarRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.SOLAR;
            }
            else if (SolarSignRadio.IsChecked == true)
            {
                config.houseCalc = EHouseCalc.SOLARSIGN;
            }
        }

        private void DoubleLetterChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (SixtyRadio.IsChecked == true)
            {
                config.decimalDisp = ECentric.DEGREE;
            }
            else if (HandredRadio.IsChecked == true)
            {
                config.decimalDisp = ECentric.DEGREE;
            }

        }

        private void SimpleChartsChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (SimpleRadio.IsChecked == true)
            {
                config.dispPattern = EDispPetern.MINI;
            }
            else if (FullRadio.IsChecked == true)
            {
                config.dispPattern = EDispPetern.FULL;
            }
        }

        private void CentricsChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (GeoCentricRadio.IsChecked == true)
            {
                config.centric = ECentric.GEO_CENTRIC;
            }
            else if (GeoCentricRadio.IsChecked == true)
            {
                config.centric = ECentric.HELIO_CENTRIC;
            }
        }

        private void TropicalChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (TropicalRadio.IsChecked == true)
            {
                config.centric = ESidereal.TROPICAL;
            }
            else if (SideRealRadio.IsChecked == true)
            {
                config.centric = ESidereal.TROPICAL;
            }
        }

        private void DegreeCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (SixtyRadio.IsChecked == true)
            {
                config.decimalDisp = EDecimalDisp.DEGREE;
            }
            else if (HandredRadio.IsChecked == true)
            {
                config.decimalDisp = EDecimalDisp.DECIMAL;
            }

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (DegreeCheck.IsChecked == true)
            {
            }

        }

        private void ConfigSave()
        {

        }
    }
}
