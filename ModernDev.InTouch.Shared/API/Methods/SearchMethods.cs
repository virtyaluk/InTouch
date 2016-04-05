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
    /// Represents one method for performing fast hints search.
    /// </summary>
    public class SearchMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public SearchMethods(InTouch api) : base(api, "search") { }

        #endregion

        #region Methods

        /// <summary>
        /// Allows the programmer to do a quick search for any substring.
        /// </summary>
        /// <param name="query">Search query string.</param>
        /// <param name="limit">Maximum number of results to return.</param>
        /// <param name="filters">List of hints types to filter on.</param>
        /// <param name="searchGlobal">True - to perform search on all users and communities.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="SearchHintItem"/> objects.</returns>
        public async Task<Response<List<SearchHintItem>>> GetHints(string query = null, int limit = 10,
            List<SearchHintsFilters> filters = null, bool searchGlobal = true)
            => await Request<List<SearchHintItem>>("getHints", new MethodParams
            {
                {"q", query},
                {"limit", limit, false, new[] {0, 200}},
                {"filters", filters},
                {"search_global", searchGlobal}
            });

        #endregion
    }
}