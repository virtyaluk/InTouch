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
    /// An info about mutual friends.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("MutualFriends {Count}")]
    public class MutualFriends
    {
        /// <summary>
        /// User Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Count of common friends.
        /// </summary>
        [DataMember]
        [JsonProperty("common_count")]
        public int Count { get; set; }

        /// <summary>
        /// A list of Ids of common friends.
        /// </summary>
        [DataMember]
        [JsonProperty("common_friends")]
        public List<int> Friends { get; set; }
    }
}