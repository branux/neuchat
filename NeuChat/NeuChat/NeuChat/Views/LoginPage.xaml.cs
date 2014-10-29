using NeuChat.Messages;
using NeuChat.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeuChat.Views {
    public partial class LoginPage {

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage() {
            InitializeComponent();

            // Set view model
            BindingContext = App.Locator.Login;
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing() {
            base.OnAppearing();

            // Allow iOS and WinPhone 
            if (App.IsLoggedIn) {
                App.LoginManager.ShowMainPage();
            }
        }
    }
}