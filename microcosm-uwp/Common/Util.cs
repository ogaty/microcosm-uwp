using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Common
{
    public static class Util
    {
        public static string DateTimeToString(DateTime dateTime, string timezone)
        {
            string year = dateTime.Year.ToString();
            string month = dateTime.Month.ToString();
            string day = dateTime.Day.ToString();
            string hour = dateTime.Hour.ToString();
            string minute = dateTime.Minute.ToString();
            string second = dateTime.Second.ToString();

            // todo あとでstringformatに
            return year + "年" + month + "月" + day + "日" + 
                " " + 
                hour + "時" + minute + "分" + second + "秒" + " " + timezone;
        }
    }
}
