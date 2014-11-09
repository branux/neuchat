using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using neuchatService.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace neuchatService.Controllers
{
    public class UserInfoController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/UserInfo
        [AuthorizeLevel(Microsoft.WindowsAzure.Mobile.Service.Security.AuthorizationLevel.User)]
        public async Task<UserInfo> Get()
        {
            var user = User as ServiceUser;

            UserInfo result = new UserInfo {
                Name = (User as ServiceUser).Id,
                Picture = "http://www.halleymedia.com/wp-content/uploads/2014/06/generic_user_image.png"
            };

            var identities = await user.GetIdentitiesAsync();
            var google = identities.OfType<GoogleCredentials>().FirstOrDefault();

            if(google != null) {
                result = await GetUserInfoFromGoogle(google.AccessToken);
            }

            return result;
        }


        private async Task<UserInfo> GetUserInfoFromGoogle(string token) {
            string url = "https://www.googleapis.com/oauth2/v2/userinfo";

            try {
                using (HttpClient client = new HttpClient()) {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    string response = await client.GetStringAsync(url);
                    UserInfo userInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(response);
                    
                    return userInfo;
                }
            }
            catch (Exception ex) {
                Services.Log.Error(ex);

                return new UserInfo {
                    Name = (User as ServiceUser).Id,
                    Picture = "http://www.halleymedia.com/wp-content/uploads/2014/06/generic_user_image.png"
                };
            }
        }
    }
}
