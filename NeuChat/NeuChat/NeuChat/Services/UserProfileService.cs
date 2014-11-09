using NeuChat.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeuChat.Services {
    public class UserProfileService : IUserProfileService {

        public async Task<UserInfo> GetUserInfoAsync() {
            try {
                return await App.MobileService.InvokeApiAsync<UserInfo>("UserInfo", HttpMethod.Get, null);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);

                return new UserInfo {
                    Name = NeuChat.App.MobileService.CurrentUser.UserId,
                    Picture = "http://www.halleymedia.com/wp-content/uploads/2014/06/generic_user_image.png"
                };
            }

        }
    }
}