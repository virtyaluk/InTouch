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
    /// Describes search hint object.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("SearchHintItem {Type")]
    public class SearchHintItem
    {
        /// <summary>
        /// Hint object type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Group profile (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("group")]
        public Group Group { get; set; }

        /// <summary>
        /// User profile (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("profile")]
        public User Profile { get; set; }

        /// <summary>
        /// The object's type.
        /// </summary>
        [DataMember]
        [JsonProperty("section")]
        [JsonConverter(typeof(StringEnumConverter))]
        public HintsSectionTypes Section { get; set; }

        /// <summary>
        /// The object's description.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DataMember]
        [JsonProperty("global")]
        public bool Global { get; set; }
    }
}