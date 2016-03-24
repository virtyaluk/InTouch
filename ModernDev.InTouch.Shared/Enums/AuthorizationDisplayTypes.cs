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

namespace ModernDev.InTouch.API
{
    /// <summary>
    /// Authorization window appearance.
    /// </summary>
    public enum AuthorizationDisplayTypes
    {
        [EnumMember(Value = "page")]
        Page,
        [EnumMember(Value = "popup")]
        Popup,
        [EnumMember(Value = "mobile")]
        Mobile
    }
}