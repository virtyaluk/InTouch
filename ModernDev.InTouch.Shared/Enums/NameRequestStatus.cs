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

using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Name request status.
    /// </summary>
    public enum NameRequestStatus
    {
        /// <summary>
        /// The request is processing now.
        /// </summary>
        [EnumMember(Value = "processing")]
        Processing,

        /// <summary>
        /// The process is declined.
        /// </summary>
        [EnumMember(Value = "declined")]
        Declined,

        /// <summary>
        /// The request is successfully accepted.
        /// </summary>
        [EnumMember(Value = "success")]
        Success,

        /// <summary>
        /// There was a successful request recently, new request can't be sent before the date from the <see cref="NameRequest.RepeatDate"/> field.
        /// </summary>
        [EnumMember(Value = "was_accepted")]
        WasAccepted,

        /// <summary>
        /// There was an unsuccessful request recently, new request can't be sent before the date from the <see cref="NameRequest.RepeatDate"/> field.
        /// </summary>
        [EnumMember(Value = "was_declined")]
        WasDeclined
    }
}