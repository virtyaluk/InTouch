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
    /// One or more users have copied the user's video.
    /// </summary>
    [DebuggerDisplay("CopyVideoNotification")]
    [DataContract]
    public class CopyVideoNotification : NotificationItem
    {
        /// <summary>
        /// A list of <see cref="Post"/> objects describing feedback.
        /// </summary>
        [DataMember]
        [JsonProperty("feedback")]
        public ItemsList<Post> Feedback { get; set; }

        /// <summary>
        /// An object describing a material owns feedback.
        /// </summary>
        public Video Parent { get; set; }
    }
}