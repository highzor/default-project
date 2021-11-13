using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Controllers.Authorization
{
    public class AuthorizationController
    {
        private static string GetRequest(string host, string req)
        {
            string str = "";

            var Vk = new HttpClient();
            Vk.DefaultRequestHeaders.Add("Connection", "close");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";
            request.Host = host;
            request.UserAgent = "RM";
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = false;

            using (HttpWebResponse responsevk = (HttpWebResponse)request.GetResponse())
            using (var stream = responsevk.GetResponseStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                str = streamReader.ReadToEnd();
            }
            return str;
        }

        //public static void VK_GetServerToken(string client_id, string client_secret)
        //{
        //    string str = GetRequest("oauth.vk.com", "https://oauth.vk.com/access_token?client_id=" + client_id + "&client_secret=" + client_secret + "&v=5.85&grant_type=client_credentials");
        //    dynamic stuff = JsonConvert.DeserializeObject(str);
        //    string token = stuff.access_token;
        //    DbInMemory.VK_TOKEN = token;
        //}

        //public static Social.SocialProfile VK_GetUserAutorization(string token)
        //{
        //    Social.SocialProfile profile = new Social.SocialProfile();

        //    string str = GetRequest("api.vk.com", "https://api.vk.com/method/secure.checkToken?token=" + token + "&v=5.85&client_secret=" + DbInMemory.VK_CLIENT_SECRET + "&access_token=" + DbInMemory.VK_TOKEN);
        //    dynamic stuff = JsonConvert.DeserializeObject(str);
        //    try
        //    {
        //        long d = stuff.response.date;
        //        var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(d).ToLocalTime();
        //        d = stuff.response.expire;
        //        var expire = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(d).ToLocalTime();
        //    }
        //    catch (Exception ex)
        //    {
        //        Program.Logger.Error(ex, ex.Message);
        //    }

        //    try
        //    {
        //        profile.IsAutorized = stuff.response.success;
        //        profile.Ident = stuff.response.user_id;

        //        profile = VK_GetUserData(token, profile);
        //    }
        //    catch (Exception ex)
        //    {
        //        Program.Logger.Error(ex, ex.Message);
        //    }

        //    return profile;
        //}

        //public static Social.SocialProfile VK_GetUserData(string token, Social.SocialProfile profile)
        //{
        //    try
        //    {
        //        string str = GetRequest("api.vk.com", "https://api.vk.com/method/users.get?access_token=" + token + "&fields=photo_id,verified,sex,bdate,city,country,home_town,has_photo,photo_50,photo_100,photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,online,domain,has_mobile,contacts,site,education,universities,schools,status,last_seen,followers_count,common_count,occupation,nickname,relatives,relation,personal,connections,exports,activities,interests,music,movies,tv,books,games,about,quotes,can_post,can_see_all_posts,can_see_audio,can_write_private_message,can_send_friend_request,is_favorite,is_hidden_from_feed,timezone,screen_name,maiden_name,crop_photo,is_friend,friend_status,career,military,blacklisted,blacklisted_by_me&v=5.85");


        //        dynamic stuff = JsonConvert.DeserializeObject(str);

        //        profile.FirstName = stuff.response[0].first_name;
        //        profile.LastName = stuff.response[0].last_name;
        //        profile.Ident = stuff.response[0].id;
        //        //string photo_max = stuff.response[0].photo_max;
        //        //string bdate = stuff.response[0].bdate;
        //        profile.Details = str;
        //    }
        //    catch (Exception ex)
        //    {
        //        Program.Logger.Error(ex, ex.Message);
        //        profile.IsAutorized = false;
        //    }

        //    return profile;
        //}

    }
}
