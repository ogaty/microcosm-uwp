using microcosm.Config;
using microcosm.Models;
using microcosm.User;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace microcosm.Common
{
    public class Db
    {
        string dbPath;

        public async void init()
        {
//            await ApplicationData.Current.LocalFolder.CreateFileAsync("microcosm.db", CreationCollisionOption.OpenIfExists);
            dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "microcosm.db");
            /*
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                string tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS config (id INTEGER PRIMARY KEY, ephepath NVARCHAR(2048) default 'ephe', centric integer default 0, is_sidereal integer default 0, " +
                    "default_place nvarchar(2048) default '東京都', default_lat real default 35.670587, default_lng real default 139.772003, default_timezone string default 'JST', " +
                    "progression integer default 0, house integer default 0, decimal_disp integer default 0)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();

                tableCommand = @"
                    create table if not exists settings (
                        id integer primary key,
                        dispname string
                    )";

                createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();

                tableCommand = @"
                    create table if not exists setting_disp_planets (
                        id integer primary key,
                        setting_id integer,
                        planet_no integer,
                        is_disp integer
                    )";

                createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();


                SqliteCommand selectCommand = new SqliteCommand("SELECT count(*) from config", db);

                long exists = (long)selectCommand.ExecuteScalar();

                if (exists == 0)
                {
                    string insert = @"
                        insert into config (ephepath, centric, is_sidereal, default_place, default_lat, default_lng, default_timezone, progression, house, decimal_disp)
                        values ('ephe', 0, 0, '東京都', 35.670587, 139.772003, 'JST', 0, 0, 0)
                    ";

                    SqliteCommand com = new SqliteCommand(insert, db);
                    com.ExecuteNonQuery();
                }

                selectCommand = new SqliteCommand("SELECT count(*) from settings", db);

                exists = (long)selectCommand.ExecuteScalar();

                if (exists < 10)
                {
                    for (int i = 0; i < 10 - exists; i++)
                    {
                        string insert = @"
                        insert into settings (dispname) values ('設定" + i.ToString() + "')";
                        SqliteCommand com = new SqliteCommand(insert, db);
                        com.ExecuteNonQuery();
                    }
                }

                db.Close();
            }
            */

        }

        public void selectConfig()
        {
            ConfigData config = new ConfigData();
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                string tableCommand = "select * from config";

                SqliteCommand getConfig = new SqliteCommand(tableCommand, db);

                SqliteDataReader query = getConfig.ExecuteReader();

                while (query.Read())
                {
                    config.ephepath = query["ephepath"].ToString();
                    config.centric = query["centric"].ToString() == "0" ? ECentric.GEO_CENTRIC : ECentric.HELIO_CENTRIC;
                    config.sidereal = query["is_sidereal"].ToString() == "0" ? ESidereal.TROPICAL : ESidereal.SIDEREAL;
                    config.default_place = query["default_place"].ToString();
                    config.default_lat = Double.Parse(query["default_lat"].ToString());
                    config.default_lng = Double.Parse(query["default_lng"].ToString());
                    config.default_timezone = query["default_timezone"].ToString();
                    switch (query["progression"].ToString())
                    {
                        case "0":
                            config.progression = EProgression.PRIMARY;
                            break;
                        case "1":
                            config.progression = EProgression.SECONDARY;
                            break;
                        case "2":
                            config.progression = EProgression.CPS;
                            break;
                    }
                    switch (query["house"].ToString())
                    {
                        case "0":
                            config.house = EHouseCalc.PLACIDUS;
                            break;
                        case "1":
                            config.house = EHouseCalc.KOCH;
                            break;
                        case "2":
                            config.house = EHouseCalc.CAMPANUS;
                            break;
                    }
                }

                db.Close();
            }

            CommonInstance.getInstance().config = config;
        }

        public void selectSettings()
        {
            SettingData[] setting = new SettingData[10];
            CommonInstance.getInstance().settings = new SettingData[10];

            for (int i = 0; i < 10; i++)
            {
                CommonInstance.getInstance().settings[i] = new SettingData();
            }

            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                for (int i = 0; i < 10; i++)
                {
                    setting[i] = new SettingData();
                }

                string tableCommand = "select * from settings";
                SqliteCommand getSettings = new SqliteCommand(tableCommand, db);

                SqliteDataReader query = getSettings.ExecuteReader();

                int index = 0;
                while (query.Read())
                {
                    setting[index].dispName = query["dispname"].ToString();
                    string id = query["id"].ToString();

                    for (int ring_no = 0; ring_no < 7; ring_no++)
                    {
                        string command = "select * from setting_disp_planets where setting_id = " + id + " and ring_no = " + ring_no;
                        getSettings = new SqliteCommand(command, db);

                        Dictionary<int, bool> dp = new Dictionary<int, bool>();
                        SqliteDataReader query2 = getSettings.ExecuteReader();
                        while (query2.Read())
                        {
                            dp[int.Parse(query2["planet_no"].ToString())] = query2["is_disp"].ToString() == "1";
                        }
                        setting[index].dispPlanet.Add(dp);

                        string command2 = "select * from orb where setting_id = " + id + " and ring_no = " + ring_no;
                        getSettings = new SqliteCommand(command2, db);
                        SqliteDataReader query3 = getSettings.ExecuteReader();

                        Dictionary<OrbKind, double> o = new Dictionary<OrbKind, double>();
                        while (query3.Read())
                        {
                            if (query3["planet_kind"].ToString() == "0")
                            {
                                if (query3["soft_hard"].ToString() == "0")
                                {
                                    if (query3["orb_kind"].ToString() == "0")
                                    {
                                        o[OrbKind.SUN_SOFT_1ST] = double.Parse(query3["orb"].ToString());
                                    }
                                    else if (query3["orb_kind"].ToString() == "1")
                                    {
                                        o[OrbKind.SUN_SOFT_2ND] = double.Parse(query3["orb"].ToString());
                                    }
                                    else
                                    {
                                        o[OrbKind.SUN_SOFT_150] = double.Parse(query3["orb"].ToString());
                                    }
                                }
                                else
                                {
                                    if (query3["orb_kind"].ToString() == "0")
                                    {
                                        o[OrbKind.SUN_HARD_1ST] = double.Parse(query3["orb"].ToString());
                                    }
                                    else if (query3["orb_kind"].ToString() == "1")
                                    {
                                        o[OrbKind.SUN_HARD_2ND] = double.Parse(query3["orb"].ToString());
                                    }
                                    else
                                    {
                                        o[OrbKind.SUN_HARD_150] = double.Parse(query3["orb"].ToString());
                                    }
                                }
                            }
                            else if (query3["planet_kind"].ToString() == "1")
                            {
                                if (query3["soft_hard"].ToString() == "0")
                                {
                                    if (query3["orb_kind"].ToString() == "0")
                                    {
                                        o[OrbKind.MOON_SOFT_1ST] = double.Parse(query3["orb"].ToString());
                                    }
                                    else if (query3["orb_kind"].ToString() == "1")
                                    {
                                        o[OrbKind.MOON_SOFT_2ND] = double.Parse(query3["orb"].ToString());
                                    }
                                    else
                                    {
                                        o[OrbKind.MOON_SOFT_150] = double.Parse(query3["orb"].ToString());
                                    }
                                }
                                else
                                {
                                    if (query3["orb_kind"].ToString() == "0")
                                    {
                                        o[OrbKind.MOON_HARD_1ST] = double.Parse(query3["orb"].ToString());
                                    }
                                    else if (query3["orb_kind"].ToString() == "1")
                                    {
                                        o[OrbKind.MOON_HARD_2ND] = double.Parse(query3["orb"].ToString());
                                    }
                                    else
                                    {
                                        o[OrbKind.MOON_HARD_150] = double.Parse(query3["orb"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (query3["soft_hard"].ToString() == "0")
                                {
                                    if (query3["orb_kind"].ToString() == "0")
                                    {
                                        o[OrbKind.OTHER_SOFT_1ST] = double.Parse(query3["orb"].ToString());
                                    }
                                    else if (query3["orb_kind"].ToString() == "1")
                                    {
                                        o[OrbKind.OTHER_SOFT_2ND] = double.Parse(query3["orb"].ToString());
                                    }
                                    else
                                    {
                                        o[OrbKind.OTHER_SOFT_150] = double.Parse(query3["orb"].ToString());
                                    }
                                }
                                else
                                {
                                    if (query3["orb_kind"].ToString() == "0")
                                    {
                                        o[OrbKind.OTHER_HARD_1ST] = double.Parse(query3["orb"].ToString());
                                    }
                                    else if (query3["orb_kind"].ToString() == "1")
                                    {
                                        o[OrbKind.OTHER_HARD_2ND] = double.Parse(query3["orb"].ToString());
                                    }
                                    else
                                    {
                                        o[OrbKind.OTHER_HARD_150] = double.Parse(query3["orb"].ToString());
                                    }
                                }
                            }
                        }
                        setting[index].orbs.Add(o);
                    }

                    for (int aspect_combination = 0; aspect_combination < 28; aspect_combination++)
                    {
                        int from = 0;
                        int to = 0;
                        CommonData.GeAspectCombination(aspect_combination, out from, out to);
                        string command = "select * from setting_disp_aspect_planets where setting_id = " + id + " and ring_from = " + from + " and ring_to = " + to;
                        getSettings = new SqliteCommand(command, db);

                        Dictionary<int, bool> da = new Dictionary<int, bool>();
                        SqliteDataReader query3 = getSettings.ExecuteReader();
                        while (query3.Read())
                        {
                            da[int.Parse(query3["planet_no"].ToString())] = query3["is_disp"].ToString() == "1";
                        }
                        setting[index].dispAspectPlanet.Add(da);

                        string command2 = "select * from setting_disp_aspect_category where setting_id = " + id + " and ring_from = " + from + " and ring_to = " + to;
                        getSettings = new SqliteCommand(command2, db);

                        Dictionary<Models.AspectKind, bool> dak = new Dictionary<Models.AspectKind, bool>();
                        SqliteDataReader query4 = getSettings.ExecuteReader();
                        while (query4.Read())
                        {
                            string a = query4["category_no"].ToString();
                            dak[CommonData.GetEnumAspectKind(query4["category_no"].ToString())] = query4["is_disp"].ToString() == "1";
                        }
                        setting[index].dispAspectCategory.Add(dak);
                    }

                    index++;
                }



                db.Close();

                CommonInstance.getInstance().settings = setting;
            }
        }

        public List<TreeViewItem2> selectUserList()
        {
            List<TreeViewItem2> udataList = new List<TreeViewItem2>();

            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                string tableCommand = "select * from user_data";
                SqliteCommand getUserData = new SqliteCommand(tableCommand, db);

                SqliteDataReader query = getUserData.ExecuteReader();

                while (query.Read())
                {
                    try
                    {
                        UserEventData udata = new UserEventData()
                        {
                            name = query["name"].ToString(),
                            furigana = query["furigana"].ToString(),
                            year = int.Parse(query["birth_year"].ToString()),
                            month = int.Parse(query["birth_month"].ToString()),
                            day = int.Parse(query["birth_day"].ToString()),
                            hour = int.Parse(query["birth_hour"].ToString()),
                            minute = int.Parse(query["birth_minute"].ToString()),
                            second = int.Parse(query["birth_second"].ToString()),
                            lat = double.Parse(query["lat"].ToString()),
                            lng = double.Parse(query["lng"].ToString()),
                            Place = query["birth_place"].ToString(),
                            timezone = query["time_zone"].ToString(),
                            memo = query["memo"].ToString(),
                        };
                        TreeViewItem2 tree = new TreeViewItem2()
                        {
                            Name = udata.name,
                            userData = udata
                        };
                        udataList.Add(tree);
                    } catch
                    {
                        Debug.WriteLine("user skip");
                    }
                }
            }

            return udataList;
        }


        public void CreateUser(UserData uData)
        {

            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                // 0 1 name
                // 2 3 4 birthday
                // 5 6 7 birthtime
                // 8 9 latlng
                // 10 11 birth_place,timezone
                // 12 memo
                string insert = string.Format(@"insert into user_data (name, furigana, birth_year, birth_month, birth_day, birth_hour, birth_minute, birth_second, lat, lng, birth_place, time_zone, memo) 
                    values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", 
                    uData.name, 
                    uData.furigana, 
                    uData.birth_year.ToString(), 
                    uData.birth_month.ToString(), 
                    uData.birth_day.ToString(),
                    uData.birth_hour.ToString(),
                    uData.birth_minute.ToString(),
                    uData.birth_second.ToString(),
                    uData.lat.ToString(),
                    uData.lng.ToString(),
                    uData.birth_place,
                    uData.timezone,
                    uData.memo
                    );
                SqliteCommand com = new SqliteCommand(insert, db);
                com.ExecuteNonQuery();
            }
        }


    }
}
