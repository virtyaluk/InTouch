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

using System;
using System.Runtime.Serialization;

namespace ModernDev.InTouch.API
{
    /// <summary>
    /// Application Access Permissions
    /// </summary>
    [Flags]
    public enum AccessPermissions
    {
        /// <summary>
        /// User allowed to send notifications to him/her.
        /// </summary>
        [EnumMember(Value = "notify")]
        Notify = 1,

        /// <summary>
        /// Access to friends.
        /// </summary>
        [EnumMember(Value = "friends")]
        Friends = 2,

        /// <summary>
        /// Access to photos.
        /// </summary>
        [EnumMember(Value = "photos")]
        Photos = 4,

        /// <summary>
        /// Access to audios.
        /// </summary>
        [EnumMember(Value = "audio")]
        Audio = 8,

        /// <summary>
        /// Access to videos.
        /// </summary>
        [EnumMember(Value = "video")]
        Video = 16,

        /// <summary>
        /// Access to documents.
        /// </summary>
        [EnumMember(Value = "docs")]
        Docs = 131072,

        /// <summary>
        /// Access to user notes.
        /// </summary>
        [EnumMember(Value = "notes")]
        Notes = 2048,

        /// <summary>
        /// Access to wiki pages.
        /// </summary>
        [EnumMember(Value = "pages")]
        Pages = 128,

        /// <summary>
        /// Access to user status.
        /// </summary>
        [EnumMember(Value = "status")]
        Status = 1024,

        /// <summary>
        /// Addition of link to the application in the left menu.
        /// </summary>
        [EnumMember(Value = "")]
        LeftMenuLink = 256,

        /// <summary>
        /// Access to standard and advanced methods for the wall.
        /// </summary>
        [EnumMember(Value = "wall")]
        Wall = 8192,

        /// <summary>
        /// Access to user groups.
        /// </summary>
        [EnumMember(Value = "groups")]
        Groups = 262144,

        /// <summary>
        /// Access to advanced methods for messaging.
        /// </summary>
        [EnumMember(Value = "messages")]
        Messages = 4096,

        /// <summary>
        /// User e-mail access.
        /// </summary>
        [EnumMember(Value = "email")]
        Email = 4194304,

        /// <summary>
        /// Access to notifications about answers to the user.
        /// </summary>
        [EnumMember(Value = "notifications")]
        Notifications = 524288,

        /// <summary>
        /// Access to statistics of user groups and applications where he/she is an administrator.
        /// </summary>
        [EnumMember(Value = "stats")]
        Stats = 1048576,

        /// <summary>
        /// Access to advanced methods for Ads API.
        /// </summary>
        [EnumMember(Value = "ads")]
        Ads = 32768,

        /// <summary>
        /// Access to API at any time.
        /// </summary>
        [EnumMember(Value = "offline")]
        Offline = 65536,

        /// <summary>
        /// None.
        /// </summary>
        [EnumMember(Value = "")]
        None = 0,
    }
}