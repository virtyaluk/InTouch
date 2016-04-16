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
    public class LikesMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("likes");
        }

        [Test]
        public async Task GetList()
        {
            var resp = await _inTouch.Likes.GetList(new LikesGetListParams
            {
                Type = MediaTypes.Post,
                ItemId = 6985632
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Likes.Add(6985632, MediaTypes.Post);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 123, "resp.Data == 123");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Likes.Delete(6985632, MediaTypes.Post);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 123, "resp.Data == 123");
        }

        [Test]
        public async Task IsLiked()
        {
            var resp = await _inTouch.Likes.IsLiked(6985632, MediaTypes.Post);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Liked, "resp.Data.Liked");
            IsTrue(resp.Data.Copied, "resp.Data.Copied");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
