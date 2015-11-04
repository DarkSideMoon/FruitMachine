using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;

namespace RandomRouletteLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRoot("UserDetails")]
    [DataContractAttribute]
    public class User
    {
        // Const starts per one game
        public const int StartsPerGame = 5;

        private static List<User> _usersInGame = new List<User>();
        public static int UserCurrentStarts = 0;
        private static User _user;

        private string _pathToDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".game");
        private string _fileName = "Users.xml";

        #region Properties
        [XmlIgnore]
        public static User CurrentUser
        {
            get { return _user; }
            set { _user = value; }
        }

        [XmlAttribute("Id")]
        public Guid Id { get; set; }

        [JsonProperty("NickName")]
        [XmlElement("NickName")]
        [DataMemberAttribute]
        public string NickName { get; set; }

        [JsonProperty("CurrentPoints")]
        [XmlElement("Points")]
        [DataMemberAttribute]
        public int CurrentPoints { get; set; }

        [JsonProperty("Debt")]
        [XmlElement("Debt")]
        [DataMemberAttribute]
        public double Debt { get; set; }

        [JsonProperty("Status")]
        [XmlElement("Status")]
        [DataMemberAttribute]
        public string Status { get; set; }
        
        [JsonProperty("Level")]
        [XmlElement("Level")]
        [DataMemberAttribute]
        public int Level { get; set; }

        [JsonProperty("Item")]
        [XmlArray("CollectionAchievements"), XmlArrayItem("Item")]
        [DataMemberAttribute]
        public List<Achievement> Achievements { get; set; }

        [XmlIgnore]
        public BitmapImage LevelImage { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor to initialize user such as object 
        /// </summary>
        public User() { }

        /// <summary>
        /// Constructor load user info. 
        /// If not load info than create new user 
        /// </summary>
        /// <param name="nickName">Nick of user</param>
        public User(string nickName)
        {
            NickName = nickName;
            Achievements = new List<Achievement>();

            if (!LoadUserProfile())
                CreateNewProfile();
        }

        /// <summary>
        /// Constructor create new user 
        /// </summary>
        /// <param name="name">Neck name</param>
        /// <param name="points">Points</param>
        /// <param name="debt">Debt</param>
        /// <param name="status">Status</param>
        /// <param name="level">Level</param>
        /// <param name="achievements">Achieves</param>
        public User(string name, int points, double debt, string status, int level, List<Achievement> achievements)
        {
            NickName = name;
            CurrentPoints = points;
            Debt = debt;
            Status = status;
            Level = level;
            Achievements = achievements;

            Id = Guid.NewGuid();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get additional points for user 
        /// </summary>
        public void GetCredit()
        {
            if (this.CurrentPoints <= 30)
            {
                this.CurrentPoints = this.CurrentPoints + 150;
                this.Debt += 100;
            }
        }

        /// <summary>
        /// Create new profile if is not exist
        /// </summary>
        private void CreateNewProfile()
        {
            List<User> users = new List<User>();
            User us = new User(NickName, 500, 0, "Junior", 1, new List<Achievement>()); 
            _user = us;
            users.Add(us);
            _usersInGame.Add(us);

            if (!Directory.Exists(_pathToDirectory + "\\" + _fileName))
                Directory.CreateDirectory(_pathToDirectory);

            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (TextWriter writer = new StreamWriter(_pathToDirectory + "/" + _fileName))
            {
                serializer.Serialize(writer, users);
            }
        }

        /// <summary>
        /// Open the .xml file with paramatrs
        /// </summary>
        /// <returns></returns>
        private XmlDocument OpenXmlDoc()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(_pathToDirectory + "/" + _fileName);
            return xml;
        }

        /// <summary>
        /// True: load user info if user is exist 
        /// False: can not load info - user is not exist 
        /// </summary>
        /// <returns>True/Falss</returns>
        private bool LoadUserProfile()
        {
            try
            {
                XmlDocument xml = OpenXmlDoc();
                XmlNodeList xnList = xml.SelectNodes("ArrayOfUser");
                foreach (XmlNode xn in xnList)
                {
                    XmlNodeList user = xn.SelectNodes("User");
                    foreach (XmlNode item in user)
                        if(item["NickName"].InnerText == this.NickName && user != null)
                        {
                            _user = new User()
                            {
                                NickName = item["NickName"].InnerText,
                                CurrentPoints = Convert.ToInt32(item["Points"].InnerText),
                                Debt = Convert.ToInt32(item["Debt"].InnerText),
                                Status = item["Status"].InnerText,
                                Level = Convert.ToInt32(item["Level"].InnerText),
                            };

                            _user.Achievements = GetAchievements();
                            _usersInGame.Add(_user);
                            return true;
                        }        
                }
            return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Save the current game of user to xml file 
        /// </summary>
        public void SaveGame()
        {
            XmlDocument xml = OpenXmlDoc();
            XmlNodeList xnList = xml.SelectNodes("ArrayOfUser");
            foreach (XmlNode xn in xnList)
            {
                XmlNodeList list = xn.SelectNodes("User");
                foreach (XmlNode item in list)
                    if (item["NickName"].InnerText == this.NickName)
                    {
                        item["Points"].InnerText = this.CurrentPoints.ToString();
                        item["Debt"].InnerText = this.Debt.ToString();
                        item["Status"].InnerText = this.Status;
                        item["Level"].InnerText = this.Level.ToString();
                    }
            }
            xml.Save(_pathToDirectory + "\\" + _fileName);
        }

        /// <summary>
        /// Save the current achievements of user 
        /// </summary>
        public void SaveAchievements()
        {
            foreach (var achieve in Achievements)
                if (achieve != null)
                {
                    XmlDocument xml = OpenXmlDoc();
                    XmlNode lastItem = xml.DocumentElement.LastChild.LastChild;

                    XmlElement newItem = xml.CreateElement("Item");

                    XmlElement desc = xml.CreateElement("Description");
                    desc.InnerText = achieve.SmallDescription;
                    
                    XmlElement isDone = xml.CreateElement("IsDone");
                    isDone.InnerText = achieve.IsDone.ToString();
                    
                    XmlElement imagePath = xml.CreateElement("Image");
                    imagePath.InnerText = achieve.ImagePath;
                    
                    XmlElement itemId = xml.CreateElement("IdItem");
                    itemId.InnerText = achieve.IdItem.ToString();

                    // The header of Item
                    lastItem.AppendChild(newItem);

                    // The child of new Item
                    newItem.AppendChild(itemId);
                    newItem.AppendChild(desc);
                    newItem.AppendChild(isDone);
                    newItem.AppendChild(imagePath);

                    xml.Save(_pathToDirectory + "\\" + _fileName);
                }
                else
                    return;
        }

        /// <summary>
        /// ---------------NOT USEFUL---------------
        /// Add user ot list online users
        /// Create for testing rest service
        /// </summary>
        /// <param name="user">User</param>
        public void AddUserOnline(User user)
        {
            _usersInGame.Add(user);
        }

        /// <summary>
        /// ---------------NOT USEFUL---------------
        /// Create for testing rest service
        /// </summary>
        /// <returns>List online users</returns>
        public static List<User> GetUsersOnline()
        {  
            return _usersInGame;
        }
        
        /// <summary>
        /// Get user achievements
        /// </summary>
        /// <returns>List of user achievements</returns>
        public List<Achievement> GetAchievements()
        {
            List<Achievement> list = new List<Achievement>();

            XmlDocument xml = OpenXmlDoc();
            XmlNodeList xnList = xml.SelectNodes("ArrayOfUser");
            foreach (XmlNode xn in xnList)
            {
                XmlNodeList listNode = xn.SelectNodes("User");
                foreach (XmlNode item in listNode)
                    if (item["NickName"].InnerText == this.NickName)
                    {
                        XmlNodeList achieveCollection = item.SelectNodes("CollectionAchievements");
                        foreach (XmlNode ach in achieveCollection)
                        {
                            XmlNodeList achieveList = ach.SelectNodes("Item");
                            foreach (XmlNode item3 in achieveList)
                            {
                                int id = Convert.ToInt32(item3["IdItem"].InnerText);
                                string desc = item3["Description"].InnerText;
                                bool isDone = Convert.ToBoolean(item3["IsDone"].InnerText);
                                string image = item3["Image"].InnerText;

                                list.Add(new Achievement(id, desc, isDone, image));
                            }
                        }
                    }
            }
            return list;
        }

        public override string ToString()
        {
            return this.NickName;
        }

        #endregion
    }
}
