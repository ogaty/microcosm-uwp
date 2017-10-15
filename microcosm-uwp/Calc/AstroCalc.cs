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
        public void PositionCalc(double timezone)
        {
            s.swe_set_ephe_path(Windows.Storage.ApplicationData.Current.LocalFolder.Path + "/ephe");
            s.OnLoadFile += (sender, e) => {
                if (File.Exists(e.FileName))
                {
                    e.File = new FileStream(e.FileName, FileMode.Open);
                }
                /*
                string fileName = Path.GetFileName(e.FileName);

                StorageFile file;
                switch (fileName)
                {
                    case "seas_18.se1":
                    case "sepl_18.se1":
                    case "semo_18.se1":
                        e.File = Task.Run(async () => await GetSwissFile(fileName)).Result;
                        break;
                    case "seleapsec.txt":
                        Task.Run(async () => {
                            file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/" + fileName));
                            e.File = GenerateStreamFromString(await FileIO.ReadTextAsync(file));
                        });
                        break;
                    default:
                        break;
                }
                */
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

            s.swe_utc_time_zone(1980, 12, 21, 12, 0, 0, timezone,
                                ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            int flag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED;
//            flag = flag | SwissEph.SEFLG_HELCTR;

            // display設定で再計算させないようにあらかじめ計算しておく

            foreach (int planet_number in Common.CommonData.target_numbers)
            {
                s.swe_calc_ut(dret[1], planet_number, flag, x, ref serr);
                Debug.WriteLine(planet_number.ToString() + " " + x[0]);
                Debug.WriteLine(serr);
            }


        }
    }
}
