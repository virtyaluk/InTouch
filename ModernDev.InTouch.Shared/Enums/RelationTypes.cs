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
    /// Relationship statuses.
    /// </summary>
    [DebuggerDisplay("RelationTypes")]
    public enum RelationTypes
    {
        /// <summary>
        /// Single.
        /// </summary>
        [EnumMember(Value = "1")]
        Single = 1,

        /// <summary>
        /// In a relationship.
        /// </summary>
        [EnumMember(Value = "in a relationship")]
        InARelationship = 2,

        /// <summary>
        /// Engaged.
        /// </summary>
        [EnumMember(Value = "engaged")]
        Engaged = 3,

        /// <summary>
        /// Married.
        /// </summary>
        [EnumMember(Value = "married")]
        Married = 4,

        /// <summary>
        /// It's complicated.
        /// </summary>
        [EnumMember(Value = "it's complicated")]
        ItsCompicated = 5,

        /// <summary>
        /// Actively searching.
        /// </summary>
        [EnumMember(Value = "actively searching")]
        ActivelySearching = 6,

        /// <summary>
        /// In love.
        /// </summary>
        [EnumMember(Value = "in love")]
        InLove = 7,

        /// <summary>
        /// In a civil union.
        /// </summary>
        [EnumMember(Value = "in a civil union")]
        InCivilUnion = 8,

        /// <summary>
        /// Not specified.
        /// </summary>
        [EnumMember(Value = "not specified")]
        NotSpecified = 0
    }
}