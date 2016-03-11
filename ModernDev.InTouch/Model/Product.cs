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

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public int OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public Category Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public string ThumbPhoto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public ProductAvailability Availability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public List<Photo> Photos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public bool CanComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public bool CanRepost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("")]
        public Likes Likes { get; set; }
    }

    /// <summary>
    /// A <see cref="Section"/> class describes a category section.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Section {Name}")]
    public class Section
    {
        /// <summary>
        /// Section Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Section name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// A <see cref="Category"/> class describes a product category.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Category {Name}")]
    public class Category
    {
        /// <summary>
        /// Category Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Category name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Category section.
        /// </summary>
        [DataMember]
        [JsonProperty("section")]
        public Section Section { get; set; }
    }
}