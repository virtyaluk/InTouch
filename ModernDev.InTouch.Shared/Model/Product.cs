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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
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
        #region Properties
        /// <summary>
        /// Product's price
        /// </summary>
        [DataMember]
        [JsonProperty("price")]
        public Price Price { get; set; }

        /// <summary>
        /// Product Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Product owner Id.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Product category.
        /// </summary>
        [DataMember]
        [JsonProperty("category")]
        public MarketCategory Category { get; set; }

        /// <summary>
        /// Url of the cover image of the product.
        /// </summary>
        [DataMember]
        [JsonProperty("thumb_photo")]
        public string ThumbPhoto { get; set; }

        /// <summary>
        /// Date added.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Product availability status.
        /// </summary>
        [DataMember]
        [JsonProperty("availability")]
        public ProductAvailability Availability { get; set; }

        /// <summary>
        /// Product photos.
        /// </summary>
        [DataMember]
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }

        /// <summary>
        /// Whether the current user is able to comment the product.
        /// </summary>
        [DataMember]
        [JsonProperty("can_comment")]
        public bool CanComment { get; set; }

        /// <summary>
        /// Whether the current user is able to repost the product.
        /// </summary>
        [DataMember]
        [JsonProperty("can_repost")]
        public bool CanRepost { get; set; }

        /// <summary>
        /// An information about likes of the product.
        /// </summary>
        [DataMember]
        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        [DataMember]
        [JsonProperty("albums_ids")]
        public List<int> AlbumsIds { get; set; }

        [DataMember]
        [JsonProperty("views_count")]
        public int ViewsCount { get; set; }

        #endregion
    }
}