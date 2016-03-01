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
    /// An <see cref="Application"/> class represents an information about market's app.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Application {AppId}")]
    public class Application
    {
        /// <summary>
        /// A <see cref="Store"/> object.
        /// </summary>
        [DataMember]
        [JsonProperty("store")]
        public Store Store { get; set; }

        /// <summary>
        /// App's ID int the market.
        /// </summary>
        [DataMember]
        [JsonProperty("app_id")]
        public int AppId { get; set; }
    }
}