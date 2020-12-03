using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using microcosm.Config;
using microcosm.Calc;
using microcosm.User;

namespace microcosm.Common
{
    public class CommonInstance
    {
        private static CommonInstance instance = new CommonInstance();
        public ConfigData config;
        public SettingData[] settings;
        public AstroCalc calc;
        public Db db;

        public UserData udata1 = new UserData();
        public UserData udata2 = new UserData();
        public UserData edata1 = new UserData();
        public UserData edata2 = new UserData();

        private CommonInstance()
        {
        }

        public static CommonInstance getInstance()
        {
            return instance;
        }
    }
}
