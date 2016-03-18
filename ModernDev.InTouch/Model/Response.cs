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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Response{T}"/> class describes a request response.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Data"/> property.</typeparam>
    [DebuggerDisplay("Response")]
    public class Response<T>
    {
        public Response(ResponseError err, T data, string raw)
        {
            Error = err;
            Data = data;
            Raw = raw;
        } 

        /// <summary>
        /// Response error (if any).
        /// </summary>
        public ResponseError Error { get; }

        /// <summary>
        /// Response data (if any).
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Whether the request response is error.
        /// </summary>
        public bool IsError => Error != null;

        /// <summary>
        /// Raw JSON response.
        /// </summary>
        public string Raw { get; }
    }
}