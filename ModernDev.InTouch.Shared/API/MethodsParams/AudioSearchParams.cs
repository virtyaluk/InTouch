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
    /// An <see cref="MessagesGetParams"/> class describes a <see cref="AudioMethods.Search"/> method params.
    /// </summary>
    public class AudioSearchParams : MethodParamsGroup
    {
        /// <summary>
        /// Search query string (e.g., The Beatles).
        /// </summary>
        [MethodParam(Name = "q")]
        public string Query { get; set; }

        /// <summary>
        /// True - to correct for mistakes in the search query (e.g., if you enter Beetles, the system will search for Beatles).
        /// </summary>
        [MethodParam(Name = "audo_complete")]
        public bool AutoComplete { get; set; }

        /// <summary>
        /// True - to return only audio files that have associated lyrics.
        /// </summary>
        [MethodParam(Name = "lyrics")]
        public bool Lyrics { get; set; }

        /// <summary>
        /// True - to search only by artist name.
        /// </summary>
        [MethodParam(Name = "performer_only")]
        public bool PerformerOnly { get; set; }

        /// <summary>
        /// Sort order: 
        /// 1 — by duration;
        /// 2 — by popularity;
        /// 0 — by date added.
        /// </summary>
        [MethodParam(Name = "sort")]
        public int Sort { get; set; } = 2;

        /// <summary>
        /// True - to search only user's audio files; False - to exclude user's audio files from search results.
        /// </summary>
        [MethodParam(Name = "search_own")]
        public bool SearchOwn { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of audio files.
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of audio files to return.
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 300})]
        public int Count { get; set; } = 30;
    }
}