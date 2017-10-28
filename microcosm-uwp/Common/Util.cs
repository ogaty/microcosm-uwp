using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Common
{
    public static class Util
    {
        public static string DateTimeToString(DateTime dateTime, string timezone)
        {
            string year = dateTime.Year.ToString();
            string month = dateTime.Month.ToString();
            string day = dateTime.Day.ToString();
            string hour = dateTime.Hour.ToString();
            string minute = dateTime.Minute.ToString();
            string second = dateTime.Second.ToString();

            // todo あとでstringformatに
            return year + "年" + month + "月" + day + "日" + 
                " " + 
                hour + "時" + minute + "分" + second + "秒" + " " + timezone;
        }

        /// <summary>
        /// 番号を引数に天体のシンボルを返す
        /// </summary>
        /// <param name="number">天体番号</param>
        /// <returns></returns>
        public static string getPlanetSymbol(int number)
        {
            switch (number)
            {
                case CommonData.ZODIAC_NUMBER_SUN:
                    return "\u2609";
                case CommonData.ZODIAC_NUMBER_MOON:
                    return "\u263d";
                case CommonData.ZODIAC_NUMBER_MERCURY:
                    return "\u263f";
                case CommonData.ZODIAC_NUMBER_VENUS:
                    return "\u2640";
                case CommonData.ZODIAC_NUMBER_MARS:
                    return "\u2642";
                case CommonData.ZODIAC_NUMBER_JUPITER:
                    return "\u2643";
                case CommonData.ZODIAC_NUMBER_SATURN:
                    return "\u2644";
                case CommonData.ZODIAC_NUMBER_URANUS:
                    return "\u2645";
                case CommonData.ZODIAC_NUMBER_NEPTUNE:
                    return "\u2646";
                case CommonData.ZODIAC_NUMBER_PLUTO:
                    return "\u2647";
                // 外部フォントだと天文学用のPLUTOになっているのが困りどころ
                case CommonData.ZODIAC_NUMBER_DH_TRUENODE:
                    return "\u260a";
                case CommonData.ZODIAC_NUMBER_EARTH:
                    return "\u2641";
                case CommonData.ZODIAC_NUMBER_CHIRON:
                    return "\u26b7";
                case CommonData.ZODIAC_NUMBER_LILITH:
                    return "\u26b8";
                case CommonData.ZODIAC_NUMBER_ERIS:
                    return "\u2641";
            }
            return number.ToString();
        }

    }
}
