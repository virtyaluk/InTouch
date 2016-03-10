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
    /// An <see cref="University"/> class describes an university.
    /// </summary>
    [DebuggerDisplay("University {Name} {FacultyName}'{Graduation}")]
    [DataContract]
    public class University : TitledItem
    {
        /// <summary>
        /// ID of the country the university is located in.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public int CountryId { get; set; }

        /// <summary>
        /// ID of the city the university is located in.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public int CityId { get; set; }

        /// <summary>
        /// University name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Faculty ID.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty")]
        public int FacultyId { get; set; }

        /// <summary>
        /// Faculty name.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty_name")]
        public string FacultyName { get; set; }

        /// <summary>
        /// University chair ID.
        /// </summary>
        [DataMember]
        [JsonProperty("chair")]
        public int ChairId { get; set; }

        /// <summary>
        /// Chair name.
        /// </summary>
        [DataMember]
        [JsonProperty("chair_name")]
        public string ChairName { get; set; }

        /// <summary>
        /// Graduation year.
        /// </summary>
        [DataMember]
        [JsonProperty("graduation")]
        public int Graduation { get; set; }
    }
}