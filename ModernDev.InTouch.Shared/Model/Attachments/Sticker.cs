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
    /// A <see cref="Sticker"/> class represents an information about sticker attachment.
    /// </summary>
    [DebuggerDisplay("Sticker {Id}_{ProductId}")]
    [DataContract]
    public class Sticker : IMediaAttachment
    {
        /// <summary>
        /// Sticker's ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Stickers pack id.
        /// </summary>
        [DataMember]
        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// URL of image with maximum size 64x64px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_64")]
        public string Photo64 { get; set; }

        /// <summary>
        /// URL of image with maximum size 128x128px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_128")]
        public string Photo128 { get; set; }

        /// <summary>
        /// URL of image with maximum size 256x256px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_256")]
        public string Photo256 { get; set; }

        /// <summary>
        /// URL of image with maximum size 352x352px.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_352")]
        public string Photo352 { get; set; }

        /// <summary>
        /// Width in pixels.
        /// </summary>
        [DataMember]
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Height in pixels.
        /// </summary>
        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Id of the user or community that owns the sticker.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }
    }
}