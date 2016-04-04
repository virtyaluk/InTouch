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
    /// Total statistic for a certain period.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Period")]
    public class Period
    {
        /// <summary>
        /// Day in <c>YYYY-MM-DD</c> format.
        /// </summary>
        [DataMember]
        [JsonProperty("day")]
        public string Day { get; set; }

        /// <summary>
        /// The number of views.
        /// </summary>
        [DataMember]
        [JsonProperty("views")]
        public int Views { get; set; }

        /// <summary>
        /// The number of unique visitors.
        /// </summary>
        [DataMember]
        [JsonProperty("visitors")]
        public int Visitors { get; set; }

        /// <summary>
        /// Total number of subscribers reached.
        /// </summary>
        [DataMember]
        [JsonProperty("reach")]
        public int Reach { get; set; }

        /// <summary>
        /// Number of subscribers reached.
        /// </summary>
        [DataMember]
        [JsonProperty("reach_subscribers")]
        public int ReachSubscribers { get; set; }

        /// <summary>
        /// The number of the new subscribers.
        /// </summary>
        [DataMember]
        [JsonProperty("subscribed")]
        public int Subscribed { get; set; }

        /// <summary>
        /// The number of unsubscribed users.
        /// </summary>
        [DataMember]
        [JsonProperty("unsubscribed")]
        public int Unsubscribed { get; set; }

        /// <summary>
        /// Statistics by sex.
        /// </summary>
        [DataMember]
        [JsonProperty("sex")]
        public List<PeriodData> Sex { get; set; }

        /// <summary>
        /// Statistics by age.
        /// </summary>
        [DataMember]
        [JsonProperty("age")]
        public List<PeriodData> Age { get; set; }

        /// <summary>
        /// Statistics by sex and age.
        /// </summary>
        [DataMember]
        [JsonProperty("sex_age")]
        public List<PeriodData> SexAge { get; set; }

        /// <summary>
        /// Statistics by city.
        /// </summary>
        [DataMember]
        [JsonProperty("cities")]
        public List<PeriodData> Cities { get; set; }

        /// <summary>
        /// Statistics by country.
        /// </summary>
        [DataMember]
        [JsonProperty("countries")]
        public List<PeriodData> Countries { get; set; }
    }
}