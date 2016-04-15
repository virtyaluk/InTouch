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
    public class DocsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("docs");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Docs.Get(3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestDoc(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Docs.GetById("546879_147852");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestDoc(resp.Data[0]);
        }

        [Test]
        public async Task GetUploadServer()
        {
            var resp = await _inTouch.Docs.GetUploadServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task GetWallUploadServer()
        {
            var resp = await _inTouch.Docs.GetWallUploadServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task Save()
        {
            var resp = await _inTouch.Docs.Save("doc_file");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestDoc(resp.Data[0]);
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Docs.Delete(12345, 369852);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Docs.Add(12345, 369852);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }


        [Test]
        public async Task GetTypes()
        {
            var resp = await _inTouch.Docs.GetTypes();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 7, "resp.Data.Count == 7");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 1, "resp.Data.Items[0].Id == 1");
            IsTrue(resp.Data.Items[0].Count == 21, "resp.Data.Items[0].Count == 21");
            IsNotEmpty(resp.Data.Items[0].Name, "resp.Data.Items[0].Name");
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Docs.Search("Book");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestDoc(resp.Data.Items[0]);
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Docs.Edit(12345, 369852);

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
