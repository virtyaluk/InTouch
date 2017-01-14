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
    /// An <see cref="IMessageAttachment"/> is a base interface for all kind of message attachments.
    /// </summary>
    public interface IMessageAttachment
    {
        /// <summary>
        /// Message ID the attachment is attached to.
        /// </summary>
        int? MessageId { get; set; }
    }
}