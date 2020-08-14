using microcosm.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace microcosm.Common
{
    public enum OrbKind
    {
        SUN_HARD_1ST = 0,
        SUN_SOFT_1ST = 1,
        SUN_HARD_2ND = 2,
        SUN_SOFT_2ND = 3,
        SUN_HARD_150 = 4,
        SUN_SOFT_150 = 5,
        MOON_HARD_1ST = 6,
        MOON_SOFT_1ST = 7,
        MOON_HARD_2ND = 8,
        MOON_SOFT_2ND = 9,
        MOON_HARD_150 = 10,
        MOON_SOFT_150 = 11,
        OTHER_HARD_1ST = 12,
        OTHER_SOFT_1ST = 13,
        OTHER_HARD_2ND = 14,
        OTHER_SOFT_2ND = 15,
        OTHER_HARD_150 = 16,
        OTHER_SOFT_150 = 17
    }

    public enum Signs
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

    public enum ECentric
    {
        GEO_CENTRIC = 0,
        HELIO_CENTRIC = 1
    }
    public enum ESidereal
    {
        TROPICAL = 0,
        SIDEREAL = 1
    }
    public enum EProgression
    {
        PRIMARY = 0,
        SECONDARY = 1,
        CPS = 2
    }
    public enum EHouseCalc
    {
        PLACIDUS = 0,
        KOCH = 1,
        CAMPANUS = 2,
        EQUAL = 3,
        PORPHYRY = 4,
        REGIOMONTANUS = 5,
        SOLAR = 6,
        SOLARSIGN = 7
    }
    public enum EDecimalDisp
    {
        DECIMAL = 0,
        DEGREE = 1
    }
    public enum EDispPetern
    {
        FULL = 0,
        MINI = 1
    }
    public enum EColor29
    {
        NOCHANGE = 0,
        CHANGE = 1
    }


    public static class CommonData
    {
        public static int[] target_numbers = {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            11, 13, 14, 15,
            17, //CERES
            18, //PALLAS 
            19, //JUNO
            20  //VESTA
//            100377, 146108, 146199, 146472
        };

        public const double TIMEZONE_JST = 9.0;
        public const double TIMEZONE_GMT = 0.0;

        public const int ZODIAC_NUMBER_SUN = 0;
        public const int ZODIAC_NUMBER_MOON = 1;
        public const int ZODIAC_NUMBER_MERCURY = 2;
        public const int ZODIAC_NUMBER_VENUS = 3;
        public const int ZODIAC_NUMBER_MARS = 4;
        public const int ZODIAC_NUMBER_JUPITER = 5;
        public const int ZODIAC_NUMBER_SATURN = 6;
        public const int ZODIAC_NUMBER_URANUS = 7;
        public const int ZODIAC_NUMBER_NEPTUNE = 8;
        public const int ZODIAC_NUMBER_PLUTO = 9;

        public const int ZODIAC_NUMBER_DH_TRUENODE = 11;
        public const int ZODIAC_NUMBER_DT_OSCULATE_APOGEE = 13;
        public const int ZODIAC_NUMBER_LILITH = 13; // 小惑星のリリス(1181)と混同しないこと
        public const int ZODIAC_NUMBER_EARTH = 14;
        public const int ZODIAC_NUMBER_CHIRON = 15;
        public const int ZODIAC_NUMBER_CERES = 17;
        public const int ZODIAC_NUMBER_PALLAS = 18;
        public const int ZODIAC_NUMBER_JUNO = 19;
        public const int ZODIAC_NUMBER_VESTA = 20;

        public const int ZODIAC_NUMBER_ASC = 10000;
        public const int ZODIAC_NUMBER_MC = 10001;

        public const int ZODIAC_NUMBER_SEDNA = 90377;
        public const int ZODIAC_NUMBER_HAUMEA = 136108;
        public const int ZODIAC_NUMBER_ERIS = 136199;
        public const int ZODIAC_NUMBER_MAKEMAKE = 136472;

        public const int ZODIAC_NUMBER_VT = 10003;
        public const int ZODIAC_NUMBER_POF = -1;

        public static double defaultLat = 35.670587;
        public static double defaultLng = 139.772003;


        /// <summary>
        /// 番号を引数に天体のシンボルを返す
        /// </summary>
        /// <param name="number">天体番号</param>
        /// <returns></returns>
        public static string getPlanetSymbol(int number)
        {
            switch (number)
            {
                case ZODIAC_NUMBER_SUN:
                    return "A";
                case ZODIAC_NUMBER_MOON:
                    return "B";
                case ZODIAC_NUMBER_MERCURY:
                    return "C";
                case ZODIAC_NUMBER_VENUS:
                    return "D";
                case ZODIAC_NUMBER_MARS:
                    return "E";
                case ZODIAC_NUMBER_JUPITER:
                    return "F";
                case ZODIAC_NUMBER_SATURN:
                    return "G";
                case ZODIAC_NUMBER_URANUS:
                    return "H";
                case ZODIAC_NUMBER_NEPTUNE:
                    return "I";
                case ZODIAC_NUMBER_PLUTO:
                    return "J";
                case ZODIAC_NUMBER_DH_TRUENODE:
                    return "M";
//                    return "K";
                case ZODIAC_NUMBER_EARTH:
                    return "♁";
                    // return "M";
                case ZODIAC_NUMBER_CHIRON:
                    return "Q";
                    // return "N";
                case ZODIAC_NUMBER_LILITH:
                    return "L";
                case ZODIAC_NUMBER_CERES:
                    return "S";
//                    return "O";
                case ZODIAC_NUMBER_PALLAS:
                    return "T";
                    // return "P";
                case ZODIAC_NUMBER_JUNO:
                    return "U";
                    // return "Q";
                case ZODIAC_NUMBER_VESTA:
                    return "V";
                    // return "R";
                case ZODIAC_NUMBER_ERIS:
                    return "X";
                case ZODIAC_NUMBER_SEDNA:
                    return "S";
                case ZODIAC_NUMBER_HAUMEA:
                    return "T";
                case ZODIAC_NUMBER_MAKEMAKE:
                    return "U";
            }
            return "";
        }

        /// <summary>
        /// 番号を引数に天体のシンボルを返す
        /// </summary>
        /// <param name="number">天体番号</param>
        /// <returns></returns>
        public static string getPlanetSymbolUTF(int number)
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
                case CommonData.ZODIAC_NUMBER_PALLAS:
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
        /// 番号を引数に天体の色を返す
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Windows.UI.Color getPlanetColor(int number)
        {
            switch (number)
            {
                case ZODIAC_NUMBER_SUN:
                    return Colors.Olive;
                case ZODIAC_NUMBER_MOON:
                    return Colors.DarkGoldenrod;
                case ZODIAC_NUMBER_MERCURY:
                    return Colors.Purple;
                case ZODIAC_NUMBER_VENUS:
                    return Colors.Green;
                case ZODIAC_NUMBER_MARS:
                    return Colors.Red;
                case ZODIAC_NUMBER_JUPITER:
                    return Colors.Maroon;
                case ZODIAC_NUMBER_SATURN:
                    return Colors.DimGray;
                case ZODIAC_NUMBER_URANUS:
                    return Colors.DarkTurquoise;
                case ZODIAC_NUMBER_NEPTUNE:
                    return Colors.DodgerBlue;
                case ZODIAC_NUMBER_PLUTO:
                    return Colors.DeepPink;
                case ZODIAC_NUMBER_DH_TRUENODE:
                    return Colors.DarkCyan;
                case ZODIAC_NUMBER_EARTH:
                    return Colors.Red;
                case ZODIAC_NUMBER_CHIRON:
                    return Colors.Aqua;
                case ZODIAC_NUMBER_LILITH:
                    return Colors.MediumSeaGreen;
                case ZODIAC_NUMBER_CERES:
                    return Colors.OrangeRed;
                case ZODIAC_NUMBER_PALLAS:
                    return Colors.OrangeRed;
                case ZODIAC_NUMBER_JUNO:
                    return Colors.OrangeRed;
                case ZODIAC_NUMBER_VESTA:
                    return Colors.OrangeRed;
                case ZODIAC_NUMBER_ERIS:
                    return Colors.LawnGreen;
                case ZODIAC_NUMBER_SEDNA:
                    return Colors.LawnGreen;
                case ZODIAC_NUMBER_HAUMEA:
                    return Colors.LawnGreen;
                case ZODIAC_NUMBER_MAKEMAKE:
                    return Colors.LawnGreen;
            }
            return Colors.Black;

        }

        /// <summary>
        /// 天体名をテキストで返す
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string getPlanetText(int number)
        {
            switch (number)
            {
                case ZODIAC_NUMBER_SUN:
                    return "太陽";
                case ZODIAC_NUMBER_MOON:
                    return "月";
                case ZODIAC_NUMBER_MERCURY:
                    return "水星";
                case ZODIAC_NUMBER_VENUS:
                    return "金星";
                case ZODIAC_NUMBER_MARS:
                    return "火星";
                case ZODIAC_NUMBER_JUPITER:
                    return "木星";
                case ZODIAC_NUMBER_SATURN:
                    return "土星";
                case ZODIAC_NUMBER_URANUS:
                    return "天王星";
                case ZODIAC_NUMBER_NEPTUNE:
                    return "海王星";
                case ZODIAC_NUMBER_PLUTO:
                    return "冥王星";
                case ZODIAC_NUMBER_DH_TRUENODE:
                    return "D.H.";
                case ZODIAC_NUMBER_EARTH:
                    return "地球";
                case ZODIAC_NUMBER_CHIRON:
                    return "キロン";
                case ZODIAC_NUMBER_LILITH:
                    return "リリス";
                case ZODIAC_NUMBER_CERES:
                    return "セレス";
                case ZODIAC_NUMBER_PALLAS:
                    return "パラス";
                case ZODIAC_NUMBER_JUNO:
                    return "ジュノー";
                case ZODIAC_NUMBER_VESTA:
                    return "ベスタ";
                case ZODIAC_NUMBER_ERIS:
                    return "エリス";
                case ZODIAC_NUMBER_SEDNA:
                    return "セドナ";
                case ZODIAC_NUMBER_HAUMEA:
                    return "ハウメア";
                case ZODIAC_NUMBER_MAKEMAKE:
                    return "マケマケ";
            }
            return "";
        }

        /// <summary>
        /// 天体をアルファベットで返す
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string getPlanetAlfabet(int number)
        {
            switch (number)
            {
                case CommonData.ZODIAC_NUMBER_SUN:
                    return "A";
                case CommonData.ZODIAC_NUMBER_MOON:
                    return "B";
                case CommonData.ZODIAC_NUMBER_MERCURY:
                    return "C";
                case CommonData.ZODIAC_NUMBER_VENUS:
                    return "D";
                case CommonData.ZODIAC_NUMBER_MARS:
                    return "E";
                case CommonData.ZODIAC_NUMBER_JUPITER:
                    return "F";
                case CommonData.ZODIAC_NUMBER_SATURN:
                    return "G";
                case CommonData.ZODIAC_NUMBER_URANUS:
                    return "H";
                case CommonData.ZODIAC_NUMBER_NEPTUNE:
                    return "I";
                case CommonData.ZODIAC_NUMBER_PLUTO:
                    // 外部フォントだと天文学用のPLUTOになっているのが困りどころ
                    return "J";
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
                case CommonData.ZODIAC_NUMBER_PALLAS:
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
        /// サインをアルファベットで返す
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string getSignAlfabet(int number)
        {
            switch ((Signs)number)
            {
                case Signs.SIGN_ARIES:
                    return "a";
                case Signs.SIGN_TAURUS:
                    return "b";
                case Signs.SIGN_GEMINI:
                    return "c";
                case Signs.SIGN_CANCER:
                    return "d";
                case Signs.SIGN_LEO:
                    return "e";
                case Signs.SIGN_VIRGO:
                    return "f";
                case Signs.SIGN_LIBRA:
                    return "g";
                case Signs.SIGN_SCORPIO:
                    return "h";
                case Signs.SIGN_SAGITTARIUS:
                    return "i";
                case Signs.SIGN_CAPRICORN:
                    return "j";
                case Signs.SIGN_AQUARIUS:
                    return "k";
                case Signs.SIGN_PISCES:
                    return "l";
            }
            return "";
        }

        /// <summary>
        /// 番号を引数にサインのシンボルを返す
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string getSignSymbol(int number)
        {
            switch (number)
            {
                case (int)Signs.SIGN_ARIES:
                    return "\u2648";
                case (int)Signs.SIGN_TAURUS:
                    return "\u2649";
                case (int)Signs.SIGN_GEMINI:
                    return "\u264a";
                case (int)Signs.SIGN_CANCER:
                    return "\u264b";
                case (int)Signs.SIGN_LEO:
                    return "\u264c";
                case (int)Signs.SIGN_VIRGO:
                    return "\u264d";
                case (int)Signs.SIGN_LIBRA:
                    return "\u264e";
                case (int)Signs.SIGN_SCORPIO:
                    return "\u264f";
                case (int)Signs.SIGN_SAGITTARIUS:
                    return "\u2650";
                case (int)Signs.SIGN_CAPRICORN:
                    return "\u2651";
                case (int)Signs.SIGN_AQUARIUS:
                    return "\u2652";
                case (int)Signs.SIGN_PISCES:
                    return "\u2653";
            }
            return "";
        }

        public static string getAspectSymbol(AspectKind kind)
        {
            switch (kind)
            {
                case AspectKind.OPPOSITION:
                    return "n";
                case AspectKind.TRINE:
                    return "p";
                case AspectKind.SQUARE:
                    return "o";
                case AspectKind.SEXTILE:
                    return "q";
                case AspectKind.INCONJUNCT:
                    return "s";
                case AspectKind.SESQUIQUADRATE:
                    return "u";
                case AspectKind.SEMISQUARE:
                    return "t";
                case AspectKind.SEMISEXTILE:
                    return "r";
                case AspectKind.QUINTILE:
                    return "v";
                case AspectKind.BIQUINTILE:
                    return "w";
                case AspectKind.SEMIQINTILE:
                    return "SQ";
                case AspectKind.NOVILE:
                    return "N";
                case AspectKind.SEPTILE:
                    return "S";
            }
            return "";

        }



    }
}
