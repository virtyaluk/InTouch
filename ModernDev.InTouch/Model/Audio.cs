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
    /// An <see cref="Audio"/> object describes an audio file.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Audio {Artist}-{Title}")]
    public partial class Audio
    {
        /// <summary>
        /// Audio ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Audio owner ID.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Artist name.
        /// </summary>
        [DataMember]
        [JsonProperty("artist")]
        public string Artist { get; set; }

        /// <summary>
        /// Audio file title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Duration (in seconds). 
        /// </summary>
        [DataMember]
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Link to mp3.
        /// <remarks>
        /// NOTE: Links to .mp3 files are bound to an IP address.
        /// </remarks>
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public int Url { get; set; }

        /// <summary>
        /// ID of the lyrics (if available) of the audio file. 
        /// </summary>
        [DataMember]
        [JsonProperty("lyrics_id")]
        public int LyricsId { get; set; }

        /// <summary>
        /// ID of the album containing the audio file (if assigned). 
        /// </summary>
        [DataMember]
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        /// <summary>
        /// Genre ID.
        /// </summary>
        [DataMember]
        [JsonProperty("genre_id")]
        public int GenreId { get; set; }
    }
}
