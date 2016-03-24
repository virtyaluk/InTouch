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
    /// Video catalog.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("VideoCatalog")]
    public class VideoCatalog : ItemsList<VideoCatalogBlock>
    {
        /// <summary>
        /// Parameter to get the next page of results.
        /// </summary>
        [DataMember]
        [JsonProperty("next")]
        public string Next { get; set; }
    }
}