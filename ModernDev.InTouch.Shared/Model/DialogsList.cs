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
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Dialogs list.
    /// </summary>
    [DebuggerDisplay("DialogsList")]
    [DataContract]
    public class DialogsList : ItemsList<Dialog>
    {
        /// <summary>
        /// The real offset.
        /// </summary>
        [DataMember]
        [JsonProperty("real_offset")]
        public int RealOffset { get; set; }

        /// <summary>
        /// The number of unread dialogs.
        /// </summary>
        [DataMember]
        [JsonProperty("unread_dialogs")]
        public int UnreadDialogs { get; set; }
    }
}