using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

namespace microcosm.User
{
    public static class UserXml
    {
        public static async Task<UserData> GetUserDataFromXml(StorageFile xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
            Stream fs = await xmlFile.OpenStreamForReadAsync();
            UserData udata = new UserData("名称未設定",
                "",
                new DateTime(2000, 1, 1, 12, 0, 0),
                35.685175,
                139.7528,
                "東京都千代田区",
                "",
                "JST");
 
            try
            {
                udata = (UserData)serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
//                MessageBox.Show("ファイルの読み込みで異常が発生しました。");
                Console.WriteLine(e.Message);
            }
            fs.Dispose();

            return udata;
        }
    }
}
