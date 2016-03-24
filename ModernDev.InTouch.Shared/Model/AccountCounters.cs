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
    /// Number of various objects the user account has.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("AccountCounters")]
    public class AccountCounters
    {
        /// <summary>
        /// Number of friends.
        /// </summary>
        [DataMember]
        [JsonProperty("friends")]
        public int Friends { get; set; }

        /// <summary>
        /// Number of messages.
        /// </summary>
        [DataMember]
        [JsonProperty("messages")]
        public int Messages { get; set; }

        /// <summary>
        /// Number of photos.
        /// </summary>
        [DataMember]
        [JsonProperty("photos")]
        public int Photos { get; set; }

        /// <summary>
        /// Number of videos.
        /// </summary>
        [DataMember]
        [JsonProperty("videos")]
        public int Videos { get; set; }

        /// <summary>
        /// Number of notes.
        /// </summary>
        [DataMember]
        [JsonProperty("notes")]
        public int Notes { get; set; }

        /// <summary>
        /// Number of gifts.
        /// </summary>
        [DataMember]
        [JsonProperty("gifts")]
        public int Gifts { get; set; }

        /// <summary>
        /// Number of events.
        /// </summary>
        [DataMember]
        [JsonProperty("events")]
        public int Events { get; set; }

        /// <summary>
        /// Number of communities.
        /// </summary>
        [DataMember]
        [JsonProperty("groups")]
        public int Groups { get; set; }

        /// <summary>
        /// Number of notifications.
        /// </summary>
        [DataMember]
        [JsonProperty("notifications")]
        public int Notifications { get; set; }
        
        [DataMember]
        [JsonProperty("sdk")]
        public int SDK { get; set; }

        /// <summary>
        /// Number of app requests.
        /// </summary>
        [DataMember]
        [JsonProperty("app_requests")]
        public int AppRequests { get; set; }
    }
}