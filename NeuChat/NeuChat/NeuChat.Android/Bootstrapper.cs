using GalaSoft.MvvmLight.Ioc;
using NeuChat.Droid.Services;
using NeuChat.Services;

namespace NeuChat.Droid {
    public static class Bootstrapper {

        /// <summary>
        /// Configures this platforms IOC.
        /// </summary>
        public static void Configure() {
            SimpleIoc.Default.Register<IAuthenticatorService, AndroidAuthenticatorService>();
            SimpleIoc.Default.Register<IChatHub, ChatHub>();
        }
    }
}