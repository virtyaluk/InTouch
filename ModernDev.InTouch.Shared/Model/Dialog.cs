/**
 * This file\code is part of InTouch project.
 *
 * InTouch - is a .NET wrapper for the vk.com API.
 * https://github.com/virtyaluk/InTouch
 *
 * Copyright (c) 2016 Bohdan Shtepan
 * http://modern-dev.com/
 *
 * Licensed under the GPLv3 license.
 */

using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Dialog"/> class describes dialog.
    /// </summary>
    [DebuggerDisplay("Dialog")]
    [DataContract]
    public class Dialog : ItemsList<Message>
    {
        /// <summary>
        /// Message Id of the last read message by the user.
        /// </summary>
        [DataMember]
        [JsonProperty("in_read")]
        public int InRead { get; set; }

        /// <summary>
        /// Message Id of the last read message by the recipient.
        /// </summary>
        [DataMember]
        [JsonProperty("out_read")]
        public int OutRead { get; set; }

        /// <summary>
        /// The number of unread messages in the dialog.
        /// </summary>
        [DataMember]
        [JsonProperty("unread")]
        public int UnreadCount { get; set; }

        /// <summary>
        /// Last message in the dialog.
        /// </summary>
        [DataMember]
        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}