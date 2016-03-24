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
    /// A <see cref="MediaLiked"/> describes an information about an object in the <c>Likes</c> list of the user.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("MediaLiked {Liked} {Copied}")]
    public class MediaLiked
    {
        /// <summary>
        /// Whether the user liked an object.
        /// </summary>
        [DataMember]
        [JsonProperty("liked")]
        public bool Liked { get; set; }

        /// <summary>
        /// Whether the user copied an object to their wall.
        /// </summary>
        [DataMember]
        [JsonProperty("copied")]
        public bool Copied { get; set; }
    }
}