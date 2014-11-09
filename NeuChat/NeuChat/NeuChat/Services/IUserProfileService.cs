using NeuChat.Models;
using System.Threading.Tasks;

namespace NeuChat.Services {
    public interface IUserProfileService {

        /// <summary>
        /// Get User Info with OAUTH access token asyncronously
        /// </summary>
        /// <returns>UserInfo model</returns>
        Task<UserInfo> GetUserInfoAsync();
    }
}