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
    public class DatabaseMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("database");
        }

        [Test]
        public async Task GetCountries()
        {
            var resp = await _inTouch.Database.GetCountries(true, new List<string>(), 5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 234, "resp.Data.Count == 234");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 19, "resp.Data.Items[0].Id == 19");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
        }

        [Test]
        public async Task GetRegions()
        {
            var resp = await _inTouch.Database.GetRegions(1, count: 5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 83, "resp.Data.Count == 83");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1000001, "resp.Data.Items[0].Id == 1000001");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
        }

        [Test]
        public async Task GetStreetsById()
        {
            var resp = await _inTouch.Database.GetStreetsById(new List<int> {1, 2, 3, 4, 5});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Count == 5, "resp.Data.Count == 5");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 1, "resp.Data[0].Id == 1");
            IsNotEmpty(resp.Data[0].Title, "resp.Data[0].Title");
        }

        [Test]
        public async Task GetCities()
        {
            var resp = await _inTouch.Database.GetCities(1, count: 5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 18, "resp.Data.Count == 18");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1, "resp.Data.Items[0].Id == 1");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
        }

        [Test]
        public async Task GetCitiesById()
        {
            var resp = await _inTouch.Database.GetCitiesById(new List<int> {1, 2, 3, 4, 5});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Count == 5, "resp.Data.Count == 5");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 1, "resp.Data[0].Id == 1");
            IsNotEmpty(resp.Data[0].Title, "resp.Data[0].Title");
        }

        [Test]
        public async Task GetUniversities()
        {
            var resp = await _inTouch.Database.GetUniversities(count: 5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 702, "resp.Data.Count == 702");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 2, "resp.Data.Items[0].Id == 2");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
        }

        [Test]
        public async Task GetSchools()
        {
            var resp = await _inTouch.Database.GetSchools(1, count: 5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 3211, "resp.Data.Count == 3211");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 8243, "resp.Data.Items[0].Id == 8243");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
        }

        [Test]
        public async Task GetFaculties()
        {
            var resp = await _inTouch.Database.GetFaculties(1, count: 5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 26, "resp.Data.Count == 26");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1, "resp.Data.Items[0].Id == 1");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
        }

        [Test]
        public async Task GetChairs()
        {
            var resp = await _inTouch.Database.GetChairs(1, count: 5);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 18, "resp.Data.Count == 18");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1, "resp.Data.Items[0].Id == 1");
            IsNotEmpty(resp.Data.Items[0].Title, "resp.Data.Items[0].Title");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
