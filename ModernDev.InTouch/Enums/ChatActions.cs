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
    /// Chat service actions.
    /// </summary>
    [DebuggerDisplay("ChatActions")]
    public enum ChatActions
    {
        [EnumMember(Value = "chat_photo_update")]
        PhotoUpdate,

        [EnumMember(Value = "chat_photo_remove")]
        PhotoRemove,

        [EnumMember(Value = "chat_create")]
        Create,

        [EnumMember(Value = "chat_title_update")]
        TitleUpdate,

        [EnumMember(Value = "chat_invite_user")]
        InviteUser,

        [EnumMember(Value = "chat_kick_user")]
        KickUser,

        [EnumMember(Value = "none")]
        None
    }
}