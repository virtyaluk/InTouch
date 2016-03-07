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
    /// An <see cref="AccountInfo"/> describes the current account info.
    /// </summary>
    [DebuggerDisplay("AccountInfo {Country}")]
    [DataContract]
    public class AccountInfo
    {
        /// <summary>
        /// String code of a country identified by ip-address of the current request.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// True – user set the "Always use secure connection" setting; False – secure connection is not required.
        /// </summary>
        [DataMember]
        [JsonProperty("https_required")]
        public bool HttpsRequired { get; set; }

        /// <summary>
        /// Numeric identifier of user's current language.
        /// </summary>
        [DataMember]
        [JsonProperty("lang")]
        public int Lang { get; set; }

        /// <summary>
        /// Bit mask responsible for passing the application usage tutorial.
        /// </summary>
        [DataMember]
        [JsonProperty("intro")]
        public int Intro { get; set; }
    }
}