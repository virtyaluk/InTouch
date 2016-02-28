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
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="UserPersonal"/> class describes user's personal views.
    /// </summary>
    [DebuggerDisplay("UserPersonal")]
    [DataContract]
    public class UserPersonal
    {
        /// <summary>
        /// Political views.
        /// </summary>
        [DataMember]
        [JsonProperty("political")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserPersonalPoliticalViewsTypes Political { get; set; }

        /// <summary>
        /// Languages.
        /// </summary>
        [DataMember]
        [JsonProperty("langs")]
        public List<string> Langs { get; set; }

        /// <summary>
        /// World view.
        /// </summary>
        [DataMember]
        [JsonProperty("religion")]
        public string Religion { get; set; }

        /// <summary>
        /// Inspired by.
        /// </summary>
        [DataMember]
        [JsonProperty("inspired_by")]
        public string InspiredBy { get; set; }

        /// <summary>
        /// Important in others.
        /// </summary>
        [DataMember]
        [JsonProperty("people_main")]
        public int PeopleMain { get; set; }

        /// <summary>
        /// Personal priority.
        /// </summary>
        [DataMember]
        [JsonProperty("life_main")]
        public int LifeMain { get; set; }

        /// <summary>
        /// Views on smoking.
        /// </summary>
        [DataMember]
        [JsonProperty("smoking")]
        public int Smoking { get; set; }

        /// <summary>
        /// Views on alcohol.
        /// </summary>
        [DataMember]
        [JsonProperty("alcohol")]
        public int Alcohol { get; set; }
    }
}