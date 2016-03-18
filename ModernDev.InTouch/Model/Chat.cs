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

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Chat"/> class describes a chat.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Chat {Title}")]
    public class Chat : IChatable
    {
        /// <summary>
        /// Chat ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Type of chat.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Chat title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the chat starter.
        /// </summary>
        [DataMember]
        [JsonProperty("admin_id")]
        public int AdminId { get; set; }

        /// <summary>
        /// List of chat participants' IDs.
        /// </summary>
        [DataMember]
        [JsonProperty("users")]
        public List<int> Users { get; set; } 
    }
}