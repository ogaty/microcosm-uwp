using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.User
{
    [JsonObject("userdata")]
    public class UserJson
    {
        [JsonProperty("name")]
        public string name;

        [JsonProperty("furigana")]
        public string furigana;

        [JsonProperty("eventdata")]
        public List<EventJson> events;

        [JsonProperty("birth_year")]
        public int birth_year;

        [JsonProperty("birth_month")]
        public int birth_month;

        [JsonProperty("birth_day")]
        public int birth_day;

        [JsonProperty("birth_hour")]
        public int birth_hour;

        [JsonProperty("birth_minute")]
        public int birth_minute;

        [JsonProperty("birth_second")]
        public int birth_second;

        [JsonProperty("birth_place")]
        public string birth_place;

        [JsonProperty("lat")]
        public double lat;

        [JsonProperty("lng")]
        public double lng;

        [JsonProperty("timezone")]
        public string timezone;

        [JsonProperty("memo")]
        public string memo;
    }
}
