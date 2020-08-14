using microcosm.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Config
{
    public class ConfigData
    {
        public string ephepath;
        public ECentric centric;
        public ESidereal sidereal;
        public string default_place;
        public double default_lat;
        public double default_lng;
        public string default_timezone;
        public EProgression progression;
        public EHouseCalc house;
        public EDecimalDisp decimal_disp;

        public ConfigData()
        {
            ephepath = "ephe";
            centric = ECentric.GEO_CENTRIC;
            sidereal = ESidereal.TROPICAL;
            default_place = "東京都中央区";
            default_lat = Common.CommonData.defaultLat;
            default_lng = Common.CommonData.defaultLng;
            default_timezone = "JST";
            house = EHouseCalc.PLACIDUS;
            decimal_disp = EDecimalDisp.DECIMAL;
        }

        public ConfigData(ConfigJson json)
        {
            ephepath = json.ephepath;
            centric = json.centric;
            sidereal = json.sidereal;
            default_place = json.default_place;
            default_lat = json.default_lat;
            default_lng = json.default_lng;
            default_timezone = json.default_timezone;
            house = json.house;
            progression = json.progression;
            decimal_disp = json.decimal_disp;

        }
    }
}
