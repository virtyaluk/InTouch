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
    /// A <see cref="Price"/> class describes product's price.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Price {Text}")]
    public class Price
    {
        /// <summary>
        /// The price of the product.
        /// </summary>
        [DataMember]
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Currency.
        /// </summary>
        [DataMember]
        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// A string representation of the price.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}