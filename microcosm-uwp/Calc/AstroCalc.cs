using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissEphNet;
using System.IO;
using System.Diagnostics;
using Windows.Storage;
using Windows.Storage.Streams;

using microcosm.Views;
using microcosm.Config;
using microcosm.Models;
using microcosm.User;
using microcosm.Common;

namespace microcosm.Calc
{
    public class AstroCalc
    {
        public SwissEph s;
        public Stream swiss_stream;

        public AstroCalc(MainPage main)
        {
            s = new SwissEph();
        }

        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        async Task<Stream> GetSwissFile(string fileName) {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/" + fileName));
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            byte[] buff2 = new byte[buffer.Length];
            MemoryStream stream = new MemoryStream(buff2);

            return stream;
        }


        /// <summary>
        /// planet position calcurate.
        /// </summary>
        /// <param name="timezone">Timezone. JST=9.0</param>
        public List<PlanetData> PositionCalc(DateTime time, double timezone)
        {
            List<PlanetData> planetList = new List<PlanetData>();
            s.swe_set_ephe_path(Windows.Storage.ApplicationData.Current.LocalFolder.Path + "/ephe");
            s.OnLoadFile += (sender, e) => {
                if (File.Exists(e.FileName))
                {
                    e.File = new FileStream(e.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                }
            };
            int utc_year = 0;
            int utc_month = 0;
            int utc_day = 0;
            int utc_hour = 0;
            int utc_minute = 0;
            double utc_second = 0;
            double[] dret = { 0.0, 0.0 };
            double[] x = { 0, 0, 0, 0, 0, 0 };
            string serr = "";

            s.swe_utc_time_zone(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, timezone,
                                ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            int flag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED;
//            flag = flag | SwissEph.SEFLG_HELCTR;

            // display設定で再計算させないようにあらかじめ全て計算しておく

            foreach (int planet_number in Common.CommonData.target_numbers)
            {
                int planet_number2 = 0;
                s.swe_calc_ut(dret[1], planet_number, flag, x, ref serr);
                if (planet_number == 100377)
                {
                    planet_number2 = CommonData.ZODIAC_NUMBER_SEDNA;
                }
                else if (planet_number == 146199)
                {
                    planet_number2 = CommonData.ZODIAC_NUMBER_ERIS;
                }
                else if (planet_number == 146108)
                {
                    planet_number2 = CommonData.ZODIAC_NUMBER_HAUMEA;
                }
                else if (planet_number == 146472)
                {
                    planet_number2 = CommonData.ZODIAC_NUMBER_MAKEMAKE;
                }
                else
                {
                    planet_number2 = planet_number;
                }
                PlanetData p = new PlanetData()
                {
                    no = planet_number2,
                    absolute_position = x[0]
                };
                planetList.Add(p);
            }

            return planetList;
        }

        /// <summary>
        /// ハウス計算
        /// </summary>
        /// <returns>The calculate.</returns>
        /// <param name="d">時刻</param>
        /// <param name="lat">緯度</param>
        /// <param name="lng">経度</param>
        /// <param name="houseKind">ハウス種別
        /// 0:Placidus
        /// 1:Koch
        /// 2:Campanus
        /// 
        /// </param>
        /// 
        public double[] CuspCalc(DateTime d, double lat, double lng, double timezone, EHouseCalc houseKind)
        {
            s.swe_set_ephe_path(Windows.Storage.ApplicationData.Current.LocalFolder.Path + "/ephe");
            s.OnLoadFile += (sender, e) => {
                if (File.Exists(e.FileName))
                {
                    e.File = new FileStream(e.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                }
            };

            int utc_year = 0;
            int utc_month = 0;
            int utc_day = 0;
            int utc_hour = 0;
            int utc_minute = 0;
            double utc_second = 0;
            string serr = "";
            // [0]:Ephemeris Time [1]:Universal Time
            double[] dret = { 0.0, 0.0 };

            // utcに変換
            s.swe_utc_time_zone(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, timezone, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            double[] cusps = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] ascmc = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            if (houseKind == EHouseCalc.PLACIDUS)
            {
                // Placidas
                s.swe_houses(dret[1], lat, lng, 'P', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.KOCH)
            {
                // Koch
                s.swe_houses(dret[1], lat, lng, 'K', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.CAMPANUS)
            {
                // Campanus
                s.swe_houses(dret[1], lat, lng, 'C', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.PORPHYRY)
            {
                // Porphyrious
                s.swe_houses(dret[1], lat, lng, 'O', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.REGIOMONTANUS)
            {
                // Porphyrious
                s.swe_houses(dret[1], lat, lng, 'R', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.EQUAL)
            {
                // Equal
                s.swe_houses(dret[1], lat, lng, 'E', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.SOLAR)
            {
                // Solar
                // 太陽の度数をASCとして30度
            }
            else if (houseKind == EHouseCalc.SOLARSIGN)
            {
                // SolarSign
                // 太陽のサインの0度をASCとして30度
            }
            s.swe_close();

            return cusps;
        }


        public Calcuration ReCalc(ConfigData config, SettingData setting, UserData udata)
        {
            List<PlanetData> p = PositionCalc(udata.birth_time, udata.timezoneDouble);
            double[] cusps = CuspCalc(udata.birth_time, udata.lat, udata.lng, udata.timezoneDouble, config.houseCalc);
            Calcuration calcurate = new Calcuration(p, cusps);

            return calcurate;
        }
    }
}
