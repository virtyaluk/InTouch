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
    /// Information about user's phone numbers.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("UserContacts {MobilePhone} {HomePhone}")]
    public class UserContacts
    {
        /// <summary>
        /// User's mobile phone number (only for standalone applications);
        /// </summary>
        [DataMember]
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// User's additional phone number.
        /// </summary>
        [DataMember]
        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }
    }
}