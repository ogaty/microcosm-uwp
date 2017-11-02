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
    public sealed partial class SettingsConfigPage : Page
    {
        ConfigData config;

        public SettingsConfigPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            config = CommonInstance.getInstance().config;
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
            if (config.progression == EProgression.PRIMARY)
            {
                PrimaryRadio.IsChecked = true;
            }
            else if (config.progression == EProgression.SECONDARY)
            {
                SecondaryRadio.IsChecked = true;
            }
            else if (config.progression == EProgression.CPS)
            {
                CompositRadio.IsChecked = true;
            }
            if (config.decimalDisp == EDecimalDisp.DECIMAL)
            {
                HandredRadio.IsChecked = true;
            }
            else if (config.decimalDisp == EDecimalDisp.DEGREE)
            {
                SixtyRadio.IsChecked = true;
            }
            if (config.dispPattern2 == EDispPetern.MINI)
            {
                SimpleRadio.IsChecked = true;
            }
            else if (config.dispPattern2 == EDispPetern.FULL)
            {
                FullRadio.IsChecked = true;
            }
            if (config.centric == ECentric.GEO_CENTRIC)
            {
                GeoRadio.IsChecked = true;
            }
            else if (config.centric == ECentric.HELIO_CENTRIC)
            {
                HelioRadio.IsChecked = true;
            }
            if (config.sidereal == ESidereal.TROPICAL)
            {
                TropicalRadio.IsChecked = true;
            }
            else if (config.sidereal == ESidereal.SIDEREAL)
            {
                SideRealRadio.IsChecked = true;
            }
            if (config.colorChange >= 0)
            {
                DegreeCheck.IsChecked = true;
                DegreeText.Text = config.colorChange.ToString();
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
            FileSave();
        }

        private void ProgressionsChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (PrimaryRadio.IsChecked == true)
            {
                config.progression = EProgression.PRIMARY;
            }
            else if (SecondaryRadio.IsChecked == true)
            {
                config.progression = EProgression.SECONDARY;
            }
            else if (CompositRadio.IsChecked == true)
            {
                config.progression = EProgression.CPS;
            }
            FileSave();
        }

        private void DoubleLetterChanged(object sender, RoutedEventArgs e)
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
            FileSave();
        }

        private void SimpleChartsChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (SimpleRadio.IsChecked == true)
            {
                config.dispPattern2 = EDispPetern.MINI;
            }
            else if (FullRadio.IsChecked == true)
            {
                config.dispPattern2 = EDispPetern.FULL;
            }
            FileSave();
        }

        private void CentricsChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (GeoRadio.IsChecked == true)
            {
                config.centric = ECentric.GEO_CENTRIC;
            }
            else if (HelioRadio.IsChecked == true)
            {
                config.centric = ECentric.HELIO_CENTRIC;
            }
            FileSave();
        }

        private void TropicalChanged(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (TropicalRadio.IsChecked == true)
            {
                config.sidereal = ESidereal.TROPICAL;
            }
            else if (SideRealRadio.IsChecked == true)
            {
                config.sidereal = ESidereal.TROPICAL;
            }
            FileSave();
        }

        private void DegreeCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (DegreeCheck.IsChecked == true)
            {
                try
                {
                    config.colorChange = int.Parse(DegreeText.Text);
                }
                catch (FormatException)
                {
                    config.colorChange = -1;
                }
                catch (InvalidCastException)
                {
                    config.colorChange = -1;
                    DegreeText.Text = "-1";
                }
            }
            else
            {
                config.colorChange = -1;
                DegreeText.Text = "-1";
            }
            FileSave();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (config == null) return;

            if (DegreeCheck.IsChecked == true)
            {
                try
                {
                    config.colorChange = int.Parse(DegreeText.Text);
                }
                catch (FormatException)
                {
                    config.colorChange = -1;
                    DegreeText.Text = "-1";
                }
                catch (InvalidCastException)
                {
                    config.colorChange = -1;
                    DegreeText.Text = "-1";
                }
            }
            else
            {
                config.colorChange = -1;
                DegreeText.Text = "-1";
            }

            FileSave();
        }

        private void DegreeCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            config.colorChange = -1;
            DegreeText.Text = "-1";
            FileSave();
        }

        private void FileSave()
        {
            ConfigSave.SaveXml(config);
        }

    }
}
