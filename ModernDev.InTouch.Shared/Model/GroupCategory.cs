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
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Group market category.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("GroupCategory")]
    public class GroupCategory : BaseCategory
    {
        /// <summary>
        /// Number of communities in a category.
        /// </summary>
        [DataMember]
        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        /// <summary>
        /// A <see cref="List{T}"/> of <see cref="Group"/> objects for preview.
        /// </summary>
        [DataMember]
        [JsonProperty("page_previews")]
        public List<Group> PagePreviews { get; set; }

        /// <summary>
        /// Subcategories.
        /// </summary>
        [DataMember]
        [JsonProperty("subcategories")]
        public List<GroupCategory> SubCategories { get; set; }
    }
}