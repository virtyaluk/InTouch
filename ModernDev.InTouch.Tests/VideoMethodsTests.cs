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
    public class VideoMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("video");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Videos.Get();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestVideo(resp.Data.Items[1]);
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Videos.Edit(new VideoEditParams { VideoId = 9 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Videos.Add(9, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Save()
        {
            var resp = await _inTouch.Videos.Save(new VideoSaveParams());

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.VideoId == 456239067, "resp.Data.VideoId == 456239067");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Videos.Delete(9);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Restore()
        {
            var resp = await _inTouch.Videos.Restore(9);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Videos.Search(new VideoSearchParams { Query = "Mr. Robot" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestVideo(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetUserVideos()
        {
            var resp = await _inTouch.Videos.GetUserVideos();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestVideo(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetAlbums()
        {
            var resp = await _inTouch.Videos.GetAlbums();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestVideoAlbum(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetAlbumById()
        {
            var resp = await _inTouch.Videos.GetAlbumById(1);

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestVideoAlbum(resp.Data);
        }

        [Test]
        public async Task AddAlbum()
        {
            var resp = await _inTouch.Videos.AddAlbum("New Album");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 1234, "resp.Data == 1234");
        }

        [Test]
        public async Task EditAlbum()
        {
            var resp = await _inTouch.Videos.EditAlbum(1, "New album title");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteAlbum()
        {
            var resp = await _inTouch.Videos.DeleteAlbum(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReorderAlbums()
        {
            var resp = await _inTouch.Videos.ReorderAlbums(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReorderVideos()
        {
            var resp = await _inTouch.Videos.ReorderVideos(new VideoReorderVideosParams { OwnerId = 12345, VideoId = 9 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task AddToAlbum()
        {
            var resp = await _inTouch.Videos.AddToAlbum(9, 12345, 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveFromAlbum()
        {
            var resp = await _inTouch.Videos.RemoveFromAlbum(1, 12345, 9);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetAlbumsByVideo()
        {
            var resp = await _inTouch.Videos.GetAlbumsByVideo(9, 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestVideoAlbum(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetComments()
        {
            var resp = await _inTouch.Videos.GetComments(new VideoGetCommentsParams
            {
                VideoId = 9
            });

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
            var resp = await _inTouch.Videos.CreateComment(new VideoCreateCommentParams
            {
                VideoId = 9,
                Message = "text"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task DeleteComment()
        {
            var resp = await _inTouch.Videos.DeleteComment(5);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RestoreComment()
        {
            var resp = await _inTouch.Videos.RestoreComment(5);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task EditComment()
        {
            var resp = await _inTouch.Videos.EditComment(5, attachments: new List<string>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetTags()
        {
            var resp = await _inTouch.Videos.GetTags(9);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].UserId == 9594917, "resp.Data[0].UserId == 9594917");
            IsNotEmpty(resp.Data[0].TaggedName, "resp.Data[0].TaggedName");
            IsNotNull(resp.Data[0].Date, "resp.Data[0].Date != null");
            IsTrue(resp.Data[0].Viewed, "resp.Data[0].Viewed");
        }

        [Test]
        public async Task PutTag()
        {
            var resp = await _inTouch.Videos.PutTag(9, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveTag()
        {
            var resp = await _inTouch.Videos.RemoveTag(9, 7);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetNewTags()
        {
            var resp = await _inTouch.Videos.GetNewTags(2);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestVideo(resp.Data.Items[1]);
        }

        [Test]
        public async Task Report()
        {
            var resp = await _inTouch.Videos.Report(9, 12345, ReportTypes.Spam);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReportComment()
        {
            var resp = await _inTouch.Videos.ReportComment(5, 12345, ReportTypes.Spam);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetCatalog()
        {
            var resp = await _inTouch.Videos.GetCatalog(2, 2);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Next, "resp.Data.Next");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == "-25988584", "resp.Data.Items[0].Id == '-25988584'");
            IsTrue(resp.Data.Items[0].CanHide, "resp.Data.Items[0].CanHide");
            IsTrue(resp.Data.Items[0].Type == VideoCatalogBlockTypes.Channel, "resp.Data.Items[0].Type == VideoCatalogBlockTypes.Channel");
            IsNotEmpty(resp.Data.Items[0].Next, "resp.Data.Items[0].Next");
            IsNotEmpty(resp.Data.Items[0].Items, "resp.Data.Items[0].Items");
            IsNotNull(resp.Data.Items[0].Items[0], "resp.Data.Items[0].Items[0] != null");
            IsInstanceOf<Video>(resp.Data.Items[0].Items[0], "resp.Data.Items[0].Items[0] instanceOf Video");
            IsTrue(resp.Data.Items[0].Items[0].Id == 456239073, "resp.Data.Items[0].Items[0].Id == 456239073");
            IsTrue(((Video)resp.Data.Items[0].Items[0]).CanAdd, "((Video)resp.Data.Items[0].Items[0]).CanAdd");
        }

        [Test]
        public async Task GetCatalogSection()
        {
            var resp = await _inTouch.Videos.GetCatalogSection("some_section", "prev_next", 2, true);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsInstanceOf<VideoAlbum>(resp.Data.Items[0], "resp.Data.Items[0] instanceOf VideoAlbum");
            IsTrue(((VideoAlbum) resp.Data.Items[0]).Id == 38887239, "((VideoAlbum) resp.Data.Items[0]).Id == 38887239");
            IsNotEmpty(((VideoAlbum) resp.Data.Items[0]).Photo320, "((VideoAlbum) resp.Data.Items[0]).Photo320");
            IsInstanceOf<Video>(resp.Data.Items[1], "resp.Data.Items[1] instanceOf Video");
            IsTrue(((Video)resp.Data.Items[1]).Id == 167787241, "((Video)resp.Data.Items[1]).Id == 167787241");
            IsNotEmpty(((Video)resp.Data.Items[1]).Photo320, "((Video) resp.Data.Items[1]).Photo320");
        }

        [Test]
        public async Task HideCatalogSection()
        {
            var resp = await _inTouch.Videos.HideCatalogSection("some_section");

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
