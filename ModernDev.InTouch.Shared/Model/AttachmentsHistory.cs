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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// List of dialog attachments.
    /// </summary>
    [DebuggerDisplay("AttachmentsHistory")]
    [DataContract]
    public class AttachmentsHistory
    {
        /// <summary>
        /// The new value of <c>start_from</c> need to send next request.
        /// </summary>
        [DataMember]
        [JsonProperty("next_from")]
        public string NextFrom { get; set; }

        /// <summary>
        /// A list of <see cref="User"/> profiles.
        /// </summary>
        [DataMember]
        [JsonProperty("profiles")]
        public List<User> Profiles { get; set; }

        /// <summary>
        /// A list of <see cref="Group"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Information about attachments.
        /// </summary>
        [DataMember]
        [JsonProperty("items")]
        [JsonConverter(typeof(JsonAttachmentsConverter))]
        public ReadOnlyCollection<IMediaAttachment> Items { get; set; }
    }
}