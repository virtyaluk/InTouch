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
    /// A <see cref="Button"/> class represents an information about a button.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Button {Title}")]
    public class Button
    {
        /// <summary>
        /// Button's title.
        /// </summary>
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Button's action
        /// </summary>
        [DataMember]
        [JsonProperty("action")]
        public ButtonAction Action { get; set; }
    }
}