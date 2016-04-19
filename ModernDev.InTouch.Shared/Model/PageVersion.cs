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

using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Wiki page version info.
    /// </summary>
    [DebuggerDisplay("PageVersion")]
    [DataContract]
    public class PageVersion
    {
        /// <summary>
        /// ID of the page version.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Length of the page version (in bytes).
        /// </summary>
        [DataMember]
        [JsonProperty("length")]
        public int Length { get; set; }

        /// <summary>
        /// Date on which the page was edited.
        /// </summary>
        [DataMember]
        [JsonProperty("Date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// ID of the user who edited the page.
        /// </summary>
        [DataMember]
        [JsonProperty("editor_id")]
        public int EditorId { get; set; }

        /// <summary>
        /// Name of the user who edited the page.
        /// </summary>
        [DataMember]
        [JsonProperty("editor_name")]
        public string EditorName { get; set; }
    }
}