﻿/**
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
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Access token status.
    /// </summary>
    [DataContract, DebuggerDisplay("TokenStatus {UserId}")]
    public class TokenStatus
    {
        /// <summary>
        /// User Id.
        /// </summary>
        [DataMember, JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Status of token.
        /// </summary>
        [DataMember, JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Date of token generation.
        /// </summary>
        [DataMember, JsonProperty("date"), JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// Date of token expiration.
        /// </summary>
        [DataMember, JsonProperty("expire"), JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Expire { get; set; }
    }
}
