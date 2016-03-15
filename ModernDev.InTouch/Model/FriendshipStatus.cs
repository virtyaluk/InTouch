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
    /// Friendship status with a user.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("FriendshipStatus {UserId}")]
    public class FriendshipStatus
    {
        /// <summary>
        /// User Id.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Friendship status.
        /// </summary>
        [DataMember]
        [JsonProperty("friend_status")]
        public FriendshipStatus Status { get; set; }

        /// <summary>
        /// Friend request message (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("request_message")]
        public string RequestMessage { get; set; }

        /// <summary>
        /// Read state of the request (True - is read, False - is not read).
        /// </summary>
        [DataMember]
        [JsonProperty("read_state")]
        public bool ReadState { get; set; }

        [DataMember]
        [JsonProperty("sign")]
        public string Sign { get; set; }
    }
}