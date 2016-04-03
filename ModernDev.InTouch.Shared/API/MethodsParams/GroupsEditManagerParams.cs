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
    /// A <see cref="GroupsEditManagerParams"/> class describes a <see cref="GroupsMethods.EditManager"/> method params.
    /// </summary>
    public class GroupsEditManagerParams : MethodParamsGroup
    {
        /// <summary>
        /// Group Id.
        /// </summary>
        [MethodParam(Name = "group_id", IsRequired = true)]
        public int GroupId { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        [MethodParam(Name = "user_id", IsRequired = true)]
        public int UserId { get; set; }

        /// <summary>
        /// Role. Leave empty to remove any role from user with <c>user_id</c>
        /// </summary>
        [MethodParam(Name = "role")]
        public CommunityManagerRoles? Role { get; set; }

        /// <summary>
        /// If True, user will appears in community contacts block.
        /// </summary>
        [MethodParam(Name = "is_contact")]
        public bool IsContact { get; set; }

        /// <summary>
        /// User's role string representation in contacts block.
        /// </summary>
        [MethodParam(Name = "contact_position")]
        public string ContactPosition { get; set; }

        /// <summary>
        /// User's phone in contacts block.
        /// </summary>
        [MethodParam(Name = "contact_phone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// User's email in contacts block.
        /// </summary>
        [MethodParam(Name = "contact_email")]
        public string ContactEmail { get; set; }
    }
}