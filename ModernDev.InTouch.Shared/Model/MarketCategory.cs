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
    /// A <see cref="MarketCategory"/> class describes a product category.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("MarketCategory {Name}")]
    public class MarketCategory : BaseCategory
    {
        /// <summary>
        /// Category section.
        /// </summary>
        [DataMember]
        [JsonProperty("section")]
        public Section Section { get; set; }
    }
}