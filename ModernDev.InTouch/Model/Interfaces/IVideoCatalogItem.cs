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
    /// Describes common state of <see cref="Video" /> and <see cref="VideoAlbum"/> objects.
    /// </summary>
    public interface IVideoCatalogItem
    {
        int Id { get; set; }
        int OwnerId { get; set; }
        string Title { get; set; }
        VideoCatalogItemTypes Type { get; set; }
    }
}