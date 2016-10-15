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
    public class MessagesMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("messages");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Messages.Get(new MessagesGetParams());

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            Ex.TestMessage(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetDialogs()
        {
            var resp = await _inTouch.Messages.GetDialogs(new MessagesGetDialogsParams {Count = 3});

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.UnreadDialogs == 22, "resp.Data.UnreadDialogs == 22");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].InRead == 147672, "resp.Data.Items[0].InRead == 147672");
            IsTrue(resp.Data.Items[0].OutRead == 146487, "resp.Data.Items[0].OutRead == 146487");
            Ex.TestMessage(resp.Data.Items[0].Message);
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Messages.GetById(new List<int> { 258 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            Ex.TestMessage(resp.Data.Items[0]);
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Messages.Search("Test");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            Ex.TestMessage(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetHistory()
        {
            var resp = await _inTouch.Messages.GetHistory(new MessagesGetHistoryParams { PeerId = 12345, Count = 3 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            Ex.TestMessage(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetHistoryAttachments()
        {
            var resp =
                await _inTouch.Messages.GetHistoryAttachments(new MessagesGetHistoryAttachmentsParams { PeerId = 12345 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsInstanceOf<Photo>(resp.Data.Items[0], "resp.Data.Items[0] instanceOf Photo");
            Ex.TestPhotoAttachments((Photo) resp.Data.Items[0]);
            IsInstanceOf<Video>(resp.Data.Items[1], "resp.Date.Items[1] instanceOf Video");
            Ex.TestVideoAttachment((Video)resp.Data.Items[1]);
        }

        [Test]
        public async Task Send()
        {
            var resp = await _inTouch.Messages.Send(new MessagesSendParams
            {
                UserId = 12345,
                Message = "test"
            });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task SendSticker()
        {
            var resp = await _inTouch.Messages.SendSticker(5566, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _inTouch.Messages.Delete(new List<int> { 1 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteDialog()
        {
            var resp = await _inTouch.Messages.DeleteDialog(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Restore()
        {
            var resp = await _inTouch.Messages.Restore(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task MarkAsRead()
        {
            var resp = await _inTouch.Messages.MarkAsRead(new List<int> { 1 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task MarkAsImportant()
        {
            var resp = await _inTouch.Messages.MarkAsImportant(new List<int> { 1, 2 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data, "resp.Data");
            IsTrue(resp.Data.Contains(12345), "resp.Data.Contains(12345)");
        }

        [Test]
        public async Task MarkAsImportantDialog()
        {
            var resp = await _inTouch.Messages.MarkAsImportantDialog(123, true);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task MarkAsAnsweredDialog()
        {
            var resp = await _inTouch.Messages.MarkAsAnsweredDialog(123);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetLongPollServer()
        {
            var resp = await _inTouch.Messages.GetLongPollServer();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.PTS == 424197, "resp.Data.PTS == 424197");
            IsNotEmpty(resp.Data.Key, "resp.Data.Key");
        }

        [Test]
        public async Task GetLongPollHistory()
        {
            var resp =
                await _inTouch.Messages.GetLongPollHistory(new MessagesGetLongPollHistoryParams { TS = 123, PTS = 23234 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.History, "resp.Data.History");
            IsTrue(resp.Data.NewPTS == 424197, "resp.Data.NewPTS == 424197");
            IsNotNull(resp.Data.Messages, "resp.Data.Messages != null");
            IsNotEmpty(resp.Data.Messages.Items, "resp.Data.Messages.Items");
            IsNotNull(resp.Data.Messages.Items[0], "resp.Data.Messages.Items[0] != null");
            IsTrue(resp.Data.Messages.Items[0].Id == 147672, "resp.Data.Messages.Items[0].Id == 147672");
            IsNotNull(resp.Data.Messages.Items[0].Date, "resp.Data.Messages.Items[0].Date != null");
            IsTrue(resp.Data.Messages.Items[0].Body == "text", "resp.Data.Messages.Items[0].Body == 'text'");
        }

        [Test]
        public async Task GetChat()
        {
            var resp = await _inTouch.Messages.GetChat(1);

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestChat(resp.Data);
        }

        [Test]
        public async Task CreateChat()
        {
            var resp = await _inTouch.Messages.CreateChat(new List<int> { 12345 }, "Chat");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data == 481516, "resp.Data == 481516");
        }

        [Test]
        public async Task EditChat()
        {
            var resp = await _inTouch.Messages.EditChat(1, "New chat title");

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetChatUsers()
        {
            var resp = await _inTouch.Messages.GetChatUsers(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsNotNull(resp.Data[1], "resp.Data[1] != null");
            Ex.TestUser(resp.Data[1]);
        }

        [Test]
        public async Task SetActivity()
        {
            var resp = await _inTouch.Messages.SetActivity(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task SearchDialogs()
        {
            var resp = await _inTouch.Messages.SearchDialogs("Test");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            IsInstanceOf<Chat>(resp.Data[0], "resp.Data[0] instanceOf Chat");
            IsTrue(((Chat) resp.Data[0]).Id == 33, "((Chat) resp.Data[0]).Id == 33");
            IsTrue(((Chat)resp.Data[0]).Title == "FooBar", "((Chat)resp.Data[0]).Title == 'FooBar'");
            IsInstanceOf<User>(resp.Data[1], "resp.Data[1] instanceOf User");
            IsTrue(((User) resp.Data[1]).Id == 156830612, "((User) resp.Data[1]).Id == 156830612");
        }

        [Test]
        public async Task AddChatUser()
        {
            var resp = await _inTouch.Messages.AddChatUser(1, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveChatUser()
        {
            var resp = await _inTouch.Messages.RemoveChatUser(1, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetLastActivity()
        {
            var resp = await _inTouch.Messages.GetLastActivity(12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.IsOnline, "resp.Data.IsOnline");
            IsNotNull(resp.Data.LastActivityTime, "resp.Data.LastActivityTime != null");
        }

        [Test]
        public async Task SetChatPhoto()
        {
            var resp = await _inTouch.Messages.SetChatPhoto("chat_photo");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.MessageId == 481516, "resp.Data.MessageId == 481516");
            Ex.TestChat(resp.Data.Chat);
        }

        [Test]
        public async Task DeleteChatPhoto()
        {
            var resp = await _inTouch.Messages.DeleteChatPhoto(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.MessageId == 481516, "resp.Data.MessageId == 481516");
            Ex.TestChat(resp.Data.Chat);
        }

        [Test]
        public async Task DenyMessagesFromGroup()
        {
            var resp = await _inTouch.Messages.DenyMessagesFromGroup(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task AllowMessagesFromGroup()
        {
            var resp = await _inTouch.Messages.AllowMessagesFromGroup(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task IsMessagesFromGroupAllowed()
        {
            var resp = await _inTouch.Messages.IsMessagesFromGroupAllowed(1, 1);

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
