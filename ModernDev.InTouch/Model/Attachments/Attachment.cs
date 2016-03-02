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

using System.Diagnostics;
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("Attachment {Type}")]
    [APIVersion(Version = 5.45)]
    public class Attachment
    {
        /// <summary>
        /// The type of the attachment.
        /// </summary>
        public AttachmentTypes Type { get; } = AttachmentTypes.Unset;

        /// <summary>
        /// The attachment.
        /// </summary>
        public IMediaAttachment Media { get; set; }
    }
}