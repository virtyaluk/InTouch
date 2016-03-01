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
    /// A <see cref="Product"/> class describes an information about a product item.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Product")]
    public class Product
    {
        /// <summary>
        /// Product's price
        /// </summary>
        [DataMember]
        [JsonProperty("price")]
        public Price Price { get; set; }
    }
}