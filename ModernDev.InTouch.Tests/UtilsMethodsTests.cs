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

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
