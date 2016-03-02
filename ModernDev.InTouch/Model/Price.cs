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
    /// TODO: https://vk.com/dev/price
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Price {Text}")]
    public class Price
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}