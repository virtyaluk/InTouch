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
    /// A base class for working with wiki-pages.
    /// </summary>
    public class PagesMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PagesMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        internal PagesMethods(InTouch api) : base(api, "pages") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns information about a wiki page.
        /// </summary>
        /// <param name="methodParams">A <see cref="PagesGetParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="Page"/> object.</returns>
        public async Task<Response<Page>> Get(PagesGetParams methodParams) => await Request<Page>("get", methodParams);

        /// <summary>
        /// Saves the text of a wiki page.
        /// </summary>
        /// <param name="title">Wiki page title.</param>
        /// <param name="text">Text of the wiki page in wiki-format.</param>
        /// <param name="pageId">Wiki page ID. The <c>title</c> parameter can be passed instead of <c>pageId</c>.</param>
        /// <param name="groupId">ID of the community that owns the wiki page.</param>
        /// <param name="userId">ID of the user that owns the wiki page.</param>
        /// <returns>Returns the ID of the created wiki page.</returns>
        public async Task<Response<int>> Save(string title, string text = null, int? pageId = null, int? groupId = null,
            int? userId = null) => await Request<int>("save", new MethodParams
            {
                {"title", title, true},
                {"text", text},
                {"page_id", pageId},
                {"group_id", groupId},
                {"user_id", userId}
            });

        /// <summary>
        /// Saves modified read and edit access settings for a wiki page.
        /// </summary>
        /// <param name="pageId">Wiki page ID.</param>
        /// <param name="groupId">ID of the community that owns the wiki page.</param>
        /// <param name="userId">ID of the user that owns the wiki page.</param>
        /// <param name="view">Who can view the wiki page.</param>
        /// <param name="edit">Who can edit the wiki page.</param>
        /// <returns>Returns the ID of the edited wiki page.</returns>
        public async Task<Response<int>> SaveAccess(int pageId, int? groupId = null, int? userId = null,
            CommunityAccessTypes view = CommunityAccessTypes.Everyone,
            CommunityAccessTypes edit = CommunityAccessTypes.ManagersOnly)
            => await Request<int>("saveAccess", new MethodParams
            {
                {"page_id", pageId},
                {"group_id", groupId},
                {"user_id", userId},
                {"view", (int) view},
                {"edit", (int) edit}
            });

        /// <summary>
        /// Returns a list of all previous versions of a wiki page.
        /// </summary>
        /// <param name="pageId">Wiki page ID.</param>
        /// <param name="groupId">ID of the community that owns the wiki page.</param>
        /// <param name="userId">ID of the user that owns the wiki page.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="PageVersion"/> objects.</returns>
        public async Task<Response<List<PageVersion>>> GetHistory(int pageId, int? groupId = null, int? userId = null)
            => await Request<List<PageVersion>>("getHistory", new MethodParams
            {
                {"page_id", pageId, true},
                {"group_id", groupId},
                {"user_id", userId}
            });

        /// <summary>
        /// Returns a list of wiki pages in a group.
        /// </summary>
        /// <param name="groupId">ID of the community that owns the wiki page.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Page"/> objects.</returns>
        public async Task<Response<List<Page>>> GetTitles(int? groupId = null)
            => await Request<List<Page>>("getTitles", new MethodParams
            {
                {"group_id", groupId}
            });

        /// <summary>
        /// Returns the text of one of the previous versions of a wiki page.
        /// </summary>
        /// <param name="versionId">Id of the page version,</param>
        /// <param name="groupId">ID of the community that owns the wiki page.</param>
        /// <param name="userId">ID of the user that owns the wiki page.</param>
        /// <param name="needHtml">True — to return the page as HTML.</param>
        /// <returns>Returns a <see cref="Page"/> object.</returns>
        public async Task<Response<Page>> GetVersion(int versionId, int? groupId = null, int? userId = null,
            bool needHtml = false) => await Request<Page>("getVersion", new MethodParams
            {
                {"version_id", versionId, true},
                {"group_id", groupId},
                {"user_id", userId},
                {"need_html", needHtml}
            });

        /// <summary>
        /// Returns HTML representation of the wiki markup.
        /// </summary>
        /// <param name="text">Text of the wiki page in wiki-format.</param>
        /// <param name="groupId">ID of the community that owns the wiki page.</param>
        /// <returns>Returns escaped HTML code corresponding to the wiki markup.</returns>
        public async Task<Response<string>> ParseWiki(string text, int? groupId = null)
            => await Request<string>("parseWiki", new MethodParams
            {
                {"text", text, true},
                {"group_id", groupId}
            });

        /// <summary>
        /// Allows to clear the cache of particular external pages which may be attached to VK posts.
        /// After clearing the cache while attaching a link to a post, page data will be refreshed.
        /// External pages are the pages attached to posts with the links and accessible with "Preview" button.
        /// </summary>
        /// <param name="url">Address of the page where you need to refresh the cached version </param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> ClearCache(string url) => await Request<bool>("clearCache",
            new MethodParams
            {
                {"url", url, true}
            }, true);

        #endregion
    }
}