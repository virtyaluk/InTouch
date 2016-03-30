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
    /// An <see cref="PagesGetParams"/> class describes a <see cref="PagesMethods.Get"/> method params.
    /// </summary>
    public class PagesGetParams : MethodParamsGroup
    {
        /// <summary>
        /// Page owner ID.
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        /// Wiki page ID.
        /// </summary>
        [MethodParam(Name = "page_id")]
        public int? PageId { get; set; }

        /// <summary>
        /// True - to return information about a global wiki page.
        /// </summary>
        [MethodParam(Name = "global")]
        public bool Global { get; set; }

        /// <summary>
        /// True - resulting wiki page is a preview for the attached link.
        /// </summary>
        [MethodParam(Name = "site_preview")]
        public bool SitePreview { get; set; }

        /// <summary>
        /// Wiki page title.
        /// </summary>
        [MethodParam(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// True - to return the page content in wiki-format.
        /// </summary>
        [MethodParam(Name = "need_source")]
        public bool NeedSource { get; set; }

        /// <summary>
        /// True — to return the page as HTML
        /// </summary>
        [MethodParam(Name = "need_html")]
        public bool NeedHtml { get; set; }
    }
}