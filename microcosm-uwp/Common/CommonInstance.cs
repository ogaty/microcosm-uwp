using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using microcosm.Config;
using microcosm.Calc;

namespace microcosm.Common
{
    public class CommonInstance
    {
        private static CommonInstance instance = new CommonInstance();
        public ConfigData config;
        public SettingData[] settings;
        public AstroCalc calc;

        private CommonInstance()
        {
        }

        public static CommonInstance getInstance()
        {
            return instance;
        }
    }
}
