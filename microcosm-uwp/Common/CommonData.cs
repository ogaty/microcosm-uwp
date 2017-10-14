using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Common
{
    public static class CommonData
    {
        public static int[] target_numbers = {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            11, 13, 14, 15,
            17, 18, 19, 20,
            10000, 10001,
            90377, 136108, 136199, 136472
        };

        const double TIMEZONE_JST = 9.0;
        const double TIMEZONE_GMT = 0.0;

        const int ZODIAC_NUMBER_SUN = 0;
        const int ZODIAC_NUMBER_MOON = 1;
        const int ZODIAC_NUMBER_MERCURY = 2;
        const int ZODIAC_NUMBER_VENUS = 3;
        const int ZODIAC_NUMBER_MARS = 4;
        const int ZODIAC_NUMBER_JUPITER = 5;
        const int ZODIAC_NUMBER_SATURN = 6;
        const int ZODIAC_NUMBER_URANUS = 7;
        const int ZODIAC_NUMBER_NEPTUNE = 8;
        const int ZODIAC_NUMBER_PLUTO = 9;

        const int ZODIAC_NUMBER_DH_TRUENODE = 11;
        const int ZODIAC_NUMBER_DT_OSCULATE_APOGEE = 13;
        const int ZODIAC_NUMBER_LILITH = 13; // 小惑星のリリス(1181)と混同しないこと
        const int ZODIAC_NUMBER_EARTH = 14;
        const int ZODIAC_NUMBER_CHIRON = 15;
        const int ZODIAC_NUMBER_CELES = 17;
        const int ZODIAC_NUMBER_PARAS = 18;
        const int ZODIAC_NUMBER_JUNO = 19;
        const int ZODIAC_NUMBER_VESTA = 20;

        const int ZODIAC_NUMBER_ASC = 10000;
        const int ZODIAC_NUMBER_MC = 10001;

        const int ZODIAC_NUMBER_SEDNA = 90377;
        const int ZODIAC_NUMBER_HAUMEA = 136108;
        const int ZODIAC_NUMBER_ERIS = 136199;
        const int ZODIAC_NUMBER_MAKEMAKE = 136472;
    }
}
