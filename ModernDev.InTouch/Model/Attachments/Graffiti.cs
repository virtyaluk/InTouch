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
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Graffiti"/> represents an information about attached graffiti.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Graffiti {Id} {OwnerId}")]
    [APIVersion(Version = 5.45)]
    public class Graffiti : IMediaAttachment
    {
        /// <summary>
        /// Graffiti ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Id of the user or community that owns the graffiti.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// URL of image with maximum size 200x200px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }

        /// <summary>
        /// URL of image with maximum size 586x586px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_586")]
        public string Photo586 { get; set; }
    }
}