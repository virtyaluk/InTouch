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
    /// Community settings.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("CommunitySettings")]
    public class CommunitySettings
    {
        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DataMember]
        [JsonProperty("address")]
        public string Address { get; set; }

        [DataMember]
        [JsonProperty("place")]
        public Place Place { get; set; }

        [DataMember]
        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        [DataMember]
        [JsonProperty("city_id")]
        public int CityId { get; set; }

        [DataMember]
        [JsonProperty("wall")]
        public bool Wall { get; set; }

        [DataMember]
        [JsonProperty("photos")]
        public bool Photos { get; set; }

        [DataMember]
        [JsonProperty("video")]
        public bool Video { get; set; }

        [DataMember]
        [JsonProperty("audio")]
        public bool Audio { get; set; }

        [DataMember]
        [JsonProperty("docs")]
        public bool Docs { get; set; }

        [DataMember]
        [JsonProperty("topics")]
        public bool Topics { get; set; }

        [DataMember]
        [JsonProperty("wiki")]
        public bool Wiki { get; set; }

        [DataMember]
        [JsonProperty("public_date")]
        public string PublicData { get; set; }

        [DataMember]
        [JsonProperty("public_date_label")]
        public string PublicDateLabel { get; set; }

        [DataMember]
        [JsonProperty("public_category")]
        public string PublicCategory { get; set; }

        [DataMember]
        [JsonProperty("public_subcategory")]
        public string PublicSubcategory { get; set; }

        [DataMember]
        [JsonProperty("contacts")]
        public bool Contacts { get; set; }

        [DataMember]
        [JsonProperty("links")]
        public bool Links { get; set; }

        [DataMember]
        [JsonProperty("events")]
        public bool Events { get; set; }

        [DataMember]
        [JsonProperty("places")]
        public bool Places { get; set; }

        [DataMember]
        [JsonProperty("website")]
        public string Website { get; set; }
    }
}