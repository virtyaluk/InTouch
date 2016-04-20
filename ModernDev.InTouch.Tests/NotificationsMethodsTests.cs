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
    public class NotificationsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("notifications");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Notifications.Get(3);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            IsNotNull(resp.Data.LastViewed, "resp.Data.LastViewed != null");
            IsNotEmpty(resp.Data.NextFrom, "resp.Data.NextFrom");
            IsNotEmpty(resp.Data.Profiles, "resp.Data.Profiles");
            IsNotEmpty(resp.Data.Groups, "resp.Data.Groups");

            // like_video
            IsNotNull(resp.Data.Items[0], "resp.Data.Items[0] != null");
            IsTrue(resp.Data.Items[0].Type == NotificationTypes.LikeVideo, "resp.Data.Items[0].Type == NotificationTypes.LikeVideo");
            IsInstanceOf<LikeVideoNotification>(resp.Data.Items[0], "resp.Data.Items[0] instanceOf LikeVideoNotification");
            IsNotNull(resp.Data.Items[0].Date, "resp.Data.Items[0].Date != null");
            IsNotNull(((LikeVideoNotification) resp.Data.Items[0]).Parent, "((LikeVideoNotification) resp.Data.Items[0]).Parent != null");
            IsTrue(((LikeVideoNotification)resp.Data.Items[0]).Parent.Id == 168603708, "((LikeVideoNotification)resp.Data.Items[0]).Parent.Id == 168603708");
            IsTrue(((LikeVideoNotification)resp.Data.Items[0]).Parent.CanAdd, "((LikeVideoNotification)resp.Data.Items[0]).Parent.CanAdd");
            IsNotEmpty(((LikeVideoNotification)resp.Data.Items[0]).Parent.Title, "((LikeVideoNotification)resp.Data.Items[0]).Parent.Title");
            IsNotNull(((LikeVideoNotification)resp.Data.Items[0]).Feedback, "((LikeVideoNotification)resp.Data.Items[0]).Feedback != null");
            IsTrue(((LikeVideoNotification)resp.Data.Items[0]).Feedback.Count == 1, "((LikeVideoNotification)resp.Data.Items[0]).Feedback.Count == 1");
            IsNotEmpty(((LikeVideoNotification)resp.Data.Items[0]).Feedback.Items, "((LikeVideoNotification)resp.Data.Items[0]).Feedback.Items != null");
            IsTrue(((LikeVideoNotification)resp.Data.Items[0]).Feedback.Items[0].FromId == 71730243, "((LikeVideoNotification)resp.Data.Items[0]).Feedback.Items[0].FromId == 71730243");

            // reply_comment
            IsNotNull(resp.Data.Items[1], "resp.Data.Items[1] != null");
            IsTrue(resp.Data.Items[1].Type == NotificationTypes.ReplyComment, "resp.Data.Items[1].Type == NotificationTypes.ReplyComment");
            IsInstanceOf<ReplyCommentNotification>(resp.Data.Items[1], "resp.Data.Items[1] instanceOf ReplyCommentNotification");
            IsNotNull(((ReplyCommentNotification) resp.Data.Items[1]).Parent, "((ReplyCommentNotification) resp.Data.Items[1]).Parent != null");
            IsTrue(((ReplyCommentNotification)resp.Data.Items[1]).Parent.Id == 35832, "((ReplyCommentNotification)resp.Data.Items[1]).Parent.Id == 35832");
            IsNotNull(((ReplyCommentNotification)resp.Data.Items[1]).Parent.Date, "((ReplyCommentNotification)resp.Data.Items[1]).Parent.Date != null");
            IsNotEmpty(((ReplyCommentNotification)resp.Data.Items[1]).Parent.Text, "((ReplyCommentNotification) resp.Data.Items[1]).Parent.Text");
            IsNotNull(((ReplyCommentNotification)resp.Data.Items[1]).Parent.Post, "((ReplyCommentNotification)resp.Data.Items[1]).Parent.Post != null");
            IsTrue(((ReplyCommentNotification)resp.Data.Items[1]).Parent.Post.Id == 35416, "((ReplyCommentNotification)resp.Data.Items[1]).Parent.Post.Id == 35416");
        }

        [Test]
        public async Task MarkAsViewed()
        {
            var resp = await _inTouch.Notifications.MarkAsViewed();

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
