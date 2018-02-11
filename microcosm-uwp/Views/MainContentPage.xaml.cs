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

using microcosm.Config;
using microcosm.Common;
using microcosm.ViewModels;
using microcosm.Models;
using microcosm.User;
using microcosm.Calc;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using System.Reflection;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace microcosm.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainContentPage : Page
    {
        public AstroCalc calc;
        public ConfigData config;
        public SettingData[] setting;
        public MainWindowCuspListViewModel vm1 = new MainWindowCuspListViewModel();
        public MainWindowCuspListViewModel vm2 = new MainWindowCuspListViewModel();
        public CuspList cuspList;

        public UserData udata1 = new UserData();
        public UserData udata2 = new UserData();
        public UserData edata1 = new UserData();
        public UserData edata2 = new UserData();

        public Calcuration[] ringsData = new Calcuration[7];


        public MainContentPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainInit();
        }

        private void MainInit()
        {
            config = CommonInstance.getInstance().config;
            setting = CommonInstance.getInstance().settings;
            calc = CommonInstance.getInstance().calc;

            ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
= calc.ReCalc(config, setting[0], new UserData());

            UserDataView.DataContext = new MainWindowUserDataViewModel();
            //            InfoFrame.Navigate(typeof(MainListPage), new CuspList() { planetList = ringsData[0].planetData, cusps = ringsData[0].cusps });

            cuspList = new CuspList { planetList = ringsData[0].planetData, cusps = ringsData[0].cusps };
            PlanetCusp.DataContext = vm1;
            HouseCusp.DataContext = vm2;
            ListRender();

            // timesetter部はwebviewにする
            DateWeb.Navigate(new Uri("ms-appdata:///local/system/datetime.html"));

            CanvasRender();
        }

        public async void CallScript()
        {
//            await Web.InvokeScriptAsync("init", new string[] {"aaaaa"});
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PlanetCusp.Width = (UserBoxPanel.ActualWidth / 2) - 30;
            HouseCusp.Width = (UserBoxPanel.ActualWidth / 2) - 30;

        }

        private void Web_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
        }

        private void Web_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
//            CallScript();

        }

        private void TimeSetterNow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DateWeb_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {

        }

        private void CanvasRender()
        {
            double margin = 20;
            double outerDiameter = 600;
            double zodiacWidth = 60;
            double innerDiameter = outerDiameter - zodiacWidth;
            double centerRadius = 360;
            string[] signs = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
            string[] planets = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "O", "L" };
            ChartCanvas.Children.Clear();

            Ellipse circle = new Ellipse();
            circle.Width = outerDiameter;
            circle.Height = outerDiameter;
            circle.Stroke = new SolidColorBrush(Colors.Black);
            circle.Fill = new SolidColorBrush(Colors.White);
            circle.SetValue(Canvas.LeftProperty, margin);
            circle.SetValue(Canvas.TopProperty, margin);
            ChartCanvas.Children.Add(circle);

            Ellipse innerCircle = new Ellipse();
            innerCircle.Width = innerDiameter;
            innerCircle.Height = innerDiameter;
            innerCircle.Stroke = new SolidColorBrush(Colors.Black);
            innerCircle.Fill = new SolidColorBrush(Colors.White);
            innerCircle.SetValue(Canvas.LeftProperty, margin + zodiacWidth / 2);
            innerCircle.SetValue(Canvas.TopProperty, margin + zodiacWidth / 2);
            ChartCanvas.Children.Add(innerCircle);
//            Assembly asm = Assembly.Load();
            /*
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            SKManagedStream stream = new SKManagedStream(asm.GetManifestResourceStream("microcosm.system.AstroDotBasic.ttf"));
            */

            TextBlock symbol = new TextBlock();
            symbol.FontFamily = new FontFamily("ms-appx:///Assets/AstroDotBasic.ttf#AstroDotBasic");
            symbol.Text = "a";
            symbol.Foreground = new SolidColorBrush(Colors.Black);
            symbol.SetValue(Canvas.LeftProperty, margin + zodiacWidth / 2);
            symbol.SetValue(Canvas.TopProperty, margin + zodiacWidth / 2);
            ChartCanvas.Children.Add(symbol);
        }

        private void ListRender()
        {
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

            vm2.houseCuspList = new ObservableCollection<HouseCuspListData>();
            for (int i = 1; i < 13; i++)
            {
                HouseCuspListData hcusp = new HouseCuspListData();
                hcusp.name = i.ToString();
                if (CommonInstance.getInstance().config.decimalDisp == EDecimalDisp.DECIMAL)
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

        }
    }
}
