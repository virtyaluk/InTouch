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

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="NewsList"/> describes a list of newsfeeds.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("NewsList")]
    public class NewsList
    {
        /// <summary>
        /// List ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// List title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// If reposts are switched off or not.
        /// </summary>
        [DataMember]
        [JsonProperty("no_reposts")]
        public bool NoReposts { get; set; }

        /// <summary>
        /// Users and communities identifiers from the list.
        /// </summary>
        [DataMember]
        [JsonProperty("source_ids")]
        public List<int> SourceIds { get; set; }
    }
}