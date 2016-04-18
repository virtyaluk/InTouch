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

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class StatsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("stats");
        }

        [Test]
        public async Task Get()
        {
            var resp =
                await _inTouch.Stats.Get(1, dateFrom: new DateTime(2016, 4, 16), dateTo: new DateTime(2016, 4, 17));

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Day == "2016-04-17", "resp.Data[0].Day == '2016-04-17'");
            IsTrue(resp.Data[0].Views == 2402, "resp.Data[0].Views == 2402");
            IsTrue(resp.Data[0].Unsubscribed == 70, "resp.Data[0].Unsubscribed == 70");
            IsNotEmpty(resp.Data[0].Sex, "resp.Data[0].Sex");
            IsNotNull(resp.Data[0].Sex[0], "resp.Data[0].Sex[0] != null");
            IsTrue(resp.Data[0].Sex[0].Visitors == 735, "resp.Data[0].Sex[0].Visitors == 735");
            IsTrue(resp.Data[0].Sex[0].Value == "f", "resp.Data[0].Sex[0].Value == 'f'");
            IsNotEmpty(resp.Data[0].Countries, "resp.Data[0].Countries");
            IsNotNull(resp.Data[0].Countries[0], "resp.Data[0].Countries[0] != null");
            IsTrue(resp.Data[0].Countries[0].Value == "1", "resp.Data[0].Countries[0].Value == '1'");
            IsTrue(resp.Data[0].Countries[0].Visitors == 1075, "resp.Data[0].Countries[0].Visitors == 1075");
            IsTrue(resp.Data[0].Countries[0].Code == "RU", "resp.Data[0].Countries[0].Code == 'RU'");
        }

        [Test]
        public async Task TrackVisitor()
        {
            var resp = await _inTouch.Stats.TrackVisitor();

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetPostReach()
        {
            var resp = await _inTouch.Stats.GetPostReach(-1, 340379);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.ReachSubscribers == 11385, "resp.Data.ReachSubscribers == 11385");
            IsTrue(resp.Data.Links == 92, "resp.Data.Links == 92");
            IsTrue(resp.Data.Hide == 58, "resp.Data.Hide == 58");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
