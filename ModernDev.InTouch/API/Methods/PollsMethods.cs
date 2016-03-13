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
using System.Linq;
using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for managing polls.
    /// </summary>
    public class PollsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PollsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public PollsMethods(InTouch api) : base(api, "polls") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns detailed information about a poll by its ID.
        /// </summary>
        /// <param name="pollId">Poll ID.</param>
        /// <param name="ownerId">ID of the user or community that owns the poll. Use a negative value to designate a community ID.</param>
        /// <param name="isBoard">True – poll is in a board, False – poll is on a wall. False by default. </param>
        /// <returns>Returns a <see cref="Poll"/> object.</returns>
        public async Task<Response<Poll>> GetById(int pollId, int? ownerId = null, bool isBoard = false)
            => await Request<Poll>("getById", new MethodParams
            {
                {"poll_id", pollId, true},
                {"owner_id", ownerId},
                {"is_board", isBoard}
            });

        /// <summary>
        /// Adds the current user's vote to the selected answer in the poll.
        /// </summary>
        /// <param name="pollId">Poll ID.</param>
        /// <param name="answerId">Answer ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the poll. Use a negative value to designate a community ID.</param>
        /// <param name="isBoard">True – poll is in a board, False – poll is on a wall. False by default. </param>
        /// <returns>Returns True if vote was added to the selected answer, or False if the user has already voted in this poll.</returns>
        public async Task<Response<bool>> AddVote(int pollId, int answerId, int? ownerId = null, bool isBoard = false)
            => await Request<bool>("addVote", new MethodParams
            {
                {"poll_id", pollId, true},
                {"answer_id", answerId, true},
                {"owner_id", ownerId},
                {"is_board", isBoard}
            });

        /// <summary>
        /// Deletes the current user's vote from the selected answer in the poll.
        /// </summary>
        /// <param name="pollId">Poll ID.</param>
        /// <param name="answerId">Answer ID. </param>
        /// <param name="ownerId">ID of the user or community that owns the poll. Use a negative value to designate a community ID.</param>
        /// <param name="isBoard">True – poll is in a board, False – poll is on a wall. False by default. </param>
        /// <returns>Returns True if vote was removed from the selected answer, or False if the user has not yet voted or the answer specified was not selected by the user.</returns>
        public async Task<Response<bool>> DeleteVote(int pollId, int answerId, int? ownerId = null, bool isBoard = false)
            => await Request<bool>("deleteVote", new MethodParams
            {
                {"poll_id", pollId, true},
                {"answer_id", answerId, true},
                {"owner_id", ownerId},
                {"is_board", isBoard}
            });

        /// <summary>
        /// Returns a list of IDs of users who selected specific answers in the poll.
        /// </summary>
        /// <param name="parameters">A <see cref="PollsGetVotersParams"/> object with the params.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="AnswerVoters"/> objects.</returns>
        public async Task<Response<List<AnswerVoters>>> GetVoters(PollsGetVotersParams parameters)
            => await Request<List<AnswerVoters>>("getVoters", parameters);

        /// <summary>
        /// Creates polls that can be attached to the users' or communities' posts.
        /// </summary>
        /// <param name="question">Question text.</param>
        /// <param name="answers">Answer ID. </param>
        /// <param name="isAnonymous"></param>
        /// <param name="ownerId">ID of the user or community that owns the poll. Use a negative value to designate a community ID.</param>
        /// <returns>If executed successfully, a <see cref="Poll"/> object is returned.</returns>
        public async Task<Response<Poll>> Create(string question, List<string> answers, bool isAnonymous = false,
            int? ownerId = null) => await Request<Poll>("create", new MethodParams
            {
                {"question", question},
                {"is_anonymous", isAnonymous},
                {"owner_id", ownerId},
                {
                    "add_answers",
                    $"[{string.Join(",", answers.Take(10).Where(a => !string.IsNullOrEmpty(a)).Select(a => $"\"{a}\""))}]",
                    true
                }
            });

        /// <summary>
        /// Edits created polls
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the poll. Use a negative value to designate a community ID.</param>
        /// <param name="pollId">Poll ID.</param>
        /// <param name="question">New question text.</param>
        /// <param name="addAnswers">Answers list.</param>
        /// <param name="editAnswers">
        /// Dictionary containing answers that need to be edited.
        /// key – answer id, value – new answer text.
        /// </param>
        /// <param name="deleteAnswers">List of answer ids to be deleted.</param>
        /// <returns>If successfully executed, returns True.</returns>
        public async Task<Response<bool>> Edit(int ownerId, int pollId, string question, List<string> addAnswers = null,
            Dictionary<int, string> editAnswers = null, List<int> deleteAnswers = null)
            => await Request<bool>("edit", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"poll_id", pollId, true},
                {"question", question},
                {
                    "add_answers",
                    $"[{string.Join(",", (addAnswers ?? new List<string>()).Take(10).Where(a => !string.IsNullOrEmpty(a)).Select(a => $"\"{a}\""))}]"
                },
                {
                    "edit_answers",
                    "{" + string.Join(",", (editAnswers ?? new Dictionary<int, string>())
                        .Where(kvp => kvp.Key >= 0 && !string.IsNullOrEmpty(kvp.Value))
                        .Select(kvp => $"\"{kvp.Key}\":\"{kvp.Value}\"")) + "}"
                },
                {"delete_answers", $"[{string.Join(",", deleteAnswers ?? new List<int>())}]"}
            });

        #endregion
    }
}