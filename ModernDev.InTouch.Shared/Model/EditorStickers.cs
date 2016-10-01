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
    /// An <see cref="EditorStickers"/> class describes photo editor stickers.
    /// </summary>
    [DebuggerDisplay("EditorStickers")]
    [DataContract]
    public class EditorStickers
    {
        /// <summary>
        /// Base URL.
        /// </summary>
        [DataMember]
        [JsonProperty("base_url")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Sticker IDs.
        /// </summary>
        [DataMember]
        [JsonProperty("sticker_ids")]
        public List<int> StickerIds { get; set; }
    }
}
