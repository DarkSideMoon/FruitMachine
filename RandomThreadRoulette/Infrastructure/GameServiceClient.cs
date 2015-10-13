using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RandomRouletteLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RandomThreadRoulette.Infrastructure
{
    #region Example WCF how to connect rest service
    //// Example 1

    //HttpClient client = new HttpClient();
    //HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/AddUserOnline/" + user.NickName + "").Result;
    //HttpContent stream = wcfResponse.Content;
    //var data = stream.ReadAsStringAsync();

    //// Example 2

    //string data1;
    //Uri serviceUri = new Uri("http://localhost:20236/GameService.svc/AddUserOnline/" + user.NickName + "");
    //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(serviceUri);
    //request.Method = "GET"; // HTTP verb
    //request.ContentType = "application/json; charset=utf-8";

    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    //{
    //    data1 = reader.ReadToEnd();
    //}
    #endregion 

    /// <summary>
    /// The client to work with rest service on http://localhost:20236/GameService.svc/
    /// </summary>
    public class GameServiceClient 
    {
        JObject dataObject;
        
        HttpClient client = new HttpClient();
        HttpResponseMessage wcfResponse;
        HttpContent stream;

        /// <summary>
        /// Load user from restfull service 
        /// </summary>
        /// <param name="userNick"></param>
        /// <returns>User object</returns>
        public User LoadUserInfo(string userNick)
        {
            User user = null;
            try
            {
                wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/LoadUserInfo/" + userNick + "").Result;
                stream = wcfResponse.Content;
                Task<string> data = stream.ReadAsStringAsync();

                User us = User.CurrentUser;
                dataObject = JObject.Parse(data.Result.ToString());
                user = JsonConvert.DeserializeObject<User>(dataObject.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        /// <summary>
        /// Check is service is alive
        /// </summary>
        /// <returns>True/False</returns>
        public async Task<bool> IsAlive()
        {
            try
            {
                wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/IsAlive/").Result;
                stream = wcfResponse.Content;
                string data = await stream.ReadAsStringAsync();

                return Convert.ToBoolean(data);
            }
            catch(AggregateException)
            {
                //throw new AggregateException(ex.Message);
                // Write to logger;
                return false;
            }
        }

        /// <summary>
        /// Get rules from service
        /// </summary>
        /// <returns>Rules of game</returns>
        public async Task<string> Rules()
        {
            try
            {
                wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/Rules/").Result;
                stream = wcfResponse.Content;
                string data = await stream.ReadAsStringAsync();

                string delFirst = data.Substring(1, data.Length - 1);
                string res = delFirst.Remove(delFirst.Length - 1);

                return Convert.ToString(res);
            }
            catch (AggregateException)
            {//GetAchievement/{nickName}
                //throw new AggregateException(ex.Message);
                // Write to logger;
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the result from service about achive
        /// True: the user get achive 
        /// False: the user is not get achive
        /// </summary>
        /// <returns>True/False</returns>
        public List<Achievement> GetAchieve(string nickName)
        {
            try
            {
                wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/UserAchievement/" + nickName + "").Result;
                stream = wcfResponse.Content;
                Task<string> data = stream.ReadAsStringAsync();

                Achievement ach = new Achievement();
                List<Achievement> listAchieves = new List<Achievement>();
                
                dynamic jsArray = (JArray)JsonConvert.DeserializeObject(data.Result.ToString());

                foreach (var item in jsArray)
                {
                    string pathToImage = item.ImagePath;
                    listAchieves.Add(new Achievement()
                        {
                            ImagePath = item.ImagePath,
                            IsDone = item.IsDone,
                            SmallDescription = item.SmallDescription,
                            ImageBytes = Achievement.ConvertPathToImage(pathToImage)
                        });
                }
                return listAchieves;
            }
            catch (AggregateException ex)
            {
                throw new AggregateException(ex.Message);
                // Write to logger;
            }
        }

        /// <summary>
        /// Get the level image depend on level
        /// </summary>
        /// <param name="level"></param>
        /// <returns>Level image</returns>
        public BitmapImage LevelImage(int level)
        {
            try
            {
                byte[] bytes = new WebClient().DownloadData("http://localhost:20236/GameService.svc/LevelImage/" + level.ToString() + "");

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = new MemoryStream(bytes);
                image.EndInit();

                return image;
            }
            catch (AggregateException)
            {
                //throw new AggregateException(ex.Message);
                // Write to logger;
                return null;
            }
        }

        /// <summary>
        /// Save the current game of user
        /// </summary>
        /// <param name="nickName">user nick</param>
        /// <param name="points">current points</param>
        /// <param name="debt">current debt</param>
        /// <param name="status">current status</param>
        /// <param name="level">current level</param>
        public async void Save(string nickName, int points, double debt, string status, int level)
        {
            try
            {
                wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/SaveGame/" + nickName + ",%20" + points.ToString() +
                                              ",%20" + debt.ToString() + ",%20" + status + ",%20" + level.ToString() + "").Result;
                stream = wcfResponse.Content;
                string data = await stream.ReadAsStringAsync();
            }
            catch (AggregateException)
            {
                //throw new AggregateException(ex.Message);
                // Write to logger;
            }
        }

        /// <summary>
        /// Add user in online list of users
        /// </summary>
        /// <param name="user"></param>
        public void AddUserOnline(User user)
        {
            wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/AddUserOnline/" + user.NickName + "").Result;
            stream = wcfResponse.Content;
            Task<string> data = stream.ReadAsStringAsync();
        }

        /// <summary>
        /// Get list of users online
        /// </summary>
        /// <returns>List of users</returns>
        public List<User> UsersOnline()
        {
            List<User> users = new List<User>();
            wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/UsersOnline/").Result;
            stream = wcfResponse.Content;
            Task<string> data = stream.ReadAsStringAsync();

            dynamic jsArray = (JArray)JsonConvert.DeserializeObject(data.Result.ToString());

            foreach (var item in jsArray)
                users.Add(new User()
                {
                    NickName = item.NickName,
                    CurrentPoints = item.CurrentPoints,
                    Debt = item.Debt,
                    Level = item.Level,
                    Status = item.Status
                });

            return new List<User>();
        }

        /// <summary>
        /// Send to server the current points to get achievements
        /// </summary>
        /// <param name="points">current points </param>
        /// <param name="nickName">user nick name</param>
        /// <returns></returns>
        public async Task<bool> SendPoints(int countPoints, string nickName)
        {
            try
            {
                wcfResponse = client.GetAsync("http://localhost:20236/GameService.svc/SendPoints/" + countPoints.ToString() 
                    + ",%20" + nickName.ToString()).Result;
                stream = wcfResponse.Content;
                string data = await stream.ReadAsStringAsync();

                return Convert.ToBoolean(data);
            }
            catch (AggregateException)
            {
                //throw new AggregateException(ex.Message);
                // Write to logger;
                return false;
            }
        }
    }
}
