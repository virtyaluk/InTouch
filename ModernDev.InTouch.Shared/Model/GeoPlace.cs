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
    /// A <see cref="GeoPlace"/> class describes an information about geo location.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("GeoPlace {Country}, {City}")]
    public class GeoPlace : BasicPlace
    {
        /// <summary>
        /// The name of the country.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// The name of the city.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public string City { get; set; }
    }
}