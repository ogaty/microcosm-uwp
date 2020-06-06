using microcosm.Calc;
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
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    udata1.birth_year = TargetDate.Date.Year;
                    udata1.birth_month = TargetDate.Date.Month;
                    udata1.birth_day = TargetDate.Date.Day;
                    udata1.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    udata1.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    udata1.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    udata1.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_year = TargetDate.Date.Year;
                    udata2.birth_month = TargetDate.Date.Month;
                    udata2.birth_day = TargetDate.Date.Day;
                    udata2.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    udata2.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    udata2.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    udata2.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_year = TargetDate.Date.Year;
                    edata1.birth_month = TargetDate.Date.Month;
                    edata1.birth_day = TargetDate.Date.Day;
                    edata1.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    edata1.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    edata1.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    edata1.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_year = TargetDate.Date.Year;
                    edata2.birth_month = TargetDate.Date.Month;
                    edata2.birth_day = TargetDate.Date.Day;
                    edata2.birth_hour = Int32.Parse(TargetHour.SelectedItem.ToString());
                    edata2.birth_minute = Int32.Parse(TargetMinute.SelectedItem.ToString());
                    edata2.birth_second = Int32.Parse(TargetSecond.SelectedItem.ToString());
                    edata2.birth_time = new DateTime(
                        TargetDate.Date.Year,
                        TargetDate.Date.Month,
                        TargetDate.Date.Day,
                        Int32.Parse(TargetHour.SelectedItem.ToString()),
                        Int32.Parse(TargetMinute.SelectedItem.ToString()),
                        Int32.Parse(TargetSecond.SelectedItem.ToString())
                    );
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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

            ReportRender();
        }


        private void MoveDateRight_Click(object sender, RoutedEventArgs e)
        {
            if (MoveDate.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddDays(Int32.Parse(MoveDate.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );

                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddDays(Int32.Parse(MoveDate.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddDays(Int32.Parse(MoveDate.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddDays(Int32.Parse(MoveDate.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            if (MoveDate.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );
                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddDays(-1 * Int32.Parse(MoveDate.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            if (MoveHour.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );

                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddHours(-1 * Int32.Parse(MoveHour.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            if (MoveHour.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddHours(Int32.Parse(MoveHour.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );

                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddHours(Int32.Parse(MoveHour.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddHours(Int32.Parse(MoveHour.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddHours(Int32.Parse(MoveHour.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            if (MoveMinute.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );
                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddMinutes(-1 * Int32.Parse(MoveMinute.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            if (MoveMinute.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );
                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddMinutes(Int32.Parse(MoveMinute.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            if (MoveSecond.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );
                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddSeconds(-1 * Int32.Parse(MoveSecond.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            if (MoveSecond.Text == "")
                return;
            switch (ChangeTarget.SelectedItem)
            {
                case "ユーザー1":
                    SetUdata1(
                        udata1.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text)),
                        udata1.birth_time.Year,
                        udata1.birth_time.Month,
                        udata1.birth_time.Day
                        );
                    udata1.birth_hour = udata1.birth_time.Hour;
                    udata1.birth_minute = udata1.birth_time.Minute;
                    udata1.birth_second = udata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata1);
                    UserBoxSet(1, udata1);
                    break;
                case "ユーザー2":
                    udata2.birth_time = udata2.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text));
                    udata2.birth_year = udata2.birth_time.Year;
                    udata2.birth_month = udata2.birth_time.Month;
                    udata2.birth_day = udata2.birth_time.Day;
                    udata2.birth_hour = udata2.birth_time.Hour;
                    udata2.birth_minute = udata2.birth_time.Minute;
                    udata2.birth_second = udata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, udata2);
                    UserBoxSet(2, udata2);
                    break;
                case "イベント1":
                    edata1.birth_time = edata1.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text));
                    edata1.birth_year = edata1.birth_time.Year;
                    edata1.birth_month = edata1.birth_time.Month;
                    edata1.birth_day = edata1.birth_time.Day;
                    edata1.birth_hour = edata1.birth_time.Hour;
                    edata1.birth_minute = edata1.birth_time.Minute;
                    edata1.birth_second = edata1.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata1);
                    UserBoxSet(3, edata1);
                    break;
                case "イベント2":
                    edata2.birth_time = edata2.birth_time.AddSeconds(Int32.Parse(MoveSecond.Text));
                    edata2.birth_year = edata2.birth_time.Year;
                    edata2.birth_month = edata2.birth_time.Month;
                    edata2.birth_day = edata2.birth_time.Day;
                    edata2.birth_hour = edata2.birth_time.Hour;
                    edata2.birth_minute = edata2.birth_time.Minute;
                    edata2.birth_second = edata2.birth_time.Second;
                    ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6]
                        = calc.ReCalc(config, currentSetting, edata2);
                    UserBoxSet(4, edata2);
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
            udata1.birth_time = birth_time;
            udata1.birth_year = birth_year;
            udata1.birth_month = birth_month;
            udata1.birth_day = birth_day;
        }

    }
}
