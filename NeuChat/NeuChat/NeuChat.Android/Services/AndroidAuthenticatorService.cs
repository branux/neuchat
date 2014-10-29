using Microsoft.WindowsAzure.MobileServices;
using NeuChat.Services;
using System.Threading.Tasks;

namespace NeuChat.Droid.Services {
    public class AndroidAuthenticatorService : IAuthenticatorService {

        /// <summary>
        /// Authorizes user to Azure Mobile Services.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public async Task<MobileServiceUser> Authorize(MobileServiceAuthenticationProvider provider) {
            return await App.MobileService.LoginAsync(Xamarin.Forms.Forms.Context, provider);
        }

        /// <summary>
        /// Logouts user from Azure Mobile Services.
        /// </summary>
        public void Logout() {
            // Clear out webview cookies
            Android.Webkit.CookieSyncManager.CreateInstance(Android.App.Application.Context);
            Android.Webkit.CookieManager.Instance.RemoveAllCookie();

            // Logout of AMS
            App.MobileService.Logout();
        }
    }
}