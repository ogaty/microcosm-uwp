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
            int margin = 30;
            double outerDiameter = 500;
            if (config.size < 3)
            {
                outerDiameter = 480;
            }
            double zodiacWidth = 60;
            double innerDiameter = outerDiameter - zodiacWidth;
            double centerDiameter = 300;
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

            DrawCusp((int)(outerDiameter / 2), margin);
            DrawSigns((int)(outerDiameter / 2), margin);

            Ellipse centerCircle = new Ellipse();
            centerCircle.Width = centerDiameter;
            centerCircle.Height = centerDiameter;
            centerCircle.Stroke = new SolidColorBrush(Colors.Black);
            centerCircle.Fill = new SolidColorBrush(Colors.White);
            centerCircle.SetValue(Canvas.LeftProperty, margin + (outerDiameter - centerDiameter) / 2);
            centerCircle.SetValue(Canvas.TopProperty, margin + (outerDiameter - centerDiameter) / 2);
            ChartCanvas.Children.Add(centerCircle);

        }

        private void ListRender()
        {
            vm1.planetCuspList = new ObservableCollection<PlanetCuspListData>();
            string[] signs = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };

            foreach (PlanetData p in cuspList.planetList)
            {
                PlanetCuspListData pcusp = new PlanetCuspListData()
                {
//                    name = Util.getPlanetSymbol(p.no)
                    name = Util.getPlanetAlpha(p.no),
                    degree1 = Util.getPlanetDegree(p.absolute_position, CommonInstance.getInstance().config.decimalDisp)
                };
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

        public void DrawCusp(int radius, int margin)
        {
            for (var i = 0; i < 6; i++)
            {
                var newPtStart = Rotate(radius, 0, 30 * i);
                var newPtEnd = Rotate(radius, 0, 30 * i + 180);

                Line line = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 2,
                    X1 = newPtStart.X + radius + margin,
                    Y1 =  -1 * newPtStart.Y + radius + margin,
                    X2 = newPtEnd.X + radius + margin,
                    Y2 = -1 * newPtEnd.Y + radius + margin
                };
                ChartCanvas.Children.Add(line);
            }
        }

        public void DrawSigns(int radius, int margin)
        {
            double[] cusps = new double[] { 1, 2, 3 };
            string[] signs = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l"};
            for (var i = 0; i < 12; i++)
            {
                var newPtStart = Rotate(radius - 16, 0, 30 * i + 17 - cusps[1]);

                TextBlock symbol = new TextBlock();
                symbol.FontFamily = new FontFamily("ms-appx:///Assets/AstroDotBasic.ttf#AstroDotBasic");
                symbol.Text = signs[i];
                symbol.Foreground = new SolidColorBrush(Colors.Black);
                symbol.SetValue(Canvas.LeftProperty, newPtStart.X + radius + margin - 3);
                symbol.SetValue(Canvas.TopProperty, -1 * newPtStart.Y + radius + margin - 5);
                ChartCanvas.Children.Add(symbol);
            }
        }


        public Point Rotate(double x, double y, double degree)
        {
            degree += 180.0;
            double rad = (degree / 180.0) * Math.PI;
            double newX = x * Math.Cos(rad) - y * Math.Sin(rad);
            double newY = x * Math.Sin(rad) + y * Math.Cos(rad);

            return new Point(newX, newY);
        }


        private void DateWeb_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }
    }
}
