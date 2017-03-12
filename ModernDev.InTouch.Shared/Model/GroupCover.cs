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
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="GroupCover"/> class describes community cover.
    /// </summary>
    [DebuggerDisplay("GroupCover")]
    [DataContract]
    public class GroupCover
    {
        #region Properties

        /// <summary>
        /// Information whether the cover is enabled.
        /// </summary>
        [DataMember]
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Cover image copies.
        /// </summary>
        [DataMember]
        [JsonProperty("images")]
        public List<CoverImage> Images { get; set; }
        #endregion
    }
}
