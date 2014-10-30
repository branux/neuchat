using NeuChat.Messages;
using NeuChat.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeuChat.Views {
    public partial class MainPage {

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage() {
            InitializeComponent();

            // Set view model
            BindingContext = App.Locator.Main;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing() {
            base.OnAppearing();

            Subscribe();

            if (!App.IsLoggedIn) {
                App.LoginManager.Logout();
            }
            else {
                Task.Factory.StartNew(async () => await ((MainViewModel)BindingContext).ConnectToChat());
            }
        }

        /// <summary>
        /// When overridden, allows the application developer to customize behavior as the <see cref="T:Xamarin.Forms.Page" /> disappears.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnDisappearing() {
            base.OnDisappearing();

            Unsubscribe();
        }

        /// <summary>
        /// Subscribes to message bus
        /// </summary>
        private void Subscribe() {
            MessagingCenter.Subscribe<ChatReceivedMessage>(this, "Chat Received", OnChatReceived);
        }

        /// <summary>
        /// Unsubscribes from message bus
        /// </summary>
        private void Unsubscribe() {
            MessagingCenter.Unsubscribe<ChatReceivedMessage>(this, "Chat Received");
        }

        /// <summary>
        /// Called when [chat received].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnChatReceived(ChatReceivedMessage message) {
            // We can do something UI related here if needed
            ((MainViewModel)BindingContext).AddMessage(message.ChatEntry);
        }
    }
}