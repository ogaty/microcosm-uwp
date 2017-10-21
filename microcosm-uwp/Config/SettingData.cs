using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using microcosm.Common;

namespace microcosm.Config
{
    // 複数クラスが存在（0～9）

    public class SettingData
    {
        public SettingXml xmlData;
        public SettingXml2 xmlData2;
        public string dispName { get; set; }

        public bool[] dispCircle = new bool[] {
            true, false, false, false, false, false
        };

        // 0:11～15:45
        public List<Dictionary<AspectKind, bool>> dispAspectCategory;

        // [from, to]
        public bool[,] aspectConjunction;
        public bool[,] aspectOpposition;
        public bool[,] aspectSquare;
        public bool[,] aspectTrine;
        public bool[,] aspectSextile;
        public bool[,] aspectInconjunct;
        public bool[,] aspectSesquiquadrate;
        public bool[,] aspectSemiSextile;
        public bool[,] aspectSemiQuintile;
        public bool[,] aspectSemiSquare;
        public bool[,] aspectNovile;
        public bool[,] aspectSeptile;
        public bool[,] aspectQuintile;
        public bool[,] aspectBiQuintile;
        // [from, to]
        public bool[,] dispAspect;

        // 円ごとなので、配列個数は7
        public List<Dictionary<OrbKind, double>> orbs;
        private double[] orb_sun_soft_1st;
        private double[] orb_sun_soft_2nd;
        private double[] orb_sun_soft_150;
        private double[] orb_sun_hard_1st;
        private double[] orb_sun_hard_2nd;
        private double[] orb_sun_hard_150;
        private double[] orb_moon_soft_1st;
        private double[] orb_moon_soft_2nd;
        private double[] orb_moon_soft_150;
        private double[] orb_moon_hard_1st;
        private double[] orb_moon_hard_2nd;
        private double[] orb_moon_hard_150;
        private double[] orb_other_soft_1st;
        private double[] orb_other_soft_2nd;
        private double[] orb_other_soft_150;
        private double[] orb_other_hard_1st;
        private double[] orb_other_hard_2nd;
        private double[] orb_other_hard_150;

        // 円ごとなので、配列個数は7
        public List<Dictionary<int, bool>> dispPlanet;

        // 11-77まで28個
        public List<Dictionary<int, bool>> dispAspectPlanet;
        private bool[] aspectSun;
        private bool[] aspectMoon;
        private bool[] aspectMercury;
        private bool[] aspectVenus;
        private bool[] aspectMars;
        private bool[] aspectJupiter;
        private bool[] aspectSaturn;
        private bool[] aspectUranus;
        private bool[] aspectNeptune;
        private bool[] aspectPluto;
        private bool[] aspectDh;
        private bool[] aspectAsc;
        private bool[] aspectMc;
        private bool[] aspectChiron;
        private bool[] aspectEarth;
        private bool[] aspectLilith;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="no">設定番号</param>
        /// <param name="xml">xmlファイル nullable</param>
        public SettingData(int no, SettingXml xml)
        {
            Init(no, xml);
        }

        public void Init(int no, SettingXml xml)
        {

            if (xml == null)
            {
                xmlData = new SettingXml();
                this.dispName = "表示設定" + no.ToString();
            } else
            {
                xmlData = xml;
                this.dispName = xml.dispname;
            }


            // dispPlanet[subIndex][commonDataNo]
            // 天体を表示
            dispPlanet = new List<Dictionary<int, bool>>();
            // 天体のアスペクトを表示
            dispAspectPlanet = new List<Dictionary<int, bool>>();
            // アスペクト種別の表示
            dispAspectCategory = new List<Dictionary<AspectKind, bool>>();
            // オーブ
            orbs = new List<Dictionary<OrbKind, double>>();

            // N-N、N-P、N-Tのアスペクト
            // dispAspect[0][2] => N-T
            // dispAspect[1][3] => P-4
            // [0][2] と [2][0]は同じ
            dispAspect = new bool[7, 7] {
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true },
                { true, true, true, true, true, true, true }
            };

            InitSet();
        }

        /// <summary>
        /// wpfソースではなぜかMainWindow.csでやっていた
        /// </summary>
        private void InitSet()
        {
            SetDispPlanet();
            SetDispAspectPlanet();
            SetDispAspectCategory();
            SetOrbs();
        }

        public void SetDispPlanet()
        {
            for (int i = 0; i < 7; i++)
            {
                dispPlanet.Add(GetDispPlanetDictionary(i));
            }
        }

        private Dictionary<int, bool> GetDispPlanetDictionary(int n)
        {
            Dictionary<int, bool> dp = new Dictionary<int, bool>();
            dp.Add(CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun11);
            dp.Add(CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon11);
            dp.Add(CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury11);
            dp.Add(CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus11);
            dp.Add(CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars11);
            dp.Add(CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter11);
            dp.Add(CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn11);
            dp.Add(CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus11);
            dp.Add(CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune11);
            dp.Add(CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto11);
            dp.Add(CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh11);
            dp.Add(CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc11);
            dp.Add(CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc11);
            dp.Add(CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron11);
            dp.Add(CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth11);
            dp.Add(CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith11);

            // 新csmだとこれらも増えるよ
            dp.Add(CommonData.ZODIAC_NUMBER_CELES, false);
            dp.Add(CommonData.ZODIAC_NUMBER_PARAS, false);
            dp.Add(CommonData.ZODIAC_NUMBER_JUNO, false);
            dp.Add(CommonData.ZODIAC_NUMBER_VESTA, false);
            // セドナ、エリス、ハウメア、マケマケ
    
            return dp;
        }

        private void Convert(SettingXml oldxml)
        {
            xmlData2 = new SettingXml2();
            double[] localorbs = new double[6];

            localorbs[0] = oldxml.orb_sun_soft_1st_0;
            localorbs[1] = oldxml.orb_sun_soft_1st_1;
            localorbs[2] = oldxml.orb_sun_soft_1st_2;
            localorbs[3] = oldxml.orb_sun_soft_1st_3;
            localorbs[4] = oldxml.orb_sun_soft_1st_4;
            localorbs[5] = oldxml.orb_sun_soft_1st_5;
            xmlData2.orb_sun_soft_1st = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_sun_hard_1st_0;
            localorbs[1] = oldxml.orb_sun_hard_1st_1;
            localorbs[2] = oldxml.orb_sun_hard_1st_2;
            localorbs[3] = oldxml.orb_sun_hard_1st_3;
            localorbs[4] = oldxml.orb_sun_hard_1st_4;
            localorbs[5] = oldxml.orb_sun_hard_1st_5;
            xmlData2.orb_sun_hard_1st = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_moon_soft_1st_0;
            localorbs[1] = oldxml.orb_moon_soft_1st_1;
            localorbs[2] = oldxml.orb_moon_soft_1st_2;
            localorbs[3] = oldxml.orb_moon_soft_1st_3;
            localorbs[4] = oldxml.orb_moon_soft_1st_4;
            localorbs[5] = oldxml.orb_moon_soft_1st_5;
            xmlData2.orb_moon_soft_1st = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_moon_hard_1st_0;
            localorbs[1] = oldxml.orb_moon_hard_1st_1;
            localorbs[2] = oldxml.orb_moon_hard_1st_2;
            localorbs[3] = oldxml.orb_moon_hard_1st_3;
            localorbs[4] = oldxml.orb_moon_hard_1st_4;
            localorbs[5] = oldxml.orb_moon_hard_1st_5;
            xmlData2.orb_moon_hard_1st = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_other_soft_1st_0;
            localorbs[1] = oldxml.orb_other_soft_1st_1;
            localorbs[2] = oldxml.orb_other_soft_1st_2;
            localorbs[3] = oldxml.orb_other_soft_1st_3;
            localorbs[4] = oldxml.orb_other_soft_1st_4;
            localorbs[5] = oldxml.orb_other_soft_1st_5;
            xmlData2.orb_other_soft_1st = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_other_hard_1st_0;
            localorbs[1] = oldxml.orb_other_hard_1st_1;
            localorbs[2] = oldxml.orb_other_hard_1st_2;
            localorbs[3] = oldxml.orb_other_hard_1st_3;
            localorbs[4] = oldxml.orb_other_hard_1st_4;
            localorbs[5] = oldxml.orb_other_hard_1st_5;
            xmlData2.orb_other_hard_1st = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_sun_soft_2nd_0;
            localorbs[1] = oldxml.orb_sun_soft_2nd_1;
            localorbs[2] = oldxml.orb_sun_soft_2nd_2;
            localorbs[3] = oldxml.orb_sun_soft_2nd_3;
            localorbs[4] = oldxml.orb_sun_soft_2nd_4;
            localorbs[5] = oldxml.orb_sun_soft_2nd_5;
            xmlData2.orb_sun_soft_2nd = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_sun_hard_2nd_0;
            localorbs[1] = oldxml.orb_sun_hard_2nd_1;
            localorbs[2] = oldxml.orb_sun_hard_2nd_2;
            localorbs[3] = oldxml.orb_sun_hard_2nd_3;
            localorbs[4] = oldxml.orb_sun_hard_2nd_4;
            localorbs[5] = oldxml.orb_sun_hard_2nd_5;
            xmlData2.orb_sun_hard_2nd = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_moon_soft_2nd_0;
            localorbs[1] = oldxml.orb_moon_soft_2nd_1;
            localorbs[2] = oldxml.orb_moon_soft_2nd_2;
            localorbs[3] = oldxml.orb_moon_soft_2nd_3;
            localorbs[4] = oldxml.orb_moon_soft_2nd_4;
            localorbs[5] = oldxml.orb_moon_soft_2nd_5;
            xmlData2.orb_moon_soft_2nd = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_moon_hard_2nd_0;
            localorbs[1] = oldxml.orb_moon_hard_2nd_1;
            localorbs[2] = oldxml.orb_moon_hard_2nd_2;
            localorbs[3] = oldxml.orb_moon_hard_2nd_3;
            localorbs[4] = oldxml.orb_moon_hard_2nd_4;
            localorbs[5] = oldxml.orb_moon_hard_2nd_5;
            xmlData2.orb_moon_hard_2nd = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_other_soft_2nd_0;
            localorbs[1] = oldxml.orb_other_soft_2nd_1;
            localorbs[2] = oldxml.orb_other_soft_2nd_2;
            localorbs[3] = oldxml.orb_other_soft_2nd_3;
            localorbs[4] = oldxml.orb_other_soft_2nd_4;
            localorbs[5] = oldxml.orb_other_soft_2nd_5;
            xmlData2.orb_other_soft_2nd = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_other_hard_2nd_0;
            localorbs[1] = oldxml.orb_other_hard_2nd_1;
            localorbs[2] = oldxml.orb_other_hard_2nd_2;
            localorbs[3] = oldxml.orb_other_hard_2nd_3;
            localorbs[4] = oldxml.orb_other_hard_2nd_4;
            localorbs[5] = oldxml.orb_other_hard_2nd_5;
            xmlData2.orb_other_hard_2nd = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_sun_soft_150_0;
            localorbs[1] = oldxml.orb_sun_soft_150_1;
            localorbs[2] = oldxml.orb_sun_soft_150_2;
            localorbs[3] = oldxml.orb_sun_soft_150_3;
            localorbs[4] = oldxml.orb_sun_soft_150_4;
            localorbs[5] = oldxml.orb_sun_soft_150_5;
            xmlData2.orb_sun_soft_150 = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_sun_hard_150_0;
            localorbs[1] = oldxml.orb_sun_hard_150_1;
            localorbs[2] = oldxml.orb_sun_hard_150_2;
            localorbs[3] = oldxml.orb_sun_hard_150_3;
            localorbs[4] = oldxml.orb_sun_hard_150_4;
            localorbs[5] = oldxml.orb_sun_hard_150_5;
            xmlData2.orb_sun_hard_150 = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_moon_soft_150_0;
            localorbs[1] = oldxml.orb_moon_soft_150_1;
            localorbs[2] = oldxml.orb_moon_soft_150_2;
            localorbs[3] = oldxml.orb_moon_soft_150_3;
            localorbs[4] = oldxml.orb_moon_soft_150_4;
            localorbs[5] = oldxml.orb_moon_soft_150_5;
            xmlData2.orb_moon_soft_150 = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_moon_hard_150_0;
            localorbs[1] = oldxml.orb_moon_hard_150_1;
            localorbs[2] = oldxml.orb_moon_hard_150_2;
            localorbs[3] = oldxml.orb_moon_hard_150_3;
            localorbs[4] = oldxml.orb_moon_hard_150_4;
            localorbs[5] = oldxml.orb_moon_hard_150_5;
            xmlData2.orb_moon_hard_150 = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_other_soft_150_0;
            localorbs[1] = oldxml.orb_other_soft_150_1;
            localorbs[2] = oldxml.orb_other_soft_150_2;
            localorbs[3] = oldxml.orb_other_soft_150_3;
            localorbs[4] = oldxml.orb_other_soft_150_4;
            localorbs[5] = oldxml.orb_other_soft_150_5;
            xmlData2.orb_other_soft_150 = ConvertString(localorbs);
            localorbs[0] = oldxml.orb_other_hard_150_0;
            localorbs[1] = oldxml.orb_other_hard_150_1;
            localorbs[2] = oldxml.orb_other_hard_150_2;
            localorbs[3] = oldxml.orb_other_hard_150_3;
            localorbs[4] = oldxml.orb_other_hard_150_4;
            localorbs[5] = oldxml.orb_other_hard_150_5;
            xmlData2.orb_other_hard_150 = ConvertString(localorbs);

        }

        private double[] ConvertDouble(string[] strings)
        {
            double[] ret = new double[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                ret[i] = double.Parse(strings[i]);
            }
            return ret;
        }

        private string ConvertString(double[] doubles)
        {
            string[] ret = new string[doubles.Length];
            for (int i = 0; i < doubles.Length; i++)
            {
                ret[i] = doubles[i].ToString();
            }
            return string.Join(",", ret);
        }

        private void SetOrbs()
        {
            orb_sun_soft_1st = ConvertDouble(xmlData2.orb_sun_soft_1st.Split(','));
            orb_sun_soft_2nd = ConvertDouble(xmlData2.orb_sun_soft_2nd.Split(','));
            orb_sun_soft_150 = ConvertDouble(xmlData2.orb_sun_soft_150.Split(','));
            orb_sun_hard_1st = ConvertDouble(xmlData2.orb_sun_hard_1st.Split(','));
            orb_sun_hard_2nd = ConvertDouble(xmlData2.orb_sun_hard_2nd.Split(','));
            orb_sun_hard_150 = ConvertDouble(xmlData2.orb_sun_hard_150.Split(','));
            orb_moon_soft_1st = ConvertDouble(xmlData2.orb_moon_soft_1st.Split(','));
            orb_moon_soft_2nd = ConvertDouble(xmlData2.orb_moon_soft_2nd.Split(','));
            orb_moon_soft_150 = ConvertDouble(xmlData2.orb_moon_soft_150.Split(','));
            orb_moon_hard_1st = ConvertDouble(xmlData2.orb_moon_hard_1st.Split(','));
            orb_moon_hard_2nd = ConvertDouble(xmlData2.orb_moon_hard_2nd.Split(','));
            orb_moon_hard_150 = ConvertDouble(xmlData2.orb_moon_hard_150.Split(','));
            orb_other_soft_1st = ConvertDouble(xmlData2.orb_other_soft_1st.Split(','));
            orb_other_soft_2nd = ConvertDouble(xmlData2.orb_other_soft_2nd.Split(','));
            orb_other_soft_150 = ConvertDouble(xmlData2.orb_other_soft_150.Split(','));
            orb_other_hard_1st = ConvertDouble(xmlData2.orb_other_hard_1st.Split(','));
            orb_other_hard_2nd = ConvertDouble(xmlData2.orb_other_hard_2nd.Split(','));
            orb_other_hard_150 = ConvertDouble(xmlData2.orb_other_hard_150.Split(','));

            for (int i = 0; i < 7; i++)
            {
                orbs.Add(GetOrbDictionary(i));
            }
        }

        private Dictionary<OrbKind, double> GetOrbDictionary(int n)
        {
            Dictionary<OrbKind, double> o = new Dictionary<OrbKind, double>();
            o.Add(OrbKind.SUN_HARD_1ST, orb_sun_hard_1st[n]);
            o.Add(OrbKind.SUN_SOFT_1ST, orb_sun_soft_1st[n]);
            o.Add(OrbKind.SUN_HARD_2ND, orb_sun_hard_2nd[n]);
            o.Add(OrbKind.SUN_SOFT_2ND, orb_sun_soft_2nd[n]);
            o.Add(OrbKind.SUN_HARD_150, orb_sun_hard_150[n]);
            o.Add(OrbKind.SUN_SOFT_150, orb_sun_soft_150[n]);
            o.Add(OrbKind.MOON_HARD_1ST, orb_moon_hard_1st[n]);
            o.Add(OrbKind.MOON_SOFT_1ST, orb_moon_soft_1st[n]);
            o.Add(OrbKind.MOON_HARD_2ND, orb_moon_hard_2nd[n]);
            o.Add(OrbKind.MOON_SOFT_2ND, orb_moon_soft_2nd[n]);
            o.Add(OrbKind.MOON_HARD_150, orb_moon_hard_150[n]);
            o.Add(OrbKind.MOON_SOFT_150, orb_moon_soft_150[n]);
            o.Add(OrbKind.OTHER_HARD_1ST, orb_other_hard_1st[n]);
            o.Add(OrbKind.OTHER_SOFT_1ST, orb_other_soft_1st[n]);
            o.Add(OrbKind.OTHER_HARD_2ND, orb_other_hard_2nd[n]);
            o.Add(OrbKind.OTHER_SOFT_2ND, orb_other_soft_2nd[n]);
            o.Add(OrbKind.OTHER_HARD_150, orb_other_hard_150[n]);
            o.Add(OrbKind.OTHER_SOFT_150, orb_other_soft_150[n]);
    
            return o;
        }
    
        public void SetDispAspectPlanet()
        {
            for (int i = 0; i < 28; i++)
            {
                dispAspectPlanet.Add(GetDispAspectDictionary(i));
            }
        }

        private  Dictionary<int, bool> GetDispAspectDictionary(int n)
        {
            Dictionary<int, bool> da = new Dictionary<int, bool>();
            da.Add(CommonData.ZODIAC_NUMBER_SUN, aspectSun[n]);
            da.Add(CommonData.ZODIAC_NUMBER_MOON, aspectMoon[n]);
            da.Add(CommonData.ZODIAC_NUMBER_MERCURY, aspectMercury[n]);
            da.Add(CommonData.ZODIAC_NUMBER_VENUS, aspectVenus[n]);
            da.Add(CommonData.ZODIAC_NUMBER_MARS, aspectMars[n]);
            da.Add(CommonData.ZODIAC_NUMBER_JUPITER, aspectJupiter[n]);
            da.Add(CommonData.ZODIAC_NUMBER_SATURN, aspectSaturn[n]);
            da.Add(CommonData.ZODIAC_NUMBER_URANUS, aspectUranus[n]);
            da.Add(CommonData.ZODIAC_NUMBER_NEPTUNE, aspectNeptune[n]);
            da.Add(CommonData.ZODIAC_NUMBER_PLUTO, aspectPluto[n]);
            da.Add(CommonData.ZODIAC_NUMBER_DH_TRUENODE, aspectDh[n]);
            da.Add(CommonData.ZODIAC_NUMBER_ASC, aspectAsc[n]);
            da.Add(CommonData.ZODIAC_NUMBER_MC, aspectMc[n]);
            da.Add(CommonData.ZODIAC_NUMBER_CHIRON, aspectChiron[n]);
            da.Add(CommonData.ZODIAC_NUMBER_EARTH, aspectEarth[n]);
            da.Add(CommonData.ZODIAC_NUMBER_LILITH, aspectLilith[n]);
            da.Add(CommonData.ZODIAC_NUMBER_CELES, false);
            da.Add(CommonData.ZODIAC_NUMBER_PARAS, false);
            da.Add(CommonData.ZODIAC_NUMBER_JUNO, false);
            da.Add(CommonData.ZODIAC_NUMBER_VESTA, false);

            return da;
        }

        private void SetDispAspectCategory()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j >= i)
                    {
                        dispAspectCategory.Add(GetDispAspectCategoryDictionary(i, j));
                    }
                }
            }
        }

        private  Dictionary<AspectKind, bool> GetDispAspectCategoryDictionary(int n, int m)
        {
            Dictionary<AspectKind, bool> dac = new Dictionary<AspectKind, bool>();
            dac.Add(AspectKind.CONJUNCTION, aspectConjunction[n, m]);
            dac.Add(AspectKind.OPPOSITION, aspectOpposition[n, m]);
            dac.Add(AspectKind.TRINE, aspectTrine[n, m]);
            dac.Add(AspectKind.SQUARE, aspectSquare[n, m]);
            dac.Add(AspectKind.SEXTILE, aspectSextile[n, m]);
            dac.Add(AspectKind.INCONJUNCT, aspectInconjunct[n, m]);
            dac.Add(AspectKind.SESQUIQUADRATE, aspectSesquiquadrate[n, m]);
            dac.Add(AspectKind.SEMISEXTILE, aspectSemiSextile[n, m]);
            dac.Add(AspectKind.SEMIQINTILE, aspectSemiQuintile[n, m]);
            dac.Add(AspectKind.SEMISQUARE, aspectSemiSquare[n, m]);
            dac.Add(AspectKind.NOVILE, aspectNovile[n, m]);
            dac.Add(AspectKind.SEPTILE, aspectSeptile[n, m]);
            dac.Add(AspectKind.QUINTILE, aspectQuintile[n, m]);
            dac.Add(AspectKind.BIQUINTILE, aspectBiQuintile[n, m]);

            return dac;
        }
    }
}

