using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace microcosm.Config
{
    public static class SettingToJson
    {
        /// <summary>
        /// settingDataをsettingJsonに変換して保存
        /// </summary>
        /// <param name="settingIndex"></param>
        /// <param name="settingData"></param>
        public static async void SaveJson(int settingIndex, SettingData settingData)
        {
                var root = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder systemFolder = await root.GetFolderAsync("system");
            //StorageFile sampleFile = await systemFolder.GetFileAsync(String.Format("setting{0}.json", settingIndex));
            //                var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //                ulong size = stream.Size;

            SettingJson json = new SettingJson(settingData);
            StorageFile file = await systemFolder.CreateFileAsync(String.Format("setting{0}.json", settingIndex), CreationCollisionOption.ReplaceExisting);
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
