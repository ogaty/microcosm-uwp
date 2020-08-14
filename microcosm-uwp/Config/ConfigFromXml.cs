using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace microcosm.Config
{
    /// <summary>
    /// XMLパスを指定してConfigDataを取得する
    /// </summary>
    public static class ConfigFromXml
    {
        /// <summary>
        /// XML系、もう使わない
        /// </summary>
        public static ConfigXml GetConfigFromXml(string xmlFile)
        {
            ConfigXml config;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigXml));
                FileStream fs = new FileStream(xmlFile, FileMode.Open);
                config = (ConfigXml)serializer.Deserialize(fs);
                fs.Dispose();
            }
            catch (IOException)
            {
                //                MessageBox.Show("設定ファイル読み込みに失敗しました。再作成します。");
                config = new ConfigXml();
            }

            return config;
        }
    }
}
