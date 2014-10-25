using NeuChat.Models;
using System;

namespace NeuChat.Messages {
    public sealed class ChatReceivedMessage {

        /// <summary>
        /// Gets or sets the chat entry.
        /// </summary>
        /// <value>
        /// The chat entry.
        /// </value>
        public ChatEntry ChatEntry { get; set; }
    }
}