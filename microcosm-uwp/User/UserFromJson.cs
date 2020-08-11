using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace microcosm.User
{
    class UserFromJson
    {
        public async Task<UserJson> GetUserDataFromJson(string jsonFile)
        {
            UserJson user;
            try
            {
                var root = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder systemFolder = await root.GetFolderAsync("data");
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
                        user = JsonConvert.DeserializeObject<UserJson>(json);
                    }
                }
            }
            catch (Exception e)
            {
                user = null;
            }

            return user;
        }
    }
}
