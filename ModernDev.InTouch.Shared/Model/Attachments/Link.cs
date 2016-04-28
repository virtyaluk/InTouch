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
    /// A <see cref="Link"/> class represents a link to the web page attachment.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Link {Title}")]
    public class Link : IMediaAttachment
    {
        #region Properties
        /// <summary>
        /// Link's url.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Link's title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Link's caption (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// Link's description.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Link's <see cref="Photo"/> object (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        /// <summary>
        /// Whether the link leads to the external resource (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("is_external")]
        public bool IsExternal { get; set; }

        /// <summary>
        /// Link's <see cref="Product"/> object (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("product")]
        public Product Product { get; set; }

        /// <summary>
        /// Link's <see cref="Rating"/> object (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("rating")]
        public Rating Rating { get; set; }

        /// <summary>
        /// Link's <see cref="Application"/> object (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("application")]
        public Application Application { get; set; }

        /// <summary>
        /// Link's <see cref="Button"/> object (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("button")]
        public Button Button { get; set; }

        /// <summary>
        /// Wiki's <see cref="Page"/> ID to preview content using methods like <see cref="PagesMethods.Get"/>.
        /// The returned Id has the next form Page.OwnerId_Page.PageId.
        /// </summary>
        [DataMember]
        [JsonProperty("preview")]
        public string PreviewPage { get; set; }


        /// <summary>
        /// An url to preview the current link.
        /// </summary>
        [DataMember]
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// Id of the user or community that owns the link.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        #region Extra properties

        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }

        [DataMember]
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }

        [DataMember]
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }

        [DataMember]
        [JsonProperty("image_src")]
        public string ImageSrc { get; set; }

        #endregion

        #endregion
    }
}