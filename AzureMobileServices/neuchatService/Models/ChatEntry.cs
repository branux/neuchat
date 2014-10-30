using System;

namespace neuchatService.Models {
    public sealed class ChatEntry {

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets the sent UTC.
        /// </summary>
        /// <value>
        /// The sent UTC.
        /// </value>
        public DateTime SentUtc { get; set; }

        /// <summary>
        /// Gets or sets the message body.
        /// </summary>
        /// <value>
        /// The message body.
        /// </value>
        public string MessageBody { get; set; }
    }
}