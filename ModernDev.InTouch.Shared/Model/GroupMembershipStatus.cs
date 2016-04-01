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
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Information about user's membership in a group.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("GroupMembershipStatus")]
    public class GroupMembershipStatus
    {
        /// <summary>
        /// Whether the user is a member of the community.
        /// </summary>
        [DataMember]
        [JsonProperty("member")]
        public bool IsMemeber { get; set; }

        /// <summary>
        /// Whether the user left a request to join the group, which can be declined by the <see cref="GroupsMethods.Leave"/> method.
        /// </summary>
        [DataMember]
        [JsonProperty("request")]
        public bool IsRequested { get; set; }

        /// <summary>
        /// Whether the user is invited to join the group or event.
        /// </summary>
        [DataMember]
        [JsonProperty("invitation")]
        public bool IsInvited { get; set; }
    }
}
