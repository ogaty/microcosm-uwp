using microcosm.Common;
using microcosm.Config;
using microcosm.Models;
using microcosm.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// たぶんこのクラス使ってない
    /// </summary>
    public sealed partial class MainListPage : Page
    {
        public MainWindowCuspListViewModel vm1 = new MainWindowCuspListViewModel();
        public MainWindowCuspListViewModel vm2 = new MainWindowCuspListViewModel();
        public CuspList cuspList;

        public MainListPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*
            cuspList = (CuspList)e.Parameter;

            PlanetCusp.DataContext = vm1;
            vm1.planetCuspList = new ObservableCollection<PlanetCuspListData>();
            foreach (PlanetData p in cuspList.planetList)
            {
                PlanetCuspListData pcusp = new PlanetCuspListData()
                {
                    name = Util.getPlanetSymbol(p.no)
                };
                pcusp.degree1 = Util.getPlanetDegree(p.absolute_position, CommonInstance.getInstance().config.decimalDisp);
                vm1.planetCuspList.Add(pcusp);
            }
            PlanetCusp.ItemsSource = vm1.planetCuspList;

            HouseCusp.DataContext = vm2;
            vm2.houseCuspList = new ObservableCollection<HouseCuspListData>();
            for (int i = 1; i < 13; i++)
            {
                HouseCuspListData hcusp = new HouseCuspListData();
                hcusp.name = i.ToString();
                if (CommonInstance.getInstance().config.decimal_disp == EDecimalDisp.DECIMAL)
                {
                    hcusp.degree1 = String.Format("{0:f2}", cuspList.cusps[i]);
                }
                else
                {
                    hcusp.degree1 = Util.DecimalToHex(cuspList.cusps[i]).ToString();
                }

                vm2.houseCuspList.Add(hcusp);
            }
            HouseCusp.ItemsSource = vm2.houseCuspList;
            */

        }

    }
}
