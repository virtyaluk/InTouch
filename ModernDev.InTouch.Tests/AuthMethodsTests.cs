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
    public class AuthMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("auth");
        }

        [Test]
        public async Task CheckPhone()
        {
            var resp = await _inTouch.Auth.CheckPhone("+1987555555", true);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Signup()
        {
            var resp = await _inTouch.Auth.Signup(new AuthSignupParams
            {
                FirstName = "Bohdan",
                LastName = "Shtepan",
                Phone = "+1987555555"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.SId == "super_sid", "resp.Data.SId == 'super_sid'");
        }

        [Test]
        public async Task Confirm()
        {
            var resp = await _inTouch.Auth.Confirm("+1987555555", "555888");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Success, "resp.Data.Success");
            IsTrue(resp.Data.UId == 12345, "resp.Data.UId == 12345");
        }

        [Test]
        public async Task Restore()
        {
            var resp = await _inTouch.Auth.Restore("01987555555");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Success, "resp.Data.Success");
            IsTrue(resp.Data.SId == "super_sid", "resp.Data.SId == 'super_sid'");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
