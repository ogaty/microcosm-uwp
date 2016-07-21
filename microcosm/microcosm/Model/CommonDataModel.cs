using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace microcosm.Model
{
    public class CommonDataModel
    {
        public const double TIMEZONE_JST = 9.0;
        public const double TIMEZONE_GMT = 0.0;

        public enum PLANETS
        {
            ZODIAC_SUN = 0,
            ZODIAC_MOON = 1,
            ZODIAC_MERCURY = 2,
            ZODIAC_VENUS = 3,
            ZODIAC_MARS = 4,
            ZODIAC_JUPITER = 5,
            ZODIAC_SATURN = 6,
            ZODIAC_URANUS = 7,
            ZODIAC_NEPTUNE = 8,
            ZODIAC_PLUTO = 9,
            ZODIAC_DH_TRUENODE = 11,
            ZODIAC_DT_OSCULATE_APOGEE = 13,
            ZODIAC_EARTH = 14,
            ZODIAC_CHIRON = 15,
            ZODIAC_CELES = 17,
            ZODIAC_PARAS = 18,
            ZODIAC_JUNO = 19,
            ZODIAC_VESTA = 20,
            ZODIAC_LILITH = 1181,
            ZODIAC_ASC = 10000,
            ZODIAC_MC = 10001
        }

        public enum SIGN
        {
            SIGN_ARIES = 0,
            SIGN_TAURUS = 1,
            SIGN_GEMINI = 2,
            SIGN_CANCER = 3,
            SIGN_LEO = 4,
            SIGN_VIRGO = 5,
            SIGN_LIBRA = 6,
            SIGN_SCORPIO = 7,
            SIGN_SAGITTARIUS = 8,
            SIGN_CAPRICORN = 9,
            SIGN_AQUARIUS = 10,
            SIGN_PISCES = 11
        }

        // 番号を引数に天体のシンボルを返す
        public static string getPlanetSymbol(PLANETS number)
        {
            switch (number)
            {
                case PLANETS.ZODIAC_SUN:
                    return "\u2609";
                case PLANETS.ZODIAC_MOON:
                    return "\u263d";
                case PLANETS.ZODIAC_MERCURY:
                    return "\u263f";
                case PLANETS.ZODIAC_VENUS:
                    return "\u2640";
                case PLANETS.ZODIAC_MARS:
                    return "\u2642";
                case PLANETS.ZODIAC_JUPITER:
                    return "\u2643";
                case PLANETS.ZODIAC_SATURN:
                    return "\u2644";
                case PLANETS.ZODIAC_URANUS:
                    return "\u2645";
                case PLANETS.ZODIAC_NEPTUNE:
                    return "\u2646";
                case PLANETS.ZODIAC_PLUTO:
                    return "\u2647";
                // 外部フォントだと天文学用のPLUTOになっているのが困りどころ
                case PLANETS.ZODIAC_DH_TRUENODE:
                    return "\u260a";
                case PLANETS.ZODIAC_EARTH:
                    return "\u2641";
                case PLANETS.ZODIAC_CHIRON:
                    return "\u26b7";
            }
            return "";
        }

        // 番号を引数に天体の文字列を返す
        public static string getPlanetText(PLANETS number)
        {
            switch (number)
            {
                case PLANETS.ZODIAC_SUN:
                    return "太陽";
                case PLANETS.ZODIAC_MOON:
                    return "月";
                case PLANETS.ZODIAC_MERCURY:
                    return "水星";
                case PLANETS.ZODIAC_VENUS:
                    return "金星";
                case PLANETS.ZODIAC_MARS:
                    return "火星";
                case PLANETS.ZODIAC_JUPITER:
                    return "木星";
                case PLANETS.ZODIAC_SATURN:
                    return "土星";
                case PLANETS.ZODIAC_URANUS:
                    return "天王星";
                case PLANETS.ZODIAC_NEPTUNE:
                    return "海王星";
                case PLANETS.ZODIAC_PLUTO:
                    return "冥王星";
                case PLANETS.ZODIAC_DH_TRUENODE:
                    return "ヘッド";
                case PLANETS.ZODIAC_CHIRON:
                    return "キロン";
                case PLANETS.ZODIAC_ASC:
                    return "ASC";
                case PLANETS.ZODIAC_MC:
                    return "MC";
            }
            return "";
        }

        // 番号を引数にサインのシンボルを返す
        public static string getSignSymbol(SIGN number)
        {
            switch (number)
            {
                case SIGN.SIGN_ARIES:
                    return "\u2648";
                case SIGN.SIGN_TAURUS:
                    return "\u2649";
                case SIGN.SIGN_GEMINI:
                    return "\u264a";
                case SIGN.SIGN_CANCER:
                    return "\u264b";
                case SIGN.SIGN_LEO:
                    return "\u264c";
                case SIGN.SIGN_VIRGO:
                    return "\u264d";
                case SIGN.SIGN_LIBRA:
                    return "\u264e";
                case SIGN.SIGN_SCORPIO:
                    return "\u264f";
                case SIGN.SIGN_SAGITTARIUS:
                    return "\u2650";
                case SIGN.SIGN_CAPRICORN:
                    return "\u2651";
                case SIGN.SIGN_AQUARIUS:
                    return "\u2652";
                case SIGN.SIGN_PISCES:
                    return "\u2653";
            }
            return "";
        }

        // 番号を引数に感受点のシンボルを返す
        public static string getSensitiveSymbol(PLANETS number)
        {
            switch (number)
            {
                // UNICODEが無い！
                case PLANETS.ZODIAC_ASC:
                    return "Ac";
                // UNICODEが無い！
                case PLANETS.ZODIAC_MC:
                    return "Mc";
                case PLANETS.ZODIAC_DH_TRUENODE:
                    return "\u260a";
            }
            return "";
        }

        // 番号を引数に感受点の文字列を返す
        public static string getSensitiveText(PLANETS number)
        {
            switch (number)
            {
                case PLANETS.ZODIAC_ASC:
                    return "ASC";
                case PLANETS.ZODIAC_MC:
                    return "MC";
                case PLANETS.ZODIAC_DH_TRUENODE:
                    return "D.H.";
            }
            return "";
        }

        // 番号を引数に天体の色を返す
        public static SolidColorBrush getPlanetColor(PLANETS number)
        {
            if (number == PLANETS.ZODIAC_SUN)
            {
                return new SolidColorBrush(Colors.Olive);
            }
            else if (number == PLANETS.ZODIAC_MOON)
            {
                return new SolidColorBrush(Colors.DarkGoldenrod);
            }
            else if (number == PLANETS.ZODIAC_MERCURY)
            {
                return new SolidColorBrush(Colors.Purple);
            }
            else if (number == PLANETS.ZODIAC_VENUS)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else if (number == PLANETS.ZODIAC_MARS)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if (number == PLANETS.ZODIAC_JUPITER)
            {
                return new SolidColorBrush(Colors.Maroon);
            }
            else if (number == PLANETS.ZODIAC_SATURN)
            {
                return new SolidColorBrush(Colors.DimGray);
            }
            else if (number == PLANETS.ZODIAC_URANUS)
            {
                return new SolidColorBrush(Colors.DarkTurquoise);
            }
            else if (number == PLANETS.ZODIAC_NEPTUNE)
            {
                return new SolidColorBrush(Colors.DodgerBlue);
            }
            else if (number == PLANETS.ZODIAC_PLUTO)
            {
                return new SolidColorBrush(Colors.DeepPink);
            }
            else if (number == PLANETS.ZODIAC_EARTH)
            {
                return new SolidColorBrush(Colors.SkyBlue);
            }
            else if (number == PLANETS.ZODIAC_DH_TRUENODE)
            {
                return new SolidColorBrush(Colors.DarkCyan);
            }
            return new SolidColorBrush(Colors.Black);
        }

    }
}
