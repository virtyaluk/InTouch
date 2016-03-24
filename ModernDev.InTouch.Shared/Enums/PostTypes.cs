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

using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Post type
    /// </summary>
    [DataContract]
    public enum PostTypes
    {
        [EnumMember(Value = "post")]
        Post,

        [EnumMember(Value = "copy")]
        Copy,

        [EnumMember(Value = "reply")]
        Reply,

        [EnumMember(Value = "postpone")]
        PostPone,

        [EnumMember(Value = "suggest")]
        Suggest
    }
}