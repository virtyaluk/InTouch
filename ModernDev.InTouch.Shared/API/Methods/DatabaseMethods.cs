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
    /// Provides a base class for retrieving VK open data.
    /// </summary>
    public class DatabaseMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public DatabaseMethods(InTouch api) : base(api, "database") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a list of countries.
        /// </summary>
        /// <param name="needAll">True — to return a full list of all countries; False — to return a list of countries near the current user's country (default) </param>
        /// <param name="code">Country codes in <a href="https://vk.com/dev/country_codes">ISO 3166-1 alpha-2</a> standard separated by comma.</param>
        /// <param name="offset">Offset needed to return a specific subset of countries.</param>
        /// <param name="count">Number of countries to return. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Country"/> objects.</returns>
        public async Task<Response<ItemsList<Country>>> GetCountries(bool needAll = false, string code = null,
            int? count = null, int offset = 100)
            => await Request<ItemsList<Country>>("getCountries", new MethodParams
            {
                {"need_all", needAll},
                {"code", code},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Returns a list of countries.
        /// </summary>
        /// <param name="needAll">True — to return a full list of all countries; False — to return a list of countries near the current user's country (default) </param>
        /// <param name="codes">A <see cref="List{T}"/> of country codes in <a href="https://vk.com/dev/country_codes">ISO 3166-1 alpha-2</a> standard.</param>
        /// <param name="offset">Offset needed to return a specific subset of countries.</param>
        /// <param name="count">Number of countries to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Country"/> objects.</returns>
        public async Task<Response<ItemsList<Country>>> GetCountries(bool needAll = false, List<string> codes = null,
            int? count = null, int offset = 100)
            => await GetCountries(needAll, string.Join(",", codes ?? new List<string>()), count, offset);

        /// <summary>
        /// Returns a list of regions.
        /// </summary>
        /// <param name="countryId">Country ID, received in <see cref="GetCountries(bool,string,System.Nullable{int},int)"/> method.</param>
        /// <param name="q">Search query.</param>
        /// <param name="count">Number of regions to return.</param>
        /// <param name="offset">Offset needed to return specific subset of regions. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Region"/> objects.</returns>
        public async Task<Response<ItemsList<Region>>> GetRegions(int countryId, string q = null, int? offset = null,
            int? count = 100) => await Request<ItemsList<Region>>("getRegions", new MethodParams
            {
                {"country_id", countryId, true},
                {"q", q},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Returns information about streets by their IDs.
        /// </summary>
        /// <param name="streetIds">Street IDs.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Street"/> objects</returns>
        public async Task<Response<ItemsList<Street>>> GetStreetsById(List<int> streetIds)
            => await Request<ItemsList<Street>>("getStreetsById", new MethodParams
            {
                {"street_ids", streetIds, true, 1000}
            }, true);

        /// <summary>
        /// Returns information about countries by their IDs.
        /// </summary>
        /// <param name="countryIds">Country IDs. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Country"/> objects.</returns>
        public async Task<Response<ItemsList<Country>>> GetCountriesById(List<int> countryIds)
            => await Request<ItemsList<Country>>("getCountriesById", new MethodParams
            {
                {"country_ids", countryIds, true, 1000}
            }, true);

        /// <summary>
        /// Returns a list of cities.
        /// </summary>
        /// <param name="countryId">Country ID. </param>
        /// <param name="regionId">Region ID. </param>
        /// <param name="q">Search query.</param>
        /// <param name="needAll">True — to return all cities in the country, False — to return major cities in the country(default)</param>
        /// <param name="offset">Offset needed to return a specific subset of cities.</param>
        /// <param name="count">Number of cities to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="City"/> objects.</returns>
        public async Task<Response<ItemsList<City>>> GetCities(int countryId, int? regionId = null, string q = null,
            bool needAll = false, int? offset = null, int count = 100)
            => await Request<ItemsList<City>>("getCities", new MethodParams
            {
                {"country_id", countryId, true},
                {"region_id", regionId},
                {"q", q},
                {"need_all", needAll},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Returns information about cities by their IDs.
        /// </summary>
        /// <param name="cityIds">City IDs. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="City"/> objects</returns>
        public async Task<Response<ItemsList<City>>> GetCitiesById(List<int> cityIds)
            => await Request<ItemsList<City>>("getCitiesById", new MethodParams
            {
                {"cityIds", cityIds, true, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Returns a list of higher education institutions.
        /// </summary>
        /// <param name="q">Search query.</param>
        /// <param name="countryId">Country ID. </param>
        /// <param name="cityId">City ID. </param>
        /// <param name="offset">Offset needed to return a specific subset of universities.</param>
        /// <param name="count">Number of universities to return.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="University"/> objects</returns>
        public async Task<Response<ItemsList<University>>> GetUniversities(string q = null, int? countryId = null,
            int? cityId = null, int? offset = null, int count = 100)
            => await Request<ItemsList<University>>("getUniversities", new MethodParams
            {
                {"q", q},
                {"country_id", countryId},
                {"city_id", cityId},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Returns a list of schools.
        /// </summary>
        /// <param name="cityId">City ID. </param>
        /// <param name="q">Search query.</param>
        /// <param name="offset">Offset needed to return a specific subset of schools.</param>
        /// <param name="count">Number of schools to return. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="School"/> objects.</returns>
        public async Task<Response<ItemsList<School>>> GetSchools(int cityId, string q = null, int? offset = null,
            int count = 100) => await Request<ItemsList<School>>("getSchools", new MethodParams
            {
                {"city_id", cityId, true},
                {"q", q},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Returns a list of faculties (i.e., university departments). 
        /// </summary>
        /// <param name="universityId">University ID. </param>
        /// <param name="offset">Offset needed to return a specific subset of faculties.</param>
        /// <param name="count">Number of faculties to return. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Faculty"/> objects.</returns>
        public async Task<Response<ItemsList<Faculty>>> GetFaculties(int universityId, int? offset = null,
            int count = 100) => await Request<ItemsList<Faculty>>("getFaculties", new MethodParams
            {
                {"university_id", universityId, true},
                {"offset", offset},
                {"count", count, false, new[] {0, 1000}}
            }, true);

        /// <summary>
        /// Returns list of chairs on a specified faculty.
        /// </summary>
        /// <param name="facultyId">Id of the faculty to get chairs from.</param>
        /// <param name="offset">Offset required to get a certain subset of chairs.</param>
        /// <param name="count">Amount of chairs to get.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="FacultyChair"/> objects.</returns>
        public async Task<Response<ItemsList<FacultyChair>>> GetChairs(int facultyId, int? offset = null,
            int count = 100) => await Request<ItemsList<FacultyChair>>("getChairs", new MethodParams
            {
                {"faculty_id", facultyId, true},
                {"offset", offset},
                {"count", count, false, new[] {0, 10000}}
            }, true);

        #endregion
    }
}