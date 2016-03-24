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
    /// <see cref="AccountInfo"/> fields.
    /// </summary>
    [DebuggerDisplay("AccountInfoFields")]
    public enum AccountInfoFields
    {
        [EnumMember(Value = "country")]
        Country,

        [EnumMember(Value = "https_required")]
        HttpsRequired,

        [EnumMember(Value = "own_posts_default")]
        OwnPostsDefault,

        [EnumMember(Value = "no_wall_replies")]
        NoWallReplies,

        [EnumMember(Value = "intro")]
        Intro,

        [EnumMember(Value = "lang")]
        Lang
    }
}