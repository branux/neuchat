using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using NeuChat.Services;
using Xamarin.Forms.Platform.Android;

namespace NeuChat.Droid {
    [Activity(Label = "NeuChat", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class ChatRoomActivity : AndroidActivity, ILoginManager {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Configure AMS
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            Xamarin.Forms.Forms.Init(this, bundle);

            // Configure IOC
            Bootstrapper.Configure();
            App.LoginManager = this;

            ShowMainPage();
        }

        public void Logout() {
            StartActivity(new Intent(this, typeof(MainActivity)));
            this.Finish();
        }

        public void ShowMainPage() {
            SetPage(App.GetMainPage());
        }
    }
}