using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.User
{
    [JsonObject("eventdata")]
    public class EventJson
    {
        [JsonProperty("name")]
        public string name;
    }
}
