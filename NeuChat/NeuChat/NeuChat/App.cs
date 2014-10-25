using NeuChat.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static Page GetMainPage() {
            return new MainPage();
        }
    }
}