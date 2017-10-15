using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace microcosm.User
{
    [XmlRoot("userdata")]
    public class UserData
    {
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
        [XmlArray("eventlist")]
        [XmlArrayItem("event")]
        public List<UserEvent> userevent { get; set; }

        public UserData()
        {
            
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
    }
}
