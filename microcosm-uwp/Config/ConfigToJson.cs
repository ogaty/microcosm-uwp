using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace microcosm.Config
{
    class ConfigToJson
    {
        public static async void SaveJson(ConfigData configData)
        {
            var root = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder systemFolder = await root.GetFolderAsync("system");

            ConfigJson json = new ConfigJson(configData);
            StorageFile file = await systemFolder.CreateFileAsync("config.json", CreationCollisionOption.ReplaceExisting);
            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    string jsonStr = JsonConvert.SerializeObject(json, Formatting.Indented);
                    sw.Write(jsonStr);
                }
            }


        }

    }
}
