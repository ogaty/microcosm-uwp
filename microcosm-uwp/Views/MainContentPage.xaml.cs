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
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

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

            UserData udata = new UserData();

            ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
= calc.ReCalc(config, setting[0], udata);

            UserDataView.DataContext = new MainWindowUserDataViewModel();
            //            InfoFrame.Navigate(typeof(MainListPage), new CuspList() { planetList = ringsData[0].planetData, cusps = ringsData[0].cusps });

            cuspList = new CuspList { planetList = ringsData[0].planetData, cusps = ringsData[0].cusps };
            //PlanetCusp.DataContext = vm1;
            //HouseCusp.DataContext = vm2;
            //ListRender();

            // timesetter部はwebviewにする
            // DateWeb.Navigate(new Uri("ms-appdata:///local/system/datetime.html"));

            var now = DateTime.Now;
            TargetYear.Text = now.Year.ToString();
            TargetMonth.Text = now.Month.ToString();
            TargetDay.Text = now.Day.ToString();
            TargetHour.Text = now.Hour.ToString();
            TargetMinute.Text = now.Minute.ToString();
            TargetSecond.Text = now.Second.ToString();
            TargetLat.Text = udata.lat.ToString();
            TargetLng.Text = udata.lng.ToString();
            CanvasRender(cuspList);
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

        private void CanvasRender(CuspList cuspList)
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

            // 中央円
            Ellipse innerCircle = new Ellipse();
            innerCircle.Width = innerDiameter;
            innerCircle.Height = innerDiameter;
            innerCircle.Stroke = new SolidColorBrush(Colors.Black);
            innerCircle.Fill = new SolidColorBrush(Colors.White);
            innerCircle.SetValue(Canvas.LeftProperty, margin + zodiacWidth / 2);
            innerCircle.SetValue(Canvas.TopProperty, margin + zodiacWidth / 2);
            ChartCanvas.Children.Add(innerCircle);

            // カスプ、獣帯上の天体
            DrawCusp((int)(outerDiameter / 2), margin, cuspList);
            DrawSigns((int)(outerDiameter / 2), margin);
            DrawPlanets((int)(outerDiameter / 2), margin);

            Ellipse centerCircle = new Ellipse();
            centerCircle.Width = centerDiameter;
            centerCircle.Height = centerDiameter;
            centerCircle.Stroke = new SolidColorBrush(Colors.Black);
            centerCircle.Fill = new SolidColorBrush(Colors.White);
            centerCircle.SetValue(Canvas.LeftProperty, margin + (outerDiameter - centerDiameter) / 2);
            centerCircle.SetValue(Canvas.TopProperty, margin + (outerDiameter - centerDiameter) / 2);
            ChartCanvas.Children.Add(centerCircle);

            DrawAspects((int)(outerDiameter / 2), margin);
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

        public void DrawCusp(int radius, int margin, CuspList cuspList)
        {
            for (var i = 1; i <= 6; i++)
            {
                var newPtStart = Rotate(radius, 0, cuspList.cusps[i] - cuspList.cusps[1]);
                var newPtEnd = Rotate(radius, 0, cuspList.cusps[i] - cuspList.cusps[1] + 180);

                Line line = new Line()
                {
                    StrokeThickness = 2,
                    X1 = newPtStart.X + radius + margin,
                    Y1 =  -1 * newPtStart.Y + radius + margin,
                    X2 = newPtEnd.X + radius + margin,
                    Y2 = -1 * newPtEnd.Y + radius + margin
                };
                if (i % 3 == 1)
                {
                    line.Stroke = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    line.Stroke = new SolidColorBrush(Colors.LightGray);
                }
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

        public void DrawPlanets(int radius, int margin)
        {
            double[] cusps = new double[] { 1, 2, 3 };
            string[] signs = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
            int[] box = new int[72];
            int planetOffset = 0;
            IOrderedEnumerable<PlanetData> sortPlanetData = ringsData[0].planetData.OrderBy(planetTmp => planetTmp.absolute_position);
            foreach (PlanetData planet in sortPlanetData)
            {
                // 重ならないようにずらしを入れる
                // 1サインに6度単位5個までデータが入る
                int index = (int)(planet.absolute_position / 5);
                if (box[index] == 1)
                {
                    while (box[index] == 1)
                    {
                        index++;
                        if (index == 72)
                        {
                            index = 0;
                        }
                    }
                    box[index] = 1;
                }
                else
                {
                    box[index] = 1;
                }

                // 天体そのもの
                planetOffset = 120;

                var newPtStart = Rotate(radius - 50, 0, 5 * index - ringsData[0].cusps[1]);
                TextBlock symbol = new TextBlock();
                symbol.FontFamily = new FontFamily("ms-appx:///Assets/astro.ttf#astro");
                symbol.FontSize = 16;
                symbol.Text = CommonData.getPlanetSymbol(planet.no);
                symbol.Foreground = new SolidColorBrush(Colors.Black);
                symbol.SetValue(Canvas.LeftProperty, newPtStart.X + radius + margin - 3);
                symbol.SetValue(Canvas.TopProperty, -1 * newPtStart.Y + radius + margin - 5);
                ChartCanvas.Children.Add(symbol);

                // 天体度数
                var newDegreePtStart = Rotate(radius - 80, 0, 5 * index - ringsData[0].cusps[1]);
                TextBlock symbolDegree = new TextBlock();
                symbolDegree.Text = ((int)(planet.absolute_position % 30)).ToString();
                symbol.FontSize = 10;
                symbolDegree.Foreground = new SolidColorBrush(Colors.Black);
                symbolDegree.SetValue(Canvas.LeftProperty, newDegreePtStart.X + radius + margin - 3);
                symbolDegree.SetValue(Canvas.TopProperty, -1 * newDegreePtStart.Y + radius + margin - 5);
                ChartCanvas.Children.Add(symbolDegree);
            }
        }

        public void DrawAspects(int radius, int margin)
        {
            double startRingX = 100;
            double endRingX = 100;

            Line line = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Gray),
                StrokeThickness = 2,
                X1 = 100 + radius + margin,
                Y1 = -1 * 100 + radius + margin,
                X2 = 200 + radius + margin,
                Y2 = -1 * 200 + radius + margin
            };
            ChartCanvas.Children.Add(line);
        }

        // startPosition、endPosition : n-pの線は1-2となる
        // aspectKind1 : aspectを使う 2: secondAspectを使う
        private void aspectRender(double startDegree, Dictionary<int, PlanetData> list,
            int startPosition, int endPosition, int aspectRings,
            int aspectKind)
        {
            if (list == null)
            {
                return;
            }
            double startRingX = tempSettings.zodiacCenter / 2;
            double endRingX = tempSettings.zodiacCenter / 2;
            if (aspectRings == 1)
            {
                // 一重円
                startRingX = tempSettings.zodiacCenter / 2;
                endRingX = tempSettings.zodiacCenter / 2;
            }
            else if (aspectRings == 2)
            {
            }
            else if (aspectRings == 3)
            {
            }

            List<PlanetData> newList = new List<PlanetData>();

            foreach (KeyValuePair<int, PlanetData> pair in list)
            {
                newList.Add(pair.Value);
            }

            for (int i = 0; i < newList.Count; i++)
            {
                if (!newList[i].isAspectDisp)
                {
                    // 表示対象外
                    continue;
                }
                PointF startPoint;
                startPoint = rotate(startRingX, 0, newList[i].absolute_position - startDegree);
                startPoint.X += (float)((rcanvas.outerWidth) / 2);
                startPoint.Y *= -1;
                startPoint.Y += (float)((rcanvas.outerHeight) / 2);
                if (aspectKind == 1)
                {
                    aspectListRender(startDegree, list, newList[i].aspects, startPoint, endRingX, endPosition);
                }
                else if (aspectKind == 2)
                {
                    aspectListRender(startDegree, list, newList[i].secondAspects, startPoint, endRingX, endPosition);
                }
                else if (aspectKind == 3)
                {
                    aspectListRender(startDegree, list, newList[i].thirdAspects, startPoint, endRingX, endPosition);
                }
            }
        }

        // aspectRender サブ関数
        private void aspectListRender(double startDegree, Dictionary<int, PlanetData> list, List<AspectInfo> aspects, PointF startPoint, double endRingX, int endPosition)
        {
            for (int j = 0; j < aspects.Count; j++)
            {
                if (!list[aspects[j].targetPlanetNo].isAspectDisp)
                {
                    continue;
                }
                PointF endPoint;

                endPoint = rotate(endRingX, 0, aspects[j].targetPosition - startDegree);
                endPoint.X += (float)((rcanvas.outerWidth) / 2);
                endPoint.Y *= -1;
                endPoint.Y += (float)((rcanvas.outerHeight) / 2);

                Line aspectLine = new Line()
                {
                    X1 = startPoint.X,
                    Y1 = startPoint.Y,
                    X2 = endPoint.X,
                    Y2 = endPoint.Y
                };
                if (aspects[j].softHard == SoftHard.SOFT)
                {
                    aspectLine.StrokeDashArray = new DoubleCollection();
                    aspectLine.StrokeDashArray.Add(4.0);
                    aspectLine.StrokeDashArray.Add(4.0);
                }
                TextBlock aspectLbl = new TextBlock();
                aspectLbl.Margin = new Thickness(Math.Abs(startPoint.X + endPoint.X) / 2 - 5, Math.Abs(endPoint.Y + startPoint.Y) / 2 - 8, 0, 0);
                if (aspects[j].aspectKind == Aspect.AspectKind.CONJUNCTION)
                {
                    // 描画しない
                }
                else if (aspects[j].aspectKind == Aspect.AspectKind.OPPOSITION)
                {
                    aspectLine.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                    //                    aspectLine.Stroke = System.Windows.Media.Brushes.Red;
                    aspectLbl.Foreground = System.Windows.Media.Brushes.Red;
                    aspectLbl.Text = "☍";
                    aspectLbl.HorizontalAlignment = HorizontalAlignment.Left;
                    aspectLbl.TextAlignment = TextAlignment.Left;
                    aspectLbl.VerticalAlignment = VerticalAlignment.Top;
                }
                else if (aspects[j].aspectKind == Aspect.AspectKind.TRINE)
                {
                    aspectLine.Stroke = System.Windows.Media.Brushes.Orange;
                    aspectLbl.Foreground = System.Windows.Media.Brushes.Orange;
                    aspectLbl.Text = "△";
                    aspectLbl.HorizontalAlignment = HorizontalAlignment.Left;
                    aspectLbl.TextAlignment = TextAlignment.Left;
                    aspectLbl.VerticalAlignment = VerticalAlignment.Top;
                }
                else if (aspects[j].aspectKind == Aspect.AspectKind.SQUARE)
                {
                    aspectLine.Stroke = System.Windows.Media.Brushes.Purple;
                    aspectLbl.Foreground = System.Windows.Media.Brushes.Purple;
                    aspectLbl.Text = "□";
                    aspectLbl.HorizontalAlignment = HorizontalAlignment.Left;
                    aspectLbl.TextAlignment = TextAlignment.Left;
                    aspectLbl.VerticalAlignment = VerticalAlignment.Top;

                }
                else if (aspects[j].aspectKind == Aspect.AspectKind.SEXTILE)
                {
                    aspectLine.Stroke = System.Windows.Media.Brushes.Green;
                    aspectLbl.Foreground = System.Windows.Media.Brushes.Green;
                    aspectLbl.Text = "⚹";
                    aspectLbl.HorizontalAlignment = HorizontalAlignment.Left;
                    aspectLbl.TextAlignment = TextAlignment.Left;
                    aspectLbl.VerticalAlignment = VerticalAlignment.Top;
                }
                else if (aspects[j].aspectKind == Aspect.AspectKind.INCONJUNCT)
                {
                    aspectLine.Stroke = System.Windows.Media.Brushes.Gray;
                    aspectLbl.Foreground = System.Windows.Media.Brushes.Gray;
                    aspectLbl.Text = "⚻";
                    aspectLbl.HorizontalAlignment = HorizontalAlignment.Left;
                    aspectLbl.TextAlignment = TextAlignment.Left;
                    aspectLbl.VerticalAlignment = VerticalAlignment.Top;
                }
                else
                {
                    aspectLine.Stroke = System.Windows.Media.Brushes.Black;
                    aspectLbl.Foreground = System.Windows.Media.Brushes.Black;
                    aspectLbl.Text = "⚼";
                    aspectLbl.HorizontalAlignment = HorizontalAlignment.Left;
                    aspectLbl.TextAlignment = TextAlignment.Left;
                    aspectLbl.VerticalAlignment = VerticalAlignment.Top;
                }
                aspectLbl.Tag = aspects[j];
                aspectLine.MouseEnter += new MouseEventHandler(aspectMouseEnter);
                aspectLine.Tag = aspects[j];
                ringCanvas.Children.Add(aspectLine);
                ringCanvas.Children.Add(aspectLbl);

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

        private async void abc_Click(object sender, RoutedEventArgs e)
        {
            var currentViewId = ApplicationView.GetForCurrentView().Id;
            await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                Window.Current.Content = new Frame();
                ((Frame)Window.Current.Content).Navigate(typeof(BlankPage1));
                Window.Current.Activate();
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                    ApplicationView.GetApplicationViewIdForWindow(Window.Current.CoreWindow),
                    ViewSizePreference.Default,
                    currentViewId,
                    ViewSizePreference.Default);
            });
        }
    }
}
