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
    public class InTouchResponseErrorException : Exception
    {
        public ResponseError ResponseError { get; private set; }
        public InTouchResponseErrorException(string message) : base(message) { }
        public InTouchResponseErrorException(string message, Exception innerException) : base(message, innerException) { }

        public InTouchResponseErrorException(string message, ResponseError responseError) : base(message)
        {
            ResponseError = responseError;
        }
    }
}