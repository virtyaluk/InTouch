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
    /// Topics list.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("TopicsList")]
    public class TopicsList : ItemsList<Topic>
    {
        /// <summary>
        /// Default sort order set by community admin.
        /// </summary>
        [DataMember]
        [JsonProperty("default_order")]
        public int DefaultOrder { get; set; }

        /// <summary>
        /// Whether the current user can create new topics in the current community.
        /// </summary>
        [DataMember]
        [JsonProperty("can_add_topics")]
        public bool CanAddTopics { get; set; }
    }
}