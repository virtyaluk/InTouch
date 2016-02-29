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
    /// 
    /// </summary>
    [DebuggerDisplay("AttachmentTypes")]
    public enum AttachmentTypes
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "photo")]
        Photo,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "video")]
        Video,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "audio")]
        Audio,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "doc")]
        Doc,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "wall")]
        Wall,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "wall_reply")]
        WallReply,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "sticker")]
        Sticker,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "link")]
        Link
    }
}