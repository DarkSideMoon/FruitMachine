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
        [JsonProperty("IdItem")]
        [XmlElement("IdItem")]
        [DataMemberAttribute]
        public int IdItem { get; set; }

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
        public Achievement(int id, string smallDesc, bool isDone, string imagePath) 
        {
            this.IdItem = id;
            this.SmallDescription = smallDesc;
            this.IsDone = isDone;
            this.ImagePath = imagePath;
        }
        #endregion

        #region Methods
        public static byte[] ConvertPathToImage(string path)
        {
            byte[] photo = null;
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(new BufferedStream(fs));
                photo = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                return photo;
            }
            catch (FileNotFoundException)
            {
                return photo;
            }
        }

        public Tuple<string, int> Result(int points, List<Achievement> listAchieves)
        {
            int resInt = 0;
            string resString = string.Empty;

            Dictionary<int, bool> dicExistAcheives = this.FindInList(listAchieves);
            Dictionary<int, bool> dicComparePoints = this.ComparePoints(points);

            foreach (var point in dicComparePoints)
            {
                // Add new achieve to string  
                resInt = point.Key;
                resString = point.Key.ToString() + "00 get points";

                foreach (var existAchieves in dicExistAcheives)
                    if (existAchieves.Key == point.Key)
                        return new Tuple<string, int>(null, 0);
            }
            return new Tuple<string,int>(resString, resInt);
        }

        public Dictionary<int, bool> ComparePoints(int points)
        {
            int points_res = points.RoundToHundrets();

            Dictionary<int, bool> res = new Dictionary<int, bool>();
            switch (points_res)
            {
                case 100:
                case 200:
                case 300:
                    res.Add(2, true);
                    break;
                case 400:
                case 500:
                    res.Add(4, true);
                    break;
                case 600:
                case 700:
                    res.Add(6, true);
                    break;
                case 800:
                    res.Add(8, true);
                    break;
                case 900:
                    res.Add(9, true);
                    break;
                case 1000:
                    res.Add(10, true);
                    break;
                default:
                    break;
            }
            return res;
        }

        public Dictionary<int, bool> FindInList(List<Achievement> listAchievements)
        {
            //int counter = 0;
            Dictionary<int, bool> res = new Dictionary<int, bool>();
            foreach (Achievement item in listAchievements)
                switch (item.IdItem)
                {
                    case 2:
                        res.Add(2, true);
                        break;
                    case 4:
                        res.Add(4, true);
                        break;
                    case 6:
                        res.Add(6, true);
                        break;
                    case 8:
                        res.Add(8, true);
                        break;
                    case 9:
                        res.Add(9, true);
                        break;
                    case 10:
                        res.Add(10, true);
                        break;
                    default:
                        break;
                }
            return res;
        }
        #endregion
    }
}
