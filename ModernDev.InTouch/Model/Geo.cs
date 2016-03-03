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
    /// A <see cref="Geo"/> class describes an information about geo location attached to the <see cref="Post"/> or a <see cref="Message"/>.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Geo {Type}")]
    public class Geo
    {
        /// <summary>
        /// Location type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Location coordinates.
        /// </summary>
        [DataMember]
        [JsonProperty("coordinates")]
        [JsonConverter(typeof(JsonCoordinatesConverter))]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Location's <see cref="Place"/> information.
        /// </summary>
        [DataMember]
        [JsonProperty("place")]
        public GeoPlace Place { get; set; }
    }
}
