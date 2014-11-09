using GalaSoft.MvvmLight.Ioc;
using NeuChat.Services;
using NeuChat.WinPhone.Services;

namespace NeuChat.WinPhone {
    public static class Bootstrapper {

        /// <summary>
        /// Configures this platforms IOC.
        /// </summary>
        public static void Configure() {
            SimpleIoc.Default.Register<IAuthenticatorService, WindowsAuthenticatorService>();
            SimpleIoc.Default.Register<IChatHub, ChatHub>();
            SimpleIoc.Default.Register<IUserProfileService, UserProfileService>();
        }
    }
}
