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
    public sealed partial class SettingDispName : Page
    {
        public SettingData[] settings;
        private SettingSettingsPage parent;

        public SettingDispName()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            settings = CommonInstance.getInstance().settings;
            parent = (SettingSettingsPage)e.Parameter;

            base.OnNavigatedTo(e);
            SettingInit();
        }

        private void SettingInit()
        {
            setting0.Text = settings[0].dispName;
            setting1.Text = settings[1].dispName;
            setting2.Text = settings[2].dispName;
            setting3.Text = settings[3].dispName;
            setting4.Text = settings[4].dispName;
            setting5.Text = settings[5].dispName;
            setting6.Text = settings[6].dispName;
            setting7.Text = settings[7].dispName;
            setting8.Text = settings[8].dispName;
            setting9.Text = settings[9].dispName;
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            settings[0].dispName = setting0.Text;
            settings[1].dispName = setting1.Text;
            settings[2].dispName = setting2.Text;
            settings[3].dispName = setting3.Text;
            settings[4].dispName = setting4.Text;
            settings[5].dispName = setting5.Text;
            settings[6].dispName = setting6.Text;
            settings[7].dispName = setting7.Text;
            settings[8].dispName = setting8.Text;
            settings[9].dispName = setting9.Text;
            CommonInstance.getInstance().settings = settings;

            //SettingToXml.SaveXml(0, settings[0]);
            for (int i = 0; i < 7; i++)
            {
                SettingToJson.SaveJson(i, settings[i]);
            }

            parent.ResetCombo();
        }
    }
}
