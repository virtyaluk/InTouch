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
    public enum FriendsOrder
    {
        /// <summary>
        /// By rating, similar to how friends are sorted in My friends section.
        /// </summary>
        [EnumMember(Value = "hints")]
        Hints,

        /// <summary>
        /// Randomly.
        /// </summary>
        [EnumMember(Value = "random")]
        Random,

        /// <summary>
        /// Mobile app users first.
        /// </summary>
        [EnumMember(Value = "value")]
        Mobile,

        /// <summary>
        /// By name.
        /// </summary>
        [EnumMember(Value = "name")]
        Name
    }
}