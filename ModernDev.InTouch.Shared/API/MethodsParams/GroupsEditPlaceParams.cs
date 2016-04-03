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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="GroupsEditPlaceParams"/> class describes a <see cref="GroupsMethods.EditPlace"/> method params.
    /// </summary>
    public class GroupsEditPlaceParams : MethodParamsGroup
    {
        /// <summary>
        /// Id of the group to edit place.
        /// </summary>
        [MethodParam(Name = "group_id", IsRequired = true)]
        public int GroupId { get; set; }

        /// <summary>
        /// Place title.
        /// </summary>
        [MethodParam(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Place address.
        /// </summary>
        [MethodParam(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Place country Id. Can be obtained using <see cref="DatabaseMethods.GetCountries(bool,string,System.Nullable{int},int)"/>
        /// </summary>
        [MethodParam(Name = "country_id")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Place city Id. Can be obtained using <see cref="DatabaseMethods.GetCities"/>
        /// </summary>
        [MethodParam(Name = "city_id")]
        public int? CityId { get; set; }

        /// <summary>
        /// Place geo latitude in degrees.
        /// </summary>
        [MethodParam(Name = "latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Place geo longitude in degrees.
        /// </summary>
        [MethodParam(Name = "longitude")]
        public double Longitude { get; set; }
    }
}