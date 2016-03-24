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
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="PhotoSize"/> class describes an info about original photo in different sizes.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("PhotoSize {Width}x{Height}x{Type}")]
    public class PhotoSize
    {
        /// <summary>
        /// Url of image copy.
        /// </summary>
        [DataMember]
        [JsonProperty("src")]
        public string Src { get; set; }

        /// <summary>
        /// Copy width, px.
        /// </summary>
        [DataMember]
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Copy height, px.
        /// </summary>
        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Notation for copy size and ratio.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PhotoSizeTypes Type { get; set; }
    }
}