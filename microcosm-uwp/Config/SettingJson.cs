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

        [JsonProperty("dispPlanetVt")]
        public string dispPlanetVt;

        [JsonProperty("dispPlanetPof")]
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

        [JsonProperty("aspectConjunction1")]
        public string aspectConjunction1;

        [JsonProperty("aspectConjunction2")]
        public string aspectConjunction2;

        [JsonProperty("aspectConjunction3")]
        public string aspectConjunction3;

        [JsonProperty("aspectConjunction4")]
        public string aspectConjunction4;

        [JsonProperty("aspectConjunction5")]
        public string aspectConjunction5;

        [JsonProperty("aspectConjunction6")]
        public string aspectConjunction6;

        [JsonProperty("aspectConjunction7")]
        public string aspectConjunction7;

        [JsonProperty("aspectOpposition1")]
        public string aspectOpposition1;

        [JsonProperty("aspectOpposition2")]
        public string aspectOpposition2;

        [JsonProperty("aspectOpposition3")]
        public string aspectOpposition3;

        [JsonProperty("aspectOpposition4")]
        public string aspectOpposition4;

        [JsonProperty("aspectOpposition5")]
        public string aspectOpposition5;

        [JsonProperty("aspectOpposition6")]
        public string aspectOpposition6;

        [JsonProperty("aspectOpposition7")]
        public string aspectOpposition7;

        [JsonProperty("aspectTrine1")]
        public string aspectTrine1;

        [JsonProperty("aspectTrine2")]
        public string aspectTrine2;

        [JsonProperty("aspectTrine3")]
        public string aspectTrine3;

        [JsonProperty("aspectTrine4")]
        public string aspectTrine4;

        [JsonProperty("aspectTrine5")]
        public string aspectTrine5;

        [JsonProperty("aspectTrine6")]
        public string aspectTrine6;

        [JsonProperty("aspectTrine7")]
        public string aspectTrine7;

        [JsonProperty("aspectSquare1")]
        public string aspectSquare1;

        [JsonProperty("aspectSquare2")]
        public string aspectSquare2;

        [JsonProperty("aspectSquare3")]
        public string aspectSquare3;

        [JsonProperty("aspectSquare4")]
        public string aspectSquare4;

        [JsonProperty("aspectSquare5")]
        public string aspectSquare5;

        [JsonProperty("aspectSquare6")]
        public string aspectSquare6;

        [JsonProperty("aspectSquare7")]
        public string aspectSquare7;

        [JsonProperty("aspectSextile1")]
        public string aspectSextile1;

        [JsonProperty("aspectSextile2")]
        public string aspectSextile2;

        [JsonProperty("aspectSextile3")]
        public string aspectSextile3;

        [JsonProperty("aspectSextile4")]
        public string aspectSextile4;

        [JsonProperty("aspectSextile5")]
        public string aspectSextile5;

        [JsonProperty("aspectSextile6")]
        public string aspectSextile6;

        [JsonProperty("aspectSextile7")]
        public string aspectSextile7;

        [JsonProperty("orb_sun_soft_1st")]
        public string orb_sun_soft_1st;

        [JsonProperty("orb_sun_hard_1st")]
        public string orb_sun_hard_1st;

        [JsonProperty("orb_sun_soft_2nd")]
        public string orb_sun_soft_2nd;

        [JsonProperty("orb_sun_hard_2nd")]
        public string orb_sun_hard_2nd;

        [JsonProperty("orb_sun_soft_150")]
        public string orb_sun_soft_150;

        [JsonProperty("orb_sun_hard_150")]
        public string orb_sun_hard_150;

        [JsonProperty("orb_moon_soft_1st")]
        public string orb_moon_soft_1st;

        [JsonProperty("orb_moon_hard_1st")]
        public string orb_moon_hard_1st;

        [JsonProperty("orb_moon_soft_2nd")]
        public string orb_moon_soft_2nd;

        [JsonProperty("orb_moon_hard_2nd")]
        public string orb_moon_hard_2nd;

        [JsonProperty("orb_moon_soft_150")]
        public string orb_moon_soft_150;

        [JsonProperty("orb_moon_hard_150")]
        public string orb_moon_hard_150;

        [JsonProperty("orb_other_soft_1st")]
        public string orb_other_soft_1st;

        [JsonProperty("orb_other_hard_1st")]
        public string orb_other_hard_1st;

        [JsonProperty("orb_other_soft_2nd")]
        public string orb_other_soft_2nd;

        [JsonProperty("orb_other_hard_2nd")]
        public string orb_other_hard_2nd;

        [JsonProperty("orb_other_soft_150")]
        public string orb_other_soft_150;

        [JsonProperty("orb_other_hard_150")]
        public string orb_other_hard_150;

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
            aspectConjunction1 = "true,true,true,true,true,true,true";
            aspectConjunction2 = "true,true,true,true,true,true,true";
            aspectConjunction3 = "true,true,true,true,true,true,true";
            aspectConjunction4 = "true,true,true,true,true,true,true";
            aspectConjunction5 = "true,true,true,true,true,true,true";
            aspectConjunction6 = "true,true,true,true,true,true,true";
            aspectConjunction7 = "true,true,true,true,true,true,true";
            aspectOpposition1 = "true,true,true,true,true,true,true";
            aspectOpposition2 = "true,true,true,true,true,true,true";
            aspectOpposition3 = "true,true,true,true,true,true,true";
            aspectOpposition4 = "true,true,true,true,true,true,true";
            aspectOpposition5 = "true,true,true,true,true,true,true";
            aspectOpposition6 = "true,true,true,true,true,true,true";
            aspectOpposition7 = "true,true,true,true,true,true,true";
            aspectTrine1 = "true,true,true,true,true,true,true";
            aspectTrine2 = "true,true,true,true,true,true,true";
            aspectTrine3 = "true,true,true,true,true,true,true";
            aspectTrine4 = "true,true,true,true,true,true,true";
            aspectTrine5 = "true,true,true,true,true,true,true";
            aspectTrine6 = "true,true,true,true,true,true,true";
            aspectTrine7 = "true,true,true,true,true,true,true";
            aspectTrine7 = "true,true,true,true,true,true,true";
            aspectSquare1 = "true,true,true,true,true,true,true";
            aspectSquare2 = "true,true,true,true,true,true,true";
            aspectSquare3 = "true,true,true,true,true,true,true";
            aspectSquare4 = "true,true,true,true,true,true,true";
            aspectSquare5 = "true,true,true,true,true,true,true";
            aspectSquare6 = "true,true,true,true,true,true,true";
            aspectSquare7 = "true,true,true,true,true,true,true";
            aspectSextile1 = "true,true,true,true,true,true,true";
            aspectSextile2 = "true,true,true,true,true,true,true";
            aspectSextile3 = "true,true,true,true,true,true,true";
            aspectSextile4 = "true,true,true,true,true,true,true";
            aspectSextile5 = "true,true,true,true,true,true,true";
            aspectSextile6 = "true,true,true,true,true,true,true";
            aspectSextile7 = "true,true,true,true,true,true,true";
            orb_sun_soft_1st = "8.0,8.0,8.0,8.0,8.0,8.0,8.0";
            orb_sun_hard_1st = "6.0,6.0,6.0,6.0,6.0,6.0,6.0";
            orb_sun_soft_2nd = "6.0,6.0,6.0,6.0,6.0,6.0,6.0";
            orb_sun_hard_2nd = "4.0,4.0,4.0,4.0,4.0,4.0,4.0";
            orb_sun_soft_150 = "3.0,3.0,3.0,3.0,3.0,3.0,3.0";
            orb_sun_hard_150 = "1.5,1.5,1.5,1.5,1.5,1.5,1.5";
            orb_moon_soft_1st = "8.0,8.0,8.0,8.0,8.0,8.0,8.0";
            orb_moon_hard_1st = "6.0,6.0,6.0,6.0,6.0,6.0,6.0";
            orb_moon_soft_2nd = "6.0,6.0,6.0,6.0,6.0,6.0,6.0";
            orb_moon_hard_2nd = "4.0,4.0,4.0,4.0,4.0,4.0,4.0";
            orb_moon_soft_150 = "3.0,3.0,3.0,3.0,3.0,3.0,3.0";
            orb_moon_hard_150 = "1.5,1.5,1.5,1.5,1.5,1.5,1.5";
            orb_other_soft_1st = "5.0,5.0,5.0,5.0,5.0,5.0,5.0";
            orb_other_hard_1st = "3.0,3.0,3.0,3.0,3.0,3.0,3.0";
            orb_other_soft_2nd = "4.0,4.0,4.0,4.0,4.0,4.0,4.0";
            orb_other_hard_2nd = "2.0,2.0,2.0,2.0,2.0,2.0,2.0";
            orb_other_soft_150 = "1.5,1.5,1.5,1.5,1.5,1.5,1.5";
            orb_other_hard_150 = "1.0,1.0,1.0,1.0,1.0,1.0,1.0";
        }
    }
}
