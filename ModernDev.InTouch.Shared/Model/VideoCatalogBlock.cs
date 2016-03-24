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
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Video catalog block item.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("VideoCatalogBlock {Name}")]
    public class VideoCatalogBlock : ItemsList<IVideoCatalogItem>
    {
        /// <summary>
        /// Block name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Block Id. Returns a string for the predefined blocks and the number for all the others.
        /// 
        /// Predefined blocks:
        /// <list type="bullet">
        ///     <item>
        ///         <term>my</term>
        ///         <description>User's videos.</description>
        ///     </item>
        ///     <item>
        ///         <term>feed</term>
        ///         <description>Post of communities and friends, containing videos and new videos added by them.</description>
        ///     </item>
        ///     <item>
        ///         <term>ugc</term>
        ///         <description>Popular videos.</description>
        ///     </item>
        ///     <item>
        ///         <term>series</term>
        ///         <description>Tv-series.</description>
        ///     </item>
        ///     <item>
        ///         <term>top</term>
        ///         <description>Editor's choice.</description>
        ///     </item>
        /// </list>
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether the block can be hidden.
        /// </summary>
        [DataMember]
        [JsonProperty("can_hide")]
        public bool CanHide { get; set; }

        /// <summary>
        /// Parameter to get the next page of results.
        /// It is necessary to pass it as the <c>from</c> value in the following call to get the contents of a directory, following the receipt of this call.
        /// </summary>
        [DataMember]
        [JsonProperty("next")]
        public string Next { get; set; }

        /// <summary>
        /// URL-icon image for the block, 28x28px.
        /// </summary>
        [DataMember]
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// URL-icon image for the block, 48x48px
        /// </summary>
        [DataMember]
        [JsonProperty("icon_2x")]
        public string Icon2X { get; set; }

        /// <summary>
        /// Block view type.
        /// </summary>
        [DataMember]
        [JsonProperty("view")]
        public string View { get; set; }

        /// <summary>
        /// Block type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public VideoCatalogBlockTypes Type { get; set; }

        /// <summary>
        /// Block items.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        [JsonConverter(typeof(JsonIVideoCatalogItemsConverter))]
        public new List<IVideoCatalogItem> Items { get; set; } 
    }
}