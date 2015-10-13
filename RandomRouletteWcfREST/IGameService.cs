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

namespace RandomRouletteWcfREST
{
    [ServiceContract]
    public interface IGameService
    {
        /// <summary>
        /// Check is server is alive
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "IsAlive/")]
        bool IsAlive();

        /// <summary>
        /// Load user info by nick name
        /// </summary>
        /// <param name="nickName">The nick of user</param>
        /// <returns>User info</returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "LoadUserInfo/{nickName}")]
        User LoadUserInfo(string nickName);

        /// <summary>
        /// Add user in list of online users
        /// Not used
        /// </summary>
        /// <param name="userNick"></param>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "AddUserOnline/{userNick}")]
        void AddUserOnline(string userNick);
 
        /// <summary>
        /// Get from list users online
        /// For testing in the Web
        /// Not used
        /// </summary>
        /// <returns>Users online</returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetUsersOnline/")]
        User[] GetUsersOnline();

        /// <summary>
        /// Get rules of game
        /// </summary>
        /// <returns>Get rules</returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Rules/")]
        string GetRules();

        /// <summary>
        /// Get user achievements
        /// </summary>
        /// <param name="nickName">User nick</param>
        /// <returns>User achievements</returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "UserAchievement/{nickName}")]
        Achievement[] GetUserAchievements(string nickName); 

        /// <summary>
        /// Save the current game of user
        /// </summary>
        /// <param name="nickName">user nick</param>
        /// <param name="points">current points</param>
        /// <param name="debt">current debt</param>
        /// <param name="status">current status</param>
        /// <param name="level">current level</param>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "SaveGame/{nickName}, {points}, {debt}, {status}, {level}")]
        void SaveGame(string nickName, string points, string debt, string status, string level);

        /// <summary>
        /// User send to server the current points to get achievement
        /// </summary>
        /// <param name="points">current points </param>
        /// <param name="nickName">user nick name</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET",
                   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "SendPoints/{points}, {nickName}")]
        bool SendPoints(string points, string nickName);

        /// <summary>
        /// Get in stream image
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Level image</returns>
        [OperationContract]
        [WebGet(UriTemplate = "LevelImage/{input}")]
        Stream LevelImage(string input);


    }
}
