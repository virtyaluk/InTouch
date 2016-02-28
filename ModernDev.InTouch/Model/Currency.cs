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
    /// Currency info.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Currency {Id} {Name}")]
    public class Currency
    {
        /// <summary>
        /// Currency Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Currency symbol.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}