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

using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class FaveMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("fave");
        }

        [Test]
        public async Task GetUsers()
        {
            var resp = await _inTouch.Fave.GetUsers(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetPhotos()
        {
            var resp = await _inTouch.Fave.GetPhotos(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestPhoto(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetPosts()
        {
            var resp = await _inTouch.Fave.GetPosts(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotEmpty(resp.Data.Groups, "resp.Data.Groups");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles");
            Ex.TestWallPost(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetVideos()
        {
            var resp = await _inTouch.Fave.GetVideos(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestVideo(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetLinks()
        {
            var resp = await _inTouch.Fave.GetLinks(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == "2_16815310_98093993", "resp.Data.Items[0].Id== '2_16815310_98093993'");
            IsNotEmpty(resp.Data.Items[0].Url, "resp.Data.Items[0].Url");
        }

        [Test]
        public async Task GetMarketItems()
        {
            var resp = await _inTouch.Fave.GetMarketItems(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestMarketItem(resp.Data.Items[0]);
        }

        [Test]
        public async Task AddUser()
        {
            var resp = await _inTouch.Fave.AddUser(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveUser()
        {
            var resp = await _inTouch.Fave.RemoveUser(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task AddGroup()
        {
            var resp = await _inTouch.Fave.AddGroup(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveGroup()
        {
            var resp = await _inTouch.Fave.RemoveGroup(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task AddLink()
        {
            var resp = await _inTouch.Fave.AddLink("https://github.com/virtyaluk");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveLink()
        {
            var resp = await _inTouch.Fave.RemoveLink(12);

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
