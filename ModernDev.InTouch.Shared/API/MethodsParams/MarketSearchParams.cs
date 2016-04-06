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
    /// <summary>
    /// A <see cref="MarketSearchParams"/> class describes a <see cref="MarketMethods.Search"/> method params.
    /// </summary>
    public class MarketSearchParams : MethodParamsGroup
    {
        /// <summary>
        /// Identifier of an items owner community.
        /// </summary>
        [MethodParam(Name = "owner_id", IsRequired = true)]
        public int OwnerId { get; set; }

        /// <summary>
        /// Identifier of a collection to return items from.
        /// </summary>
        [MethodParam(Name = "album_id", IsRequired = false)]
        public int? AlbumId { get; set; }

        /// <summary>
        /// Search query, for example "pink slippers".
        /// </summary>
        [MethodParam(Name = "q", IsRequired = false)]
        public string Query { get; set; }

        /// <summary>
        /// Minimum item price value. For example "100".
        /// </summary>
        [MethodParam(Name = "price_from", IsRequired = false)]
        public int? PriceFrom { get; set; }

        /// <summary>
        /// Maximum item price value. For example "14100".
        /// </summary>
        [MethodParam(Name = "price_to", IsRequired = false)]
        public int? PriceTo { get; set; }

        /// <summary>
        /// Tag ids list.
        /// </summary>
        [MethodParam(Name = "tags", IsRequired = false)]
        public List<int> Tags { get; set; }

        /// <summary>
        /// Sorting. 0 - user defined, 1 - by date added, 2 - by price, 3 - by popularity.
        /// </summary>
        [MethodParam(Name = "sort", IsRequired = false)]
        public int Sort { get; set; } = 0;

        /// <summary>
        /// False - do not use reverse order, True - use reverse order.
        /// </summary>
        [MethodParam(Name = "rev", IsRequired = false)]
        public bool Rev { get; set; }

        /// <summary>
        /// Offset based on a first matching item to get a certain items subset.
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] {0, 200}, IsRequired = false)]
        public int Count { get; set; } = 20;

        /// <summary>
        /// Number of items to return.
        /// </summary>
        [MethodParam(Name = "offset", IsRequired = false)]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// True - method will return additional fields. These parameters are not returned by default.
        /// </summary>
        [MethodParam(Name = "extended", IsRequired = false)]
        public bool Extended { get; set; }
    }
}