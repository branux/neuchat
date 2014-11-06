using Microsoft.AspNet.SignalR.Client;
using NeuChat.Messages;
using NeuChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeuChat.Services {
    public class ChatHub : IChatHub {

        private HubConnection _hubConnection;
        private IHubProxy _proxy;

        /// <summary>
        /// Connects to SignalR hub.
        /// </summary>
        public async Task ConnectAsync() {
            _hubConnection = new HubConnection(NeuChat.App.MobileService.ApplicationUri.AbsoluteUri);

            if (NeuChat.App.MobileService.CurrentUser != null) {
                _hubConnection.Headers["x-zumo-auth"] = NeuChat.App.MobileService.CurrentUser.MobileServiceAuthenticationToken;
            }
            else {
                throw new UnauthorizedAccessException();
            }

            _proxy = _hubConnection.CreateHubProxy("ChatHub");

            await _hubConnection.Start();
            
            _proxy.On<ChatEntry>("BroadcastMessage", OnReceivedMessage);
        }

        /// <summary>
        /// Sends the message asynchronously.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task SendMessageAsync(ChatEntry message) {
            await _proxy.Invoke<ChatEntry>("Send", message);
        }

        /// <summary>
        /// Called when [received message].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnReceivedMessage(ChatEntry message) {
            Device.BeginInvokeOnMainThread(() => {
                MessagingCenter.Send<ChatReceivedMessage>(new ChatReceivedMessage { ChatEntry = message }, "Chat Received");
            });
        }
    }
}
