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
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class BoardMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("board");
        }

        [Test]
        public async Task GetTopics()
        {
            var resp = await _inTouch.Board.GetTopics(new BoardGetTopicsParams { GroupId = 1, Count = 5 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 80, "resp.Data.Count == 80");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 21972158, "resp.Data.Items[0].Id == 21972158");
            IsNotNull(resp.Data.Items[0].Created, "resp.Data.Items[0].Created != null");
            IsTrue(resp.Data.Items[0].IsFixed, "resp.Data.Items[0].IsFixed");
            IsFalse(resp.Data.Items[0].IsClosed, "resp.Data.Items[0].IsClosed");
            IsTrue(resp.Data.Items[0].Comments == 20490, "resp.Data.Items[0].Comments == 20490");
        }

        [Test]
        public async Task GetComments()
        {
            var resp = await _inTouch.Board.GetComments(new BoardGetCommentsParams
            {
                TopicId = 147852,
                GroupId = 1,
                Count = 5
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles != null");
            Ex.TestComment(resp.Data.Items[0]);

            if (resp.Data.Items[0]?.Attachments?.First() is Photo)
            {
                Ex.TestPhotoAttachments((Photo) resp.Data.Items[0].Attachments.First());
            }

            if (resp.Data.Items[1]?.Attachments?.First() is Video)
            {
                Ex.TestVideoAttachment((Video) resp.Data.Items[1].Attachments.First());
            }

            if (resp.Data.Items[2]?.Attachments?.First() is Link)
            {
                Ex.TestLinkAttachment((Link) resp.Data.Items[2].Attachments.First());
            }
        }

        [Test]
        public async Task AddTopic()
        {
            var resp = await _inTouch.Board.AddTopic(1, "My Topic", attachments: new List<string>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task AddComment()
        {
            var resp = await _inTouch.Board.AddComment(new BoardAddCommentParams { GroupId = 1, TopicId = 147852 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task DeleteTopic()
        {
            var resp = await _inTouch.Board.DeleteTopic(1, 147852);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task EditTopic()
        {
            var resp = await _inTouch.Board.EditTopic(1, 147852, "New Topic Title");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task EditComment()
        {
            var resp = await _inTouch.Board.EditComment(1, 147852, 258963, attachments: new List<string>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RestoreComment()
        {
            var resp = await _inTouch.Board.RestoreComment(1, 147852, 258963);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteComment()
        {
            var resp = await _inTouch.Board.DeleteComment(1, 147852, 258963);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task OpenTopic()
        {
            var resp = await _inTouch.Board.OpenTopic(1, 147852);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task CloseTopic()
        {
            var resp = await _inTouch.Board.CloseTopic(1, 147852);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task FixTopic()
        {
            var resp = await _inTouch.Board.FixTopic(1, 147852);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task UnfixTopic()
        {
            var resp = await _inTouch.Board.UnfixTopic(1, 147852);

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
