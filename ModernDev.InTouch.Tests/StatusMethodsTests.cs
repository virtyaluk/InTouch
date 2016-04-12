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
    public class StatusMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("status");
        }

        [Test]
        public async Task Set()
        {
            var resp = await _inTouch.Status.Set("Test");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Status.Get();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Text, "resp.Data.Text");
            IsNotNull(resp.Data.Audio, "resp.Data.Audio != null");
            IsTrue(resp.Data.Audio.Id == 456239425, "resp.Data.Audio.Id == 456239425");
            IsTrue(resp.Data.Audio.Artist == "Major Lazer x Showtek", "resp.Data.Audio.Artist == 'Major Lazer x Showtek'");
            IsTrue(resp.Data.Audio.NoSearch, "resp.Data.Audio.NoSearch");
            IsNotNull(resp.Data.Audio.Date, "resp.Data.Audio.Date != null");
            IsTrue(resp.Data.Audio.GenreId == AudioGenres.Other, "resp.Data.Audio.GenreId == AudioGenres.Other");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
