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
    class SettingFromJson
    {
        SettingData[] settings;

        public SettingFromJson()
        {
            settings = new SettingData[10];
        }


        public async Task<bool> GetSettingDataFromJson(string jsonFile, int no)
        {
            try
            {
                var root = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder systemFolder = await root.GetFolderAsync("system");
                StorageFile sampleFile = await systemFolder.GetFileAsync(jsonFile);

                var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                ulong size = stream.Size;

                using (var inputStream = stream.GetInputStreamAt(0))
                {
                    // We'll add more code here in the next step.
                    using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                    {
                        uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                        string json = dataReader.ReadString(numBytesLoaded);

                        Debug.WriteLine(json);
                        SettingJson setting = JsonConvert.DeserializeObject<SettingJson>(json);
                        settings[no] = new SettingData(no, setting);
                    }
                }
            }
            catch (Exception e)
            {
                settings[no] = new SettingData(no, new SettingJson());
            }

            return true;
        }
    }
}
