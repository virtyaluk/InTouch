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
    /// Cases for declension of user name and surname.
    /// </summary>
    [DebuggerDisplay("NameCases")]
    public enum NameCases
    {
        /// <summary>
        /// Nominative
        /// </summary>
        [EnumMember(Value = "nom")]
        Nominative,

        /// <summary>
        /// Genitive
        /// </summary>
        [EnumMember(Value = "gen")]
        Genitive,

        /// <summary>
        /// Dative
        /// </summary>
        [EnumMember(Value = "dat")]
        Dative,

        /// <summary>
        /// Accusative
        /// </summary>
        [EnumMember(Value = "acc")]
        Accusative,

        /// <summary>
        /// Instrumental
        /// </summary>
        [EnumMember(Value = "ins")]
        Instrumental,

        /// <summary>
        /// Prepositional
        /// </summary>
        [EnumMember(Value = "abl")]
        Prepositional
    }
}