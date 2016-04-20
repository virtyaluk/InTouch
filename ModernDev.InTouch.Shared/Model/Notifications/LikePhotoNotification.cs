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
    /// One or more Likes have been added to the user's photo.
    /// </summary>
    [DebuggerDisplay("LikePhotoNotification")]
    [DataContract]
    public class LikePhotoNotification : NotificationItem
    {
        /// <summary>
        /// A list of <see cref="User"/> objects describing feedback.
        /// </summary>
        [DataMember]
        [JsonProperty("feedback")]
        public ItemsList<User> Feedback { get; set; }

        /// <summary>
        /// An object describing a material owns feedback.
        /// </summary>
        [DataMember]
        [JsonProperty("parent")]
        public Photo Parent { get; set; }
    }
}