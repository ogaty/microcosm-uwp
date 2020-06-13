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

        [JsonProperty("dispPlanetEris")]
        public string dispPlanetEris;

        [JsonProperty("dispPlanetSedna")]
        public string dispPlanetSedna;

        [JsonProperty("dispPlanetHaumea")]
        public string dispPlanetHaumea;

        [JsonProperty("dispPlanetMakemake")]
        public string dispPlanetMakemake;

        [JsonProperty("dispPlanetMakemake")]
        public string dispPlanetVt;

        [JsonProperty("dispPlanetMakemake")]
        public string dispPlanetPof;

        [JsonProperty("aspectSun")]
        public string aspectSun;

        [JsonProperty("aspectMoon")]
        public string aspectMoon;

        [JsonProperty("aspectMercury")]
        public string aspectMercury;

        [JsonProperty("aspectVenus")]
        public string aspectVenus;

        [JsonProperty("aspectMars")]
        public string aspectMars;

        [JsonProperty("aspectJupiter")]
        public string aspectJupiter;

        [JsonProperty("aspectSaturn")]
        public string aspectSaturn;

        [JsonProperty("aspectUranus")]
        public string aspectUranus;

        [JsonProperty("aspectNeptune")]
        public string aspectNeptune;

        [JsonProperty("aspectPluto")]
        public string aspectPluto;

        [JsonProperty("aspectDh")]
        public string aspectDh;

        // TODO

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
            dispPlanetEris = "false,false,false,false,false,false,false";
            dispPlanetSedna = "false,false,false,false,false,false,false";
            dispPlanetHaumea = "false,false,false,false,false,false,false";
            dispPlanetMakemake = "false,false,false,false,false,false,false";
            dispPlanetVt = "false,false,false,false,false,false,false";
            dispPlanetPof = "false,false,false,false,false,false,false";
            aspectSun = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectMoon = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectMercury = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectVenus = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectMars = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectJupiter = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectSaturn = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectUranus = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectNeptune = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectPluto = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
            aspectDh = "true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true";
        }
    }
}
