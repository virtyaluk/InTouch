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
    /// An <see cref="IMediaAttachment"/> is a base interface for all kind of attachments.
    /// </summary>
    public interface IMediaAttachment
    {
        /// <summary>
        /// Item owner Id.
        /// </summary>
        int OwnerId { get; set; }
    }
}