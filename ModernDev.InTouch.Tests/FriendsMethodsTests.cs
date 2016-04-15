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
    public class FriendsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("friends");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Friends.Get();

            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetOnline()
        {
            var resp = await _inTouch.Friends.GetOnline();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Online, "resp.Data.Online");
            IsNotEmpty(resp.Data.OnlineMobile, "resp.Data.OnlineMobile");
        }

        [Test]
        public async Task GetMutual()
        {
            var resp = await _inTouch.Friends.GetMutual(new List<int> { 12345 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 16133651, "resp.Data[0].Id == 16133651");
            IsNotEmpty(resp.Data[0].Friends, "resp.Data[0].Friends");
        }

        [Test]
        public async Task GetRecent()
        {
            var resp = await _inTouch.Friends.GetRecent(3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Contains(12345), "resp.Data.Contains(12345)");
        }

        [Test]
        public async Task GetRequests()
        {
            var resp = await _inTouch.Friends.GetRequests(3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsTrue(resp.Data.Items[0].UserId == 224586038, "resp.Data.Items[0].UserId == 224586038");
            IsTrue(resp.Data.Items[0].From == "178250508", "resp.Data.Items[0].From == '178250508'");
            IsNotNull(resp.Data.Items[0].Mutual, "resp.Data.Items[0].Mutual != null");
            IsTrue(resp.Data.Items[0].Mutual.Count == 1, "resp.Data.Items[0].Mutual.Count == 1");
            IsNotEmpty(resp.Data.Items[0].Mutual.Users, "resp.Data.Items[0].Mutual.Users");
            IsTrue(resp.Data.Items[0].Mutual.Users.Contains(178250508), "resp.Data.Items[0].Mutual.Users.Contains(178250508)");
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Friends.Add(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Friends.Edit(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Friends.Delete(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Success, "resp.Data.Success");
            IsTrue(resp.Data.FriendDeleted, "resp.Data.FriendDeleted");
        }

        [Test]
        public async Task GetLists()
        {
            var resp = await _inTouch.Friends.GetLists();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1, "resp.Data.Items[0].Id == 1");
            IsNotEmpty(resp.Data.Items[0].Name, "resp.Data.Items[0].Name");
        }

        [Test]
        public async Task AddList()
        {
            var resp = await _inTouch.Friends.AddList("New list");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 2, "resp.Data == 2");
        }

        [Test]
        public async Task EditList()
        {
            var resp = await _inTouch.Friends.EditList(546321);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteList()
        {
            var resp = await _inTouch.Friends.DeleteList(546321);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetAppUsers()
        {
            var resp = await _inTouch.Friends.GetAppUsers();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Contains(12345), "resp.Data.Contains(12345)");
        }

        [Test]
        public async Task GetByPhones()
        {
            var resp = await _inTouch.Friends.GetByPhones(new List<string> { "+1582555555" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[1], "resp.Data[1] != null");
            Ex.TestUser(resp.Data[1]);
        }

        [Test]
        public async Task DeleteAllRequests()
        {
            var resp = await _inTouch.Friends.DeleteAllRequests();

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetSuggestions()
        {
            var resp = await _inTouch.Friends.GetSuggestions();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task AreFriends()
        {
            var resp = await _inTouch.Friends.AreFriends(new List<int> { 12345 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].UserId == 66748, "resp.Data[0].UserId == 66748");
            IsNotEmpty(resp.Data[0].Sign, "resp.Data[0].Sign");
            IsTrue(resp.Data[0].Status == FriendshipStatuses.NotFriend, "resp.Data[0].Status == FriendshipStatuses.NotFriend");
        }

        [Test]
        public async Task GetAvailableForCall()
        {
            var resp = await _inTouch.Friends.GetAvailableForCall();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Friends.Search(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
