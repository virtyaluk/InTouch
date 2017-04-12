/**
 * This file\code is part of InTouch project.
 *
 * InTouch - is a .NET wrapper for the vk.com API.
 * https://github.com/virtyaluk/InTouch
 *
 * Copyright (c) 2017 Bohdan Shtepan
 * http://modern-dev.com/
 *
 * Licensed under the GPLv3 license.
 */

using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Represents vk.cc shortened link.
    /// </summary>
    [DataContract, DebuggerDisplay("ShortenedLink: {ShortURL}")]
    public class ShortenedLink
    {
        #region Properties

        /// <summary>
        /// Creation time.
        /// </summary>
        [DataMember, JsonProperty("timestamp"), JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Full URL.
        /// </summary>
        [DataMember, JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Shortened URL.
        /// </summary>
        [DataMember, JsonProperty("short_url")]
        public string ShortURL { get; set; }

        /// <summary>
        /// Link key (characters after "vk.cc")
        /// </summary>
        [DataMember, JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Views number.
        /// </summary>
        [DataMember, JsonProperty("views")]
        public int? Views { get; set; }

        /// <summary>
        /// Access key for private stats.
        /// </summary>
        [DataMember, JsonProperty("access_key")]
        public string AccessKey { get; set; }

        #endregion
    }
}
