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
    /// Information about likes.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Likes: {UserLikes}, {Count}")]
    public partial class Likes
    {
        [DataMember]
        [JsonConverter(typeof(JsonBoolConverter))]
        [JsonProperty("user_likes")]
        public bool UserLikes { get; set; }

        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}