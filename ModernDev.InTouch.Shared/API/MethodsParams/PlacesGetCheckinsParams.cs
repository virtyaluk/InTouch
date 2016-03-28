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
    /// An <see cref="PlacesGetCheckinsParams"/> class describes a <see cref="PlacesMethods.GetCheckins"/> method params.
    /// </summary>
    public class PlacesGetCheckinsParams : MethodParamsGroup
    {
        /// <summary>
        /// Geographical latitude of the initial search point, in degrees (from -90 to 90).
        /// </summary>
        [MethodParam(Name = "latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Geographical longitude of the initial search point, in degrees (from -180 to 180).
        /// </summary>
        [MethodParam(Name = "longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Location ID of check-ins to return. (Ignored if latitude and longitude are specified.) 
        /// </summary>
        [MethodParam(Name = "place")]
        public int? PlaceId { get; set; }

        /// <summary>
        /// ID of the user whose check-ins will be returned. (Ignored if latitude and longitude are specified.) 
        /// </summary>
        [MethodParam(Name = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of check-ins. (Ignored if timestamp is not null.) 
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of check-ins to return. (Ignored if timestamp is not null.) 
        /// </summary>
        [MethodParam(Name = "count")]
        public int Count { get; set; } = 20;

        /// <summary>
        /// Specifies that only those check-ins created after the specified timestamp will be returned.
        /// </summary>
        [MethodParam(Name = "timestamp")]
        public int? Timestamp { get; set; }

        /// <summary>
        /// True - to return only check-ins with set geographical coordinates. (Ignored if latitude and longitude are not set.) 
        /// </summary>
        [MethodParam(Name = "friends_only")]
        public bool FriendsOnly { get; set; }

        /// <summary>
        /// True - to return location information with the check-ins. (Ignored if place is not set.) 
        /// </summary>
        [MethodParam(Name = "need_places")]
        public bool NeedPlaces { get; set; }
    }
}