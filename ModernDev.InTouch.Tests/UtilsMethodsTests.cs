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
    public class UtilsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("utils");
        }

        [Test]
        public async Task CheckLink()
        {
            var resp = await _inTouch.Utils.CheckLink("https://github.com/virtyaluk");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Status == LinkStatuses.NotBanned, "resp.Data.Status == LinkStatuses.NotBanned");
            IsTrue(resp.Data.Link == "https://github.com/virtyaluk", "resp.Data.Link == 'https://github.com/virtyaluk'");
        }

        [Test]
        public async Task ResolveScreenName()
        {
            var resp = await _inTouch.Utils.ResolveScreenName("virtyaluk");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Type == ObjectTypes.User, "resp.Data.Type == ObjectTypes.User");
            IsTrue(resp.Data.Id == 16815310, "resp.Data.Id == 16815310");
        }

        [Test]
        public async Task GetServerTime()
        {
            var resp = await _inTouch.Utils.GetServerTime();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data == 1460247613, "resp.Data == 1460247613");
        }

        [Test]
        public async Task GetShortLink()
        {
            var resp = await _inTouch.Utils.GetShortLink("http://modern-dev.com/");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data == "https://vk.cc/1wHm8g", "resp.Data == 'https://vk.cc/1wHm8g'");
        }

        [Test]
        public async Task GetLinkStats()
        {
            var resp = await _inTouch.Utils.GetLinkStats("6drK78", LinkStatsInterval.Day, 4);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Key == "6drK78", "resp.Data.Key == '6drK78'");
            IsNotEmpty(resp.Data.Stats, "resp.Data.Stats not empty");
            IsTrue(resp.Data.Stats[0].Views == 0, "resp.Data.Stats[0].Views == 0");
            IsTrue(resp.Data.Stats[1].SegAge[0].Male == 1, "resp.Data.Stats[1].SegAge[0].Male == 1");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
