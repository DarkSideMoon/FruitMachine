using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace RandomRouletteLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRoot("CollectionAchievements")]
    [DataContractAttribute]
    public class Achievement
    {
        #region Properties 
        [JsonProperty("Description")]
        [XmlElement("Description")]
        [DataMemberAttribute]
        public string SmallDescription { get; set; }

        [JsonProperty("IsDone")]
        [XmlElement("IsDone")]
        [DataMemberAttribute]
        public bool IsDone { get; set; }

        [JsonProperty("ImagePath")]
        [XmlElement("ImagePath")]
        [DataMemberAttribute]
        public string ImagePath { get; set; }

        public byte[] ImageBytes { get; set; }
        #endregion

        #region Constructors

        public Achievement() { }
        public Achievement(string smallDesc, bool isDone, string imagePath) 
        {
            this.SmallDescription = smallDesc;
            this.IsDone = isDone;
            this.ImagePath = imagePath;
        }
        #endregion

        public static byte[] ConvertPathToImage(string path)
        {
            byte[] photo = null;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(new BufferedStream(fs));
            photo = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return photo;
        }
    }
}
