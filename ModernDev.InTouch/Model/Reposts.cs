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
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Information about reposts.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Reposts {Count}")]
    public class Reposts
    {
        /// <summary>
        /// The total number of users who reposts the specified object.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Whether the user reposted the post
        /// </summary>
        [DataMember]
        [JsonProperty("user_reposted")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool UserReposted { get; set; }
    }
}