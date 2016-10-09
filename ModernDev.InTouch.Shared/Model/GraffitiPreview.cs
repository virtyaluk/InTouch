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
    /// Graffiti preview info.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("GrafittiPreview")]
    public class GraffitiPreview
    {
        /// <summary>
        /// Graffiti URL.
        /// </summary>
        [DataMember]
        [JsonProperty("src")]
        public string Src { get; set; }

        /// <summary>
        /// Image with in px.
        /// </summary>
        [DataMember]
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Image height in px.
        /// </summary>
        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}