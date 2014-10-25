using NeuChat.Messages;
using Xamarin.Forms;
namespace NeuChat.Views {
    public partial class MainPage {

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage() {
            InitializeComponent();

            // Set view model
            BindingContext = App.Locator.Main;
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

        private void Subscribe() {
            MessagingCenter.Subscribe<ChatReceivedMessage>(this, "Chat Received", OnChatReceived);
        }

        private void Unsubscribe() {
            MessagingCenter.Unsubscribe<ChatReceivedMessage>(this, "Chat Received");
        }

        /// <summary>
        /// Called when [chat received].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnChatReceived(ChatReceivedMessage message) {
            // We can do something UI related here if needed
        }
    }
}