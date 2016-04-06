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

namespace ModernDev.InTouch
{
    public abstract class BaseMarketAddEditParams : MethodParamsGroup
    {
        /// <summary>
        /// Identifier of an item owner community.
        /// </summary>
        [MethodParam(Name = "owner_id", IsRequired = true)]
        public int OwnerId { get; set; }

        /// <summary>
        /// Item name.
        /// </summary>
        [MethodParam(Name = "name", IsRequired = true)]
        public string Name { get; set; }

        /// <summary>
        /// Item description.
        /// </summary>
        [MethodParam(Name = "description", IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// Item category Id.
        /// </summary>
        [MethodParam(Name = "category_id", IsRequired = true)]
        public int CategoryId { get; set; }

        /// <summary>
        /// Item price.
        /// </summary>
        [MethodParam(Name = "price", IsRequired = true)]
        public double Price { get; set; }

        /// <summary>
        /// Item status (True - deleted, False - not deleted).
        /// </summary>
        [MethodParam(Name = "deleted", IsRequired = true)]
        public bool Deleted { get; set; }

        /// <summary>
        /// Cover photo identifier.
        /// </summary>
        [MethodParam(Name = "main_photo_id", IsRequired = true)]
        public int MainPhotoId { get; set; }

        /// <summary>
        /// Ids of additional photos.
        /// </summary>
        [MethodParam(Name = "photo_ids", IsRequired = false)]
        public List<int> PhotoIds { get; set; }
    }
}