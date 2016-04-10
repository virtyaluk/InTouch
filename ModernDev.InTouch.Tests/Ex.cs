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

using System.Resources;
using RichardSzalay.MockHttp;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    public static class Ex
    {
        public static MockHttpMessageHandler WhenAndRespond(this MockHttpMessageHandler @this, string url, string json)
        {
            @this.When($"/method/{url}.json").Respond("application/json", json);

            return @this;
        }

        public static ResourceManager Responses { get; } = MockJsonResponses.ResourceManager;

        public static InTouch GetMockedClient(string cat = null, bool setSessionData = true)
        {
            var mochHttp = new MockHttpMessageHandler();

            switch (cat)
            {
                case "users":
                {
                    mochHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("usersList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.isAppUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getSubscriptions", Responses.GetString("profilesMixedList"))
                        .WhenAndRespond($"{cat}.getFollowers", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.report", Responses.GetString("responseFalse"))
                        .WhenAndRespond($"{cat}.getNearby", Responses.GetString("usersItemsList"));
                    }
                    break;

                case "utils":
                    mochHttp
                        .WhenAndRespond($"{cat}.checkLink", Responses.GetString("linkStatus"))
                        .WhenAndRespond($"{cat}.resolveScreenName", Responses.GetString("objectInfo"))
                        .WhenAndRespond($"{cat}.getServerTime", Responses.GetString("serverTime"));
                    break;

                case "gifts":
                    mochHttp.WhenAndRespond($"{cat}.get", Responses.GetString("giftsItemsList"));
                    break;
            }

            var client = new InTouch(mochHttp, 12345, "super_secret");

            if (setSessionData)
            {
                client.SetSessionData("super_secret_access_token", 1);
            }

            return client;
        }

        public static void TestUser(User user)
        {
            IsNotNull(user, "user != null");
            IsFalse(user.Blacklisted, "user.Blacklisted");
            IsNotNull(user.LastSeen, "user.LastSeen != null");
            IsFalse(user.Verified, "user.Verified");
            IsTrue(user.MobilePhone == "+48 794756099", "user.MobilePhone == '+48 794756099'");
            IsNotEmpty(user.Photo100, nameof(user.Photo100));
            IsTrue(user.CommonCount == 6, "user.CommonCount == 6");
            IsNotNull(user.Country, "user.Country != null");
            IsTrue(user.Country.Id == 160, "user.Country.Id == 160");
            IsTrue(user.WallCommentsAllowed, "user.WallCommentsAllowed");
            IsNotNull(user.Occupation, "user.Occupation != null");
            IsTrue(user.Occupation.Type == OccupationTypes.University, "user.Occupation.Type == OccupationTypes.University");
            IsNotNull(user.Personal, "user.Personal != null");
            IsTrue(user.Personal.Political == UserPersonalPoliticalViewsTypes.Moderate, "user.Personal.Political == UserPersonalPoliticalViewsTypes.Moderate");
            IsNotNull(user.Personal.Langs, "user.Personal.Langs != null");
            IsTrue(user.Personal.Langs.Count == 3, nameof(user.Personal.Langs));
            IsNotEmpty(user.Games, nameof(user.Games));
            IsNotNull(user.Universities, "user.Universities != null");
            IsNotEmpty(user.Universities, nameof(user.Universities));
            IsTrue(user.Universities[0].Id == 1172960, "user.Universities[0].Id == 1172960");
            IsNotNull(user.Schools, "user.Schools != null");
            IsNotEmpty(user.Schools, nameof(user.Schools));
            IsTrue(user.Schools[0].Id == 253181, "user.Schools[0].Id == 253181");
            IsNotNull(user.Relatives, nameof(user.Relatives));
            IsNotEmpty(user.Relatives, nameof(user.Relatives));
            IsTrue(user.Relatives[0].Type == RelativeTypes.Sibling, "user.Relatives[0].Type == RelativeTypes.Sibling");
            IsFalse(user.Online, "user.Online");
            IsNotNull(user.Lists, "user.Lists != null");
            IsNotEmpty(user.Lists);
            IsTrue(user.Lists[0] == 2, "user.Lists[0] == 2");
        }

        public static void TestGroup(Group group)
        {
            IsNotNull(group, "group != null");
            IsTrue(group.Id == 65596623, "group.Id == 65596623");
            IsTrue(group.Type == CommunityTypes.Page, "group.Type == CommunityTypes.Page");
            IsNotNull(group.StartDate, "group.StartDate != null");
            IsFalse(group.CanPost, "group.CanPost");
            IsNotNull(group.Contacts, "group.Contacts != null");
            IsNotEmpty(group.Contacts, nameof(group.Contacts));
            IsTrue(group.Contacts[0].UserId == 171605462, "group.Contacts[0].UserId == 171605462");
            IsTrue(group.CanSeeAllPosts, "group.CanSeeAllPosts");
            IsTrue(group.MainAlbumId == 219302511, "group.MainAlbumId == 219302511");
            IsNotEmpty(group.Photo100, nameof(group.Photo100));
        }
    }
}