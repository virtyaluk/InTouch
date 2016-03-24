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
    /// Supported languages for the data to be displayed on.
    /// </summary>
    [DebuggerDisplay("Lang")]
    public enum Langs
    {
        /// <summary>
        /// Russian
        /// </summary>
        [EnumMember(Value = "ru")]
        Russian,

        /// <summary>
        /// Ukrainian
        /// </summary>
        [EnumMember(Value = "ua")]
        Ukrainian,

        /// <summary>
        /// Belorussian
        /// </summary>
        [EnumMember(Value = "be")]
        Belorussian,

        /// <summary>
        /// English
        /// </summary>
        [EnumMember(Value = "en")]
        English,

        /// <summary>
        /// Spanish
        /// </summary>
        [EnumMember(Value = "es")]
        Spanish,

        /// <summary>
        /// Finnish
        /// </summary>
        [EnumMember(Value = "fi")]
        Finnish,

        /// <summary>
        /// German
        /// </summary>
        [EnumMember(Value = "de")]
        German,

        /// <summary>
        /// Italian
        /// </summary>
        [EnumMember(Value = "it")]
        Italian,

        /// <summary>
        /// Use user's current language based on <see cref="AccountMethods.GetInfo"/>
        /// </summary>
        UsersCurrentLanguage
    }
}