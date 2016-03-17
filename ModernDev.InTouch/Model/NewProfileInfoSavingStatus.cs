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
    /// Saving profile info status.
    /// </summary>
    [DebuggerDisplay("NewProfileInfoSavingStatus")]
    [DataContract]
    public class NewProfileInfoSavingStatus
    {
        /// <summary>
        /// True if the information is saved, False if no fields were saved.
        /// </summary>
        [DataMember]
        [JsonProperty("changed")]
        public bool Changed { get; set; }

        /// <summary>
        /// Info about name change request (if any).
        /// </summary>
        [DataMember]
        [JsonProperty("name_request")]
        public NameRequest NameRequest { get; set; }
    }
}