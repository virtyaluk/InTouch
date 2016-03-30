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
    /// Audio lyrics.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Lyrics")]
    public class Lyrics
    {
        /// <summary>
        /// Lyrics Id.
        /// </summary>
        [DataMember]
        [JsonProperty("lyrics_id")]
        public int LyricsId { get; set; }

        /// <summary>
        /// Lyrics text.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}