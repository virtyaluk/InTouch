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
    /// A <see cref="Place"/> class describes a location item.
    /// </summary>
    [DebuggerDisplay("Place {Title}")]
    [DataContract]
    public partial class Place : BasicPlace
    {
        /// <summary>
        /// Country ID.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public int CountryId { get; set; }

        /// <summary>
        /// City ID.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public int? CityId { get; set; }

        /// <summary>
        /// Distance from the initial search point.
        /// </summary>
        [DataMember]
        [JsonProperty("distance")]
        public int Distance { get; set; }
    }
}