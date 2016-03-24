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
    /// Friend request.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Mutual {UserId}")]
    public class FriendRequest
    {
        /// <summary>
        /// User Id.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Suggestion sender Id.
        /// </summary>
        [DataMember]
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// An information about mutual friends.
        /// </summary>
        [DataMember]
        [JsonProperty("mutual")]
        public Mutual Mutual { get; set; }
    }
}