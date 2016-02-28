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
    /// Number of various objects the user has.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("UserCounters")]
    public class UserCounters
    {
        /// <summary>
        /// Number of photo albums.
        /// </summary>
        [DataMember]
        [JsonProperty("albums")]
        public int Albums { get; set; }

        /// <summary>
        /// Number of videos.
        /// </summary>
        [DataMember]
        [JsonProperty("videos")]
        public int Videos { get; set; }

        /// <summary>
        /// Number of audios.
        /// </summary>
        [DataMember]
        [JsonProperty("audios")]
        public int Audios { get; set; }

        /// <summary>
        /// Number of notes.
        /// </summary>
        [DataMember]
        [JsonProperty("notes")]
        public int Notes { get; set; }

        /// <summary>
        /// Number of friends.
        /// </summary>
        [DataMember]
        [JsonProperty("friends")]
        public int Friends { get; set; }

        /// <summary>
        /// Number of communities.
        /// </summary>
        [DataMember]
        [JsonProperty("groups")]
        public int Groups { get; set; }

        /// <summary>
        /// Number of online friends.
        /// </summary>
        [DataMember]
        [JsonProperty("online_friends")]
        public int OnlineFriends { get; set; }

        /// <summary>
        /// Number of mutual friends.
        /// </summary>
        [DataMember]
        [JsonProperty("mutual_friends")]
        public int MutualFriends { get; set; }

        /// <summary>
        /// Number of videos the user is tagged on.
        /// </summary>
        [DataMember]
        [JsonProperty("user_videos")]
        public int UserVideos { get; set; }

        /// <summary>
        /// Number of followers.
        /// </summary>
        [DataMember]
        [JsonProperty("followers")]
        public int Followers { get; set; }

        /// <summary>
        /// Number of photos the user is tagged on.
        /// </summary>
        [DataMember]
        [JsonProperty("user_photos")]
        public int UserPhotos { get; set; }

        /// <summary>
        /// Number of subscriptions (users only).
        /// </summary>
        [DataMember]
        [JsonProperty("subscriptions")]
        public int Subscriptions { get; set; }
    }
}