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
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// User subscriptions extended.
    /// </summary>
    [DebuggerDisplay("UserSubscriptionsExtended")]
    [DataContract]
    public class UserSubscriptionsExtended : ItemsList<IProfileItem>
    {
        [DataMember]
        [JsonProperty("items")]
        [JsonConverter(typeof (JsonIProfileItemListConverter))]
        public new List<IProfileItem> Items { get; set; }
    }
}