using Microsoft.WindowsAzure.MobileServices;
using MonoTouch.Foundation;
using NeuChat.Services;
using System;
using System.Threading.Tasks;

namespace NeuChat.iOS.Services {
    public class AppleAuthenticatorService : IAuthenticatorService {

        public async Task<MobileServiceUser> Authorize(MobileServiceAuthenticationProvider provider) {
            return await App.MobileService.LoginAsync(AppDelegate.MainView, provider);
        }

        public void Logout() {

            // Clear all webview cookies
            foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);

            App.MobileService.Logout();
        }
    }
}
