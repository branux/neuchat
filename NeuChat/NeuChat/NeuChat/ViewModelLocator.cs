using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NeuChat.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace NeuChat {
    public class ViewModelLocator {

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> class.
        /// </summary>
        static ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register all ViewModels here
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
        }

        /// <summary>
        /// Gets the main view model.
        /// </summary>
        /// <value>
        /// The main view model.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the login view model.
        /// </summary>
        /// <value>
        /// The login view model.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public LoginViewModel Login {
            get {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
    }
}