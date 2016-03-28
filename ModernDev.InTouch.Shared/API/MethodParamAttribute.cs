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

namespace ModernDev.InTouch
{
    /// <summary>
    /// Describes a property and its settings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MethodParamAttribute : Attribute
    {
        /// <summary>
        /// The name of the property
        /// </summary>
        public string Name;

        /// <summary>
        /// Whether the property is required.
        /// </summary>
        public bool IsRequired = false;

        /// <summary>
        /// The max value of the property.
        /// </summary>
        public int MaxAllowed;

        /// <summary>
        /// The property extra settings.
        /// </summary>
        public object Extra;
    }
}