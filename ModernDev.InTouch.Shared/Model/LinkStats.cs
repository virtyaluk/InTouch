using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for link stats,
    /// </summary>
    [DataContract, DebuggerDisplay("StatsBase")]
    public abstract class StatsBase
    {
        /// <summary>
        /// Views count.
        /// </summary>
        [DataMember, JsonProperty("views")]
        public int Views { get; set; }
    }

    /// <summary>
    /// City stats.
    /// </summary>
    [DataContract, DebuggerDisplay("CityStats {CityId}")]
    public class CityStats : StatsBase
    {
        /// <summary>
        /// City Id.
        /// </summary>
        [DataMember, JsonProperty("city_id")]
        public int CityId { get; set; }
    }

    /// <summary>
    /// Country stats.
    /// </summary>
    [DataContract, DebuggerDisplay("CountryStats {CountryId}")]
    public class CountryStats : StatsBase
    {
        /// <summary>
        /// Country Id.
        /// </summary>
        [DataMember, JsonProperty("country_id")]
        public int CountryId { get; set; }
    }

    /// <summary>
    /// Sex-age stats.
    /// </summary>
    [DataContract, DebuggerDisplay("SexAgeStats")]
    public class SexAgeStats : StatsBase
    {
        /// <summary>
        /// Age range.
        /// </summary>
        [DataMember, JsonProperty("age_range")]
        public string AgeRange { get; set; }

        /// <summary>
        /// Female count.
        /// </summary>
        [DataMember, JsonProperty("female")]
        public int Female { get; set; }

        /// <summary>
        /// Male count.
        /// </summary>
        [DataMember, JsonProperty("male")]
        public int Male { get; set; }
    }

    /// <summary>
    /// Stats.
    /// </summary>
    [DataContract, DebuggerDisplay("Stats")]
    public class Stats : StatsBase
    {
        /// <summary>
        /// Timestamp.
        /// </summary>
        [DataMember, JsonProperty("timestamp"), JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Sex-age stats.
        /// </summary>
        [DataMember, JsonProperty("sex_age")]
        public List<SexAgeStats> SegAge { get; set; }

        /// <summary>
        /// Countries stats.
        /// </summary>
        [DataMember, JsonProperty("countries")]
        public List<CountryStats> Countries { get; set; }

        /// <summary>
        /// Cities stats.
        /// </summary>
        [DataMember, JsonProperty("cities")]
        public List<CityStats> Cities { get; set; }
    }

    /// <summary>
    /// Short link stats
    /// </summary>
    [DataContract, DebuggerDisplay("LinkStats {Key}")]
    public class LinkStats
    {
        /// <summary>
        /// Short link key.
        /// </summary>
        [DataMember, JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Stats list.
        /// </summary>
        [DataMember, JsonProperty("stats")]
        public List<Stats> Stats { get; set; }
    }
}