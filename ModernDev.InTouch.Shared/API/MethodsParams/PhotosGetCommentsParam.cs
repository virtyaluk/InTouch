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
using System.Linq;
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="PhotosGetCommentsParam"/> class describes a <see cref="PhotosMethods.GetComments"/> method params.
    /// </summary>
    public class PhotosGetCommentsParam : BaseGetCommentsParams
    {
        /// <summary>
        /// Photo ID. 
        /// </summary>
        [MethodParam(Name = "photo_id", IsRequired = true)]
        public int PhotoId { get; set; }

        /// <summary>
        /// Photo access key.
        /// </summary>
        [MethodParam(Name = "access_key")]
        public string AccessKey { get; set; }

        private List<string> _fields;

        /// <summary>
        /// The list of additional fields for the profiles and groups that need to be returned. The list can accept <see cref="UserProfileFields"/>, <see cref="GroupProfileFields"/> and regular string objects.
        /// </summary>
        [MethodParam(Name = "fields")]
        public List<object> Fields
        {
            get { return _fields?.Cast<object>().ToList(); }
            set
            {
                _fields = value?.Where(
                    el => el != null && (el is UserProfileFields || el is GroupProfileFields || el is string))
                    .Select(el => el is string ? (string)el : ToEnumString(el)).ToList();
            }
        }
    }
}