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
using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class PlacesMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("places");
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Places.Add("New Place", new Coordinates(0.0, 0.0));

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 1234, "resp.Data == 1234");
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Places.GetById(new List<int> { 55, 58 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 4980426, "resp.Data[0].Id == 4980426");
            IsTrue(resp.Data[0].Title == "test", "resp.Data[0].Title == 'test'");
            IsNotNull(resp.Data[0].Updated, "resp.Data[0].Updated != null");
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Places.Search(new Coordinates(0.0, 0.0));

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsTrue(resp.Data.Items[0].Id == 213784, "resp.Data.Items[0].Id == 213784");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
            IsNotNull(resp.Data.Items[0].Created, "resp.Data.Items[0].Created != null");
        }

        [Test]
        public async Task Checkin()
        {
            var resp = await _inTouch.Places.Checkin(55);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task GetCheckins()
        {
            var resp = await _inTouch.Places.GetCheckins(new PlacesGetCheckinsParams { UserId = 12345 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == "3796764_1127", "resp.Data.Items[0].Id == '3796764_1127'");
            IsTrue(resp.Data.Items[0].UserId == 3796764, "resp.Data.Items[0].UserId == 3796764");
            IsNotNull(resp.Data.Items[0].Text, "resp.Data.Items[0].Text");
        }

        [Test]
        public async Task GetTypes()
        {
            var resp = await _inTouch.Places.GetTypes();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 1, "resp.Data[0].Id == 1");
            IsNotEmpty(resp.Data[0].Title, "resp.Data[0].Title");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
