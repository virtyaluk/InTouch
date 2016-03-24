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
    /// A <see cref="Store"/> class represents an information about a market.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Store {Name}")]
    public class Store
    {
        /// <summary>
        /// Market's ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Market's name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}