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
    /// Online friends
    /// </summary>
    [DataContract]
    [DebuggerDisplay("OnlineFriends")]
    public class OnlineFriends
    {
        /// <summary>
        /// A list of Ids of online friends.
        /// </summary>
        [DataMember]
        [JsonProperty("online")]
        public List<int> Online { get; set; }

        /// <summary>
        /// A list of Ids of online from mobile.
        /// </summary>
        [DataMember]
        [JsonProperty("online_mobile")]
        public List<int> OnlineMobile { get; set; } 
    }
}