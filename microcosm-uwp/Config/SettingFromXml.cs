using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace microcosm.Config
{
    public static class SettingFromXml
    {
        public static SettingData GetSettingFromXml(string xmlFile, int no)
        {
            SettingXml settingXml;
            SettingData setting;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingXml));
                FileStream fs = new FileStream(xmlFile, FileMode.Open);
                settingXml = (SettingXml)serializer.Deserialize(fs);
                fs.Dispose();
                setting = new SettingData(no, settingXml);
            }
            catch (IOException)
            {
                //                MessageBox.Show("設定ファイル読み込みに失敗しました。再作成します。");
                setting = new SettingData(no, null);
            }
            catch (InvalidOperationException)
            {
                setting = new SettingData(no, null);
            }


            return setting;
        }
    }
}
