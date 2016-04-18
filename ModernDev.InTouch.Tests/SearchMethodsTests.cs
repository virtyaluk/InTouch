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
    public class SearchMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("search");
        }

        [Test]
        public async Task GetHints()
        {
            var resp = await _inTouch.Search.GetHints(limit: 2);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Type == "profile", "resp.Data[0].Type == 'profile'");
            IsTrue(resp.Data[0].Section == HintsSectionTypes.Friends, "resp.Data[0].Section == HintsSectionTypes.Friends");
            IsNotNull(resp.Data[0].Profile, "resp.Data[0].Profile != null");
            IsTrue(resp.Data[0].Profile.Id == 24945500, "resp.Data[0].Profile.Id == 24945500");
            IsNotNull(resp.Data[1], "resp.Data[1] != null");
            IsTrue(resp.Data[1].Type == "group", "resp.Data[1].Type == 'group'");
            IsTrue(resp.Data[1].Section == HintsSectionTypes.Publics, "resp.Data[1].Section == HintsSectionTypes.Publics");
            IsNotNull(resp.Data[1].Group, "resp.Data[1].Group != null");
            IsTrue(resp.Data[1].Group.Id == 69019591, "resp.Data[1].Group.Id == 69019591");
        }


        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
