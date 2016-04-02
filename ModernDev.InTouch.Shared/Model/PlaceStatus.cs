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
    /// Status of place editing.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("PlaceStatus")]
    public class PlaceStatus
    {
        /// <summary>
        /// Whether the editing is successful.
        /// </summary>
        [DataMember]
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Formatted address string.
        /// </summary>
        [DataMember]
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}