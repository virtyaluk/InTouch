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

using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for VK utilities.
    /// </summary>
    public class UtilsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal UtilsMethods(InTouch api) : base(api, "utils") { }

        #endregion

        #region Methods

        /// <summary>
        /// Checks whether a link is blocked in VK.
        /// </summary>
        /// <param name="link">Link to check</param>
        /// <returns>Returns a <see cref="LinkStatus"/> object.</returns>
        public async Task<Response<LinkStatus>> CheckLink(string link)
            => await Request<LinkStatus>("checkLink", new MethodParams {{"link", link, true}}, true);

        /// <summary>
        /// Detects a type of object (e.g., user, community, application) and its ID by screen name.
        /// </summary>
        /// <param name="screenName">Screen name of the user, community (e.g., apiclub, virtyaluk, or rules_of_war), or application. </param>
        /// <returns>Returns a <see cref="ObjectInfo"/> object.</returns>
        public async Task<Response<ObjectInfo>> ResolveScreenName(string screenName)
            => await Request<ObjectInfo>("resolveScreenName", new MethodParams
            {
                {"screen_name", screenName, true}
            }, true);

        /// <summary>
        /// Returns the current time of the VK server.
        /// </summary>
        /// <returns>Returns the current time (in Unix time).</returns>
        public async Task<Response<int>> GetServerTime()
            => await Request<int>("getServerTime", new MethodParams(), true);

        /// <summary>
        /// Allows to receive a link shortened via vk.cc.
        /// </summary>
        /// <param name="url">URL to be shortened.</param>
        /// <returns>Returns an object containing shortened URL.</returns>
        public async Task<Response<string>> GetShortLink(string url)
            => await Request<string>("getShortLink", new MethodParams
            {
                {"url", url}
            }, false, "short_url");

        /// <summary>
        /// Returns stats data for shortened link.
        /// </summary>
        /// <param name="key">Part of the link after "vk.cc/".</param>
        /// <param name="interval">Interval.</param>
        /// <param name="intervalsCount">Number of intervals to return.</param>
        /// <param name="extended">True (default) — to return extended stats data (sex, age, geo). False — to return views number only. </param>
        /// <returns>
        /// Returns <see cref="LinkStats"/> object which contains <see cref="LinkStats.Key"/> field with key value and <see cref="LinkStats.Stats"/> list with the stats data.
        /// Each object in stats contains <see cref="Stats.Timestamp"/> field with the start time, <see cref="StatsBase.Views"/> field with total views number, and stats lists: <see cref="SexAgeStats"/>, <see cref="CountryStats"/>, <see cref="CityStats"/>.
        /// </returns>
        public async Task<Response<LinkStats>> GetLinkStats(string key,
            LinkStatsInterval interval = LinkStatsInterval.Day, int intervalsCount = 100, bool extended = true)
            => await Request<LinkStats>("getLinkStats", new MethodParams
            {
                {"key", key},
                {"interval", interval},
                {"intervals_count", intervalsCount},
                {"extended", extended}
            });

        #endregion
    }
}