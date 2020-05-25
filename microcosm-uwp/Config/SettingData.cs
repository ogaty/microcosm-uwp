using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using microcosm.Common;
using microcosm.Models;

namespace microcosm.Config
{
    // 複数クラスが存在（0～9）

    public class SettingData
    {
        public const int xmlVersion = 2;
        public int version;

        public SettingXml xmlData;
        public SettingXml2 xmlData2;
        public string dispName { get; set; }

        public bool[] dispCircle = new bool[] {
            true, false, false, false, false, false
        };

        // アスペクト種別(Oppositionとか)の表示
        // [0] | 11, 22, 33, 44, 55, 66, 77
        // [7] | 12, 13, 14, 15, 16, 17
        // [13] | 23, 24, 25, 26, 27
        // [18] | 34, 35, 36, 37
        // [22] | 45, 46, 47
        // [25] | 56, 57
        // [27] | 67
        public List<Dictionary<AspectKind, bool>> dispAspectCategory = new List<Dictionary<AspectKind, bool>>();

        // 内部変数
        // [from, to]
        // [0,0] = true -> １重円のアスペクトを表示
        public bool[] aspectConjunction;
        public bool[] aspectOpposition;
        public bool[] aspectSquare;
        public bool[] aspectTrine;
        public bool[] aspectSextile;
        public bool[] aspectInconjunct;
        public bool[] aspectSesquiquadrate;
        public bool[] aspectSemiSextile;
        public bool[] aspectSemiQuintile;
        public bool[] aspectSemiSquare;
        public bool[] aspectNovile;
        public bool[] aspectSeptile;
        public bool[] aspectQuintile;
        public bool[] aspectBiQuintile;

        // アスペクト一括表示、非表示切り替え
        // [from, to]
        public bool[,] dispAspect;

        // オーブ
        // ソフト/ハード、1種2種150、太陽/月/その他の組み合わせ 2*3*3=18通り
        public List<Dictionary<OrbKind, double>> orbs = new List<Dictionary<OrbKind, double>>();
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

        // 天体の表示可否
        // 円ごとなので、配列個数は7
        public List<Dictionary<int, bool>> dispPlanet = new List<Dictionary<int, bool>>();

        // 天体のアスペクトを表示
        // 11-77まで28個
        public List<Dictionary<int, bool>> dispAspectPlanet = new List<Dictionary<int, bool>>();
        private bool[] aspectSun = new bool[28];
        private bool[] aspectMoon = new bool[28];
        private bool[] aspectMercury = new bool[28];
        private bool[] aspectVenus = new bool[28];
        private bool[] aspectMars = new bool[28];
        private bool[] aspectJupiter = new bool[28];
        private bool[] aspectSaturn = new bool[28];
        private bool[] aspectUranus = new bool[28];
        private bool[] aspectNeptune = new bool[28];
        private bool[] aspectPluto = new bool[28];
        private bool[] aspectDh = new bool[28];
        private bool[] aspectAsc = new bool[28];
        private bool[] aspectMc = new bool[28];
        private bool[] aspectChiron = new bool[28];
        private bool[] aspectEarth = new bool[28];
        private bool[] aspectLilith = new bool[28];
        private bool[] aspectCeres = new bool[28];
        private bool[] aspectParas = new bool[28];
        private bool[] aspectJuno = new bool[28];
        private bool[] aspectVesta = new bool[28];
        private bool[] aspectEris = new bool[28];
        private bool[] aspectSedna = new bool[28];
        private bool[] aspectHaumea = new bool[28];
        private bool[] aspectMakemake = new bool[28];
        private bool[] aspectVt = new bool[28];
        private bool[] aspectPof = new bool[28];

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

            // UWPだしコンバートとか考えるのやめる
            InitSet();

        }

        /// <summary>
        /// wpfソースではなぜかMainWindow.csでやっていたやつ
        /// </summary>
        private void InitSet()
        {
            version = xmlData.version;

            SetDispPlanet();
            SetDispAspectPlanet();
            SetDispAspectCategory();
            SetOrbs();
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

        private string ConvertString(bool[] bools)
        {
            string[] ret = new string[bools.Length];
            for (int i = 0; i < bools.Length; i++)
            {
                ret[i] = bools[i].ToString();
            }
            return string.Join(",", ret);
        }

        private bool[] ConvertBool(string[] strings)
        {
            bool[] ret = new bool[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                ret[i] = strings[i] == "true" ? true : false;
            }
            return ret;
        }

        /// <summary>
        /// 天体表示(新)
        /// </summary>
        public void SetDispPlanet()
        {
            Dictionary<int, bool> dp = new Dictionary<int, bool>();
            bool[] sun = ConvertBool(xmlData.dispPlanetSun.Split(','));
            bool[] moon = ConvertBool(xmlData.dispPlanetMoon.Split(','));
            /*
            bool[] mercury = ConvertBool(xmlData.dispPlanetMercury.Split(','));
            bool[] venus = ConvertBool(xmlData.dispPlanetVenus.Split(','));
            bool[] mars = ConvertBool(xmlData.dispPlanetMars.Split(','));
            bool[] jupiter = ConvertBool(xmlData.dispPlanetJupiter.Split(','));
            bool[] saturn = ConvertBool(xmlData.dispPlanetSaturn.Split(','));
            bool[] uranus = ConvertBool(xmlData.dispPlanetUranus.Split(','));
            bool[] neptune = ConvertBool(xmlData.dispPlanetNeptune.Split(','));
            bool[] pluto = ConvertBool(xmlData.dispPlanetPluto.Split(','));
            bool[] dh = ConvertBool(xmlData.dispPlanetDh.Split(','));
            bool[] asc = ConvertBool(xmlData.dispPlanetAsc.Split(','));
            bool[] mc = ConvertBool(xmlData.dispPlanetMc.Split(','));
            bool[] chiron = ConvertBool(xmlData.dispPlanetChiron.Split(','));
            bool[] earth = ConvertBool(xmlData.dispPlanetEarth.Split(','));
            bool[] lilith = ConvertBool(xmlData.dispPlanetLilith.Split(','));
            bool[] ceres = ConvertBool(xmlData.dispPlanetCeres.Split(','));
            bool[] paras = ConvertBool(xmlData.dispPlanetParas.Split(','));
            bool[] juno = ConvertBool(xmlData.dispPlanetJuno.Split(','));
            bool[] vesta = ConvertBool(xmlData.dispPlanetVesta.Split(','));
            bool[] eris = ConvertBool(xmlData.dispPlanetEris.Split(','));
            bool[] sedna = ConvertBool(xmlData.dispPlanetSedna.Split(','));
            bool[] haumea = ConvertBool(xmlData.dispPlanetHaumea.Split(','));
            bool[] makemake = ConvertBool(xmlData.dispPlanetMakemake.Split(','));
            bool[] vt = ConvertBool(xmlData.dispPlanetVt.Split(','));
            bool[] pof = ConvertBool(xmlData.dispPlanetPof.Split(','));
            */


            for (int i = 0; i < 7; i++)
            {
                dp[CommonData.ZODIAC_NUMBER_SUN] = sun[i];
                dp[CommonData.ZODIAC_NUMBER_MOON] = moon[i];
                /*
                dp.Add(CommonData.ZODIAC_NUMBER_MOON, moon[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_MERCURY, mercury[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_VENUS, venus[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_MARS, mars[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_JUPITER, jupiter[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_SATURN, saturn[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_URANUS, uranus[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_NEPTUNE, neptune[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_PLUTO, pluto[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_DH_TRUENODE, dh[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_ASC, asc[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_MC, mc[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_CHIRON, chiron[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_EARTH, earth[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_LILITH, lilith[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_CERES, ceres[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_PALLAS, paras[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_JUNO, juno[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_VESTA, vesta[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_ERIS, eris[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_SEDNA, sedna[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_HAUMEA, haumea[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_MAKEMAKE, makemake[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_VT, vt[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_POF, pof[i]);
                */
                dispPlanet.Add(dp);
            }
        }


        #region neworbs
        /// <summary>
        /// オーブ設定(新)
        /// </summary>
        private void SetOrbs()
        {
            orb_sun_soft_1st = ConvertDouble(xmlData.orb_sun_soft_1st.Split(','));
            orb_sun_soft_2nd = ConvertDouble(xmlData.orb_sun_soft_2nd.Split(','));
            orb_sun_soft_150 = ConvertDouble(xmlData.orb_sun_soft_150.Split(','));
            orb_sun_hard_1st = ConvertDouble(xmlData.orb_sun_hard_1st.Split(','));
            orb_sun_hard_2nd = ConvertDouble(xmlData.orb_sun_hard_2nd.Split(','));
            orb_sun_hard_150 = ConvertDouble(xmlData.orb_sun_hard_150.Split(','));
            orb_moon_soft_1st = ConvertDouble(xmlData.orb_moon_soft_1st.Split(','));
            orb_moon_soft_2nd = ConvertDouble(xmlData.orb_moon_soft_2nd.Split(','));
            orb_moon_soft_150 = ConvertDouble(xmlData.orb_moon_soft_150.Split(','));
            orb_moon_hard_1st = ConvertDouble(xmlData.orb_moon_hard_1st.Split(','));
            orb_moon_hard_2nd = ConvertDouble(xmlData.orb_moon_hard_2nd.Split(','));
            orb_moon_hard_150 = ConvertDouble(xmlData.orb_moon_hard_150.Split(','));
            orb_other_soft_1st = ConvertDouble(xmlData.orb_other_soft_1st.Split(','));
            orb_other_soft_2nd = ConvertDouble(xmlData.orb_other_soft_2nd.Split(','));
            orb_other_soft_150 = ConvertDouble(xmlData.orb_other_soft_150.Split(','));
            orb_other_hard_1st = ConvertDouble(xmlData.orb_other_hard_1st.Split(','));
            orb_other_hard_2nd = ConvertDouble(xmlData.orb_other_hard_2nd.Split(','));
            orb_other_hard_150 = ConvertDouble(xmlData.orb_other_hard_150.Split(','));

            for (int i = 0; i < 7; i++)
            {
                orbs.Add(GetOrbDictionary(i));
            }
        }

        /// <summary>
        /// Listに入れる用Dictonaryを設定
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private Dictionary<OrbKind, double> GetOrbDictionary(int n)
        {
            Dictionary<OrbKind, double> o = new Dictionary<OrbKind, double>();
            o[OrbKind.SUN_HARD_1ST] = orb_sun_hard_1st[n];
            o[OrbKind.SUN_SOFT_1ST] = orb_sun_hard_1st[n];
            o[OrbKind.SUN_HARD_2ND] = orb_sun_hard_2nd[n];
            o[OrbKind.SUN_SOFT_2ND] = orb_sun_hard_2nd[n];
            o[OrbKind.SUN_HARD_150] = orb_sun_hard_150[n];
            o[OrbKind.SUN_SOFT_150] = orb_sun_hard_150[n];
            o[OrbKind.MOON_HARD_1ST] = orb_moon_hard_1st[n];
            o[OrbKind.MOON_SOFT_1ST] = orb_moon_hard_1st[n];
            o[OrbKind.MOON_HARD_2ND] = orb_moon_hard_2nd[n];
            o[OrbKind.MOON_SOFT_2ND] = orb_moon_hard_2nd[n];
            o[OrbKind.MOON_HARD_150] = orb_moon_hard_150[n];
            o[OrbKind.MOON_SOFT_150] = orb_moon_hard_150[n];
            o[OrbKind.OTHER_HARD_1ST] = orb_other_hard_1st[n];
            o[OrbKind.OTHER_SOFT_1ST] = orb_other_hard_1st[n];
            o[OrbKind.OTHER_HARD_2ND] = orb_other_hard_2nd[n];
            o[OrbKind.OTHER_SOFT_2ND] = orb_other_hard_2nd[n];
            o[OrbKind.OTHER_HARD_150] = orb_other_hard_150[n];
            o[OrbKind.OTHER_SOFT_150] = orb_other_hard_150[n];
    
            return o;
        }

        #endregion

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
            da.Add(CommonData.ZODIAC_NUMBER_CERES, aspectCeres[n]);
            da.Add(CommonData.ZODIAC_NUMBER_PALLAS, false);
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
                        // List型に7個ずついれていく
                        dispAspectCategory.Add(GetDispAspectCategoryDictionary(i, j));
                    }
                }
            }
        }

        private  Dictionary<AspectKind, bool> GetDispAspectCategoryDictionary(int n, int m)
        {
            Dictionary<AspectKind, bool> dac = new Dictionary<AspectKind, bool>();
            switch (n)
            {
                case 1:
                    aspectConjunction = ConvertBool(xmlData.aspectConjunction1.Split(','));
                    aspectOpposition = ConvertBool(xmlData.aspectOpposition1.Split(','));
                    dac[AspectKind.CONJUNCTION] = aspectConjunction[m];
                    dac[AspectKind.OPPOSITION] = aspectOpposition[m];
                    break;

            }
            /*
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
            */

            return dac;
        }
    }
}

