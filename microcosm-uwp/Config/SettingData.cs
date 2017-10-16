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

        // no: 設定番号
        public SettingData(int no)
        {
            init(no);
        }
        public void init(int no)
        {
            xmlData = new SettingXml();

            this.dispName = "表示設定" + no.ToString();


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

        }
    }
}
