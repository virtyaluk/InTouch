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
    public class WallMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("wall");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Wall.Get(new WallGetParams
            {
                Count = 2
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Groups, "resp.Data.Groups");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles");
            Ex.TestWallPost(resp.Data.Items[0]);
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Wall.Search(new WallSearchParams
            {
                Count = 2,
                Query = "test"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Groups, "resp.Data.Groups");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles");
            Ex.TestWallPost(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Wall.GetById(new List<string> { "16815310_8226" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Groups, "resp.Data.Groups");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles");
            Ex.TestWallPost(resp.Data.Items[0]);
        }

        [Test]
        public async Task Post()
        {
            var resp = await _inTouch.Wall.Post(new WallPostParams
            {
                Message = "Test"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 1234, "resp.Data == 1234");
        }

        [Test]
        public async Task Repost()
        {
            var resp = await _inTouch.Wall.Repost("16815310_8226", "Repost");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Success, "resp.Data.Success");
            IsTrue(resp.Data.PostId == 1234, "resp.Data.PostId == 1234");
            IsTrue(resp.Data.LikesCount == 105, "resp.Data.LikesCount == 105");
        }

        [Test]
        public async Task GetReposts()
        {
            var resp = await _inTouch.Wall.GetReposts(8226);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Groups, "resp.Data.Groups");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles");
            Ex.TestWallPost(resp.Data.Items[0]);
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            IsNotEmpty(resp.Data.Items[1].CopyHistory, "resp.Data.Items[1].CopyHistory");
            IsTrue(resp.Data.Items[1].CopyHistory[0].SignerId == 18149923, "resp.Data.Items[1].CopyHistory[0].SignerId == 18149923");
            IsTrue(resp.Data.Items[1].CopyHistory[0].PostType == PostTypes.Post, "resp.Data.Items[1].CopyHistory[0].PostType == PostTypes.Post");

        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Wall.Edit(new WallEditParams
            {
                PostId = 8226,
                Message = "New title"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Wall.Delete(8226);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Restore()
        {
            var resp = await _inTouch.Wall.Restore(8226);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Pin()
        {
            var resp = await _inTouch.Wall.Pin(8226);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Unpin()
        {
            var resp = await _inTouch.Wall.Unpin(8226);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetComments()
        {
            var resp = await _inTouch.Wall.GetComments(new WallGetCommentsParam { PostId = 8226 });

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
        public async Task AddComment()
        {
            var resp = await _inTouch.Wall.AddComment(new WallAddCommentParams
            {
                PostId = 8226,
                Text = "comment"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 8227, "resp.Data == 8227");
        }

        [Test]
        public async Task EditComment()
        {
            var resp = await _inTouch.Wall.EditComment(124, attachments: new List<string>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteComment()
        {
            var resp = await _inTouch.Wall.DeleteComment(124);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RestoreComment()
        {
            var resp = await _inTouch.Wall.RestoreComment(124);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReportComment()
        {
            var resp = await _inTouch.Wall.ReportComment(124, 16815310, ReportReasonTypes.AbuseOrInsult);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Report()
        {
            var resp = await _inTouch.Wall.ReportPost(8226, 16815310, ReportReasonTypes.AbuseOrInsult);

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
