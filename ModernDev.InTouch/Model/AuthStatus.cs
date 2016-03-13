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
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Authentication status.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("AuthStatus")]
    public class AuthStatus
    {
        /// <summary>
        /// ID of the registered user.
        /// </summary>
        [DataMember]
        [JsonProperty("uid")]
        public int UId { get; set; }

        /// <summary>
        /// Whether the confirmation or restoring is success.
        /// </summary>
        [DataMember]
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonProperty("sid")]
        public string SId { get; set; }
    }
}