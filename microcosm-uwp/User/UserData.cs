using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using microcosm.Common;
using microcosm.Models;
using Windows.Graphics.Printing3D;

namespace microcosm.User
{
    [XmlRoot("userdata")]
    public class UserData
    {
        public int id;
        public string name;
        public string furigana;
        public int birth_year;
        public int birth_month;
        public int birth_day;
        public int birth_hour;
        public int birth_minute;
        public int birth_second;
        public DateTime birth_time;
        public double lat;
        public double lng;
        public string birth_place;
        public string memo;
        public string timezone;
        public double timezoneDouble;
        public List<UserEvent> userevent;

        public string birthdayStr
        {
            get
            {
                return String.Format("{0:0000}/{1:00}/{2:00}", birth_year, birth_month, birth_day);
            }
        }

        public string birthdayFullStr
        {
            get
            {
                return String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", birth_year, birth_month, birth_day, birth_hour, birth_minute, birth_second);
            }
        }

        /*
        [XmlElement("name")]
        public string name { get; set; }
        [XmlElement("furigana")]
        public string furigana { get; set; }
        [XmlElement("birth_year")]
        public int birth_year { get; set; }
        [XmlElement("birth_month")]
        public int birth_month { get; set; }
        [XmlElement("birth_day")]
        public int birth_day { get; set; }
        [XmlElement("birth_hour")]
        public int birth_hour { get; set; }
        [XmlElement("birth_minute")]
        public int birth_minute { get; set; }
        [XmlElement("birth_second")]
        public int birth_second { get; set; }
        public DateTime birth_time;
        [XmlElement("lat")]
        public double lat { get; set; }
        [XmlElement("lng")]
        public double lng { get; set; }
        [XmlElement("birth_place")]
        public string birth_place { get; set; }
        [XmlElement("memo")]
        public string memo { get; set; }
        [XmlElement("timezone")]
        public string timezone { get; set; }
        public double timezoneDouble;
        [XmlArray("eventlist")]
        [XmlArrayItem("event")]
        public List<UserEvent> userevent { get; set; }
        */

        public UserData()
        {
            name = "現在時刻";
            birth_time = DateTime.Now;
            birth_year = birth_time.Year;
            birth_month = birth_time.Month;
            birth_day = birth_time.Day;
            birth_hour = birth_time.Hour;
            birth_minute = birth_time.Minute;
            birth_second = birth_time.Second;
            birth_place = "";
            memo = "";
            timezone = "JST";
            timezoneDouble = 9.0;
            lat = CommonData.defaultLat;
            lng = CommonData.defaultLng;
        }

        public UserData(
            string name,
            string furigana,
            DateTime birth,
            double lat,
            double lng,
            string birth_place,
            string memo,
            string timezone
        )
        {
            this.name = name;
            this.furigana = furigana;
            this.birth_year = birth.Year;
            this.birth_month = birth.Month;
            this.birth_day = birth.Day;
            this.birth_hour = birth.Hour;
            this.birth_minute = birth.Minute;
            this.birth_second = birth.Second;
            this.birth_time = new DateTime(
                birth.Year,
                birth.Month,
                birth.Day,
                birth.Hour,
                birth.Minute,
                birth.Second
                );
            this.lat = lat;
            this.lng = lng;
            this.birth_place = birth_place;
            this.memo = memo;
            if (timezone == "JST(日本標準")
            {
                this.timezone = "JST";
            }
            else
            {
                this.timezone = timezone;
            }
        }

        /// <summary>
        /// EventをUserDataとして扱う
        /// </summary>
        /// <param name="edata"></param>
        public UserData(UserEvent edata)
        {
            this.name = edata.event_name;
            this.furigana = "";
            this.birth_year = edata.event_year;
            this.birth_month = edata.event_month;
            this.birth_day = edata.event_day;
            this.birth_hour = edata.event_hour;
            this.birth_minute = edata.event_minute;
            this.birth_second = edata.event_second;
            this.birth_time = new DateTime(
                birth_year,
                birth_month,
                birth_day,
                birth_hour,
                birth_minute,
                birth_second
                );
            this.lat = edata.event_lat;
            this.lng = edata.event_lng;
            this.birth_place = edata.event_place;
            this.memo = edata.event_memo;
            if (timezone == "JST(日本標準")
            {
                this.timezone = "JST";
            }
            else
            {
                this.timezone = edata.event_timezone;
            }
            this.userevent = new List<UserEvent>();
        }

        /// <summary>
        /// EventをUserDataとして扱う
        /// </summary>
        /// <param name="edata"></param>
        public UserData(UserEventData edata)
        {
            this.name = edata.name;
            this.furigana = "";
            this.birth_year = edata.year;
            this.birth_month = edata.month;
            this.birth_day = edata.day;
            this.birth_hour = edata.hour;
            this.birth_minute = edata.minute;
            this.birth_second = edata.second;
            this.birth_time = new DateTime(
                birth_year,
                birth_month,
                birth_day,
                birth_hour,
                birth_minute,
                birth_second
                );
            this.lat = edata.lat;
            this.lng = edata.lng;
            this.birth_place = edata.Place;
            this.memo = edata.memo;
            if (timezone == "JST(日本標準")
            {
                this.timezone = "JST";
            }
            else
            {
                this.timezone = edata.timezone;
            }
            this.userevent = new List<UserEvent>();
        }

        public UserData(UserJson json)
        {
            this.name = json.name;
            this.furigana = json.furigana;
            this.birth_year = json.birth_year;
            this.birth_month = json.birth_month;
            this.birth_day = json.birth_day;
            this.birth_hour = json.birth_hour;
            this.birth_minute = json.birth_minute;
            this.birth_second = json.birth_second;
            this.birth_place = json.birth_place;
            this.lat = json.lat;
            this.lng = json.lng;
            this.memo = json.memo;
            //this.userevent = json.events;
            this.userevent = new List<UserEvent>();
        }

        public UserEventData ToUserEventData()
        {
            return new UserEventData()
            {
                name = name,
                year = birth_year,
                month = birth_month,
                day = birth_day,
                hour = birth_hour,
                minute = birth_minute,
                second = birth_second,
                lat = lat,
                lng = lng,
                Place = birth_place,
                timezone = timezone,
                memo = memo
            };
        }
    }
}
