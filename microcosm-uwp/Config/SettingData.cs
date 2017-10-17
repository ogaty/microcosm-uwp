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
        public string dispName { get; set; }

        public bool[] dispCircle = new bool[] {
            true, false, false, false, false, false
        };
        // 0:11～15:45
        public List<Dictionary<OrbKind, double>> orbs;
        public List<Dictionary<int, bool>> dispPlanet;
        public List<Dictionary<int, bool>> dispAspectPlanet;
        public List<Dictionary<AspectKind, bool>> dispAspectCategory;

        // [from, to]
        public bool[,] aspectConjunction;
        public bool[,] aspectOpposition;
        public bool[,] aspectSquare;
        public bool[,] aspectTrine;
        public bool[,] aspectSextile;
        public bool[,] aspectInconjunct;
        public bool[,] aspectSesquiquadrate;
        // [from, to]
        public bool[,] dispAspect;

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
            dispPlanet = new List<Dictionary<int, bool>>();
            dispAspectPlanet = new List<Dictionary<int, bool>>();
            dispAspectCategory = new List<Dictionary<AspectKind, bool>>();
            orbs = new List<Dictionary<OrbKind, double>>();

            // N-N、N-P、N-Tのアスペクト
            dispAspect = new bool[6, 6] {
                { true, true, true, true, true, true },
                { true, true, true, true, true, true },
                { true, true, true, true, true, true },
                { true, true, true, true, true, true },
                { true, true, true, true, true, true },
                { true, true, true, true, true, true }
            };

            InitSet();
        }

        /// <summary>
        /// wpfソースではなぜかMainWindow.csでやっていた
        /// </summary>
        private void InitSet()
        {
            SetDispPlanet();
        }

        public void SetDispPlanet()
        {
            // N-N
            Dictionary<int, bool> dp11 = new Dictionary<int, bool>();
            dp11.Add(CommonData.ZODIAC_NUMBER_SUN, xmlData.dispPlanetSun11);
            dp11.Add(CommonData.ZODIAC_NUMBER_MOON, xmlData.dispPlanetMoon11);
            dp11.Add(CommonData.ZODIAC_NUMBER_MERCURY, xmlData.dispPlanetMercury11);
            dp11.Add(CommonData.ZODIAC_NUMBER_VENUS, xmlData.dispPlanetVenus11);
            dp11.Add(CommonData.ZODIAC_NUMBER_MARS, xmlData.dispPlanetMars11);
            dp11.Add(CommonData.ZODIAC_NUMBER_JUPITER, xmlData.dispPlanetJupiter11);
            dp11.Add(CommonData.ZODIAC_NUMBER_SATURN, xmlData.dispPlanetSaturn11);
            dp11.Add(CommonData.ZODIAC_NUMBER_URANUS, xmlData.dispPlanetUranus11);
            dp11.Add(CommonData.ZODIAC_NUMBER_NEPTUNE, xmlData.dispPlanetNeptune11);
            dp11.Add(CommonData.ZODIAC_NUMBER_PLUTO, xmlData.dispPlanetPluto11);
            dp11.Add(CommonData.ZODIAC_NUMBER_DH_TRUENODE, xmlData.dispPlanetDh11);
            dp11.Add(CommonData.ZODIAC_NUMBER_ASC, xmlData.dispPlanetAsc11);
            dp11.Add(CommonData.ZODIAC_NUMBER_MC, xmlData.dispPlanetMc11);
            dp11.Add(CommonData.ZODIAC_NUMBER_CHIRON, xmlData.dispPlanetChiron11);
            dp11.Add(CommonData.ZODIAC_NUMBER_EARTH, xmlData.dispPlanetEarth11);
            dp11.Add(CommonData.ZODIAC_NUMBER_LILITH, xmlData.dispPlanetLilith11);

            // 新csmだとこれらも増えるよ
            dp11.Add(CommonData.ZODIAC_NUMBER_CELES, false);
            dp11.Add(CommonData.ZODIAC_NUMBER_PARAS, false);
            dp11.Add(CommonData.ZODIAC_NUMBER_JUNO, false);
            dp11.Add(CommonData.ZODIAC_NUMBER_VESTA, false);
            // セドナ、エリス、ハウメア、マケマケ
            dispPlanet.Add(dp11);
        }
    }
}
