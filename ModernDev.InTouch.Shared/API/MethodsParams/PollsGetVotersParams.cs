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
using System.Diagnostics;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="PollsGetVotersParams"/> class describes a <see cref="PollsMethods.GetVoters"/> method params.
    /// </summary>
    [DebuggerDisplay("PollsGetVotersParams")]
    public class PollsGetVotersParams : MethodParamsGroup
    {
        /// <summary>
        /// ID of the user or community that owns the poll. Use a negative value to designate a community ID. 
        /// </summary>
        [MethodParam(Name = "owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        /// Poll ID. 
        /// </summary>
        [MethodParam(Name = "poll_id", IsRequired = true)]
        public int PollId { get; set; }

        /// <summary>
        /// Answer IDs. 
        /// </summary>
        [MethodParam(Name = "answer_ids", IsRequired = true)]
        public List<int> AnswerIds { get; set; }

        /// <summary>
        /// True – poll is in a board, False – poll is on a wall. False by default. 
        /// </summary>
        [MethodParam(Name = "is_board")]
        public bool IsBoard { get; set; }

        /// <summary>
        /// True — to return only current user's friends; False — to return all users(default).
        /// </summary>
        [MethodParam(Name = "friends_only")]
        public bool FriendsOnly { get; set; }

        /// <summary>
        /// Offset needed to return a specific subset of voters. 0 — (default).
        /// </summary>
        [MethodParam(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Number of user IDs to return (if the <see cref="FriendsOnly"/> parameter is not set, maximum 1000; otherwise 10). 100 — (default) 
        /// </summary>
        [MethodParam(Name = "count", Extra = new[] { 0, 1000 })]
        public int Count { get; set; } = 100;

        /// <summary>
        /// Profile fields to return.
        /// </summary>
        [MethodParam(Name = "fields", IsRequired = true)]
        public List<UserProfileFields> Fields { get; set; } = new List<UserProfileFields> {UserProfileFields.Nickname};

        /// <summary>
        /// Case for declension of user name and surname.
        /// </summary>
        [MethodParam(Name = "name_case")]
        public NameCases NameCase { get; set; } = NameCases.Nominative;
    }
}