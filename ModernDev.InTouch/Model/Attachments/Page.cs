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
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Page"/>class describes a wiki page.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Page {Title}")]
    [APIVersion(Version = 5.45)]
    public partial class Page : IMediaAttachment
    {
        /// <summary>
        /// Page identifier.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Community identifier.
        /// </summary>
        [DataMember]
        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// Page creator identifier.
        /// </summary>
        [DataMember]
        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Page name.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// True, if current user can edit the page text.
        /// </summary>
        [DataMember]
        [JsonProperty("current_user_can_edit")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool CanEdit { get; set; }

        /// <summary>
        /// True, if current user can edit access permissions for the page.
        /// </summary>
        [DataMember]
        [JsonProperty("current_user_can_edit_access")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool CanEditAccess { get; set; }

        /// <summary>
        /// Shows who can view the page.
        /// </summary>
        [DataMember]
        [JsonProperty("who_can_view")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommunityAccessTypes WhoCanView { get; set; }

        /// <summary>
        /// Shows who can edit the page.
        /// </summary>
        [DataMember]
        [JsonProperty("who_can_edit")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommunityAccessTypes WhoCanEdit { get; set; }

        /// <summary>
        /// Date of the last edit.
        /// </summary>
        [DataMember]
        [JsonProperty("edited")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Edited { get; set; }

        /// <summary>
        /// Date of the page creation.
        /// </summary>
        [DataMember]
        [JsonProperty("created")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Id of the user last edited the page.
        /// </summary>
        [DataMember]
        [JsonProperty("editor_id")]
        public int EditorId { get; set; }

        /// <summary>
        /// Page views amount.
        /// </summary>
        [DataMember]
        [JsonProperty("views")]
        public int Views { get; set; }

        /// <summary>
        /// Parent page name for navigation, if exists.
        /// </summary>
        [DataMember]
        [JsonProperty("parent")]
        public string Parent { get; set; }

        /// <summary>
        /// Second parent page name for navigation, if exists.
        /// </summary>
        [DataMember]
        [JsonProperty("parent2")]
        public string Parent2 { get; set; }

        /// <summary>
        /// Page text in wiki format, if requested.
        /// </summary>
        [DataMember]
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// Page text in HTML format, if requested.
        /// </summary>
        [DataMember]
        [JsonProperty("html")]
        public string Html { get; set; }

        /// <summary>
        /// Address for page display.
        /// </summary>
        [DataMember]
        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        /// <summary>
        /// Id of the user or community that owns the page.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }
    }
}
