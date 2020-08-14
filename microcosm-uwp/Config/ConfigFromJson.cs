using microcosm.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace microcosm.Config
{
    class ConfigFromJson
    {
        public async Task<bool> GetConfigDataFromJson(string jsonFile)
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

                        //Debug.WriteLine(json);
                        ConfigJson config = JsonConvert.DeserializeObject<ConfigJson>(json);
                        CommonInstance.getInstance().config = new ConfigData(config);
                    }
                }
            }
            catch (Exception e)
            {
                CommonInstance.getInstance().config = new ConfigData();
            }

            return true;
        }

    }
}
