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
    /// Market info.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Market {Enabled} {ContactId}")]
    public class Market
    {
        /// <summary>
        /// Returns true if a community has items.
        /// </summary>
        [DataMember]
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The min price of the items.
        /// </summary>
        [DataMember]
        [JsonProperty("price_min")]
        public int PriceMin { get; set; }

        /// <summary>
        /// The max price of the items.
        /// </summary>
        [DataMember]
        [JsonProperty("price_max")]
        public int PriceMax { get; set; }

        /// <summary>
        /// Id of the main items album.
        /// </summary>
        [DataMember]
        [JsonProperty("main_album_id")]
        public int MainAlbumId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("contact_id")]
        public int ContactId { get; set; }

        /// <summary>
        /// Info about used currency.
        /// </summary>
        [DataMember]
        [JsonProperty("currency")]
        public Currency Currency { get; set; }
    }
}