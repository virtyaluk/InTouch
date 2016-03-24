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
    /// User subscriptions.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("UserSubscriptions {Users.Count} {Groups.Count}")]
    public class UserSubscriptions
    {
        /// <summary>
        /// Users in subscriptions.
        /// </summary>
        [DataMember]
        [JsonProperty("users")]
        public ItemsList<int> Users { get; set; }

        /// <summary>
        /// Groups in subscriptions.
        /// </summary>
        [DataMember]
        [JsonProperty("groups")]
        public ItemsList<int> Groups { get; set; }  
    }
}