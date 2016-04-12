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
    public class PollsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("polls");
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Polls.GetById(54321, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            Ex.TestPoll(resp.Data);
        }

        [Test]
        public async Task AddVote()
        {
            var resp = await _inTouch.Polls.AddVote(12345, 54321);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteVote()
        {
            var resp = await _inTouch.Polls.DeleteVote(12345, 54321);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetVoters()
        {
            var resp = await _inTouch.Polls.GetVoters(new PollsGetVotersParams
            {
                PollId = 12345,
                OwnerId = 54321,
                AnswerIds = new List<int> {1, 2, 3}
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsTrue(resp.Data[0].AnswerId == 739946640, "resp.Data[0].AnswerId == 739946640");
            IsNotNull(resp.Data[0].Users, "resp.Data[0].Users != null");
            IsTrue(resp.Data[0].Users.Count == 1, "resp.Data[0].Users.Count == 1");
            IsNotNull(resp.Data[0].Users.Items, "resp.Data[0].Users.Items != null");
            IsNotEmpty(resp.Data[0].Users.Items, "resp.Data[0].Users.Items");
            IsTrue(resp.Data[0].Users.Items[0].Id == 16815310, "resp.Data[0].Users.Items[0].Id == 16815310");
            IsTrue(resp.Data[0].Users.Items[0].ScreenName == "virtyaluk", "resp.Data[0].Users.Items[0].ScreenName == 'virtyaluk'");
            IsTrue(resp.Data[2].AnswerId == 739946642, "resp.Data[2].AnswerId == 739946642");
            IsNotNull(resp.Data[2].Users, "resp.Data[2].Users != null");
            IsTrue(resp.Data[2].Users.Count == 0, "resp.Data[2].Users.Count == 0");
        }

        [Test]
        public async Task Create()
        {
            var resp = await _inTouch.Polls.Create("test", new List<string> {"foo", "bar", "baz"});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            Ex.TestPoll(resp.Data);
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Polls.Edit(12345, 54321, "Test");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
