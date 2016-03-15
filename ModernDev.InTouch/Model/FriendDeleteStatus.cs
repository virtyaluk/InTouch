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
    /// An information about deleted friend or rejected request.
    /// </summary>
    [DebuggerDisplay("FriendDeleteStatus")]
    [DataContract]
    public class FriendDeleteStatus
    {
        /// <summary>
        /// Friend deleted successful.
        /// </summary>
        [DataMember]
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Friend deleted.
        /// </summary>
        [DataMember]
        [JsonProperty("friend_deleted")]
        public bool FriendDeleted { get; set; }

        /// <summary>
        /// Outgoing fried request withdrawn.
        /// </summary>
        [DataMember]
        [JsonProperty("out_request_deleted")]
        public bool OutRequestDeleted { get; set; }

        /// <summary>
        /// Incoming friend request rejected.
        /// </summary>
        [DataMember]
        [JsonProperty("in_request_deleted")]
        public bool InRequestDeleted { get; set; }

        /// <summary>
        /// Friend suggestion rejected.
        /// </summary>
        [DataMember]
        [JsonProperty("suggestion_deleted")]
        public bool SuggestionDeleted { get; set; }
    }
}