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
    /// An information about mutual friends.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Mutual {Count}")]
    public class Mutual
    {
        /// <summary>
        /// Total number of mutual friends.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// A list of mutual friends ids.
        /// </summary>
        [DataMember]
        [JsonProperty("users")]
        public List<int> Users { get; set; }
    }
}