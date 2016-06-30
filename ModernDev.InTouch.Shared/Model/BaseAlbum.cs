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
    /// A base class for all kind of albums.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("BaseAlbum {Title}")]
    public abstract class BaseAlbum
    {
        #region Properties

        /// <summary>
        /// Album Id.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Owner Id.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Album title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        #endregion

        public override string ToString()
        {
            return Title;
        }
    }
}