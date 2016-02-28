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
    /// Number of various objects the user\community has.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Counters")]
    public class Counters
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
    }
}