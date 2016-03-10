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
    /// A <see cref="City"/> class describes a city.
    /// </summary>
    [DebuggerDisplay("City {Title}")]
    [DataContract]
    public class City : TitledItem
    {
        [DataMember]
        [JsonProperty("important")]
        public bool Important { get; set; }

        /// <summary>
        /// The area of the city.
        /// </summary>
        [DataMember]
        [JsonProperty("area")]
        public string Area { get; set; }

        /// <summary>
        /// The region of the city.
        /// </summary>
        [DataMember]
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}