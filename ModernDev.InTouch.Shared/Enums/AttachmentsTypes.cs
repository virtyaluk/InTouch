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
        [EnumMember(Value = "photo")]
        Photo,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "doc")]
        Doc,

        [EnumMember(Value = "link")]
        Link,

        [EnumMember(Value = "market")]
        Market,

        [EnumMember(Value = "wall")]
        Wall,

        [EnumMember(Value = "share")]
        Share
    }
}