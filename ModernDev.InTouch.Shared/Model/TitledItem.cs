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
    /// A base class for all items that contains <c>id</c> and <c>title</c> properties.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("TitledItem {Title}")]
    public abstract class TitledItem
    {
        /// <summary>
        /// Item ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Item title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}