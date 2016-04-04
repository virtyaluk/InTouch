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
    /// Post reach statistics.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("PostStats")]
    public class PostStats
    {
        /// <summary>
        /// Number of subscribers reached.
        /// </summary>
        [DataMember]
        [JsonProperty("reach_subscribers")]
        public int ReachSubscribers { get; set; }

        /// <summary>
        /// Total number of subscribers reached.
        /// </summary>
        [DataMember]
        [JsonProperty("reach_total")]
        public int ReachTotal { get; set; }

        /// <summary>
        /// The number of clicks on the link.
        /// </summary>
        [DataMember]
        [JsonProperty("links")]
        public int Links { get; set; }

        /// <summary>
        /// The number of times the group was visited.
        /// </summary>
        [DataMember]
        [JsonProperty("to_group")]
        public int ToGroup { get; set; }

        /// <summary>
        /// The number if times the group was joined.
        /// </summary>
        [DataMember]
        [JsonProperty("join_group")]
        public int JoinGroup { get; set; }

        /// <summary>
        /// The number of reports made on the post.
        /// </summary>
        [DataMember]
        [JsonProperty("report")]
        public int Report { get; set; }

        /// <summary>
        /// The number of times the post was hided.
        /// </summary>
        [DataMember]
        [JsonProperty("hide")]
        public int Hide { get; set; }

        /// <summary>
        /// The number of unsubscribed users.
        /// </summary>
        [DataMember]
        [JsonProperty("unsubscribe")]
        public int Unsubscribe { get; set; }
    }
}