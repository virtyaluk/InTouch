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
    /// A list of items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    [DebuggerDisplay("ItemsList {Count}")]
    public class ItemsList<T>
    {
        /// <summary>
        /// The number of the items in the list.
        /// </summary>
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// The items.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        public List<T> Items { get; set; }

        /// <summary>
        /// The users the items belongs to.
        /// </summary>
        [DataMember]
        [JsonProperty("profiles")]
        public List<User> Profiles { get; set; }

        /// <summary>
        /// The communities the items belongs to.
        /// </summary>
        [DataMember]
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}