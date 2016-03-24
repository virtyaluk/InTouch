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
    /// Gift privacy levels.
    /// </summary>
    public enum GiftPrivacies
    {
        /// <summary>
        /// Everyone can see the sender's name and the message.
        /// </summary>
        Open = 0,

        /// <summary>
        /// Everybody can see the sender's name, but only the owner can see the message.
        /// </summary>
        Hidden = 1,

        /// <summary>
        /// The sender's name is hidden for everyone and only the owner can see the message.
        /// </summary>
        Anonymous = 2
    }
}