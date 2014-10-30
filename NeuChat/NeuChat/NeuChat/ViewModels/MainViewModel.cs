using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NeuChat.Messages;
using NeuChat.Models;
using NeuChat.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeuChat.ViewModels {
    public class MainViewModel : ViewModelBase {

        #region Bindable Properties

        private List<ChatEntry> _rawChatEntries;
        private ObservableCollection<ChatEntry> _chatEntries;
        public const string ChatEntriesPropertyName = "ChatEntries";

        public ObservableCollection<ChatEntry> ChatEntries {
            get {
                return _chatEntries;
            }
            set {
                if (!_chatEntries.Equals(value)) {
                    _chatEntries = value;
                    RaisePropertyChanged(ChatEntriesPropertyName);
                }
            }
        }

        private string _chatMessage;
        public const string ChatMessagePropertyName = "ChatMessage";

        public string ChatMessage {
            get {
                return _chatMessage;
            }
            set {
                if (_chatMessage != value) {
                    _chatMessage = value;
                    RaisePropertyChanged(ChatMessagePropertyName);
                }
            }
        }

        #endregion

        #region Bindable Commands

        private RelayCommand _sendMessageCommand;
        public RelayCommand SendMessageCommand {
            get {
                return _sendMessageCommand ?? (_sendMessageCommand = new RelayCommand(async () => await ExecuteSendCommand()));
            }
        }

        private RelayCommand _logoutCommand;
        public RelayCommand LogoutCommand {
            get {
                return _logoutCommand ?? (_logoutCommand = new RelayCommand(() => {
                    _authService.Logout();
                    App.Logout();
                }));
            }
        }

        #endregion

        private IAuthenticatorService _authService;
        private IChatHub _chatHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel(IAuthenticatorService authService, IChatHub chatHub) {
            _authService = authService;
            _chatHub = chatHub;

            _rawChatEntries = new List<ChatEntry>();
            _chatEntries = new ObservableCollection<ChatEntry>();
        }

        /// <summary>
        /// Processes the entry.
        /// </summary>
        public void AddMessage(ChatEntry msg) {
            
            // Add to raw msg stack
            _rawChatEntries.Add(msg);

            // Take the latest 25 entries only
            var tmp = new List<ChatEntry>(_rawChatEntries.Skip(_rawChatEntries.Count > 25 ? _rawChatEntries.Count - 25 : 0).Take(25));
            _rawChatEntries = new List<ChatEntry>(tmp);

            // Reverse it to newest is on top
            tmp.Reverse();

            // Bind reversed top 25 to observable collection
            ChatEntries = new ObservableCollection<ChatEntry>(tmp);
        }

        /// <summary>
        /// Connects to chat.
        /// </summary>
        public async Task ConnectToChat() {
            await _chatHub.ConnectAsync();
        }

        /// <summary>
        /// Executes the send command.
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteSendCommand() {

            if (string.IsNullOrEmpty(ChatMessage)) return;

            var msg = new ChatEntry {
                Sender = "Local",
                SentUtc = DateTime.UtcNow,
                MessageBody = ChatMessage
            };

            AddMessage(msg);

            // Clear the user input
            ChatMessage = string.Empty;

            await _chatHub.SendMessageAsync(msg);
        }
    }
}
