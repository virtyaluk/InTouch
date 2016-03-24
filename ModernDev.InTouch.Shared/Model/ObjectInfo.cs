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
    /// An <see cref="ObjectInfo"/> describes general information about VK object.
    /// </summary>
    [DebuggerDisplay("ObjectInfo {Type} {Id}")]
    [DataContract]
    public class ObjectInfo
    {
        /// <summary>
        /// Object Id.
        /// </summary>
        [DataMember]
        [JsonProperty("object_id")]
        public int Id { get; set; }

        /// <summary>
        /// Object type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObjectTypes Type { get; set; }
    }
}