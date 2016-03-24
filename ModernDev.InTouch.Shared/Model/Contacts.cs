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

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Founded contacts.
    /// </summary>
    [DebuggerDisplay("Contacts")]
    [DataContract]
    public class Contacts
    {
        /// <summary>
        /// A list of <see cref="User"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("found")]
        public List<User> Found { get; set; }

        /// <summary>
        /// A list of contacts that were not found.
        /// </summary>
        [DataMember]
        [JsonProperty("other")]
        public List<Contacts> Other { get; set; }
    }
}