using microcosm.Config;
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

            return String.Format("{0}/{1}/{2} {3}:{4}:{5} {6}", year, month, day, hour, minute, second, timezone);
        }


        /// <summary>
        /// ♈ 15.10みたいな感じで返す
        /// </summary>
        /// <param name="absolute_position"></param>
        /// <returns></returns>
        public static string getPlanetDegree(double absolute_position)
        {
            double degree = absolute_position % 30;
            string symbol = CommonData.getSignAlfabet((int)(absolute_position / 30));
            EDecimalDisp decimalDisp = CommonInstance.getInstance().config.decimal_disp;
            if (decimalDisp == EDecimalDisp.DECIMAL)
            {
                return symbol + String.Format("{0:f2}",degree);
            } else
            {
                return symbol + DecimalToHex(degree).ToString();
            }
        }

        public static double DecimalToHex(string decimalStr)
        {
            double tmp = double.Parse(decimalStr);
            double ftmp = tmp - (int)tmp;
            ftmp = ftmp / 100 * 60;
            int itmp = (int)tmp;
            return itmp + ftmp;
        }

        public static double DecimalToHex(double tmp)
        {
            double ftmp = tmp - (int)tmp;
            ftmp = ftmp / 100 * 60;
            int itmp = (int)tmp;
            return itmp + ftmp;
        }
    }
}
