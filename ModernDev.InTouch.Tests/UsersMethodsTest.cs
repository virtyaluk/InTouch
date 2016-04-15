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
using NUnit.Framework;
using System.Threading.Tasks;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class UsersMethodsTest
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("users");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Users.Get();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[1], "resp.Data[1] != null");
            Ex.TestUser(resp.Data[1]);
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Users.Search();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task IsAppUser()
        {
            var resp = await _inTouch.Users.IsAppUser();
            
            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetSubscriptions()
        {
            var resp = await _inTouch.Users.GetSubscriptionsExtended(null, 20, 0, new List<string>());

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsTrue(resp.Data.Count == 6, "resp.Data.Count == 6");
            IsNotNull(resp.Data.Items[2], "resp.Data.Items[2] != null");
            IsInstanceOf(typeof(User), resp.Data.Items[2], "resp.date.Items[2] is typeof User");
            Ex.TestUser((User) resp.Data.Items[2]);
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            IsInstanceOf(typeof(Group), resp.Data.Items[1], "resp.Data.Items is typeof Group");
            Ex.TestGroup((Group) resp.Data.Items[1]);
        }

        [Test]
        public async Task GetFollowers()
        {
            var resp = await _inTouch.Users.GetFollowers(null, 0);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task Report()
        {
            var resp = await _inTouch.Users.Report(2, ReportTypes.Porn);

            IsFalse(resp.IsError, "resp.IsError");
            IsFalse(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetNearby()
        {
            var resp = await _inTouch.Users.GetNearby(new Coordinates {Latitude = 45, Longitude = 45});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
