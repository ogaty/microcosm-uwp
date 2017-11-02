using microcosm.Common;
using microcosm.Config;
using microcosm.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class SettingDetailPlanet : Page
    {
        public SettingData[] settings;
        public int settingIndex = 0;

        public SettingDetailPlanet()
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
            for (int i = 0; i < 7; i++)
            {
                int j = i + 1;
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_SUN] == true)
                {
                    var btn = ((ToggleButton)FindName("Sun1"));
                    ((ToggleButton)FindName("Sun" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_MOON] == true)
                {
                    ((ToggleButton)FindName("Moon" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_MERCURY] == true)
                {
                    ((ToggleButton)FindName("Mercury" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_VENUS] == true)
                {
                    ((ToggleButton)FindName("Venus" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_MARS] == true)
                {
                    ((ToggleButton)FindName("Mars" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_JUPITER] == true)
                {
                    ((ToggleButton)FindName("Jupiter" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_SATURN] == true)
                {
                    ((ToggleButton)FindName("Saturn" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_URANUS] == true)
                {
                    ((ToggleButton)FindName("Uranus" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_NEPTUNE] == true)
                {
                    ((ToggleButton)FindName("Neptune" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_PLUTO] == true)
                {
                    ((ToggleButton)FindName("Pluto" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_DH_TRUENODE] == true)
                {
                    ((ToggleButton)FindName("Dh" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_CHIRON] == true)
                {
                    ((ToggleButton)FindName("Chiron" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_EARTH] == true)
                {
                    ((ToggleButton)FindName("Earth" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_LILITH] == true)
                {
                    ((ToggleButton)FindName("Lilith" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_ASC] == true)
                {
                    ((ToggleButton)FindName("Asc" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_MC] == true)
                {
                    ((ToggleButton)FindName("Mc" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_CERES] == true)
                {
                    ((ToggleButton)FindName("Ceres" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_PARAS] == true)
                {
                    ((ToggleButton)FindName("Paras" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_JUNO] == true)
                {
                    ((ToggleButton)FindName("Juno" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_VESTA] == true)
                {
                    ((ToggleButton)FindName("Vesta" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_ERIS] == true)
                {
                    ((ToggleButton)FindName("Eris" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_SEDNA] == true)
                {
                    ((ToggleButton)FindName("Sedna" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_HAUMEA] == true)
                {
                    ((ToggleButton)FindName("Haumea" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_MAKEMAKE] == true)
                {
                    ((ToggleButton)FindName("Makemake" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_VT] == true)
                {
                    ((ToggleButton)FindName("Vt" + j.ToString())).IsChecked = true;
                }
                if (settings[settingIndex].dispPlanet[i][CommonData.ZODIAC_NUMBER_POF] == true)
                {
                    ((ToggleButton)FindName("Pof" + j.ToString())).IsChecked = true;
                }
            }
        }

        private void DispPlanetClicked(object sender, RoutedEventArgs e)
        {
            // Nameからクリックされた場所を判定
            var s = (ToggleButton)sender;
            int planet_no = 0;
            int index = 0;
            
            if (s.Name.IndexOf("Sun") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_SUN;
            }
            else if (s.Name.IndexOf("Moon") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MOON;
            }
            else if (s.Name.IndexOf("Mercury") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MERCURY;
            }
            else if (s.Name.IndexOf("Venus") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_VENUS;
            }
            else if (s.Name.IndexOf("Mars") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MARS;
            }
            else if (s.Name.IndexOf("Jupiter") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_JUPITER;
            }
            else if (s.Name.IndexOf("Saturn") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_SATURN;
            }
            else if (s.Name.IndexOf("Uranus") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_URANUS;
            }
            else if (s.Name.IndexOf("Neptune") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_NEPTUNE;
            }
            else if (s.Name.IndexOf("Pluto") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_PLUTO;
            }
            else if (s.Name.IndexOf("Dh") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_DH_TRUENODE;
            }
            else if (s.Name.IndexOf("Chiron") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_CHIRON;
            }
            else if (s.Name.IndexOf("Earth") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_EARTH;
            }
            else if (s.Name.IndexOf("Lilith") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_LILITH;
            }
            else if (s.Name.IndexOf("Asc") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_ASC;
            }
            else if (s.Name.IndexOf("Mc") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MC;
            }
            else if (s.Name.IndexOf("Ceres") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_CERES;
            }
            else if (s.Name.IndexOf("Paras") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_PARAS;
            }
            else if (s.Name.IndexOf("Juno") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_JUNO;
            }
            else if (s.Name.IndexOf("Vesta") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_VESTA;
            }
            else if (s.Name.IndexOf("Eris") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_ERIS;
            }
            else if (s.Name.IndexOf("Sedna") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_SEDNA;
            }
            else if (s.Name.IndexOf("Haumea") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_HAUMEA;
            }
            else if (s.Name.IndexOf("Makemake") > 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MAKEMAKE;
            }

            if (s.Name.EndsWith("1"))
            {
                index = 0;
            }
            else if (s.Name.EndsWith("2"))
            {
                index = 1;
            }
            else if (s.Name.EndsWith("3"))
            {
                index = 2;
            }
            else if (s.Name.EndsWith("4"))
            {
                index = 3;
            }
            else if (s.Name.EndsWith("5"))
            {
                index = 4;
            }
            else if (s.Name.EndsWith("6"))
            {
                index = 5;
            }
            else if (s.Name.EndsWith("7"))
            {
                index = 6;
            }

            if (((ToggleButton)sender).IsChecked == true)
            {
                settings[settingIndex].dispPlanet[index][planet_no] = true;
            }
            else
            {
                settings[settingIndex].dispPlanet[index][planet_no] = false;
            }
        }
    }
}
