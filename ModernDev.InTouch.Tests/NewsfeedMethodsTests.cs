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
using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class NewsfeedMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("newsfeed");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Newsfeed.Get(new NewsfeedGetParams { Count = 3 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Date.Items");
            IsNotEmpty(resp.Data.NextFrom, "resp.Data.NextFrom");
            Ex.TestNewsPost(resp.Data.Items[0]);
            Ex.TestNewsPost2(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetRecommended()
        {
            var resp = await _inTouch.Newsfeed.GetRecommended(new NewsfeedGetRecommendedParams { Count = 3 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Date.Items");
            IsNotEmpty(resp.Data.NextFrom, "resp.Data.NextFrom");
            Ex.TestNewsPost(resp.Data.Items[0]);
            Ex.TestNewsPost2(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetComments()
        {
            var resp = await _inTouch.Newsfeed.GetComments(new NewsfeedGetCommentsParams { Count = 3 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Date.Items");
            IsNotEmpty(resp.Data.NextFrom, "resp.Data.NextFrom");
            Ex.TestNewsPost(resp.Data.Items[0]);
            Ex.TestNewsPost2(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetMentions()
        {
            var resp = await _inTouch.Newsfeed.GetMentions(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1127235, "resp.Data.Items[0].Id == 1127235");
            IsNotNull(resp.Data.Items[0].Date, "resp.Data.Items[0].Date != null");
            IsNotEmpty(resp.Data.Items[0].Text, "resp.Data.Items[0].Text");
            IsNotNull(resp.Data.Items[0].Likes);
            IsTrue(resp.Data.Items[0].Likes.Count == 0, "resp.Data.Items[0].Likes.Count == 0");
            IsFalse(resp.Data.Items[0].Likes.UserLikes, "resp.Data.Items[0].Likes.UserLikes");
        }

        [Test]
        public async Task GetBanned()
        {
            var resp = await _inTouch.Newsfeed.GetBanned();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles");
            Ex.TestUser(resp.Data.Profiles[0]);
            IsNotEmpty(resp.Data.Groups, "resp.Data.Groups");
            Ex.TestGroup(resp.Data.Groups[0]);
        }

        [Test]
        public async Task AddBan()
        {
            var resp = await _inTouch.Newsfeed.AddBan(new List<int> { 12345 }, new List<int>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteBan()
        {
            var resp = await _inTouch.Newsfeed.DeleteBan(new List<int> { 12345 }, new List<int>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task IgnoreItem()
        {
            var resp = await _inTouch.Newsfeed.IgnoreItem(NewsfeedIgnoreItemTypes.Audio, 12345, 5432);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task UnignoreItem()
        {
            var resp = await _inTouch.Newsfeed.UnignoreItem(NewsfeedIgnoreItemTypes.Audio, 12345, 54321);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Newsfeed.Search(new NewsfeedSearchParams { Query = "Test" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Date.Items");
            IsNotEmpty(resp.Data.NextFrom, "resp.Data.NextFrom");
            Ex.TestNewsPost(resp.Data.Items[0]);
            Ex.TestNewsPost2(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetLists()
        {
            var resp = await _inTouch.Newsfeed.GetLists();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1, "resp.Data.Items[0].Id == 1");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
            IsTrue(resp.Data.Items[0].NoReposts, "resp.Data.Items[0].NoReposts");
            IsNotEmpty(resp.Data.Items[0].SourceIds, "resp.Data.Items[0].SourceIds");
        }

        [Test]
        public async Task SaveList()
        {
            var resp = await _inTouch.Newsfeed.SaveList("New list");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task DeleteList()
        {
            var resp = await _inTouch.Newsfeed.DeleteList(6565);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Unsubscribe()
        {
            var resp = await _inTouch.Newsfeed.Unsubscribe(2323, NewsfeedCommentsFilters.Photo);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetSuggestedSources()
        {
            var resp = await _inTouch.Newsfeed.GetSuggestedSources(2);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsInstanceOf<User>(resp.Data.Items[0], "resp.Data.Items[0] instanceOf User");
            Ex.TestUser((User) resp.Data.Items[0]);
            IsInstanceOf<Group>(resp.Data.Items[1], "resp.Data.Items[1] instanceOf Group");
            Ex.TestGroup((Group) resp.Data.Items[1]);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
