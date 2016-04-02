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
    /// Community link.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("CommunityLink {Name")]
    public class CommunityLink
    {
        /// <summary>
        /// Link Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Link URL.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Link name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// True - if the name can be changed (only for external links).
        /// </summary>
        [DataMember]
        [JsonProperty("edit_title")]
        public bool EditTitle { get; set; }

        /// <summary>
        /// Link description.
        /// </summary>
        [DataMember]
        [JsonProperty("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// True - if link's preview is still processing.
        /// </summary>
        [DataMember]
        [JsonProperty("image_processing")]
        public bool ImageProcessing { get; set; }
    }
}