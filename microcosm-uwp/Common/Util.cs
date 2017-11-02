using microcosm.Config;
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
                case CommonData.ZODIAC_NUMBER_CERES:
                    return "\u26B3";
                case CommonData.ZODIAC_NUMBER_PARAS:
                    return "\u26B4";
                case CommonData.ZODIAC_NUMBER_JUNO:
                    return "\u26B5";
                case CommonData.ZODIAC_NUMBER_VESTA:
                    return "\u26B6";
                case CommonData.ZODIAC_NUMBER_VT:
                    return "Vt";
                case CommonData.ZODIAC_NUMBER_POF:
                    return "Pof";
                case CommonData.ZODIAC_NUMBER_SEDNA:
                    return "Se";
                case CommonData.ZODIAC_NUMBER_ERIS:
                    return "Er";
                case CommonData.ZODIAC_NUMBER_HAUMEA:
                    return "Ha";
                case CommonData.ZODIAC_NUMBER_MAKEMAKE:
                    return "Ma";
            }
            return number.ToString();
        }

                /// <summary>
        /// 番号を引数にサインのシンボルを返す
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string getSignSymbol(int number)
        {
            switch ((Signs)number)
            {
                case Signs.SIGN_ARIES:
                    return "\u2648";
                case Signs.SIGN_TAURUS:
                    return "\u2649";
                case Signs.SIGN_GEMINI:
                    return "\u264a";
                case Signs.SIGN_CANCER:
                    return "\u264b";
                case Signs.SIGN_LEO:
                    return "\u264c";
                case Signs.SIGN_VIRGO:
                    return "\u264d";
                case Signs.SIGN_LIBRA:
                    return "\u264e";
                case Signs.SIGN_SCORPIO:
                    return "\u264f";
                case Signs.SIGN_SAGITTARIUS:
                    return "\u2650";
                case Signs.SIGN_CAPRICORN:
                    return "\u2651";
                case Signs.SIGN_AQUARIUS:
                    return "\u2652";
                case Signs.SIGN_PISCES:
                    return "\u2653";
            }
            return "";
        }

        public static string getPlanetDegree(double absolute_position, EDecimalDisp decimalDisp)
        {
            double degree = absolute_position % 30;
            string symbol = getSignSymbol((int)(absolute_position / 30));
            if (decimalDisp == EDecimalDisp.DECIMAL)
            {
                return symbol + String.Format("{0:f2}",degree);
            } else
            {
                return symbol + DecimalToHex(degree).ToString();
            }
        }

        public static double DecimalToHex(string decimalStr)
        {
            double tmp = double.Parse(decimalStr);
            double ftmp = tmp - (int)tmp;
            ftmp = ftmp / 100 * 60;
            int itmp = (int)tmp;
            return itmp + ftmp;
        }

        public static double DecimalToHex(double tmp)
        {
            double ftmp = tmp - (int)tmp;
            ftmp = ftmp / 100 * 60;
            int itmp = (int)tmp;
            return itmp + ftmp;
        }
    }
}
