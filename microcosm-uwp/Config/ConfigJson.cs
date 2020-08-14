using microcosm.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Config
{
    public class ConfigJson
    {
        [JsonProperty("ephepath")]
        public string ephepath;

        [JsonProperty("centric")]
        public ECentric centric;

        [JsonProperty("sidereal")]
        public ESidereal sidereal;

        [JsonProperty("default_place")]
        public string default_place;

        [JsonProperty("default_lat")]
        public double default_lat;

        [JsonProperty("default_lng")]
        public double default_lng;

        [JsonProperty("default_timezone")]
        public string default_timezone;

        [JsonProperty("progression")]
        public EProgression progression;

        [JsonProperty("house")]
        public EHouseCalc house;

        [JsonProperty("decimal_disp")]
        public EDecimalDisp decimal_disp;

        /*
          <ephepath>ephe</ephepath>
  <centric>GEO_CENTRIC</centric>
  <sidereal>TROPICAL</sidereal>
  <defaultPlace>東京都中央区</defaultPlace>
  <lat>35.670587</lat>
  <lng>139.772003</lng>
  <defaultTimezone>JST</defaultTimezone>
  <progression>CPS</progression>
  <defaultbands>1</defaultbands>
  <house>KOCH</house>
  <zodiacOuterWidth>470</zodiacOuterWidth>
  <zodiacWidth>60</zodiacWidth>
  <zodiacCenter>250</zodiacCenter>
  <decimalDisp>DECIMAL</decimalDisp>
  <dispPattern>1</dispPattern>
  <dispPattern2>MINI</dispPattern2>
  <color29>NOCHANGE</color29>
  <colorChange>-1</colorChange>
  <size>3</size>


        -->*/

        public ConfigJson()
        {
            ephepath = "ephe";
            centric = ECentric.GEO_CENTRIC;
            sidereal = ESidereal.TROPICAL;
            default_place = "東京都中央区";
            default_lat = 35.670587;
            default_lng = 35.670587;
            default_timezone = "JST";
            progression = EProgression.PRIMARY;
            house = EHouseCalc.PLACIDUS;
            decimal_disp = EDecimalDisp.DEGREE;
        }

        public ConfigJson(ConfigData config)
        {
            ephepath = config.ephepath;
            centric = config.centric;
            sidereal = config.sidereal;
            default_place = config.default_place;
            default_lat = config.default_lat;
            default_lng = config.default_lng;
            default_timezone = config.default_timezone;
            progression = config.progression;
            house = config.house;
            decimal_disp = config.decimal_disp;
        }
    }
}
