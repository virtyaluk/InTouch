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
    /// Friend suggestions types.
    /// </summary>
    [DebuggerDisplay("FriendSuggestionsTypes")]
    public enum FriendSuggestionsTypes
    {
        /// <summary>
        /// Users with many mutual friends.
        /// </summary>
        [EnumMember(Value = "mutual")]
        Mutual,

        /// <summary>
        /// Users found with the <see cref="AccountMethods.ImportContacts"/> method.
        /// </summary>
        [EnumMember(Value = "contacts")]
        Contacts,

        /// <summary>
        /// Users who imported the same contacts as the current user with the <see cref="AccountMethods.ImportContacts"/> method.
        /// </summary>
        [EnumMember(Value = "mutual_contacts")]
        MutualContacts,

        /// <summary>
        /// All suggestions.
        /// </summary>
        [EnumMember(Value = "all")]
        All
    }
}