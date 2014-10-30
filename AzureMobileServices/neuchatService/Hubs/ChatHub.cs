using Microsoft.AspNet.SignalR;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using neuchatService.Models;

namespace neuchatService.Hubs {
    public class ChatHub : Hub {

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        public ApiServices Services { get; set; }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [AuthorizeLevel(AuthorizationLevel.User)]
        public void Send(ChatEntry message) {

            // Invoke "BroadcastMessage" on all other clients
            this.Clients.Others.BroadcastMessage(message);
        }
    }
}