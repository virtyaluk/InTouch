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
    /// Group catalog info.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("GroupCatalogInfo")]
    public class GroupCatalogInfo
    {
        /// <summary>
        /// True - catalog is available.
        /// </summary>
        [DataMember]
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Market categories.
        /// </summary>
        [DataMember]
        [JsonProperty("categories")]
        public List<GroupCategory> Categories { get; set; }
    }
}