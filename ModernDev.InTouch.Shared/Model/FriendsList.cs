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
    /// Friends list item.
    /// </summary>
    [DebuggerDisplay("FriendsList {Id} {Name}")]
    [DataContract]
    public class FriendsList
    {
        /// <summary>
        /// List id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// List name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}