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
        public const int xmlVersion = 2;
        public int version;

        public SettingXml xmlData;
        public SettingXml2 xmlData2;
        public string dispName { get; set; }

        public bool[] dispCircle = new bool[] {
            true, false, false, false, false, false
        };

        // アスペクト種別の表示
        // [0] | 11, 22, 33, 44, 55, 66, 77
        // [7] | 12, 13, 14, 15, 16, 17
        // [13] | 23, 24, 25, 26, 27
        // [18] | 34, 35, 36, 37
        // [22] | 45, 46, 47
        // [25] | 56, 57
        // [27] | 67
        public List<Dictionary<AspectKind, bool>> dispAspectCategory = new List<Dictionary<AspectKind, bool>>();

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

        // 天体を表示
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

            if (xmlData.version == 0)
            {
                Convert();
            }
            InitSet();
        }

        /// <summary>
        /// wpfソースではなぜかMainWindow.csでやっていた
        /// </summary>
        private void InitSet()
        {
            version = xmlData.version;

            SetDispPlanet();
            SetDispAspectPlanet();
            SetDispAspectCategory();
            SetOrbs();
        }

        private void Convert()
        {
            xmlData.version = 2;
            ConvertOrbs();
            ConvertDispAspect();
            ConvertDispAspectCategory();
        }

        #region oldorb
        /// <summary>
        /// オーブ設定(旧)
        /// </summary>
        private void ConvertOrbs( )
        {
            double[] localorbs = new double[6];

            localorbs[0] = xmlData.orb_sun_soft_1st_0;
            localorbs[1] = xmlData.orb_sun_soft_1st_1;
            localorbs[2] = xmlData.orb_sun_soft_1st_2;
            localorbs[3] = xmlData.orb_sun_soft_1st_3;
            localorbs[4] = xmlData.orb_sun_soft_1st_4;
            localorbs[5] = xmlData.orb_sun_soft_1st_5;
            xmlData.orb_sun_soft_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_hard_1st_0;
            localorbs[1] = xmlData.orb_sun_hard_1st_1;
            localorbs[2] = xmlData.orb_sun_hard_1st_2;
            localorbs[3] = xmlData.orb_sun_hard_1st_3;
            localorbs[4] = xmlData.orb_sun_hard_1st_4;
            localorbs[5] = xmlData.orb_sun_hard_1st_5;
            xmlData.orb_sun_hard_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_soft_1st_0;
            localorbs[1] = xmlData.orb_moon_soft_1st_1;
            localorbs[2] = xmlData.orb_moon_soft_1st_2;
            localorbs[3] = xmlData.orb_moon_soft_1st_3;
            localorbs[4] = xmlData.orb_moon_soft_1st_4;
            localorbs[5] = xmlData.orb_moon_soft_1st_5;
            xmlData.orb_moon_soft_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_hard_1st_0;
            localorbs[1] = xmlData.orb_moon_hard_1st_1;
            localorbs[2] = xmlData.orb_moon_hard_1st_2;
            localorbs[3] = xmlData.orb_moon_hard_1st_3;
            localorbs[4] = xmlData.orb_moon_hard_1st_4;
            localorbs[5] = xmlData.orb_moon_hard_1st_5;
            xmlData.orb_moon_hard_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_soft_1st_0;
            localorbs[1] = xmlData.orb_other_soft_1st_1;
            localorbs[2] = xmlData.orb_other_soft_1st_2;
            localorbs[3] = xmlData.orb_other_soft_1st_3;
            localorbs[4] = xmlData.orb_other_soft_1st_4;
            localorbs[5] = xmlData.orb_other_soft_1st_5;
            xmlData.orb_other_soft_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_hard_1st_0;
            localorbs[1] = xmlData.orb_other_hard_1st_1;
            localorbs[2] = xmlData.orb_other_hard_1st_2;
            localorbs[3] = xmlData.orb_other_hard_1st_3;
            localorbs[4] = xmlData.orb_other_hard_1st_4;
            localorbs[5] = xmlData.orb_other_hard_1st_5;
            xmlData.orb_other_hard_1st = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_soft_2nd_0;
            localorbs[1] = xmlData.orb_sun_soft_2nd_1;
            localorbs[2] = xmlData.orb_sun_soft_2nd_2;
            localorbs[3] = xmlData.orb_sun_soft_2nd_3;
            localorbs[4] = xmlData.orb_sun_soft_2nd_4;
            localorbs[5] = xmlData.orb_sun_soft_2nd_5;
            xmlData.orb_sun_soft_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_hard_2nd_0;
            localorbs[1] = xmlData.orb_sun_hard_2nd_1;
            localorbs[2] = xmlData.orb_sun_hard_2nd_2;
            localorbs[3] = xmlData.orb_sun_hard_2nd_3;
            localorbs[4] = xmlData.orb_sun_hard_2nd_4;
            localorbs[5] = xmlData.orb_sun_hard_2nd_5;
            xmlData.orb_sun_hard_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_soft_2nd_0;
            localorbs[1] = xmlData.orb_moon_soft_2nd_1;
            localorbs[2] = xmlData.orb_moon_soft_2nd_2;
            localorbs[3] = xmlData.orb_moon_soft_2nd_3;
            localorbs[4] = xmlData.orb_moon_soft_2nd_4;
            localorbs[5] = xmlData.orb_moon_soft_2nd_5;
            xmlData.orb_moon_soft_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_hard_2nd_0;
            localorbs[1] = xmlData.orb_moon_hard_2nd_1;
            localorbs[2] = xmlData.orb_moon_hard_2nd_2;
            localorbs[3] = xmlData.orb_moon_hard_2nd_3;
            localorbs[4] = xmlData.orb_moon_hard_2nd_4;
            localorbs[5] = xmlData.orb_moon_hard_2nd_5;
            xmlData.orb_moon_hard_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_soft_2nd_0;
            localorbs[1] = xmlData.orb_other_soft_2nd_1;
            localorbs[2] = xmlData.orb_other_soft_2nd_2;
            localorbs[3] = xmlData.orb_other_soft_2nd_3;
            localorbs[4] = xmlData.orb_other_soft_2nd_4;
            localorbs[5] = xmlData.orb_other_soft_2nd_5;
            xmlData.orb_other_soft_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_hard_2nd_0;
            localorbs[1] = xmlData.orb_other_hard_2nd_1;
            localorbs[2] = xmlData.orb_other_hard_2nd_2;
            localorbs[3] = xmlData.orb_other_hard_2nd_3;
            localorbs[4] = xmlData.orb_other_hard_2nd_4;
            localorbs[5] = xmlData.orb_other_hard_2nd_5;
            xmlData.orb_other_hard_2nd = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_soft_150_0;
            localorbs[1] = xmlData.orb_sun_soft_150_1;
            localorbs[2] = xmlData.orb_sun_soft_150_2;
            localorbs[3] = xmlData.orb_sun_soft_150_3;
            localorbs[4] = xmlData.orb_sun_soft_150_4;
            localorbs[5] = xmlData.orb_sun_soft_150_5;
            xmlData.orb_sun_soft_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_sun_hard_150_0;
            localorbs[1] = xmlData.orb_sun_hard_150_1;
            localorbs[2] = xmlData.orb_sun_hard_150_2;
            localorbs[3] = xmlData.orb_sun_hard_150_3;
            localorbs[4] = xmlData.orb_sun_hard_150_4;
            localorbs[5] = xmlData.orb_sun_hard_150_5;
            xmlData.orb_sun_hard_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_soft_150_0;
            localorbs[1] = xmlData.orb_moon_soft_150_1;
            localorbs[2] = xmlData.orb_moon_soft_150_2;
            localorbs[3] = xmlData.orb_moon_soft_150_3;
            localorbs[4] = xmlData.orb_moon_soft_150_4;
            localorbs[5] = xmlData.orb_moon_soft_150_5;
            xmlData.orb_moon_soft_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_moon_hard_150_0;
            localorbs[1] = xmlData.orb_moon_hard_150_1;
            localorbs[2] = xmlData.orb_moon_hard_150_2;
            localorbs[3] = xmlData.orb_moon_hard_150_3;
            localorbs[4] = xmlData.orb_moon_hard_150_4;
            localorbs[5] = xmlData.orb_moon_hard_150_5;
            xmlData.orb_moon_hard_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_soft_150_0;
            localorbs[1] = xmlData.orb_other_soft_150_1;
            localorbs[2] = xmlData.orb_other_soft_150_2;
            localorbs[3] = xmlData.orb_other_soft_150_3;
            localorbs[4] = xmlData.orb_other_soft_150_4;
            localorbs[5] = xmlData.orb_other_soft_150_5;
            xmlData.orb_other_soft_150 = ConvertString(localorbs);
            localorbs[0] = xmlData.orb_other_hard_150_0;
            localorbs[1] = xmlData.orb_other_hard_150_1;
            localorbs[2] = xmlData.orb_other_hard_150_2;
            localorbs[3] = xmlData.orb_other_hard_150_3;
            localorbs[4] = xmlData.orb_other_hard_150_4;
            localorbs[5] = xmlData.orb_other_hard_150_5;
            xmlData.orb_other_hard_150 = ConvertString(localorbs);
        }

        #endregion

        #region olddispaspect
        private void ConvertDispAspect()
        {
            bool[] bools = new bool[28];
            bools[0] = xmlData.aspectSun11;
            bools[1] = xmlData.aspectSun22;
            bools[2] = xmlData.aspectSun33;
            bools[3] = xmlData.aspectSun12;
            bools[4] = xmlData.aspectSun13;
            bools[5] = xmlData.aspectSun23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectSun = ConvertString(bools);

            bools[0] = xmlData.aspectMoon11;
            bools[1] = xmlData.aspectMoon22;
            bools[2] = xmlData.aspectMoon33;
            bools[3] = xmlData.aspectMoon12;
            bools[4] = xmlData.aspectMoon13;
            bools[5] = xmlData.aspectMoon23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectMoon = ConvertString(bools);

            bools[0] = xmlData.aspectVenus11;
            bools[1] = xmlData.aspectVenus22;
            bools[2] = xmlData.aspectVenus33;
            bools[3] = xmlData.aspectVenus12;
            bools[4] = xmlData.aspectVenus13;
            bools[5] = xmlData.aspectVenus23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectVenus = ConvertString(bools);

            bools[0] = xmlData.aspectMars11;
            bools[1] = xmlData.aspectMars22;
            bools[2] = xmlData.aspectMars33;
            bools[3] = xmlData.aspectMars12;
            bools[4] = xmlData.aspectMars13;
            bools[5] = xmlData.aspectMars23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectMars = ConvertString(bools);

            bools[0] = xmlData.aspectJupiter11;
            bools[1] = xmlData.aspectJupiter22;
            bools[2] = xmlData.aspectJupiter33;
            bools[3] = xmlData.aspectJupiter12;
            bools[4] = xmlData.aspectJupiter13;
            bools[5] = xmlData.aspectJupiter23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectJupiter = ConvertString(bools);

            bools[0] = xmlData.aspectSaturn11;
            bools[1] = xmlData.aspectSaturn22;
            bools[2] = xmlData.aspectSaturn33;
            bools[3] = xmlData.aspectSaturn12;
            bools[4] = xmlData.aspectSaturn13;
            bools[5] = xmlData.aspectSaturn23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectSaturn = ConvertString(bools);

            bools[0] = xmlData.aspectUranus11;
            bools[1] = xmlData.aspectUranus22;
            bools[2] = xmlData.aspectUranus33;
            bools[3] = xmlData.aspectUranus12;
            bools[4] = xmlData.aspectUranus13;
            bools[5] = xmlData.aspectUranus23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectUranus = ConvertString(bools);

            bools[0] = xmlData.aspectNeptune11;
            bools[1] = xmlData.aspectNeptune22;
            bools[2] = xmlData.aspectNeptune33;
            bools[3] = xmlData.aspectNeptune12;
            bools[4] = xmlData.aspectNeptune13;
            bools[5] = xmlData.aspectNeptune23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectNeptune = ConvertString(bools);

            bools[0] = xmlData.aspectPluto11;
            bools[1] = xmlData.aspectPluto22;
            bools[2] = xmlData.aspectPluto33;
            bools[3] = xmlData.aspectPluto12;
            bools[4] = xmlData.aspectPluto13;
            bools[5] = xmlData.aspectPluto23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectPluto = ConvertString(bools);

            bools[0] = xmlData.aspectDh11;
            bools[1] = xmlData.aspectDh22;
            bools[2] = xmlData.aspectDh33;
            bools[3] = xmlData.aspectDh12;
            bools[4] = xmlData.aspectDh13;
            bools[5] = xmlData.aspectDh23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectDh = ConvertString(bools);

            bools[0] = xmlData.aspectChiron11;
            bools[1] = xmlData.aspectChiron22;
            bools[2] = xmlData.aspectChiron33;
            bools[3] = xmlData.aspectChiron12;
            bools[4] = xmlData.aspectChiron13;
            bools[5] = xmlData.aspectChiron23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectChiron = ConvertString(bools);

            bools[0] = xmlData.aspectAsc11;
            bools[1] = xmlData.aspectAsc22;
            bools[2] = xmlData.aspectAsc33;
            bools[3] = xmlData.aspectAsc12;
            bools[4] = xmlData.aspectAsc13;
            bools[5] = xmlData.aspectAsc23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectAsc = ConvertString(bools);

            bools[0] = xmlData.aspectMc11;
            bools[1] = xmlData.aspectMc22;
            bools[2] = xmlData.aspectMc33;
            bools[3] = xmlData.aspectMc12;
            bools[4] = xmlData.aspectMc13;
            bools[5] = xmlData.aspectMc23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectMc = ConvertString(bools);

            bools[0] = xmlData.aspectEarth11;
            bools[1] = xmlData.aspectEarth22;
            bools[2] = xmlData.aspectEarth33;
            bools[3] = xmlData.aspectEarth12;
            bools[4] = xmlData.aspectEarth13;
            bools[5] = xmlData.aspectEarth23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectEarth = ConvertString(bools);

            bools[0] = xmlData.aspectLilith11;
            bools[1] = xmlData.aspectLilith22;
            bools[2] = xmlData.aspectLilith33;
            bools[3] = xmlData.aspectLilith12;
            bools[4] = xmlData.aspectLilith13;
            bools[5] = xmlData.aspectLilith23;
            for (int i = 6; i < 28; i++)
            {
                bools[i] = false;
            }
            xmlData.aspectLilith = ConvertString(bools);

            for (int i = 0; i < 28; i++)
            {
                bools[i] = false;
            }
            string allFalse = ConvertString(bools);
            xmlData.aspectCeres = allFalse;
            xmlData.aspectParas = allFalse;
            xmlData.aspectJuno = allFalse;
            xmlData.aspectVesta = allFalse;
            xmlData.aspectEris = allFalse;
            xmlData.aspectSedna = allFalse;
            xmlData.aspectHaumea = allFalse;
            xmlData.aspectMakemake = allFalse;
            xmlData.aspectVt = allFalse;
            xmlData.aspectPof = allFalse;
        }

        #endregion

        private void ConvertDispAspectCategory()
        {
            Dictionary<AspectKind, bool> dac11 = new Dictionary<AspectKind, bool>();
            dac11.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction11);
            dac11.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition11);
            dac11.Add(AspectKind.SQUARE, xmlData.aspectSquare11);
            dac11.Add(AspectKind.TRINE, xmlData.aspectTrine11);
            dac11.Add(AspectKind.SEXTILE, xmlData.aspectSextile11);
            dac11.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct11);
            dac11.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate11);
            dac11.Add(AspectKind.SEMISEXTILE, false);
            dac11.Add(AspectKind.SEMISQUARE, false);
            dac11.Add(AspectKind.SEMIQINTILE, false);
            dac11.Add(AspectKind.SEPTILE, false);
            dac11.Add(AspectKind.NOVILE, false);
            dac11.Add(AspectKind.QUINTILE, false);
            dac11.Add(AspectKind.BIQUINTILE, false);
            dispAspectCategory.Add(dac11);

            Dictionary<AspectKind, bool> dac22 = new Dictionary<AspectKind, bool>();
            dac22.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction22);
            dac22.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition22);
            dac22.Add(AspectKind.TRINE, xmlData.aspectTrine22);
            dac22.Add(AspectKind.SQUARE, xmlData.aspectSquare22);
            dac22.Add(AspectKind.SEXTILE, xmlData.aspectSextile22);
            dac22.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct22);
            dac22.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate22);
            dispAspectCategory.Add(dac22);

            Dictionary<AspectKind, bool> dac33 = new Dictionary<AspectKind, bool>();
            dac33.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction33);
            dac33.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition33);
            dac33.Add(AspectKind.TRINE, xmlData.aspectTrine33);
            dac33.Add(AspectKind.SQUARE, xmlData.aspectSquare33);
            dac33.Add(AspectKind.SEXTILE, xmlData.aspectSextile33);
            dac33.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct33);
            dac33.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate33);
            dispAspectCategory.Add(dac33);

            Dictionary<AspectKind, bool> dac12 = new Dictionary<AspectKind, bool>();
            dac12.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction12);
            dac12.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition12);
            dac12.Add(AspectKind.TRINE, xmlData.aspectTrine12);
            dac12.Add(AspectKind.SQUARE, xmlData.aspectSquare12);
            dac12.Add(AspectKind.SEXTILE, xmlData.aspectSextile12);
            dac12.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct12);
            dac12.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate12);
            dispAspectCategory.Add(dac12);

            Dictionary<AspectKind, bool> dac13 = new Dictionary<AspectKind, bool>();
            dac13.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction13);
            dac13.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition13);
            dac13.Add(AspectKind.TRINE, xmlData.aspectTrine13);
            dac13.Add(AspectKind.SQUARE, xmlData.aspectSquare13);
            dac13.Add(AspectKind.SEXTILE, xmlData.aspectSextile13);
            dac13.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct13);
            dac13.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate13);
            dispAspectCategory.Add(dac13);

            Dictionary<AspectKind, bool> dac23 = new Dictionary<AspectKind, bool>();
            dac23.Add(AspectKind.CONJUNCTION, xmlData.aspectConjunction23);
            dac23.Add(AspectKind.OPPOSITION, xmlData.aspectOpposition23);
            dac23.Add(AspectKind.TRINE, xmlData.aspectTrine23);
            dac23.Add(AspectKind.SQUARE, xmlData.aspectSquare23);
            dac23.Add(AspectKind.SEXTILE, xmlData.aspectSextile23);
            dac23.Add(AspectKind.INCONJUNCT, xmlData.aspectInconjunct23);
            dac23.Add(AspectKind.SESQUIQUADRATE, xmlData.aspectSesquiquadrate23);
            dispAspectCategory.Add(dac23);

            for (int i = 0; i < 28; i++)
            {
            }
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


            for (int i = 0; i < 7; i++)
            {
                dp.Add(CommonData.ZODIAC_NUMBER_SUN, sun[i]);
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
                dp.Add(CommonData.ZODIAC_NUMBER_PARAS, paras[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_JUNO, juno[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_VESTA, vesta[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_ERIS, eris[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_SEDNA, sedna[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_HAUMEA, haumea[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_MAKEMAKE, makemake[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_VT, vt[i]);
                dp.Add(CommonData.ZODIAC_NUMBER_POF, pof[i]);
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

