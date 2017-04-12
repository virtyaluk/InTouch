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

using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Represents an information about post views.
    /// </summary>
    [DataContract, DebuggerDisplay("PostViews: {Count}")]
    public class PostViews
    {
        /// <summary>
        /// Views number.
        /// </summary>
        [DataMember, JsonProperty("views")]
        public int? Count { get; set; }
    }
}