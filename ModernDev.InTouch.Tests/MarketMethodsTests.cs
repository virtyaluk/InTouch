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
    public class MarketMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("market");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Market.Get(-1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestMarketItem(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Market.GetById(new List<string> { "456_1223" }, true);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestMarketItem(resp.Data.Items[0]);
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Market.Search(new MarketSearchParams { OwnerId = -1 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestMarketItem(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetAlbums()
        {
            var resp = await _inTouch.Market.GetAlbums(-1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestMarketAlbum(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetAlbumById()
        {
            var resp = await _inTouch.Market.GetAlbumById(-1, new List<int> { 1, 2, 3 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestMarketAlbum(resp.Data.Items[0]);
        }

        [Test]
        public async Task CreateComment()
        {
            var resp = await _inTouch.Market.CreateComment(new MarketCreateCommentParams
            {
                ItemId = 1,
                OwnerId = -1,
                Message = "My message"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task GetComments()
        {
            var resp = await _inTouch.Market.GetComments(new MarketGetCommentsParams { OwnerId = -1, ItemId = 1 });

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
        public async Task DeleteComment()
        {
            var resp = await _inTouch.Market.DeleteComment(-1, 1234);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RestoreComment()
        {
            var resp = await _inTouch.Market.RestoreComment(-1, 1234);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task EditComment()
        {
            var resp = await _inTouch.Market.EditComment(-1, 1234, "My comment.", new List<string>());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReportComment()
        {
            var resp = await _inTouch.Market.ReportComment(-1, 1234, ReportTypes.Advertisment);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetCategories()
        {
            var resp = await _inTouch.Market.GetCategories(5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1, "resp.Data.Items[0].Id == 1");
            IsNotEmpty(resp.Data.Items[0].Name, "resp.Data.Items[0].Name");
            IsNotNull(resp.Data.Items[0].Section, "resp.Data.Items[0].Section != null");
            IsTrue(resp.Data.Items[0].Section.Id == 0, "resp.Data.Items[0].Section.Id == 0");
        }

        [Test]
        public async Task Report()
        {
            var resp = await _inTouch.Market.Report(-1, 1, ReportTypes.Advertisment);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Market.Add(new MarketAddParams
            {
                OwnerId = -1,
                Name = "Item #1",
                Description = "Item description",
                CategoryId = 1,
                Price = 100,
                MainPhotoId = 239302342
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Market.Edit(new MarketEditParams
            {
                OwnerId = -1,
                ItemId = 1,
                Name = "Item name",
                Description = "Item description",
                CategoryId = 1,
                Price = 100,
                MainPhotoId = 32432656
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Market.Delete(-1, 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Restore()
        {
            var resp = await _inTouch.Market.Restore(-1, 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReorderItems()
        {
            var resp = await _inTouch.Market.ReorderItems(-1, 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReorderAlbums()
        {
            var resp = await _inTouch.Market.ReorderAlbums(-1, 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task AddAlbum()
        {
            var resp = await _inTouch.Market.AddAlbum(-1, "Items album");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task EditAlbum()
        {
            var resp = await _inTouch.Market.EditAlbum(-1, 1, "New album title");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteAlbum()
        {
            var resp = await _inTouch.Market.DeleteAlbum(-1, 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveFromAlbum()
        {
            var resp = await _inTouch.Market.RemoveFromAlbum(-1, 1, new List<int> { 1 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task AddToAlbum()
        {
            var resp = await _inTouch.Market.AddToAlbum(-1, 1, new List<int> {1});

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
