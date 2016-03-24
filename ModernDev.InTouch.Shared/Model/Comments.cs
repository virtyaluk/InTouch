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
    /// Information about comments.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Comments {Count}")]
    public class Comments
    {
        /// <summary>
        /// The total number of the comments.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Whether the current user can leave comments to the post
        /// </summary>
        [DataMember]
        [JsonProperty("can_posst")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool CanPost { get; set; }
    }
}