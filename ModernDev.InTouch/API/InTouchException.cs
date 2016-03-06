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

namespace ModernDev.InTouch.API
{
    public class InTouchException : Exception
    {
        public object Detail { get; private set; }
        public InTouchException(string message) : base(message) { }
        public InTouchException(string message, Exception innerException) : base(message, innerException) { }

        public InTouchException(string message, object detail) : base(message)
        {
            Detail = detail;
        }
    }
}