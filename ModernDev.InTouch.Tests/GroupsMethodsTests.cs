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
    public class GroupsMethodsTests
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("groups");
        }

        [Test]
        public async Task IsMember()
        {
            var resp = await _inTouch.Groups.IsMember(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsFalse(resp.Data.IsMemeber, "resp.Data.IsMemeber");
            IsTrue(resp.Data.IsRequested, "resp.Data.IsRequested");
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _inTouch.Groups.GetById(new List<object> { 1 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotEmpty(resp.Data, "resp.Data");
            Ex.TestGroup(resp.Data[0]);
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Groups.Get(new GroupsGetParams());

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestGroup(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetMembers()
        {
            var resp = await _inTouch.Groups.GetMembers(new GroupsGetMembersParams { GroupId = "1" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task Join()
        {
            var resp = await _inTouch.Groups.Join(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Leave()
        {
            var resp = await _inTouch.Groups.Leave(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Search()
        {
            var resp = await _inTouch.Groups.Search(new GroupsSearchParams { Query = "InTouch" });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestGroup(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetCatalog()
        {
            var resp = await _inTouch.Groups.GetCatalog();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestGroup(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetCatalogInfo()
        {
            var resp = await _inTouch.Groups.GetCatalogInfo(true, true);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Enabled, "resp.Data.Enabled");
            IsNotEmpty(resp.Data.Categories, "resp.Data.Categories");
            IsNotNull(resp.Data.Categories[0], "resp.Data.Categories[0] != null");
            IsTrue(resp.Data.Categories[0].Id == 0, "resp.Data.Categories[0].Id == 0");
            IsNotEmpty(resp.Data.Categories[0].Name, "resp.Data.Categories[0].Name");
            IsNotEmpty(resp.Data.Categories[0].PagePreviews, "resp.Data.Categories[0].PagePreviews");
            IsNotNull(resp.Data.Categories[0].PagePreviews[0], "resp.Data.Categories[0].PagePreviews[0] != null");
            IsTrue(resp.Data.Categories[0].PagePreviews[0].Id == 59576823, "resp.Data.Categories[0].PagePreviews[0].Id == 59576823");
        }

        [Test]
        public async Task GetInvites()
        {
            var resp = await _inTouch.Groups.GetInvites();

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestGroup(resp.Data.Items[0]);
        }

        [Test]
        public async Task GetInvitedUsers()
        {
            var resp = await _inTouch.Groups.GetInvitedUsers(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task BanUser()
        {
            var resp = await _inTouch.Groups.BanUser(1, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task UnbanUser()
        {
            var resp = await _inTouch.Groups.UnbanUser(1, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task GetBanned()
        {
            var resp = await _inTouch.Groups.GetBanned(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task Create()
        {
            var resp = await _inTouch.Groups.Create("InTouch");

            IsFalse(resp.IsError, "resp.IsError");
            Ex.TestGroup(resp.Data);
        }

        [Test]
        public async Task Edit()
        {
            var resp = await _inTouch.Groups.Edit(new GroupsEditParams { GroupId = 1 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task EditPlace()
        {
            var resp = await _inTouch.Groups.EditPlace(new GroupsEditPlaceParams { GroupId = 1 });

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.Success, "resp.Data.Success");
            IsNotEmpty(resp.Data.Address, "resp.Data.Address");
        }

        [Test]
        public async Task GetSettings()
        {
            var resp = await _inTouch.Groups.GetSettings(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Title, "resp.Data.Title");
            IsTrue(resp.Data.Wall, "resp.Data.Wall");
            IsFalse(resp.Data.Docs, "resp.Data.Docs");
            IsTrue(resp.Data.CountryId == 0, "resp.Data.CountryId == 0");
        }

        [Test]
        public async Task GetRequests()
        {
            var resp = await _inTouch.Groups.GetRequests(1);

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
            Ex.TestUser(resp.Data.Items[1]);
        }

        [Test]
        public async Task EditManager()
        {
            var resp = await _inTouch.Groups.EditManager(new GroupsEditManagerParams { GroupId = 1, UserId = 12345 });

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task Invite()
        {
            var resp = await _inTouch.Groups.Invite(1, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task AddLink()
        {
            var resp = await _inTouch.Groups.AddLink(1, "https://github.com/virtyaluk");

            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.EditTitle, "resp.Data.EditTitle");
            IsTrue(resp.Data.ImageProcessing, "resp.Data.ImageProcessing");
            IsNotEmpty(resp.Data.Url, "resp.Date.Url");
            IsTrue(resp.Data.Id == 124, "resp.Data.Id == 124");
        }

        [Test]
        public async Task EditLink()
        {
            var resp = await _inTouch.Groups.EditLink(1, 134);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task DeleteLink()
        {
            var resp = await _inTouch.Groups.DeleteLink(1, 134);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ReorderLink()
        {
            var resp = await _inTouch.Groups.ReorderLink(1, 134);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task RemoveUser()
        {
            var resp = await _inTouch.Groups.RemoveUser(1, 12345);

            IsFalse(resp.IsError, "resp.IsError");
            IsTrue(resp.Data, "resp.Data");
        }

        [Test]
        public async Task ApproveRequest()
        {
            var resp = await _inTouch.Groups.ApproveRequest(1, 12345);

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
