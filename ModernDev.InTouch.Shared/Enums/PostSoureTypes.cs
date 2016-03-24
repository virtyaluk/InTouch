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
    /// Post source types.
    /// </summary>
    [DataContract]
    public enum PostSoureTypes
    {
        /// <summary>
        /// The post was created through the main site interface.
        /// </summary>
        [EnumMember(Value = "vk")]
        VK,

        /// <summary>
        /// The post was created using widget.
        /// </summary>
        [EnumMember(Value = "widget")]
        Widget,

        /// <summary>
        /// The post was created by app using the API.
        /// </summary>
        [EnumMember(Value = "api")]
        API,

        /// <summary>
        /// The post was created by importing RSS feed from another site.
        /// </summary>
        [EnumMember(Value = "rss")]
        RSS,

        /// <summary>
        /// The post was created by sending an SMS to a special number.
        /// </summary>
        [EnumMember(Value = "sms")]
        SMS
    }
}