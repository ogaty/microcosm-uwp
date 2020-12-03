using microcosm.Calc;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace microcosm.Views
{
    partial class MainContentPage
    {
        /// <summary>
        /// TimeSetterクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetSet_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    CommonInstance.getInstance().udata1.birth_year = TargetDate.Date.Year;
                    CommonInstance.getInstance().udata1.birth_month = TargetDate.Date.Month;
                    CommonInstance.getInstance().udata1.birth_day = TargetDate.Date.Day;
                    CommonInstance.getInstance().udata1.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    CommonInstance.getInstance().udata1.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    CommonInstance.getInstance().udata1.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    CommonInstance.getInstance().udata1.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_year = TargetDate.Date.Year;
                    CommonInstance.getInstance().udata2.birth_month = TargetDate.Date.Month;
                    CommonInstance.getInstance().udata2.birth_day = TargetDate.Date.Day;
                    CommonInstance.getInstance().udata2.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    CommonInstance.getInstance().udata2.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    CommonInstance.getInstance().udata2.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    CommonInstance.getInstance().udata2.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_year = TargetDate.Date.Year;
                    CommonInstance.getInstance().edata1.birth_month = TargetDate.Date.Month;
                    CommonInstance.getInstance().edata1.birth_day = TargetDate.Date.Day;
                    CommonInstance.getInstance().edata1.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    CommonInstance.getInstance().edata1.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    CommonInstance.getInstance().edata1.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    CommonInstance.getInstance().edata1.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_year = TargetDate.Date.Year;
                    CommonInstance.getInstance().edata2.birth_month = TargetDate.Date.Month;
                    CommonInstance.getInstance().edata2.birth_day = TargetDate.Date.Day;
                    CommonInstance.getInstance().edata2.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    CommonInstance.getInstance().edata2.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    CommonInstance.getInstance().edata2.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    CommonInstance.getInstance().edata2.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
            ListRender();

            ReportRender();
        }


        private void MoveDateRight_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveDate.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddDays(Int32.Parse(MoveDate.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );

                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddDays(Int32.Parse(MoveDate.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddDays(Int32.Parse(MoveDate.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddDays(Int32.Parse(MoveDate.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
            ListRender();
            ReportRender();
        }

        private void MoveDateLeft_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveDate.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );
                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
            ListRender();
            ReportRender();
        }

        private void MoveHourLeft_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveHour.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );

                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
        }

        private void MoveHourRight_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveHour.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddHours(Int32.Parse(MoveHour.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );

                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddHours(Int32.Parse(MoveHour.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddHours(Int32.Parse(MoveHour.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddHours(Int32.Parse(MoveHour.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
        }

        private void MoveMinuteLeft_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveMinute.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );
                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
        }

        private void MoveMinuteRight_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveMinute.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );
                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
        }

        private void MoveSecondLeft_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveSecond.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );
                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
        }

        private void MoveSecondRight_Click(object sender, RoutedEventArgs e)
        {
            ConfigData config = CommonInstance.getInstance().config;
            if (MoveSecond.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        CommonInstance.getInstance().udata1.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text)),
                        CommonInstance.getInstance().udata1.birth_time.Year,
                        CommonInstance.getInstance().udata1.birth_time.Month,
                        CommonInstance.getInstance().udata1.birth_time.Day
                        );
                    CommonInstance.getInstance().udata1.birth_hour = CommonInstance.getInstance().udata1.birth_time.Hour;
                    CommonInstance.getInstance().udata1.birth_minute = CommonInstance.getInstance().udata1.birth_time.Minute;
                    CommonInstance.getInstance().udata1.birth_second = CommonInstance.getInstance().udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata1);
                    UserBoxSet(1, CommonInstance.getInstance().udata1);
                    break;
                case "ユーザー2":
                    CommonInstance.getInstance().udata2.birth_time = CommonInstance.getInstance().udata2.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text));
                    CommonInstance.getInstance().udata2.birth_year = CommonInstance.getInstance().udata2.birth_time.Year;
                    CommonInstance.getInstance().udata2.birth_month = CommonInstance.getInstance().udata2.birth_time.Month;
                    CommonInstance.getInstance().udata2.birth_day = CommonInstance.getInstance().udata2.birth_time.Day;
                    CommonInstance.getInstance().udata2.birth_hour = CommonInstance.getInstance().udata2.birth_time.Hour;
                    CommonInstance.getInstance().udata2.birth_minute = CommonInstance.getInstance().udata2.birth_time.Minute;
                    CommonInstance.getInstance().udata2.birth_second = CommonInstance.getInstance().udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().udata2);
                    UserBoxSet(2, CommonInstance.getInstance().udata2);
                    break;
                case "イベント1":
                    CommonInstance.getInstance().edata1.birth_time = CommonInstance.getInstance().edata1.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text));
                    CommonInstance.getInstance().edata1.birth_year = CommonInstance.getInstance().edata1.birth_time.Year;
                    CommonInstance.getInstance().edata1.birth_month = CommonInstance.getInstance().edata1.birth_time.Month;
                    CommonInstance.getInstance().edata1.birth_day = CommonInstance.getInstance().edata1.birth_time.Day;
                    CommonInstance.getInstance().edata1.birth_hour = CommonInstance.getInstance().edata1.birth_time.Hour;
                    CommonInstance.getInstance().edata1.birth_minute = CommonInstance.getInstance().edata1.birth_time.Minute;
                    CommonInstance.getInstance().edata1.birth_second = CommonInstance.getInstance().edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata1);
                    UserBoxSet(3, CommonInstance.getInstance().edata1);
                    break;
                case "イベント2":
                    CommonInstance.getInstance().edata2.birth_time = CommonInstance.getInstance().edata2.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text));
                    CommonInstance.getInstance().edata2.birth_year = CommonInstance.getInstance().edata2.birth_time.Year;
                    CommonInstance.getInstance().edata2.birth_month = CommonInstance.getInstance().edata2.birth_time.Month;
                    CommonInstance.getInstance().edata2.birth_day = CommonInstance.getInstance().edata2.birth_time.Day;
                    CommonInstance.getInstance().edata2.birth_hour = CommonInstance.getInstance().edata2.birth_time.Hour;
                    CommonInstance.getInstance().edata2.birth_minute = CommonInstance.getInstance().edata2.birth_time.Minute;
                    CommonInstance.getInstance().edata2.birth_second = CommonInstance.getInstance().edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(currentSetting, CommonInstance.getInstance().edata2);
                    UserBoxSet(4, CommonInstance.getInstance().edata2);
                    break;
                default:
                    return;
            }

            // 天体情報を元にカスプを取得
            cuspList = new CuspList
            {
                planetList = ringsData[0].planetData,
                cusps = ringsData[0].cusps
            };

            aspectList = AspectCalc.AspectCalcSame(ringsData[0].planetData, 0);

            // 表示メイン部分
            CanvasRender(cuspList);
        }


        public void SetUdata1(
            DateTime birth_time, 
            int birth_year,
            int birth_month,
            int birth_day)
        {
            CommonInstance.getInstance().udata1.birth_time = birth_time;
            CommonInstance.getInstance().udata1.birth_year = birth_year;
            CommonInstance.getInstance().udata1.birth_month = birth_month;
            CommonInstance.getInstance().udata1.birth_day = birth_day;
        }

    }
}
