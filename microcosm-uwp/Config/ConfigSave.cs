using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace microcosm.Config
{
    public class ConfigSave
    {
        public async static void SaveXml(ConfigData config)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigData));
            var root = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder systemFolder = await root.GetFolderAsync("system");

            var cfg = await systemFolder.GetFileAsync("config.csm");

            FileStream fs = new FileStream(cfg.Path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            serializer.Serialize(sw, config);
            sw.Dispose();
            fs.Dispose();
        }
    }
}
