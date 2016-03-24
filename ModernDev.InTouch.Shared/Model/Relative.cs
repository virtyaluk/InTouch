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
    /// A <see cref="Relative"/> class describes user's relative.
    /// </summary>
    [DebuggerDisplay("Relative {Id} {Type}")]
    [DataContract]
    public class Relative
    {
        /// <summary>
        /// Relationship type.
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public RelativeTypes Type { get; set; }

        /// <summary>
        /// User ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}