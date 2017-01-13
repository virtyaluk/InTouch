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
    /// A <see cref="CoverImage"/> class describes single community cover image.
    /// </summary>
    [DebuggerDisplay("CoverImage")]
    [DataContract]
    public class CoverImage
    {
        #region Properties

        /// <summary>
        /// URL of the image copy.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Image width.
        /// </summary>
        [DataMember]
        [JsonProperty("weight")]
        public int Width { get; set; }

        /// <summary>
        /// Image height.
        /// </summary>
        [DataMember]
        [JsonProperty("height")]
        public int Height { get; set; }
        #endregion
    }
}