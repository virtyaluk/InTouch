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
    /// A <see cref="School"/> class represents a school.
    /// </summary>
    [DebuggerDisplay("School {Name} {YearGraduated}")]
    [DataContract]
    public class School : TitledItem
    {
        /// <summary>
        /// ID of the country the school is located in.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public int CountryId { get; set; }

        /// <summary>
        /// ID of the city the school is located in.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public int CityId { get; set; }

        /// <summary>
        /// School name.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Year the user started to study.
        /// </summary>
        [DataMember]
        [JsonProperty("year_from")]
        public int YearFrom { get; set; }

        /// <summary>
        /// Year the user finished to study.
        /// </summary>
        [DataMember]
        [JsonProperty("year_to")]
        public int YearTo { get; set; }

        /// <summary>
        /// Graduation year.
        /// </summary>
        [DataMember]
        [JsonProperty("year_graduated")]
        public int YearGraduated { get; set; }

        /// <summary>
        /// School class letter.
        /// </summary>
        [DataMember]
        [JsonProperty("class")]
        public string Class { get; set; }

        /// <summary>
        /// Speciality.
        /// </summary>
        [DataMember]
        [JsonProperty("speciality")]
        public string Speciality { get; set; }

        /// <summary>
        /// Type ID.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        public int TypeId { get; set; }

        /// <summary>
        /// Type name. 
        /// </summary>
        [DataMember]
        [JsonProperty("type_str")]
        public string Type { get; set; }
    }
}