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
    public class AccountMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("account");
        }

        [Test]
        public async Task GetCounters()
        {
            var resp = await _inTouch.Account.GetCounters();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Friends == 733, "resp.Data.Friends == 733");
            IsTrue(resp.Data.Messages == 21, "resp.Data.Messages == 21");
        }

        [Test]
        public async Task SetNameInMenu()
        {
            var resp = await _inTouch.Account.SetNameInMenu(12345, "Test app");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SetOnline()
        {
            var resp = await _inTouch.Account.SetOnline();

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SetOffline()
        {
            var resp = await _inTouch.Account.SetOffline();

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task LookupContacts()
        {
            var resp = await _inTouch.Account.LookupContacts(Services.Phone, new List<string> { "+325544" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Found, "resp.Data.Found");
            IsTrue(resp.Data.Found.Count == 2, "resp.Data.Found.Count == 2");
            Ex.TestUser(resp.Data.Found[1]);
        }

        [Test]
        public async Task RegisterDevice()
        {
            var resp = await _inTouch.Account.RegisterDevice("super_token", "super_device_id");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task UnregisterDevice()
        {
            var resp = await _inTouch.Account.UnregisterDevice("super_device_id");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SetSilinceMode()
        {
            var resp = await _inTouch.Account.SetSilenceMode("super_device_id");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SetPushSettings()
        {
            var resp = await _inTouch.Account.SetPushSettings("super_device_id", "settings");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetAppPermissions()
        {
            var resp = await _inTouch.Account.GetAppPermissions(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task BanUser()
        {
            var resp = await _inTouch.Account.BanUser(54321);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetBanned()
        {
            var resp = await _inTouch.Account.GetBanned(count: 3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task GetInfo()
        {
            var resp = await _inTouch.Account.GetInfo();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.HttpsRequired, "resp.Data.HttpsRequired");
            IsTrue(resp.Data.OwnPostsDefault, "resp.Data.OwnPostsDefault");
            IsTrue(resp.Data.Country == "UA", "resp.Data.Country == 'UA'");
        }

        [Test]
        public async Task SetInfo()
        {
            var resp = await _inTouch.Account.SetInfo();

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ChangePassword()
        {
            var resp = await _inTouch.Account.ChangePassword("new_super_password");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == "super_token", "resp.Data == 'super_token'");
        }

        [Test]
        public async Task GetProfileInfo()
        {
            var resp = await _inTouch.Account.GetProfileInfo();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.ScreenName == "virtyaluk", "resp.Data.ScreenName == 'virtyaluk'");
            IsNotNull(resp.Data.NameRequest, "resp.Data.NameRequest != null");
            IsTrue(resp.Data.NameRequest.Status == NameRequestStatus.Processing, "resp.Data.NameRequest.Status == NameRequestStatus.Processing");
            IsTrue(resp.Data.NameRequest.Id == 12345, "resp.Data.NameRequest.Id == 12345");
        }

        [Test]
        public async Task SaveProfileInfo()
        {
            var resp = await _inTouch.Account.SaveProfileInfo(new AccountSaveProfileInfoParams
            {
                FirstName = "Bohdan",
                LastName = "Shtepan"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Changed, "resp.Data.Changed");
            IsNotNull(resp.Data.NameRequest, "resp.Data.NameRequest != null");
            IsTrue(resp.Data.NameRequest.Id == 12345, "resp.Data.NameRequest.Id == 12345");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
