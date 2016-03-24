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
    /// An <see cref="UserOccupation"/> class describes current user's occupation.
    /// </summary>
    [DebuggerDisplay("UserOccupation {Name}")]
    [DataContract]
    public class UserOccupation
    {
        /// <summary>
        /// Occupation type.
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public OccupationTypes Type { get; set; }

        /// <summary>
        /// ID of school, university, company group (the one a user works in).
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of school, university or work place.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}