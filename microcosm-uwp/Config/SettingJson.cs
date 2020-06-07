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
        [JsonProperty("dispname")]
        public string dispname;
    }
}
