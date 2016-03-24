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
    /// Media types
    /// </summary>
    [DebuggerDisplay("MediaTypes")]
    public enum MediaTypes
    {
        [EnumMember(Value = "post")]
        Post,

        [EnumMember(Value = "comment")]
        Comment,

        [EnumMember(Value = "photo")]
        Photo,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "note")]
        Note,

        [EnumMember(Value = "market")]
        Market,

        [EnumMember(Value = "photo_comment")]
        PhotoComment,

        [EnumMember(Value = "video_comment")]
        VideoComment,

        [EnumMember(Value = "topic_comment")]
        TopicComment,

        [EnumMember(Value = "market_comment")]
        MarketComment,

        [EnumMember(Value = "sitepage")]
        Sitepage
    }
}