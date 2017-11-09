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
        public string place { get; set; }
        public string timezone { get; set; }
        public string memo { get; set; }
        public string datestr
        {
            get
            {
                return String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", year, month, day, hour, minute, second);
            }
        }
    }
}
