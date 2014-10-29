using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using NeuChat.Services;
using System.Threading.Tasks;

namespace NeuChat.WinPhone.Services {
    public class WindowsAuthenticatorService : IAuthenticatorService {

        public async Task<MobileServiceUser> Authorize(MobileServiceAuthenticationProvider provider) {
            return await NeuChat.App.MobileService.LoginAsync(provider);
        }

        public void Logout() {
            NeuChat.App.MobileService.Logout();

            var dummyBrowser = new WebBrowser();
            Task cookie = WebBrowserExtensions.ClearCookiesAsync(dummyBrowser);

            cookie.Wait(3000);
        }
    }
}
