using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Config
{
    [JsonObject("setting")]
    public class SettingJson
    {
        [JsonProperty("version")]
        public int version;

        [JsonProperty("dispname")]
        public string dispname;

        [JsonProperty("dispPlanetSun")]
        public string dispPlanetSun;

        [JsonProperty("dispPlanetMoon")]
        public string dispPlanetMoon;

        [JsonProperty("dispPlanetMercury")]
        public string dispPlanetMercury;

        [JsonProperty("dispPlanetVenus")]
        public string dispPlanetVenus;

        [JsonProperty("dispPlanetMars")]
        public string dispPlanetMars;

        [JsonProperty("dispPlanetJupiter")]
        public string dispPlanetJupiter;

        [JsonProperty("dispPlanetSaturn")]
        public string dispPlanetSaturn;

        [JsonProperty("dispPlanetUranus")]
        public string dispPlanetUranus;

        [JsonProperty("dispPlanetNeptune")]
        public string dispPlanetNeptune;

        [JsonProperty("dispPlanetPluto")]
        public string dispPlanetPluto;

        [JsonProperty("dispPlanetDh")]
        public string dispPlanetDh;

        [JsonProperty("dispPlanetAsc")]
        public string dispPlanetAsc;

        [JsonProperty("dispPlanetMc")]
        public string dispPlanetMc;

        [JsonProperty("dispPlanetChiron")]
        public string dispPlanetChiron;

        [JsonProperty("dispPlanetEarth")]
        public string dispPlanetEarth;

        [JsonProperty("dispPlanetLilith")]
        public string dispPlanetLilith;

        [JsonProperty("dispPlanetCeres")]
        public string dispPlanetCeres;

        [JsonProperty("dispPlanetPallas")]
        public string dispPlanetPallas;

        [JsonProperty("dispPlanetJuno")]
        public string dispPlanetJuno;

        [JsonProperty("dispPlanetVesta")]
        public string dispPlanetVesta;


        public SettingJson()
        {
            version = 1;
            dispname = "名称未設定";
            dispPlanetSun = "true,true,true,true,true,true,true";
            dispPlanetMoon = "true,true,true,true,true,true,true";
            dispPlanetMercury = "true,true,true,true,true,true,true";
            dispPlanetVenus = "true,true,true,true,true,true,true";
            dispPlanetMars = "true,true,true,true,true,true,true";
            dispPlanetJupiter = "true,true,true,true,true,true,true";
            dispPlanetSaturn = "true,true,true,true,true,true,true";
            dispPlanetUranus = "true,true,true,true,true,true,true";
            dispPlanetNeptune = "true,true,true,true,true,true,true";
            dispPlanetPluto = "true,true,true,true,true,true,true";
            dispPlanetDh = "true,true,true,true,true,true,true";
            dispPlanetAsc = "true,true,true,true,true,true,true";
            dispPlanetMc = "true,true,true,true,true,true,true";
            dispPlanetChiron = "true,true,true,true,true,true,true";
            dispPlanetEarth = "false,false,false,false,false,false,false";
            dispPlanetLilith = "false,false,false,false,false,false,false";
            dispPlanetCeres = "false,false,false,false,false,false,false";
            dispPlanetPallas = "false,false,false,false,false,false,false";
            dispPlanetJuno = "false,false,false,false,false,false,false";
            dispPlanetVesta = "false,false,false,false,false,false,false";
        }
    }
}
