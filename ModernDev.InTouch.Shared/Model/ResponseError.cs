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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace ModernDev.InTouch
{
    /// <summary>
    /// A basic class for response error.
    /// </summary>
    [DebuggerDisplay("ResponseError")]
    [DataContract]
    public class ResponseError : EventArgs
    {
        /// <summary>
        /// Error code.
        /// </summary>
        [DataMember]
        [JsonProperty("error_code")]
        public int Code { get; private set; }

        /// <summary>
        /// Error text.
        /// </summary>
        [DataMember]
        [JsonProperty("error_msg")]
        public string Message { get; private set; }

        /// <summary>
        /// Captcha identifier.
        /// </summary>
        [DataMember]
        [JsonProperty("captcha_sid")]
        public string CaptchaSId { get; set; }

        /// <summary>
        /// A link to an image that will be shown to a user.
        /// </summary>
        [DataMember]
        [JsonProperty("captcha_img")]
        public string CaptchaImg { get; private set; }

        /// <summary>
        /// Request parameters.
        /// </summary>
        [DataMember]
        [JsonProperty("request_params")]
        [JsonConverter(typeof(JsonRequestParamsConverter))]
        public Dictionary<string, string> RequestParams { get; private set; }

        public override string ToString()
        {
            return $"{Code}: {Message}";
        }
    }
}