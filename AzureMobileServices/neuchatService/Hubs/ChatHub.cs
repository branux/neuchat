using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.WindowsAzure.Mobile.Service;

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
        public string Send(string message) {
            return "SignalR sez Hi!";
        }
    }
}