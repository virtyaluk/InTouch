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
    public class StorageMethodsTest
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("storage");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Storage.Get(new List<string> {"foo"});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Key == "foo", "resp.Data[0].Key == 'foo'");
            IsTrue(resp.Data[0].Value == "bar", "resp.Data[0].Value == 'bar'");
        }

        [Test]
        public async Task Set()
        {
            var resp = await _inTouch.Storage.Set("foo", "bar");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetKeys()
        {
            var resp = await _inTouch.Storage.GetKeys();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Count == 3, "resp.Data.Count == 3");
            IsTrue(resp.Data.Contains("foo"), "resp.Data.Contains('foo')");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
