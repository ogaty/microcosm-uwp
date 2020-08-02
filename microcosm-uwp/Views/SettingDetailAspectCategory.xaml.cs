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
            /*
            settingDisp11.IsOn = settings[settingIndex].dispAspect[0, 0];
            settingDisp22.IsOn = settings[settingIndex].dispAspect[1, 1];
            settingDisp33.IsOn = settings[settingIndex].dispAspect[2, 2];
            */

            settingAspectCategoryConjunction11.IsChecked = settings[settingIndex].dispAspectCategory[0][Models.AspectKind.CONJUNCTION];
            settingAspectCategoryConjunction22.IsChecked = settings[settingIndex].dispAspectCategory[1][Models.AspectKind.CONJUNCTION];
            settingAspectCategoryConjunction33.IsChecked = settings[settingIndex].dispAspectCategory[2][Models.AspectKind.CONJUNCTION];
            settingAspectCategoryConjunction12.IsChecked = settings[settingIndex].dispAspectCategory[7][Models.AspectKind.CONJUNCTION];
            settingAspectCategoryConjunction13.IsChecked = settings[settingIndex].dispAspectCategory[8][Models.AspectKind.CONJUNCTION];
            settingAspectCategoryConjunction23.IsChecked = settings[settingIndex].dispAspectCategory[13][Models.AspectKind.CONJUNCTION];
            settingAspectCategoryOpposition11.IsChecked = settings[settingIndex].dispAspectCategory[0][Models.AspectKind.OPPOSITION];
            settingAspectCategoryOpposition22.IsChecked = settings[settingIndex].dispAspectCategory[1][Models.AspectKind.OPPOSITION];
            settingAspectCategoryOpposition33.IsChecked = settings[settingIndex].dispAspectCategory[2][Models.AspectKind.OPPOSITION];
            settingAspectCategoryOpposition12.IsChecked = settings[settingIndex].dispAspectCategory[7][Models.AspectKind.OPPOSITION];
            settingAspectCategoryOpposition13.IsChecked = settings[settingIndex].dispAspectCategory[8][Models.AspectKind.OPPOSITION];
            settingAspectCategoryOpposition23.IsChecked = settings[settingIndex].dispAspectCategory[13][Models.AspectKind.OPPOSITION];
            settingAspectCategoryTrine11.IsChecked = settings[settingIndex].dispAspectCategory[0][Models.AspectKind.TRINE];
            settingAspectCategoryTrine22.IsChecked = settings[settingIndex].dispAspectCategory[1][Models.AspectKind.TRINE];
            settingAspectCategoryTrine33.IsChecked = settings[settingIndex].dispAspectCategory[2][Models.AspectKind.TRINE];
            settingAspectCategoryTrine12.IsChecked = settings[settingIndex].dispAspectCategory[7][Models.AspectKind.TRINE];
            settingAspectCategoryTrine13.IsChecked = settings[settingIndex].dispAspectCategory[8][Models.AspectKind.TRINE];
            settingAspectCategoryTrine23.IsChecked = settings[settingIndex].dispAspectCategory[13][Models.AspectKind.TRINE];
            settingAspectCategorySquare11.IsChecked = settings[settingIndex].dispAspectCategory[0][Models.AspectKind.SQUARE];
            settingAspectCategorySquare22.IsChecked = settings[settingIndex].dispAspectCategory[1][Models.AspectKind.SQUARE];
            settingAspectCategorySquare33.IsChecked = settings[settingIndex].dispAspectCategory[2][Models.AspectKind.SQUARE];
            settingAspectCategorySquare12.IsChecked = settings[settingIndex].dispAspectCategory[7][Models.AspectKind.SQUARE];
            settingAspectCategorySquare13.IsChecked = settings[settingIndex].dispAspectCategory[8][Models.AspectKind.SQUARE];
            settingAspectCategorySquare23.IsChecked = settings[settingIndex].dispAspectCategory[13][Models.AspectKind.SQUARE];
            settingAspectCategorySextile11.IsChecked = settings[settingIndex].dispAspectCategory[0][Models.AspectKind.SEXTILE];
            settingAspectCategorySextile22.IsChecked = settings[settingIndex].dispAspectCategory[1][Models.AspectKind.SEXTILE];
            settingAspectCategorySextile33.IsChecked = settings[settingIndex].dispAspectCategory[2][Models.AspectKind.SEXTILE];
            settingAspectCategorySextile12.IsChecked = settings[settingIndex].dispAspectCategory[7][Models.AspectKind.SEXTILE];
            settingAspectCategorySextile13.IsChecked = settings[settingIndex].dispAspectCategory[8][Models.AspectKind.SEXTILE];
            settingAspectCategorySextile23.IsChecked = settings[settingIndex].dispAspectCategory[13][Models.AspectKind.SEXTILE];
        }

        private void OrbUpdate_Click(object sender, RoutedEventArgs e)
        {
            settings[settingIndex].dispAspectCategory[0][Models.AspectKind.CONJUNCTION] = settingAspectCategoryConjunction11.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[1][Models.AspectKind.CONJUNCTION] = settingAspectCategoryConjunction22.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[2][Models.AspectKind.CONJUNCTION] = settingAspectCategoryConjunction33.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[7][Models.AspectKind.CONJUNCTION] = settingAspectCategoryConjunction12.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[8][Models.AspectKind.CONJUNCTION] = settingAspectCategoryConjunction13.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[13][Models.AspectKind.CONJUNCTION] = settingAspectCategoryConjunction23.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[0][Models.AspectKind.OPPOSITION] = settingAspectCategoryOpposition11.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[1][Models.AspectKind.OPPOSITION] = settingAspectCategoryOpposition22.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[2][Models.AspectKind.OPPOSITION] = settingAspectCategoryOpposition33.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[7][Models.AspectKind.OPPOSITION] = settingAspectCategoryOpposition12.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[8][Models.AspectKind.OPPOSITION] = settingAspectCategoryOpposition13.IsChecked ?? false;
            settings[settingIndex].dispAspectCategory[13][Models.AspectKind.OPPOSITION] = settingAspectCategoryOpposition23.IsChecked ?? false;

            var nop = new int[] { 3,4,5,6,9,10,11,12,14,15,16,17,18,19,20,21,22,23,24,25,26,27 };
            foreach (int i in nop)
            {
                settings[settingIndex].dispAspectCategory[i][Models.AspectKind.CONJUNCTION] = false;
                settings[settingIndex].dispAspectCategory[i][Models.AspectKind.OPPOSITION] = false;
            }

            CommonInstance.getInstance().settings = settings;
            SettingToJson.SaveJson(settingIndex, settings[settingIndex]);
        }
    }
}
