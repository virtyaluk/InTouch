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

using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class NotesMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("notes");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Notes.Get();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestNote(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Notes.GetById(2244);

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestNote(resp.Data);
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Notes.Add("New note", "Note content");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Notes.Edit(2244, "New title", "New content");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Notes.Delete(2244);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetComments()
        {
            var resp = await _inTouch.Notes.GetComments(2244);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles != null");
            Ex.TestComment(resp.Data.Items[0]);

            if (resp.Data.Items[0]?.Attachments?.First() is Photo)
            {
                Ex.TestPhotoAttachments((Photo)resp.Data.Items[0].Attachments.First());
            }

            if (resp.Data.Items[1]?.Attachments?.First() is Video)
            {
                Ex.TestVideoAttachment((Video)resp.Data.Items[1].Attachments.First());
            }

            if (resp.Data.Items[2]?.Attachments?.First() is Link)
            {
                Ex.TestLinkAttachment((Link)resp.Data.Items[2].Attachments.First());
            }
        }

        [Test]
        public async Task CreateComment()
        {
            var resp = await _inTouch.Notes.CreateComment(2244, "Comment content");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task EditComment()
        {
            var resp = await _inTouch.Notes.EditComment(3366, "New comment content");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteComment()
        {
            var resp = await _inTouch.Notes.DeleteComment(3366);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RestoreComment()
        {
            var resp = await _inTouch.Notes.RestoreComment(3366);

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
