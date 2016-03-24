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
    /// Number of various objects the community has.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("CommunityCounters")]
    public class CommunityCounters : Counters
    {
        /// <summary>
        /// Number of photos.
        /// </summary>
        [DataMember]
        [JsonProperty("photos")]
        public int Photos { get; set; }

        /// <summary>
        /// Number of topics.
        /// </summary>
        [DataMember]
        [JsonProperty("topics")]
        public int Topics { get; set; }

        /// <summary>
        /// Number of documents.
        /// </summary>
        [DataMember]
        [JsonProperty("docs")]
        public int Docs { get; set; }
    }
}