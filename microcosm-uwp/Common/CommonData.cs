using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public static class CommonData
    {
        public static int[] target_numbers = {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            11, 13, 14, 15,
            17, 18, 19, 20,
            100377, 146108, 146199, 146472
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
        public const int ZODIAC_NUMBER_PARAS = 18;
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
                    return "L";
                case ZODIAC_NUMBER_EARTH:
                    return "O";
                case ZODIAC_NUMBER_CHIRON:
                    return "U";
                case ZODIAC_NUMBER_LILITH:
                    return "T";
                case ZODIAC_NUMBER_ERIS:
                    return "E";
                case ZODIAC_NUMBER_SEDNA:
                    return "S";
                case ZODIAC_NUMBER_HAUMEA:
                    return "H";
                case ZODIAC_NUMBER_MAKEMAKE:
                    return "M";
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
