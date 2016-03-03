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
    /// A <see cref="Coordinates"/> class describes a geographic coordinate.
    /// </summary>
    [DebuggerDisplay("Coordinates {Latitude} {Longitude}")]
    [DataContract]
    public class Coordinates
    {
        /// <summary>
        /// Geographical latitude, in degrees (from -90 to 90).
        /// </summary>
        [DataMember]
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Geographical longitude, in degrees (from -180 to 180).
        /// </summary>
        [DataMember]
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}