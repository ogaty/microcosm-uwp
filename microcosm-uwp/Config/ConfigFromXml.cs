using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace microcosm.Config
{
    public static class ConfigFromXml
    {
        public static ConfigData GetConfigFromXml(string xmlFile)
        {
            ConfigData config;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigData));
                FileStream fs = new FileStream(xmlFile, FileMode.Open);
                config = (ConfigData)serializer.Deserialize(fs);
                fs.Dispose();
            }
            catch (IOException)
            {
                //                MessageBox.Show("設定ファイル読み込みに失敗しました。再作成します。");
                config = new ConfigData();
            }

            return config;
        }
    }
}
