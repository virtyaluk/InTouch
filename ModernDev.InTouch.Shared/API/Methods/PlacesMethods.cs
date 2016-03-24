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
using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for working with geographical places.
    /// </summary>
    public class PlacesMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PlacesMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public PlacesMethods(InTouch api) : base(api, "places") { }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new location to the location database.
        /// Created locations will be shown in search by locations only for the user who added it.
        /// </summary>
        /// <param name="title">Title of the location. </param>
        /// <param name="coords">Geographical coordinates.</param>
        /// <param name="typeId">ID of the location's type (e.g., 1 — Home, 2 — Work). To get location type IDs, use the <see cref="GetTypes"/> method.</param>
        /// <param name="countryId">ID of the location's country. To get country IDs, use the <see cref="DatabaseMethods.GetCountries(bool,string,int?,int)"/> method. </param>
        /// <param name="cityId">ID of the location's city. To get city IDs, use the <see cref="DatabaseMethods.GetCities"/> method.</param>
        /// <param name="address">Street address of the location (e.g., 125 Elm Street).</param>
        /// <returns>Returns the ID of the created location.</returns>
        public async Task<Response<int>> Add(string title, Coordinates coords, int? typeId = null, int? countryId = null,
            int? cityId = null, string address = null) => await Request<int>("add", new MethodParams
            {
                {"title", title, true},
                {"type", typeId},
                {"latitude", coords?.Latitude, true},
                {"longitude", coords?.Longitude, true},
                {"city", cityId},
                {"country", countryId},
                {"address", address}
            }, false, "id");

        /// <summary>
        /// Returns information about locations by their IDs.
        /// </summary>
        /// <param name="places">Location IDs. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Place"/> objects.</returns>
        public async Task<Response<List<Place>>> GetById(List<int> places)
            => await Request<List<Place>>("getById", new MethodParams
            {
                {"places", places, true}
            });

        /// <summary>
        /// Returns a list of locations that match the search criteria.
        /// Those locations added by website moderators and the current user are searched.Locations are sorted by increasing distance from the initial search point.
        /// </summary>
        /// <param name="coords">Geographical coordinates and radius.</param>
        /// <param name="query">Search query string.</param>
        /// <param name="cityId">City ID.</param>
        /// <param name="count">Number of locations to return.</param>
        /// <param name="offset">Offset needed to return a specific subset of locations.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Place"/> objects.</returns>
        public async Task<Response<ItemsList<Place>>> Search(Coordinates coords, string query = null, int? cityId = null,
            int count = 30, int offset = 0) => await Request<ItemsList<Place>>("search", new MethodParams
            {
                {"q", query},
                {"latitude", coords?.Latitude, true},
                {"longitude", coords?.Longitude, true},
                {"radius", coords?.Radius},
                {"city", cityId},
                {"count", count, false, new[] {0, 1000}},
                {"offset", offset}
            });

        /// <summary>
        /// Checks a user in at the specified location.
        /// </summary>
        /// <param name="placeId">Location ID. </param>
        /// <param name="coords">Geographical coordinates.</param>
        /// <param name="text">Text of the comment on the check-in (255 characters maximum; line breaks not supported). </param>
        /// <param name="friendsOnly">True - Check-in will be available only for friends. False — Check-in will be available for all users(default).</param>
        /// <param name="services">List of services or websites (e.g., twitter, facebook) to which the check-in will be exported, if the user has set up the respective option.</param>
        /// <returns></returns>
        public async Task<Response<int>> Checkin(int placeId, Coordinates coords = null, string text = null,
            bool friendsOnly = false, List<Services> services = null) => await Request<int>("checkin", new MethodParams
            {
                {"place_id", placeId, true},
                {"text", text?.Substring(0, 255)},
                {"latitude", coords?.Latitude},
                {"longitude", coords?.Longitude},
                {"friends_only", friendsOnly},
                {"services", services}
            });

        /// <summary>
        /// Returns a list of user check-ins at locations according to the set parameters.
        /// </summary>
        /// <param name="methodParams">A <see cref="PlacesGetCheckinsParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Checkin"/> objects.</returns>
        public async Task<Response<ItemsList<Checkin>>> GetCheckins(PlacesGetCheckinsParams methodParams)
            => await Request<ItemsList<Checkin>>("getCheckins", methodParams);

        /// <summary>
        /// Returns a list of all types of locations.
        /// </summary>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="PlaceType"/> objects.</returns>
        public async Task<Response<List<PlaceType>>> GetTypes() => await Request<List<PlaceType>>("getTypes");

        #endregion
    }
}