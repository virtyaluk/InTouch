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
    /// A <see cref="Rating"/> class represents an information about product's rating.
    /// </summary>
    [DebuggerDisplay(("Rating {Stars}_{ReviewsCount}"))]
    [DataContract]
    public class Rating
    {
        /// <summary>
        /// Product's stars count.
        /// </summary>
        [DataMember]
        [JsonProperty("start")]
        public int Stars { get; set; }

        /// <summary>
        /// The number of reviews the current product has received.
        /// </summary>
        [DataMember]
        [JsonProperty("reviews_count")]
        public int ReviewsCount { get; set; }
    }
}