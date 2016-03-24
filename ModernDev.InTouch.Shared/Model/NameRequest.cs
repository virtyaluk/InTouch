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
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="NameRequest"/> class describes an information about name changing request.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("NameRequest {FirstName} {LastName}")]
    public class NameRequest
    {
        /// <summary>
        /// Request id, required to cancel it.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Request status.
        /// </summary>
        [DataMember]
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NameRequestStatus Status { get; set; }

        /// <summary>
        /// First name from the request.
        /// </summary>
        [DataMember]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name from the request.
        /// </summary>
        [DataMember]
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}