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
    public class PhotosMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("photos");
        }

        [Test]
        public async Task CreateAlbum()
        {
            var resp = await _inTouch.Photos.CreateAlbum(new PhotosCreateAlbumParams
            {
                Title = "New photo album"
            });

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestPhotoAlbum(resp.Data);
            IsFalse(resp.Data.ThumbIsLast, "album.ThumbIsLast");
        }

        [Test]
        public async Task EditAlbum()
        {
            var resp = await _inTouch.Photos.EditAlbum(new PhotosEdiAlbumParams
            {
                AlbumId = 258,
                Title = "New album title"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetAlbums()
        {
            var resp = await _inTouch.Photos.GetAlbums(new PhotosGetAlbumsParams());

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestPhotoAlbum(resp.Data.Items[0]);
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Photos.Get(new PhotosGetParams());

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestPhoto(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetAlbumsCount()
        {
            var resp = await _inTouch.Photos.GetAlbumsCount();

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Photos.GetById(new List<string> { "523654_56874" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestPhoto(resp.Data[0]);
        }

        [Test]
        public async Task GetUploadServer()
        {
            var resp = await _inTouch.Photos.GetUploadServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task GetOwnerPhotoUploadServer()
        {
            var resp = await _inTouch.Photos.GetOwnerPhotoUploadServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task GetChatUploadServer()
        {
            var resp = await _inTouch.Photos.GetChatUploadServer(2356);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task GetMarketUploadServer()
        {
            var resp = await _inTouch.Photos.GetMarketUploadServer(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task GetMarketAlbumUploadServer()
        {
            var resp = await _inTouch.Photos.GetMarketAlbumUploadServer(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task SaveMarketPhoto()
        {
            var resp = await _inTouch.Photos.SaveMarketPhoto(new MarketPhotoUploadResponse
            {
                Photo = "photo",
                Server = "server",
                Hash = "hash",
                GroupId = "1"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestPhoto(resp.Data[0]);
        }

        [Test]
        public async Task SaveMarketAlbumPhotoW()
        {
            var resp = await _inTouch.Photos.SaveMarketAlbumPhoto(new MarketPhotoUploadResponse
            {
                GroupId = "1",
                Photo = "photo",
                Server = "server",
                Hash = "hash"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestPhoto(resp.Data[0]);
        }

        [Test]
        public async Task SaveOwnerPhoto()
        {
            var resp = await _inTouch.Photos.SaveOwnerPhoto(new PhotoUploadResponse
            {
                Photo = "photo",
                Server = "server",
                Hash = "hash"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.PhotoHash, "resp.Data.PhotoHash");
        }

        [Test]
        public async Task SaveWallPhoto()
        {
            var resp = await _inTouch.Photos.SaveWallPhoto(new PhotoUploadResponse
            {
                Photo = "photo",
                Server = "server",
                Hash = "hash"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestPhoto(resp.Data[0]);
        }

        [Test]
        public async Task GetWallUploadServer()
        {
            var resp = await _inTouch.Photos.GetWallUploadServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task GetMessagesUploadServer()
        {
            var resp = await _inTouch.Photos.GetMessagesUploadServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task SaveMessagesPhoto()
        {
            var resp = await _inTouch.Photos.SaveMessagesPhoto(new PhotoUploadResponse
            {
                Photo = "photo",
                Server = "server",
                Hash = "hash"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestPhoto(resp.Data[0]);
        }

        [Test]
        public async Task Report()
        {
            var resp = await _inTouch.Photos.Report(12345, 5588, ReportTypes.Advertisment);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReportComment()
        {
            var resp = await _inTouch.Photos.ReportComment(12345, 4477, ReportTypes.Advertisment);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Photos.Search("Amsterdam");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestPhoto(resp.Data.Items[0]);
        }

        [Test]
        public async Task Save()
        {
            var resp = await _inTouch.Photos.Save(new AlbumPhotoUploadResponse
            {
                Server = "server",
                Hash = "hash",
                PhotosList = "photos_list"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestPhoto(resp.Data[0]);
        }

        [Test]
        public async Task Copy()
        {
            var resp = await _inTouch.Photos.Copy(12345, 5588, "accessKey");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Photos.Edit(5588);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Move()
        {
            var resp = await _inTouch.Photos.Move(5588, 2255);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task MakeCover()
        {
            var resp = await _inTouch.Photos.MakeCover(5588);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReorderAlbums()
        {
            var resp = await _inTouch.Photos.ReorderAlbums(998);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReorderPhotos()
        {
            var resp = await _inTouch.Photos.ReorderPhotos(9985);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetAll()
        {
            var resp = await _inTouch.Photos.GetAll();

            IsFalse(resp.IsError, "resp.IsError");

            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestPhoto(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetUserPhotos()
        {
            var resp = await _inTouch.Photos.GetUserPhotos();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestPhoto(resp.Data.Items[0]);
        }

        [Test]
        public async Task DeleteAlbum()
        {
            var resp = await _inTouch.Photos.DeleteAlbum(5588);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Photos.Delete(2233);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Restore()
        {
            var resp = await _inTouch.Photos.Restore(2233);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ConfirmTag()
        {
            var resp = await _inTouch.Photos.ConfirmTag(233, 565);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetComments()
        {
            var resp = await _inTouch.Photos.GetComments(new PhotosGetCommentsParam
            {
                PhotoId = 3355
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
        public async Task GetAllComments()
        {
            var resp = await _inTouch.Photos.GetAllComments();

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
            var resp = await _inTouch.Photos.CreateComment(new PhotosCreateCommentParams
            {
                PhotoId = 5566,
                Message = "message"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task DeleteComment()
        {
            var resp = await _inTouch.Photos.DeleteComment(3366);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RestoreComment()
        {
            var resp = await _inTouch.Photos.RestoreComment(3366);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task EditComment()
        {
            var resp = await _inTouch.Photos.EditComment(3366, attachments: new List<string>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetTags()
        {
            var resp = await _inTouch.Photos.GetTags(3366);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 42830775, "resp.Data[0].Id == 42830775");
            IsFalse(resp.Data[0].Viewed, "resp.Data[0].Viewed");
            IsNotNull(resp.Data[0].Date, "resp.Data[0].Date != null");
        }

        [Test]
        public async Task PutTags()
        {
            var resp = await _inTouch.Photos.PutTag(3366, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task RemoveTag()
        {
            var resp = await _inTouch.Photos.RemoveTag(3366, 15677);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetNewTags()
        {
            var resp = await _inTouch.Photos.GetNewTags(3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestPhoto(resp.Data.Items[0]);
        }

        public async Task GetEditorStickers()
        {
            var resp = await _inTouch.Photos.GetEditorStickers();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.BaseUrl, "resp.Data.BaseUrl");
            IsNotEmpty(resp.Data.StickerIds, "resp.Data.StickerIds");
            Contains(resp.Data.StickerIds, new List<int> {3178, 3210, 3229});
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
