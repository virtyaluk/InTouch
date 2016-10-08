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
    ///  A <see cref="CallbackServerSettings"/> class describes callback server settings.
    /// </summary>
    [DebuggerDisplay("CallbackServerSettings")]
    [DataContract]
    public class CallbackServerSettings
    {
        #region Properties

        /// <summary>
        /// Server URL. 
        /// </summary>
        [JsonProperty("server_url")]
        [DataMember]
        public string ServerUrl { get; set; }

        /// <summary>
        /// Secret key.
        /// </summary>
        [JsonProperty("secret_key")]
        [DataMember]
        public string SecretKey { get; set; }
        #endregion
    }
}
