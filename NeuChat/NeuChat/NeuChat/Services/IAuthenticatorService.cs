using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace NeuChat.Services {
    public interface IAuthenticatorService {
        Task<MobileServiceUser> Authorize(MobileServiceAuthenticationProvider provider);

        void Logout();
    }
}
