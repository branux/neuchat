using Microsoft.WindowsAzure.MobileServices;
using NeuChat.Resources;
using NeuChat.Views;
using Xamarin.Forms;

namespace NeuChat {
    public class App {

        #region View Model Locator
        private static ViewModelLocator _locator;

        /// <summary>
        /// Gets the view model locator.
        /// </summary>
        /// <value>
        /// The view model locator.
        /// </value>
        public static ViewModelLocator Locator {
            get {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
        #endregion

        /// <summary>
        /// Azure mobile service client
        /// </summary>
        public static MobileServiceClient MobileService = new MobileServiceClient(ApiKeys.AZURE_URL, ApiKeys.AZURE_KEY);

        /// <summary>
        /// Gets a value indicating whether the current user is logged in.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current user is logged in; otherwise, <c>false</c>.
        /// </value>
        public static bool IsLoggedIn {
            get {
                return (MobileService.CurrentUser != null);
            }
        }

        /// <summary>
        /// Gets the main page.
        /// </summary>
        /// <returns></returns>
        public static Page GetMainPage() {
            return new MainPage();
        }
    }
}