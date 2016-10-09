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
    /// Audio message info.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("AudioMessage")]
    public class AudioMessage
    {
        /// <summary>
        /// Duration in seconds.
        /// </summary>
        [DataMember]
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// List of integers used to visual representation of waveform.
        /// </summary>
        [DataMember]
        [JsonProperty("waveform")]
        public List<int> Waveform { get; set; }

        /// <summary>
        /// URL to .ogg file.
        /// </summary>
        [DataMember]
        [JsonProperty("link_ogg")]
        public string LingOGG { get; set; }

        /// <summary>
        /// URL to .mp3 file.
        /// </summary>
        [DataMember]
        [JsonProperty("link_mp3")]
        public string LinkMP3 { get; set; }
    }
}