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
    public class GiftsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("gifts");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Gifts.Get();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, nameof(resp.Data.Items));
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsEmpty(resp.Data.Items[0].Message, "resp.Data.Items[0].Message");
            IsTrue(resp.Data.Items[0].Privacy == GiftPrivacies.Hidden, "resp.Data.Items[0].Privacy == GiftPrivacies.Hidden");
            IsNotNull(resp.Data.Items[0].Date, "resp.Data.Items[0].Date != null");
            IsTrue(resp.Data.Items[0].Id == 653008904, "resp.Data.Items[0].Id == 653008904");
            IsNotNull(resp.Data.Items[0].Gift, "resp.Data.Items[0].Gift != null");
            IsTrue(resp.Data.Items[0].Gift.Id == 770, "resp.Data.Items[0].Gift.Id == 770");
            IsNotEmpty(resp.Data.Items[0].Hash, "resp.Data.Items[0].Hash");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
