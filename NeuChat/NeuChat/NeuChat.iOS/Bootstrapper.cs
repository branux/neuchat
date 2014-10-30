using GalaSoft.MvvmLight.Ioc;
using NeuChat.iOS.Services;
using NeuChat.Services;

namespace NeuChat.iOS {
    public static class Bootstrapper {

        /// <summary>
        /// Configures this platforms IOC.
        /// </summary>
        public static void Configure() {
            SimpleIoc.Default.Register<IAuthenticatorService, AppleAuthenticatorService>();
            SimpleIoc.Default.Register<IChatHub, ChatHub>();
        }
    }
}