using microcosm.Common;
using microcosm.Config;
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
    public sealed partial class SettingDetailPlanetAspect : Page
    {
        public SettingData[] settings;
        public int settingIndex = 0;

        public SettingDetailPlanetAspect()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            settings = CommonInstance.getInstance().settings;
            settingIndex = (int)e.Parameter;

            base.OnNavigatedTo(e);
            SettingInit();
        }

        private void SettingInit()
        {
            AspectSun1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SUN];
            AspectMoon1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MOON];
            AspectMercury1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MERCURY];
            AspectVenus1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VENUS];
            AspectMars1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MARS];
            AspectJupiter1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_JUPITER];
            AspectSaturn1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SATURN];
            AspectUranus1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_URANUS];
            AspectNeptune1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_NEPTUNE];
            AspectPluto1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_PLUTO];
            AspectAsc1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_ASC];
            AspectMc1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MC];
            AspectDh1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            AspectChiron1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_CHIRON];
            AspectEarth1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_EARTH];
            AspectLilith1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_LILITH];
            AspectCeres1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_CERES];
            AspectPallas1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_PALLAS];
            AspectJuno1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_JUNO];
            AspectVesta1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VESTA];
            /*
            AspectEris1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_ERIS];
            AspectSedna1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SEDNA];
            AspectHaumea1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_HAUMEA];
            AspectMakemake1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            AspectVt1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VT];
            AspectPof1.IsChecked = settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_POF];
            */

            AspectSun2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SUN];
            AspectMoon2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MOON];
            AspectMercury2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MERCURY];
            AspectVenus2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VENUS];
            AspectMars2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MARS];
            AspectJupiter2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_JUPITER];
            AspectSaturn2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SATURN];
            AspectUranus2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_URANUS];
            AspectNeptune2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_NEPTUNE];
            AspectPluto2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_PLUTO];
            AspectAsc2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_ASC];
            AspectMc2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MC];
            AspectDh2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            AspectChiron2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_CHIRON];
            AspectEarth2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_EARTH];
            AspectLilith2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_LILITH];
            AspectCeres2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_CERES];
            AspectPallas2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_PALLAS];
            AspectJuno2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_JUNO];
            AspectVesta2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VESTA];
            /*
            AspectEris2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_ERIS];
            AspectSedna2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SEDNA];
            AspectHaumea2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_HAUMEA];
            AspectMakemake2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            AspectVt2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VT];
            AspectPof2.IsChecked = settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_POF];
            */

            AspectSun3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SUN];
            AspectMoon3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MOON];
            AspectMercury3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MERCURY];
            AspectVenus3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VENUS];
            AspectMars3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MARS];
            AspectJupiter3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_JUPITER];
            AspectSaturn3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SATURN];
            AspectUranus3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_URANUS];
            AspectNeptune3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_NEPTUNE];
            AspectPluto3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_PLUTO];
            AspectAsc3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_ASC];
            AspectMc3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MC];
            AspectDh3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            AspectChiron3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_CHIRON];
            AspectEarth3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_EARTH];
            AspectLilith3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_LILITH];
            AspectCeres3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_CERES];
            AspectPallas3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_PALLAS];
            AspectJuno3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_JUNO];
            AspectVesta3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VESTA];
            /*
            AspectEris3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_ERIS];
            AspectSedna3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SEDNA];
            AspectHaumea3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_HAUMEA];
            AspectMakemake3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            AspectVt3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VT];
            AspectPof3.IsChecked = settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_POF];
            */
        }

        private void DispPlanetClicked(object sender, RoutedEventArgs e)
        {
            #region notuse
            /*
            // Nameからクリックされた場所を判定
            var s = (ToggleButton)sender;
            int planet_no = 0;
            int index = 0;

            if (s.Name.IndexOf("AspectSun") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_SUN;
            }
            else if (s.Name.IndexOf("AspectMoon") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MOON;
            }
            else if (s.Name.IndexOf("AspectMercury") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MERCURY;
            }
            else if (s.Name.IndexOf("AspectVenus") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_VENUS;
            }
            else if (s.Name.IndexOf("AspectMars") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MARS;
            }
            else if (s.Name.IndexOf("AspectJupiter") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_JUPITER;
            }
            else if (s.Name.IndexOf("AspectSaturn") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_SATURN;
            }
            else if (s.Name.IndexOf("AspectUranus") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_URANUS;
            }
            else if (s.Name.IndexOf("AspectNeptune") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_NEPTUNE;
            }
            else if (s.Name.IndexOf("AspectPluto") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_PLUTO;
            }
            else if (s.Name.IndexOf("AspectDh") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_DH_TRUENODE;
            }
            else if (s.Name.IndexOf("AspectChiron") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_CHIRON;
            }
            else if (s.Name.IndexOf("AspectEarth") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_EARTH;
            }
            else if (s.Name.IndexOf("AspectLilith") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_LILITH;
            }
            else if (s.Name.IndexOf("AspectAsc") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_ASC;
            }
            else if (s.Name.IndexOf("AspectMc") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_MC;
            }
            else if (s.Name.IndexOf("AspectVt") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_VT;
            }
            else if (s.Name.IndexOf("AspectPof") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_POF;
            }
            else if (s.Name.IndexOf("AspectCeres") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_CERES;
            }
            else if (s.Name.IndexOf("AspectParas") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_PALLAS;
            }
            else if (s.Name.IndexOf("AspectJuno") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_JUNO;
            }
            else if (s.Name.IndexOf("AspectVesta") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_VESTA;
            }
            else if (s.Name.IndexOf("AspectEris") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_ERIS;
            }
            else if (s.Name.IndexOf("AspectSedna") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_SEDNA;
            }
            else if (s.Name.IndexOf("AspectHaumea") >= 0)
            {
                planet_no = CommonData.ZODIAC_NUMBER_HAUMEA;
            }
            else if (s.Name.IndexOf("AspectMakemake") >= 0)
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
            */
            #endregion
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SUN] = AspectSun1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SUN] = AspectSun2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SUN] = AspectSun3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MOON] = AspectMoon1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MOON] = AspectMoon2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MOON] = AspectMoon3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MERCURY] = AspectMercury1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MERCURY] = AspectMercury2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MERCURY] = AspectMercury3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VENUS] = AspectVenus1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VENUS] = AspectVenus2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VENUS] = AspectVenus3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MARS] = AspectMars1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MARS] = AspectMars2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MARS] = AspectMars3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_JUPITER] = AspectJupiter1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_JUPITER] = AspectJupiter2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_JUPITER] = AspectJupiter3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SATURN] = AspectSaturn1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SATURN] = AspectSaturn2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SATURN] = AspectSaturn3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_URANUS] = AspectUranus1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_URANUS] = AspectUranus2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_URANUS] = AspectUranus3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_NEPTUNE] = AspectNeptune1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_NEPTUNE] = AspectNeptune2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_NEPTUNE] = AspectNeptune3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_PLUTO] = AspectPluto1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_PLUTO] = AspectPluto2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_PLUTO] = AspectPluto3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_ASC] = AspectAsc1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_ASC] = AspectAsc2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_ASC] = AspectAsc3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MC] = AspectMc1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MC] = AspectMc2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MC] = AspectMc3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_DH_TRUENODE] = AspectDh1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_DH_TRUENODE] = AspectDh2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_DH_TRUENODE] = AspectDh3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_CHIRON] = AspectChiron1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_CHIRON] = AspectChiron2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_CHIRON] = AspectChiron3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_EARTH] = AspectEarth1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_EARTH] = AspectEarth2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_EARTH] = AspectEarth3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_LILITH] = AspectLilith1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_LILITH] = AspectLilith2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_LILITH] = AspectLilith3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_CERES] = AspectCeres1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_CERES] = AspectCeres2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_CERES] = AspectCeres3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_PALLAS] = AspectPallas1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_PALLAS] = AspectPallas2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_PALLAS] = AspectPallas3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_JUNO] = AspectJuno1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_JUNO] = AspectJuno2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_JUNO] = AspectJuno3.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VESTA] = AspectVesta1.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VESTA] = AspectVesta2.IsChecked ?? false;
            settings[settingIndex].dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VESTA] = AspectVesta3.IsChecked ?? false;

            CommonInstance.getInstance().settings = settings;
            SettingToJson.SaveJson(settingIndex, settings[settingIndex]);
        }
    }
}
