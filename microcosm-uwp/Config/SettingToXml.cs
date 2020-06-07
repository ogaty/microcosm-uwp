using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace microcosm.Config
{
    public static class SettingToXml
    {
        public static async void SaveXml(int settingIndex, SettingData settingData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingXml));
//            Stream fs = new FileStream("setting" + settingIndex.ToString() + ".csm", FileMode.Create);
//            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
            // Serialize using the XmlTextWriter.
//            serializer.Serialize(writer, new SettingXml());
////            writer.Close();

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = 
                await storageFolder.CreateFileAsync("sample.json",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);

            var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

            //            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");

            string json = JsonConvert.SerializeObject(new SettingXml(), Newtonsoft.Json.Formatting.Indented);

            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                // We'll add more code here in the next step.
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(json);
//                    serializer.Serialize(outputStream, new SettingXml());

                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose(); // Or use the stream variable (see previous code snippet) with a using statement as well.


        }

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
            catch (InvalidOperationException e)
            {
                setting = new SettingData(no, null);
            }


            return setting;
        }
    }
}
