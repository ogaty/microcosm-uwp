using microcosm.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    public class UserEventData
    {
        public string name { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string Place { get; set; }
        public string timezone { get; set; }
        public string memo { get; set; }
        public int index { get; set; }
        public string datestr
        {
            get
            {
                return String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", year, month, day, hour, minute, second);
            }
        }
        public string LatLng
        {
            get
            {
                return String.Format("{0:00.000}/{1:000.000}", lat, lng);
            }
        }

        public UserEventData()
        {

        }

        public UserEventData(UserData udata, int index)
        {
            name = udata.name;
            year = udata.birth_year;
            month = udata.birth_month;
            day = udata.birth_day;
            hour = udata.birth_hour;
            minute = udata.birth_minute;
            second = udata.birth_second;
            Place = udata.birth_place;
            lat = udata.lat;
            lng = udata.lng;
            memo = udata.memo;
            timezone = udata.timezone;
            this.index = index;
        }

        public UserEventData(UserEvent ev, int index)
        {
            name = ev.event_name;
            year = ev.event_year;
            month = ev.event_month;
            day = ev.event_day;
            hour = ev.event_hour;
            minute = ev.event_minute;
            second = ev.event_second;
            Place = ev.event_place;
            lat = ev.event_lat;
            lng = ev.event_lng;
            memo = ev.event_memo;
            timezone = ev.event_timezone;
            this.index = index;
        }
    }
}
