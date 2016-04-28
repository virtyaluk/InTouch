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

namespace ModernDev.InTouch
{
    /// <summary>
    /// Media types that can be attached to the message.
    /// </summary>
    [DebuggerDisplay("AttachmentTypes")]
    public enum AttachmentsTypes
    {
        /// <summary>
        /// Photos.
        /// </summary>
        [EnumMember(Value = "photo")]
        Photo,

        /// <summary>
        /// Videos.
        /// </summary>
        [EnumMember(Value = "video")]
        Video,

        /// <summary>
        /// Audio files.
        /// </summary>
        [EnumMember(Value = "audio")]
        Audio,

        /// <summary>
        /// Documents.
        /// </summary>
        [EnumMember(Value = "doc")]
        Doc,

        /// <summary>
        /// Links.
        /// </summary>
        [EnumMember(Value = "link")]
        Link,

        /// <summary>
        /// Market items.
        /// </summary>
        [EnumMember(Value = "market")]
        Market,

        /// <summary>
        /// Wall posts.
        /// </summary>
        [EnumMember(Value = "wall")]
        Wall,

        /// <summary>
        /// Links, market items and wall posts.
        /// </summary>
        [EnumMember(Value = "share")]
        Share
    }
}