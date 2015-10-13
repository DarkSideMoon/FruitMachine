using RandomRouletteLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Media.Imaging;

namespace RandomRouletteWcfREST
{
    public class GameService : IGameService
    {
        #region Implementation of IGameService

        public User LoadUserInfo(string nickName)
        {
            User user = new User(nickName);
            return User.CurrentUser;
        }

        public bool IsAlive()
        {
            return true;
        }

        public void AddUserOnline(string userNick)
        {
            User us = new User(userNick);
            us.AddUserOnline(User.CurrentUser);
        }

        public User[] GetUsersOnline()
        {
            return User.GetUsersOnline().ToArray();
        }

        public string GetRules()
        {
            string res = null;
            string rulesPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "Rules.txt");
            using(StreamReader reader = new StreamReader(rulesPath))
            {
                res = reader.ReadToEnd();
            }
            return res;
        }

        public Achievement[] GetUserAchievements(string nickName)
        {
            User us = new User(nickName);
            us = User.CurrentUser;
            return us.Achievements.ToArray();
        }

        public bool SendPoints(string input, string nickName)
        {
            List<Achievement> achs = new List<Achievement>();
            
            // Read from xml file current user 
            User user = new User(nickName);
            user = User.CurrentUser;
           
            // Get the Achievements for user in order not to match the sames 
            Achievement[] userAchievements = GetUserAchievements(nickName);

            // Get the current points and check if user has same achievement 
            int points = int.Parse(input);
            bool isBrown = points >= 0 && points <= 200 && !userAchievements.Any(p => p.SmallDescription == "Get 200 points");
            bool isGreen = points >= 201 && points <= 599 && !userAchievements.Any(p => p.SmallDescription == "Get 400 points");
            bool isPink = points >= 600 && points <= 799 && !userAchievements.Any(p => p.SmallDescription == "Get 600 points");
            bool isBlue = points >= 800 && points <= 899 && !userAchievements.Any(p => p.SmallDescription == "Get 800 points");
            bool isRed = points >= 900 && points <= 999 && !userAchievements.Any(p => p.SmallDescription == "Get 900 points");
            bool isGold = points >= 1000 && !userAchievements.Any(p => p.SmallDescription == "Get 1000 points");

            // Add to list the achievement 
            if (isBrown)
                achs.Add(new Achievement("Get 200 points", true, PathToAppData("Achievements", "Achiv1.png")));
            else if (isGreen)
                achs.Add(new Achievement("Get 400 points", true, PathToAppData("Achievements", "Achiv2.png")));
            else if (isPink)
                achs.Add(new Achievement("Get 600 points", true, PathToAppData("Achievements", "Achiv3.png")));
            else if (isBlue)
                achs.Add(new Achievement("Get 800 points", true, (PathToAppData("Achievements", "Achiv4.png"))));
            else if (isRed)
                achs.Add(new Achievement("Get 900 points", true, PathToAppData("Achievements", "Achiv5.png")));
            else if (isGold)
                achs.Add(new Achievement("Get 1000 points", true, PathToAppData("Achievements", "Achiv6.png")));

            // If user get achievement we increment the level of user
            if (achs.Count != 0)
                user.Level += 5;

            // Set to user list - current user achivements 
            user.Achievements = achs;
            // Save the game (level)
            user.SaveGame();
            // Save achievements to xml file 
            user.SaveAchievements();
            // Return the value. True - user get achievement, false - vice versa
            return (achs.Count != 0) ? true : false;
        }

        public void SaveGame(string nickName, string points, string debt, string status, string level)
        {
            User user = new User(nickName);
            user.CurrentPoints = int.Parse(points);
            user.Debt = int.Parse(debt);
            user.Status = status;
            user.Level = int.Parse(level);
            user.SaveGame();
        }

        public Stream LevelImage(string input)
        {
            int level = int.Parse(input);
            FileStream fs;

            WebOperationContext.Current.OutgoingResponse.ContentType = "image/png";

            // Get the current level of user
            bool isBronze = (level >= 1 && level <= 10);
            bool isSilver = (level >= 11 && level <= 20);
            bool isGold = (level >= 21 && level <= 29);
            bool isDiamon = level >= 30;

            // Return the stream of level image
            if (isBronze)
                return fs = File.OpenRead(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data\\Levels", "Level1.png"));
            else if (isSilver)
                return fs = File.OpenRead(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data\\Levels", "Level2.png"));
            else if (isGold)
                return fs = File.OpenRead(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data\\Levels", "Level3.png"));
            else
                return fs = File.OpenRead(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data\\Levels", "Level4.png"));
        }

        #endregion

        #region Private server methods

        private BitmapImage ConvertToBitmapImage(string path)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(path);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = new MemoryStream(bytes);
                image.EndInit();

                return image;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private byte[] ConvertToByte(string path)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(path);
                return bytes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string PathToAppData(string folder, string file)
        {
            return Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data\\" + folder + "", file);
        }

        #endregion
    }
}
