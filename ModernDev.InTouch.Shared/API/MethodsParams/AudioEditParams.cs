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
    /// An <see cref="AudioEditParams"/> class describes a <see cref="AudioMethods.Edit"/> method params.
    /// </summary>
    public class AudioEditParams : MethodParamsGroup
    {
        /// <summary>
        /// ID of the user or community that owns the audio file.
        /// </summary>
        [MethodParam(Name = "owner_id", IsRequired = true)]
        public int OwnerId { get; set; }

        /// <summary>
        /// Audio file ID. 
        /// </summary>
        [MethodParam(Name = "audio_id", IsRequired = true)]
        public int AudioId { get; set; }

        /// <summary>
        /// Name of the artist.
        /// </summary>
        [MethodParam(Name = "artist")]
        public string Artist { get; set; }

        /// <summary>
        /// Title of the audio file.
        /// </summary>
        [MethodParam(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Text of the lyrics of the audio file.
        /// </summary>
        [MethodParam(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Genre of the audio file. See the list of <see cref="AudioGenres"/>
        /// </summary>
        [MethodParam(Name = "genre_id")]
        public int Genre { get; set; } = (int) AudioGenres.Other;

        /// <summary>
        /// True — audio file will not be available for search; False — audio file will be available for search(default).
        /// </summary>
        [MethodParam(Name = "no_search")]
        public bool ExcludeFromSearch { get; set; }
    }
}