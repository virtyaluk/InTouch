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
            var mockHttp = new MockHttpMessageHandler();

            switch (cat)
            {
                case "users":
                {
                    mockHttp
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
                    mockHttp
                        .WhenAndRespond($"{cat}.checkLink", Responses.GetString("linkStatus"))
                        .WhenAndRespond($"{cat}.resolveScreenName", Responses.GetString("objectInfo"))
                        .WhenAndRespond($"{cat}.getServerTime", Responses.GetString("serverTime"));
                    break;

                case "gifts":
                    mockHttp.WhenAndRespond($"{cat}.get", Responses.GetString("giftsItemsList"));
                    break;

                case "storage":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("storageValsList"))
                        .WhenAndRespond($"{cat}.set", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getKeys", Responses.GetString("stringsList"));
                    break;

                case "polls":
                    mockHttp
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("poll"))
                        .WhenAndRespond($"{cat}.addVote", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteVote", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getVoters", Responses.GetString("pollVoters"))
                        .WhenAndRespond($"{cat}.create", Responses.GetString("poll"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"));
                    break;

                case "status":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("userStatus"))
                        .WhenAndRespond($"{cat}.set", Responses.GetString("responseTrue"));
                    break;

                case "database":
                    mockHttp
                        .WhenAndRespond($"{cat}.getCountries", Responses.GetString("countriesItemsList"))
                        .WhenAndRespond($"{cat}.getRegions", Responses.GetString("regionsItemsList"))
                        .WhenAndRespond($"{cat}.getStreetsById", Responses.GetString("streetsList"))
                        .WhenAndRespond($"{cat}.getCountriesById", Responses.GetString("countriesList"))
                        .WhenAndRespond($"{cat}.getCities", Responses.GetString("citiesItemsList"))
                        .WhenAndRespond($"{cat}.getCitiesById", Responses.GetString("citiesList"))
                        .WhenAndRespond($"{cat}.getUniversities", Responses.GetString("universitiesItemsList"))
                        .WhenAndRespond($"{cat}.getSchools", Responses.GetString("schoolsItemsList"))
                        .WhenAndRespond($"{cat}.getFaculties", Responses.GetString("facultiesItemsList"))
                        .WhenAndRespond($"{cat}.getChairs", Responses.GetString("chairsItemsList"));
                    break;

                case "account":
                    mockHttp
                        .WhenAndRespond($"{cat}.getCounters", Responses.GetString("accountCounters"))
                        .WhenAndRespond($"{cat}.setNameInMenu", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.setOnline", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.setOffline", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.lookupContacts", Responses.GetString("accountContacts"))
                        .WhenAndRespond($"{cat}.registerDevice", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unregisterDevice", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.setSilenceMode", Responses.GetString("responseTrue"))
                        //.WhenAndRespond($"{cat}.getPushSettings", Responses.GetString(""))
                        .WhenAndRespond($"{cat}.setPushSettings", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getAppPermissions", Responses.GetString("appPermissions"))
                        .WhenAndRespond($"{cat}.banUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unbanUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getBanned", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.getInfo", Responses.GetString("accountInfo"))
                        .WhenAndRespond($"{cat}.setInfo", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.changePassword", Responses.GetString("changePassword"))
                        .WhenAndRespond($"{cat}.getProfileInfo", Responses.GetString("profileInfo"))
                        .WhenAndRespond($"{cat}.saveProfileInfo", Responses.GetString("setProfileInfo"));
                    break;
            }

            var client = new InTouch(mockHttp, 12345, "super_secret");

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

        public static void TestPoll(Poll poll)
        {
            IsNotNull(poll, "poll != null");
            IsTrue(poll.OwnerId == -26406986, "poll.OwnerId == -26406986");
            IsTrue(poll.PollId == 222496894, "poll.Id == 222496894");
            IsNotNull(poll.Created, "poll.Created != null");
            IsNotEmpty(poll.Question, "poll.Question");
            IsTrue(poll.Votes == 3911, "poll.Votes == 3911");
            IsNotNull(poll.Answers, "poll.Answers != null");
            IsNotEmpty(poll.Answers, "poll.Answers");
            IsNotNull(poll.Answers[0], "poll.Answers[0] != null");
            IsTrue(poll.Answers[0].Id == 739902439, "poll.Answers[0].Id == 739902439");
            IsTrue(poll.Answers[0].Votes == 401, "poll.Answers[0].Votes == 401");
            IsTrue(Math.Abs(poll.Answers[0].Rate - 10.25) < double.Epsilon, "Math.Abs(poll.Answers[0].Rate - 10.25) < double.Epsilon");
        }
    }
}