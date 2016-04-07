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
    /// Describes an object that can be accepted as notification feedback.
    /// </summary>
    public interface IFeedback
    {
        /// <summary>
        /// The id of the wall's owner on which the post was published.
        /// </summary>
        int? ToId { get; set; }

        /// <summary>
        /// Feedback owner Id.
        /// </summary>
        int? FromId { get; set; }
    }
}