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
    /// Chat photo changing information.
    /// </summary>
    [DebuggerDisplay("NewChatPhoto")]
    [DataContract]
    public class NewChatPhoto
    {
        /// <summary>
        /// The id of message sent by system.
        /// </summary>
        [DataMember]
        [JsonProperty("message_id")]
        public int MessageId { get; set; }

        /// <summary>
        /// Chat object.
        /// </summary>
        [DataMember]
        [JsonProperty("chat")]
        public Chat Chat { get; set; }
    }
}