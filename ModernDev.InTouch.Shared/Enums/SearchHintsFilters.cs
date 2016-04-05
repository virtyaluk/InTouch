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
    /// Search hints types to filter on.
    /// </summary>
    [DebuggerDisplay("SearchHintsFilters")]
    public enum SearchHintsFilters
    {
        /// <summary>
        /// User's friends.
        /// </summary>
        [EnumMember(Value = "friends")]
        Friends,

        /// <summary>
        /// User's subscriptions.
        /// </summary>
        [EnumMember(Value = "idols")]
        Idols,

        /// <summary>
        /// User's public page subscriptions.
        /// </summary>
        [EnumMember(Value = "publics")]
        Publics,

        /// <summary>
        /// User's groups.
        /// </summary>
        [EnumMember(Value = "groups")]
        Groups,

        /// <summary>
        /// User's events.
        /// </summary>
        [EnumMember(Value = "events")]
        Events,

        /// <summary>
        /// User's conversations participants.
        /// </summary>
        [EnumMember(Value = "correspondents")]
        Correspondents,

        /// <summary>
        /// People with common friends.
        /// </summary>
        [EnumMember(Value = "mutual_friends")]
        MutualFriends
    }
}