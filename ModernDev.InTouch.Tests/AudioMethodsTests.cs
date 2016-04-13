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
    public class AudioMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("audio");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Audio.Get();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestAudio(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Audio.GetById(new List<string> { "12345_54321" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestAudio(resp.Data[0]);
        }

        [Test]
        public async Task GetLyrics()
        {
            var resp = await _inTouch.Audio.GetLyrics(123456);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.LyricsId == 2428970, "resp.Data.LyricsId == 2428970");
            IsNotEmpty(resp.Data.Text, "resp.Data.Text");
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Audio.Search(new AudioSearchParams { Query = "Diplo" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestAudio(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetUploadServer()
        {
            var resp = await _inTouch.Audio.GetUploadServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data);
            IsNotEmpty(resp.Data.UploadUrl, "resp.Data.UploadUrl");
        }

        [Test]
        public async Task Save()
        {
            var resp = await _inTouch.Audio.Save(new AudioUploadResponse
            {
                Server = "server",
                Audio = "audio",
                Hash = "hash"
            });

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestAudio(resp.Data);
        }

        [Test]
        public async Task Add()
        {
            var resp = await _inTouch.Audio.Add(123456, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Audio.Delete(123456, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Audio.Edit(new AudioEditParams());

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task Reorder()
        {
            var resp = await _inTouch.Audio.Reorder(123456);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Restore()
        {
            var resp = await _inTouch.Audio.Restore(123456);

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestAudio(resp.Data);
        }

        [Test]
        public async Task GetAlbums()
        {
            var resp = await _inTouch.Audio.GetAlbums();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Count == 15, "resp.Data.Count == 15");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Id == 71581179, "resp.Data.Items[0].Id == 71581179");
            IsTrue(resp.Data.Items[0].Title == "Future House", "resp.Data.Items[0].Title == 'Future House'");
        }

        [Test]
        public async Task AddAlbum()
        {
            var resp = await _inTouch.Audio.AddAlbum("Deep House");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task EditAlbum()
        {
            var resp = await _inTouch.Audio.EditAlbum(654321, "Deep House 2016");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteAlbum()
        {
            var resp = await _inTouch.Audio.DeleteAlbum(654321);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task MoveToAlbum()
        {
            var resp = await _inTouch.Audio.MoveToAlbum(new List<int> { 123456 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SetBroadcast()
        {
            var resp = await _inTouch.Audio.SetBroadcast("123456_54321", new List<int> {12345});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Contains(12345), "resp.Data.Contains(12345)");
        }

        [Test]
        public async Task GetBroadcastList()
        {
            var resp = await _inTouch.Audio.GetGroupsBroadcastList();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[0], "resp.Data[0] != null");
            IsNotNull(resp.Data[0].StatusAudio, "resp.Data[0].StatusAudio != null");
            Ex.TestAudio(resp.Data[0].StatusAudio);
        }

        [Test]
        public async Task GetReccomendations()
        {
            var resp = await _inTouch.Audio.GetRecommendations();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestAudio(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetPopular()
        {
            var resp = await _inTouch.Audio.GetPopular();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestAudio(resp.Data[0]);
        }

        [Test]
        public async Task GetCount()
        {
            var resp = await _inTouch.Audio.GetCount(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
