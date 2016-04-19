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
    public class PagesMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("pages");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Pages.Get(new PagesGetParams { Global = true });

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestWikiPage(resp.Data);
        }

        [Test]
        public async Task Save()
        {
            var resp = await _inTouch.Pages.Save("My page");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task SaveAccess()
        {
            var resp = await _inTouch.Pages.SaveAccess(336699);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task GetHistory()
        {
            var resp = await _inTouch.Pages.GetHistory(336699);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 183526239, "resp.Data[0].Id == 183526239");
            IsNotNull(resp.Data[0].Date, "resp.Data[0].Date != null");
            IsNotEmpty(resp.Data[0].EditorName, "resp.Data[0].EditorName");
        }

        [Test]
        public async Task GetTitles()
        {
            var resp = await _inTouch.Pages.GetTitles(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsTrue(resp.Data[0].Id == 48646066, "resp.Data[0].Id == 48646066");
            IsTrue(resp.Data[0].Title == "book", "resp.Data[0].Title == 'book'");
            IsNotNull(resp.Data[0].Created, "resp.Data[0].Created != null");
            IsTrue(resp.Data[0].WhoCanView == CommunityAccessTypes.Everyone, "resp.Data[0].WhoCanView == CommunityAccessTypes.Everyone");
        }

        [Test]
        public async Task GetVersion()
        {
            var resp = await _inTouch.Pages.GetVersion(2255);

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestWikiPage(resp.Data);
        }

        [Test]
        public async Task ParseWiki()
        {
            var resp = await _inTouch.Pages.ParseWiki("pseudo wiki markup");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ClearCache()
        {
            var resp = await _inTouch.Pages.ClearCache("https://some.url/");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
