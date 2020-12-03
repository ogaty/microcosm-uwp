using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace microcosm.User
{
    /// <summary>
    /// UserDataをUserJsonにして保存
    /// </summary>
    class UserToJson
    {
        public static async void SaveJson(StorageFolder dir, string fileName, UserData uData)
        {
            var root = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder systemFolder = await root.GetFolderAsync("data");
            //StorageFile sampleFile = await systemFolder.GetFileAsync(String.Format("setting{0}.json", settingIndex));
            //                var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //                ulong size = stream.Size;

            UserJson json = new UserJson(uData);
            StorageFile file = await dir.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
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
