using microcosm.Config;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
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
            await ApplicationData.Current.LocalFolder.CreateFileAsync("microcosm.db", CreationCollisionOption.OpenIfExists);
            dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "microcosm.db");
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

            using (SqliteConnection db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                for (int i = 0; i < 10; i++)
                {
                    setting[i] = new SettingData();
                    string tableCommand = "select * from settings";
                    SqliteCommand getSettings = new SqliteCommand(tableCommand, db);

                    SqliteDataReader query = getSettings.ExecuteReader();

                    while (query.Read())
                    {
                        setting[i].dispName = query["dispname"].ToString();
                        string id = query["id"].ToString();

                        string command = "select * from setting_disp_planets where setting_ id = " + id;
                        getSettings = new SqliteCommand(command, db);

                        query = getSettings.ExecuteReader();
                        while (query.Read())
                        {
                            setting[i].dispPlanet[int.Parse(query["ring_no"].ToString())][int.Parse(query["planet_no"].ToString())] = query["is_disp"].ToString() == "1";
                        }
                    }



                }





                db.Close();

            }
        }
    }
}
