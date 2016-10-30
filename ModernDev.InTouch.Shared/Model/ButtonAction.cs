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
    /// A <see cref="ButtonAction"/> class represents an information about button's action.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ButtonAction {Url}")]
    public class ButtonAction
    {
        /// <summary>
        /// Action's type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// URL to head over to.
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}