/**
 * This file\code is part of InTouch project.
 *
 * InTouch - is a .NET wrapper for the vk.com API.
 * https://github.com/virtyaluk/InTouch
 *
 * Copyright (c) 2017 Bohdan Shtepan
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
    public class SecureMethodsTest
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("secure");
        }

        [Test]
        public async Task SetUserLevel()
        {
            var resp = await _inTouch.Secure.SetUserLevel(new[] {"1:1"});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SetCounter()
        {
            var resp = await _inTouch.Secure.SetCounter(new[] { "1:1" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SendSMSNotification()
        {
            var resp = await _inTouch.Secure.SendSMSNotification(1, "foo bar");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SendNotification()
        {
            var resp = await _inTouch.Secure.SendNotification("foo bar", userId: 1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            That(resp.Data, Has.Member(12345));
        }

        [Test]
        public async Task GetAppBalance()
        {
            var resp = await _inTouch.Secure.GetAppBalance();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            That(resp.Data, Is.EqualTo(481516));
        }

        [Test]
        public async Task CheckToken()
        {
            var resp = await _inTouch.Secure.CheckToken("some_token", "192.168.0.1");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Success, "resp.Data.Success");
            That(resp.Data.UserId, Is.EqualTo(1));
            IsNotNull(resp.Data.Date, "resp.Data.Date != null");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
