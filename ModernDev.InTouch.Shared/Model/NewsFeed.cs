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
    /// A <see cref="NewsFeed"/> class describes a user's newsfeed.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("NewsFeed")]
    public class NewsFeed : ItemsList<NewsPost>
    {
        /// <summary>
        /// Contains an <c>offset</c> parameter that is passed to get the next array of news.
        /// </summary>
        [DataMember]
        [JsonProperty("new_offset")]
        public string NewOffset { get; set; }

        /// <summary>
        /// Contains a <c>from</c> parameter that is passed to get the next array of news.
        /// </summary>
        [DataMember]
        [JsonProperty("next_from")]
        public string NextFrom { get; set; }

        /// <summary>
        /// The total number of news.
        /// </summary>
        [DataMember]
        [JsonProperty("total_number")]
        public int TotalCount { get; set; }
    }
}