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
using System.Net;
using System.Resources;
using RichardSzalay.MockHttp;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    public static class Ex
    {
        private static MockHttpMessageHandler WhenAndRespond(this MockHttpMessageHandler @this, string url, string json)
        {
            @this.When($"/method/{url}").Respond("application/json", json);

            return @this;
        }

        private static ResourceManager Responses { get; } = MockJsonResponses.ResourceManager;

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
                        .WhenAndRespond($"{cat}.getAppPermissions", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.banUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unbanUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getBanned", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.getInfo", Responses.GetString("accountInfo"))
                        .WhenAndRespond($"{cat}.setInfo", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.changePassword", Responses.GetString("changePassword"))
                        .WhenAndRespond($"{cat}.getProfileInfo", Responses.GetString("profileInfo"))
                        .WhenAndRespond($"{cat}.saveProfileInfo", Responses.GetString("setProfileInfo"));
                    break;

                case "audio":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("audioItemsList"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("audioList"))
                        .WhenAndRespond($"{cat}.getLyrics", Responses.GetString("audioLyrics"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("audioItemsList"))
                        .WhenAndRespond($"{cat}.getUploadServer", Responses.GetString("uploadServer"))
                        .WhenAndRespond($"{cat}.save", Responses.GetString("audio"))
                        .WhenAndRespond($"{cat}.add", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.reorder", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restore", Responses.GetString("audio"))
                        .WhenAndRespond($"{cat}.getAlbums", Responses.GetString("audioAlbumItemsList"))
                        .WhenAndRespond($"{cat}.addAlbum", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.editAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.moveToAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.setBroadcast", Responses.GetString("responseNumsList"))
                        .WhenAndRespond($"{cat}.getBroadcastList", Responses.GetString("broadcastList"))
                        .WhenAndRespond($"{cat}.getRecommendations", Responses.GetString("audioItemsList"))
                        .WhenAndRespond($"{cat}.getPopular", Responses.GetString("audioList"))
                        .WhenAndRespond($"{cat}.getCount", Responses.GetString("responseNum"));
                    break;

                case "auth":
                    mockHttp
                        .WhenAndRespond($"{cat}.checkPhone", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.signup", Responses.GetString("authStatus"))
                        .WhenAndRespond($"{cat}.confirm", Responses.GetString("authStatus"))
                        .WhenAndRespond($"{cat}.restore", Responses.GetString("authStatus"));
                    break;

                case "board":
                    mockHttp
                        .WhenAndRespond($"{cat}.getTopics", Responses.GetString("topicItemsList"))
                        .WhenAndRespond($"{cat}.getComments", Responses.GetString("commentItemsList"))
                        .WhenAndRespond($"{cat}.addTopic", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.addComment", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.deleteTopic", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.editTopic", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.editComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restoreComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.openTopic", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.closeTopic", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.fixTopic", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unfixTopic", Responses.GetString("responseTrue"));
                    break;

                case "docs":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("docsItemsList"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("docsList"))
                        .WhenAndRespond($"{cat}.getUploadServer", Responses.GetString("uploadServer"))
                        .WhenAndRespond($"{cat}.getWallUploadServer", Responses.GetString("uploadServer"))
                        .WhenAndRespond($"{cat}.save", Responses.GetString("docsList"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.add", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.getTypes", Responses.GetString("typesItemsList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("docsItemsList"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"));
                    break;

                case "friends":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.getOnline", Responses.GetString("usersOnline"))
                        .WhenAndRespond($"{cat}.getMutual", Responses.GetString("mutualFriends"))
                        .WhenAndRespond($"{cat}.getRecent", Responses.GetString("responseNumsList"))
                        .WhenAndRespond($"{cat}.getRequests", Responses.GetString("requestsItemsList"))
                        .WhenAndRespond($"{cat}.add", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("friendDeleteStatus"))
                        .WhenAndRespond($"{cat}.getLists", Responses.GetString("friendsLists"))
                        .WhenAndRespond($"{cat}.addList", Responses.GetString("addFriendsList"))
                        .WhenAndRespond($"{cat}.editList", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteList", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getAppUsers", Responses.GetString("responseNumsList"))
                        .WhenAndRespond($"{cat}.getByPhones", Responses.GetString("usersList"))
                        .WhenAndRespond($"{cat}.deleteAllRequests", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getSuggestions", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.areFriends", Responses.GetString("areFriends"))
                        .WhenAndRespond($"{cat}.getAvailableForCall", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("usersItemsList"));
                    break;

                case "groups":
                    mockHttp
                        .WhenAndRespond($"{cat}.isMember", Responses.GetString("groupIsMember"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("groupsList"))
                        .WhenAndRespond($"{cat}.get", Responses.GetString("groupsItemsList"))
                        .WhenAndRespond($"{cat}.getMembers", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.join", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.leave", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("groupsItemsList"))
                        .WhenAndRespond($"{cat}.getCatalog", Responses.GetString("groupsItemsList"))
                        .WhenAndRespond($"{cat}.getCatalogInfo", Responses.GetString("groupsCatalogInfo"))
                        .WhenAndRespond($"{cat}.getInvites", Responses.GetString("groupsItemsList"))
                        .WhenAndRespond($"{cat}.getInvitedUsers", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.banUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unbanUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getBanned", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.create", Responses.GetString("group"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.editPlace", Responses.GetString("editPlace"))
                        .WhenAndRespond($"{cat}.getSettings", Responses.GetString("groupSettings"))
                        .WhenAndRespond($"{cat}.getRequests", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.editManager", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.invite", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.addLink", Responses.GetString("groupAddLink"))
                        .WhenAndRespond($"{cat}.deleteLink", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.editLink", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reorderLink", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.approveRequest", Responses.GetString("responseTrue"));
                    break;

                case "likes":
                    mockHttp
                        .WhenAndRespond($"{cat}.getList", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.add", Responses.GetString("likesCount"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("likesCount"))
                        .WhenAndRespond($"{cat}.isLiked", Responses.GetString("isLiked"));
                    break;

                case "wall":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("postsItemsList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("postsItemsList"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("postsItemsList"))
                        .WhenAndRespond($"{cat}.post", Responses.GetString("wallPost"))
                        .WhenAndRespond($"{cat}.repost", Responses.GetString("wallPost"))
                        .WhenAndRespond($"{cat}.getReposts", Responses.GetString("postsItemsList"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restore", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.pin", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unpin", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getComments", Responses.GetString("commentItemsList"))
                        .WhenAndRespond($"{cat}.addComment", Responses.GetString("addComment"))
                        .WhenAndRespond($"{cat}.editComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restoreComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reportPost", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reportComment", Responses.GetString("responseTrue"));
                    break;

                case "video":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("videosItemsList"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.add", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.save", Responses.GetString("videoSave"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restore", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("videosItemsList"))
                        .WhenAndRespond($"{cat}.getUserVideos", Responses.GetString("videosItemsList"))
                        .WhenAndRespond($"{cat}.getAlbums", Responses.GetString("videoAlbumsItemsList"))
                        .WhenAndRespond($"{cat}.getAlbumById", Responses.GetString("videoAlbum"))
                        .WhenAndRespond($"{cat}.addAlbum", Responses.GetString("videoAddAlbum"))
                        .WhenAndRespond($"{cat}.editAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reorderAlbums", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reorderVideos", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.addToAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeFromAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getAlbumsByVideo", Responses.GetString("videoAlbumsItemsList"))
                        .WhenAndRespond($"{cat}.getComments", Responses.GetString("commentItemsList"))
                        .WhenAndRespond($"{cat}.createComment", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.deleteComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restoreComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.editComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getTags", Responses.GetString("videoTags"))
                        .WhenAndRespond($"{cat}.putTag", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeTag", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getNewTags", Responses.GetString("videosItemsList"))
                        .WhenAndRespond($"{cat}.report", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reportComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getCatalog", Responses.GetString("videoCatalog"))
                        .WhenAndRespond($"{cat}.getCatalogSection", Responses.GetString("videoCatalogSection"))
                        .WhenAndRespond($"{cat}.hideCatalogSection", Responses.GetString("responseTrue"));
                    break;

                case "stats":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("stats"))
                        .WhenAndRespond($"{cat}.trackVisitor", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getPostReach", Responses.GetString("postReach"));
                    break;

                case "search":
                    mockHttp.WhenAndRespond($"{cat}.getHints", Responses.GetString("searchHints"));
                    break;

                case "places":
                    mockHttp
                        .WhenAndRespond($"{cat}.add", Responses.GetString("placeAdd"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("placesList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("placesItemsList"))
                        .WhenAndRespond($"{cat}.checkin", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.getCheckins", Responses.GetString("checkinsItemsList"))
                        .WhenAndRespond($"{cat}.getTypes", Responses.GetString("placeTypes"));
                    break;
                case "photos":
                    mockHttp
                        .WhenAndRespond($"{cat}.createAlbum", Responses.GetString("photoAlbum"))
                        .WhenAndRespond($"{cat}.editAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getAlbums", Responses.GetString("photoAlbumsItemsList"))
                        .WhenAndRespond($"{cat}.get", Responses.GetString("photosItemsList"))
                        .WhenAndRespond($"{cat}.getAlbumsCount", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("photosList"))
                        .WhenAndRespond($"{cat}.getUploadServer", Responses.GetString("photosUploadServer"))
                        .WhenAndRespond($"{cat}.getOwnerPhotoUploadServer", Responses.GetString("photosUploadServer"))
                        .WhenAndRespond($"{cat}.getChatUploadServer", Responses.GetString("photosUploadServer"))
                        .WhenAndRespond($"{cat}.getMarketUploadServer", Responses.GetString("photosUploadServer"))
                        .WhenAndRespond($"{cat}.getMarketAlbumUploadServer", Responses.GetString("photosUploadServer"))
                        .WhenAndRespond($"{cat}.saveMarketPhoto", Responses.GetString("photosList"))
                        .WhenAndRespond($"{cat}.saveMarketAlbumPhoto", Responses.GetString("photosList"))
                        .WhenAndRespond($"{cat}.saveOwnerPhoto", Responses.GetString("saveOwnerPhoto"))
                        .WhenAndRespond($"{cat}.saveWallPhoto", Responses.GetString("photosList"))
                        .WhenAndRespond($"{cat}.getWallUploadServer", Responses.GetString("photosUploadServer"))
                        .WhenAndRespond($"{cat}.getMessagesUploadServer", Responses.GetString("photosUploadServer"))
                        .WhenAndRespond($"{cat}.saveMessagesPhoto", Responses.GetString("photosList"))
                        .WhenAndRespond($"{cat}.report", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reportComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("photosItemsList"))
                        .WhenAndRespond($"{cat}.save", Responses.GetString("photosList"))
                        .WhenAndRespond($"{cat}.copy", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.move", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.makeCover", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reorderAlbums", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reorderPhotos", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getAll", Responses.GetString("photosItemsList"))
                        .WhenAndRespond($"{cat}.getUserPhotos", Responses.GetString("photosItemsList"))
                        .WhenAndRespond($"{cat}.deleteAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restore", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.confirmTag", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getComments", Responses.GetString("commentItemsList"))
                        .WhenAndRespond($"{cat}.getAllComments", Responses.GetString("commentItemsList"))
                        .WhenAndRespond($"{cat}.createComment", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.deleteComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restoreComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.editComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getTags", Responses.GetString("photoTags"))
                        .WhenAndRespond($"{cat}.putTag", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.removeTag", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getNewTags", Responses.GetString("photosItemsList"));
                    break;

                case "pages":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("wikiPage"))
                        .WhenAndRespond($"{cat}.save", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.saveAccess", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.getHistory", Responses.GetString("wikiHistory"))
                        .WhenAndRespond($"{cat}.getTitles", Responses.GetString("wikiTitles"))
                        .WhenAndRespond($"{cat}.getVersion", Responses.GetString("wikiPage"))
                        .WhenAndRespond($"{cat}.parseWiki", Responses.GetString("responseText"))
                        .WhenAndRespond($"{cat}.clearCache", Responses.GetString("responseTrue"));
                    break;

                case "notifications":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("notifications"))
                        .WhenAndRespond($"{cat}.markAsViewed", Responses.GetString("responseTrue"));
                    break;

                case "notes":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("notesItemsList"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("note"))
                        .WhenAndRespond($"{cat}.add", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getComments", Responses.GetString("commentItemsList"))
                        .WhenAndRespond($"{cat}.createComment", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.editComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restoreComment", Responses.GetString("responseTrue"));
                    break;

                case "newsfeed":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("newsItemsList"))
                        .WhenAndRespond($"{cat}.getRecommended", Responses.GetString("newsItemsList"))
                        .WhenAndRespond($"{cat}.getComments", Responses.GetString("newsItemsList"))
                        .WhenAndRespond($"{cat}.getMentions", Responses.GetString("mentionsItemsList"))
                        .WhenAndRespond($"{cat}.getBanned", Responses.GetString("separatedProfilesList"))
                        .WhenAndRespond($"{cat}.addBan", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteBan", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.ignoreItem", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unignoreItem", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("newsItemsList"))
                        .WhenAndRespond($"{cat}.getLists", Responses.GetString("newsLists"))
                        .WhenAndRespond($"{cat}.saveList", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.deleteList", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.unsubscribe", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getSuggestedSources", Responses.GetString("mixedProfilesList"));
                    break;

                case "messages":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("messagesItemsList"))
                        .WhenAndRespond($"{cat}.getDialogs", Responses.GetString("dialogsItemsList"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("messagesItemsList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("messagesItemsList"))
                        .WhenAndRespond($"{cat}.getHistory", Responses.GetString("messagesItemsList"))
                        .WhenAndRespond($"{cat}.getHistoryAttachments", Responses.GetString("attachmentsItemsList"))
                        .WhenAndRespond($"{cat}.send", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.sendSticker", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteDialog", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restore", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.markAsRead", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.markAsImportant", Responses.GetString("responseNumsList"))
                        .WhenAndRespond($"{cat}.getLongPollServer", Responses.GetString("messagesLongPollServer"))
                        .WhenAndRespond($"{cat}.getLongPollHistory", Responses.GetString("messagesLongPollHistory"))
                        .WhenAndRespond($"{cat}.getChat", Responses.GetString("chat"))
                        .WhenAndRespond($"{cat}.createChat", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.editChat", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getChatUsers", Responses.GetString("usersList"))
                        .WhenAndRespond($"{cat}.setActivity", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.searchDialogs", Responses.GetString("searchDialogs"))
                        .WhenAndRespond($"{cat}.addChatUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeChatUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getLastActivity", Responses.GetString("userLastActivity"))
                        .WhenAndRespond($"{cat}.setChatPhoto", Responses.GetString("newChatPhoto"))
                        .WhenAndRespond($"{cat}.deleteChatPhoto", Responses.GetString("newChatPhoto"));
                    break;

                case "fave":
                    mockHttp
                        .WhenAndRespond($"{cat}.getUsers", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.getPhotos", Responses.GetString("photosItemsList"))
                        .WhenAndRespond($"{cat}.getPosts", Responses.GetString("postsItemsList"))
                        .WhenAndRespond($"{cat}.getVideos", Responses.GetString("videosItemsList"))
                        .WhenAndRespond($"{cat}.getLinks", Responses.GetString("linksItemsList"))
                        .WhenAndRespond($"{cat}.getMarketItems", Responses.GetString("marketItemsList"))
                        .WhenAndRespond($"{cat}.addUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.addGroup", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeGroup", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.addLink", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeLink", Responses.GetString("responseTrue"));
                    break;

                case "market":
                    mockHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("marketItemsList"))
                        .WhenAndRespond($"{cat}.getById", Responses.GetString("marketItemsList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("marketItemsList"))
                        .WhenAndRespond($"{cat}.getAlbums", Responses.GetString("marketAlbumsItemsList"))
                        .WhenAndRespond($"{cat}.getAlbumById", Responses.GetString("marketAlbumsItemsList"))
                        .WhenAndRespond($"{cat}.createComment", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.getComments", Responses.GetString("commentItemsList"))
                        .WhenAndRespond($"{cat}.deleteComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restoreComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.editComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reportComment", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getCategories", Responses.GetString("marketCategories"))
                        .WhenAndRespond($"{cat}.report", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.add", Responses.GetString("responseNum"))
                        .WhenAndRespond($"{cat}.edit", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.delete", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.restore", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reorderItems", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.reorderAlbums", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.addAlbum", Responses.GetString("addMarketAlbum"))
                        .WhenAndRespond($"{cat}.editAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.deleteAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.removeFromAlbum", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.addToAlbum", Responses.GetString("responseTrue"));
                    break;

                default:
                    mockHttp
                        .WhenAndRespond("test", Responses.GetString("responseTrue"))
                        .WhenAndRespond("users.get", Responses.GetString("apiError5"))
                        .WhenAndRespond("users.search", Responses.GetString("apiError14"))
                        .WhenAndRespond("users.isAppUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond("users.getFollowers", Responses.GetString("usersItemsList"))
                        .When("/method/test2.json").Respond(HttpStatusCode.BadRequest);
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
            IsTrue(user.Occupation.Type == OccupationTypes.University,
                "user.Occupation.Type == OccupationTypes.University");
            IsNotNull(user.Personal, "user.Personal != null");
            IsTrue(user.Personal.Political == UserPersonalPoliticalViewsTypes.Moderate,
                "user.Personal.Political == UserPersonalPoliticalViewsTypes.Moderate");
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
            IsTrue(Math.Abs(poll.Answers[0].Rate - 10.25) < double.Epsilon,
                "Math.Abs(poll.Answers[0].Rate - 10.25) < double.Epsilon");
        }

        public static void TestAudio(Audio audio)
        {
            IsNotNull(audio, "audio != null");
            IsTrue(audio.Id == 456239447, "audio.Id == 456239447");
            IsTrue(audio.Artist == "Ghastly", "audio.Artist == 'Ghastly'");
            IsTrue(audio.Duration == 249, "audio.Duration == 249");
            IsNotNull(audio.Date, "audio.Date != null");
            IsNotEmpty(audio.Url, "audio.Url");
        }

        public static void TestComment(Comment comment)
        {
            IsNotNull(comment, "comment != null");
            IsTrue(comment.Id == 85995, "comment.Id == 85995");
            IsNotNull(comment.Date, "comment.Date != null");
            IsNotEmpty(comment.Text, "comment.Text");
            IsNotNull(comment.Likes, "comment.Likes != null");
            IsTrue(comment.Likes.Count == 0, "comment.Likes.Count == 0");
            IsFalse(comment.Likes.UserLikes, "comment.Likes.UserLikes");
            IsFalse(comment.CanEdit, "comment.CanEdit");
            IsNotEmpty(comment.Attachments, "comment.Attachments != null");
        }

        public static void TestPhotoAttachments(Photo photo)
        {
            IsNotNull(photo, "photo != null");
            IsTrue(photo.Id == 410545563, "photo.Id == 410545563");
            IsNotEmpty(photo.Photo75, "photo.Photo75");
            IsNotNull(photo.Date, "photo.Date != null");
            IsNotEmpty(photo.AccessKey, "photo.AccessKey");
        }

        public static void TestVideoAttachment(Video video)
        {
            IsNotNull(video, "video != null");
            IsTrue(video.Id == 172047301, "video.Id == 172047301");
            IsTrue(video.Duration == 9, "video.Duration == 9");
            IsNotNull(video.Date, "video.Date != null");
            IsFalse(video.CanAdd, "video.CanAdd");
        }

        public static void TestLinkAttachment(Link link)
        {
            IsNotNull(link, "link != null");
            IsNotEmpty(link.Url, "link.Url");
            IsNotEmpty(link.Title, "link.Title");
            IsNotNull(link.Photo, "link.Photo != null");
        }

        public static void TestDoc(Doc doc)
        {
            IsNotNull(doc, "doc != null");
            IsTrue(doc.Id == 437429925, "doc.Id == 437429925");
            IsNotEmpty(doc.Title, "doc.Title");
            IsNotNull(doc.Preview, "doc.Preview != null");
            IsNotNull(doc.Preview.Video, "doc.Preview.Video != null");
            IsNotEmpty(doc.Preview.Video.Src, "doc.Preview.Video.Src");
            IsTrue(doc.Preview.Video.FileSize == 80787, "doc.Preview.Video.FileSize == 80787");
            IsNotNull(doc.Preview.Photo, "doc.Preview.Photo != null");
            IsNotEmpty(doc.Preview.Photo.Sizes, "doc.Preview.Photo.Sizes");
            IsTrue(doc.Preview.Photo.Sizes[0].Type == PhotoSizeTypes.M,
                "doc.Preview.Photo.Sizes[0].Type == PhotoSizeTypes.M");
            IsNotEmpty(doc.Preview.Photo.Sizes[0].Src, "doc.Preview.Photo.Sizes[0].Src");
        }

        public static void TestWallPost(Post post)
        {
            IsNotNull(post, "post != null");
            IsTrue(post.Id == 8226, "post.Id == 8226");
            IsTrue(post.PostType == PostTypes.Post, "post.PostType == PostTypes.Post");
            IsNotEmpty(post.Text, "post.Text");
            IsTrue(post.CanEdit, "post.CanEdit");

            // attachments
            IsNotEmpty(post.Attachments, "post.Attachments");
            IsInstanceOf<Photo>(post.Attachments[0], "post.Attachments[0] instanceOf Photo");
            IsTrue(((Photo) post.Attachments[0]).Id == 412644711, "((Photo) post.Attachments[0]).Id == 412644711");
            IsInstanceOf<Video>(post.Attachments[1], "post.Attachments[1] instanceOf Video");
            IsTrue(((Video) post.Attachments[1]).CanAdd, "((Video) post.Attachments[1]).CanAdd");

            // geo
            IsNotNull(post.Geo, "post.Geo != null");
            IsTrue(post.Geo.Type == "point", "post.Geo.Type == 'point'");
            IsNotNull(post.Geo.Coordinates, "post.Geo.Coordinates != null");
            IsNotNull(post.Geo.Place, "post.Geo.Place != null");
            IsTrue(post.Geo.Place.Id == 0, "post.Geo.Place.Id == 0");
            IsTrue(post.Geo.Place.City == "Киев", "post.Geo.Place.City == 'Киев'");
            IsTrue(post.Geo.Showmap, "post.Geo.Showmap");

            // post_source
            IsNotNull(post.PostSource, "post.PostSource != null");
            IsTrue(post.PostSource.Type == PostSoureTypes.VK, "post.PostSource.Type == PostSoureTypes.VK");

            // comments
            IsNotNull(post.Comments, "post.Comments != null");
            IsTrue(post.Comments.Count == 0, "post.Comments.Count == 0");
            IsFalse(post.Comments.CanPost, "post.Comments.CanPost");

            // likes
            IsNotNull(post.Likes, "post.Likes != null");
            IsTrue(post.Likes.Count == 0, "post.Likes.Count == 0");
            IsFalse(post.Likes.UserLikes, "post.Likes.UserLikes");

            // reposts
            IsNotNull(post.Reposts, "post.Reposts != null");
            IsTrue(post.Reposts.Count == 0, "post.Reposts.Count == 0");
            IsFalse(post.Reposts.UserReposted, "post.Reposts.UserReposted");
        }

        public static void TestVideo(Video video)
        {
            IsNotNull(video, "video != null");
            IsTrue(video.Id == 456239064, "video.Id == 456239064");
            IsFalse(video.Repeat, "video.Repeat");
            IsNotEmpty(video.Title, "video.Title");
            IsNotNull(video.Date, "video.Date != null");
            IsNotNull(video.Likes, "video.Likes != null");
            IsFalse(video.Likes.UserLikes, "video.Likes.UserLikes");
            IsNotNull(video.PrivacyView, "video.PrivacyView != null");
            IsTrue(video.PrivacyView.Contains("all"), "video.PrivacyView.Contains('all')");
        }

        public static void TestVideoAlbum(VideoAlbum album)
        {
            IsNotNull(album, "album != null");
            IsTrue(album.Id == 38887239, "album.Id == 38887239");
            IsTrue(album.Title == "test", "album.Title == 'test'");
            IsNotNull(album.UpdatedTime, "album.UpdatedTime != null");
            IsTrue(album.Privacy.Contains("only_me"), "album.Privacy.Contains('only_me')");
        }

        public static void TestPhotoAlbum(PhotoAlbum album)
        {
            IsNotNull(album, "album != null");
            IsTrue(album.Id == 230870814, "album.Id == 230870814");
            IsTrue(album.Title == "Test Album", "album.Title == 'Test Album'");
            IsNotNull(album.Created, "album.Created != null");
            IsTrue(album.PrivacyView.Contains("friends"), "album.PrivacyView.Contains('friends')");

            if (album.Sizes != null)
            {
                IsNotEmpty(album.Sizes, "album.Sizes");
                IsNotNull(album.Sizes[0], "album.Sizes[0] != null");
                IsNotEmpty(album.Sizes[0].Src, "album.Sizes[0].Src");
                IsTrue(album.Sizes[0].Width == 75, "album.Sizes[0].Width == 75");
                IsTrue(album.Sizes[0].Type == PhotoSizeTypes.S, "album.Sizes[0].Type == PhotoSizeTypes.S");
            }
        }

        public static void TestPhoto(Photo photo)
        {
            IsNotNull(photo, "photo != null");
            IsTrue(photo.Id == 397256148, "photo.Id == 397256148");
            IsNotEmpty(photo.Sizes, "photo.Sizes != null");
            IsNotNull(photo.Sizes[0], "photo.Sizes[0] != null");
            IsTrue(photo.Sizes[0].Width == 87, "photo.Sizes[0].Width == 87");
            IsTrue(photo.Sizes[0].Type == PhotoSizeTypes.M, "photo.Sizes[0].Type == PhotoSizeTypes.M");
            IsNotEmpty(photo.Text, "photo.Text");
            IsNotNull(photo.Date, "photo.Date != null");
            IsNotNull(photo.Likes, "photo.Likes != null");
            IsFalse(photo.Likes.UserLikes, "photo.Likes.UserLikes");
            IsNotNull(photo.Reposts, "photo.Reposts != null");
            IsTrue(photo.Reposts.Count == 0, "photo.Reposts.Count == 0");
            IsNotNull(photo.Comments, "photo.Comments != null");
            IsTrue(photo.Comments.Count == 0, "photo.Comments.Count == 0");
            IsTrue(photo.CanComment, "photo.CanComment");
            IsNotNull(photo.Tags, "photo.Tags != null");
            IsTrue(photo.Tags.Count == 0, "photo.Tags.Count == 0");
        }

        public static void TestWikiPage(Page page)
        {
            IsNotNull(page, "page != null");
            IsTrue(page.Id == 48646066, "page.Id == 48646066");
            IsTrue(page.Title == "book", "page.Title == 'book'");
            IsTrue(page.WhoCanView == CommunityAccessTypes.Everyone, "page.WhoCanView == CommunityAccessTypes.Everyone");
            IsNotNull(page.Created, "page.Created != null");
        }

        public static void TestNote(Note note)
        {
            IsNotNull(note, "note != null");
            IsTrue(note.Id == 11096473, "note.Id == 11096473");
            IsNotNull(note.Date, "note.Date != null");
            IsTrue(note.Text == "note html", "note.Text == 'note html'");
        }

        public static void TestNewsPost(NewsPost post)
        {
            IsNotNull(post, "news != null");
            IsTrue(post.Type == NewsfeedFilters.Video, "post.Type == NewsfeedFilters.Video");
            IsTrue(post.SourceId == -2682332, "post.SourceId == -2682332");
            IsNotNull(post.Date, "post.Date != null");
            IsNotNull(post.Video, "post.Video != null");
            IsNotEmpty(post.Video.Items, "post.Video.Items");
            IsNotNull(post.Video.Items[0], "post.Video.Items[0] != null");
            IsTrue(post.Video.Items[0].Id == 456239274, "post.Video.Items[0].Id == 456239274");
            IsTrue(post.Video.Items[0].CanAdd, "post.Video.Items[0].CanAdd");
            IsNotEmpty(post.Video.Items[0].Title, "post.Video.Items[0].Title");
            IsNotNull(post.Video.Items[0].Date, "post.Video.Items[0].Date != null");
        }

        public static void TestNewsPost2(NewsPost post)
        {
            IsNotNull(post, "post != null");
            IsTrue(post.Type == NewsfeedFilters.Post, "post.Type == NewsfeedFilters.Post");
            IsTrue(post.SourceId == -2682332, "post.SourceId == --2682332");
            IsTrue(post.PostId == 109876, "post.PostId == 109876");
            IsNotEmpty(post.Text, "post.Text");
            IsNotEmpty(post.Attachments, "post.Attachments");
            IsNotNull(post.Likes, "post.Likes != null");
            IsTrue(post.Likes.Count == 0, "post.Likes.Count == 0");
            IsFalse(post.Likes.UserLikes, "post.Likes.UserLikes");
        }

        public static void TestChat(Chat chat)
        {
            IsNotNull(chat, "chat != null");
            IsTrue(chat.Id == 1, "chat.Id == 1");
            IsTrue(chat.Type == "chat", "chat.Type == 'chat'");
            IsNotEmpty(chat.Title, "chat.Title");
            IsTrue(chat.AdminId == 16815310, "chat.AdminId == 16815310");
            IsNotEmpty(chat.Users, "chat.Users");

            if (chat.Users[0] is User)
            {
                IsTrue(((User) chat.Users[0]).Id == 16815310, "((User)chat.Users[0]).Id == 16815310");
            }
        }

        public static void TestMessage(Message msg)
        {
            IsNotNull(msg, "msg != null");
            IsTrue(msg.Id == 147673, "msg.Id == 147673");
            IsNotNull(msg.Date, "msg.Date != null");
            IsTrue(msg.Body == "text", "msg.Body == 'text'");
            IsTrue(msg.Out, "msg.Out");
            IsFalse(msg.ReadState, "msg.ReadState");
            IsNotEmpty(msg.Attachments, "msg.Attachments");
            IsInstanceOf<Photo>(msg.Attachments[0], "msg.Attachments[0] instanceOf Photo");
            TestPhotoAttachments((Photo) msg.Attachments[0]);
            IsInstanceOf<Video>(msg.Attachments[1], "msg.Attachments[1] instanceOf Video");
            TestVideoAttachment((Video) msg.Attachments[1]);
        }

        public static void TestMarketItem(Product item)
        {
            IsNotNull(item, "item != null");
            IsTrue(item.Id == 198, "item.Id == 198");
            IsNotEmpty(item.Title, "item.Title");
            IsNotNull(item.Price, "item.Price != null");
            IsTrue(item.Price.Amount == 235000, "item.Price.Amount == 235000");
            IsNotNull(item.Price.Currency, "item.Price.Currency != null");
            IsTrue(item.Price.Currency.Id == 643, "item.Price.Currency.Id == 643");
            IsNotEmpty(item.Price.Text, "item.Price.Text");
            IsNotEmpty(item.Price.Currency.Name, "item.Price.Currency.Name");
            IsNotNull(item.Category, "item.Category != null");
            IsTrue(item.Category.Id == 1, "item.Category.Id == 1");
            IsNotEmpty(item.Category.Name, "item.Category.Name");
            IsNotNull(item.Category.Section, "item.Category.Section != null");
            IsTrue(item.Category.Section.Id == 0, "item.Category.Section.Id == 0");
            IsNotNull(item.Date, "item.Date != null");
            IsNotEmpty(item.ThumbPhoto, "item.ThumbPhoto");
            IsTrue(item.Availability == ProductAvailability.Available, "item.Availability == ProductAvailability.Available");
            IsNotEmpty(item.AlbumsIds, "item.AlbumsIds");
            IsTrue(item.AlbumsIds.Contains(6), "item.AlbumsIds.Contains(6)");
            IsNotEmpty(item.Photos, "item.Photos");
            IsNotNull(item.Photos[0], "item.Photos[0] != null");
            IsTrue(item.Photos[0].Id == 379184674, "item.Photos[0].Id == 379184674");
            IsTrue(item.CanComment, "item.CanComment");
            IsNotNull(item.Likes, "item.Likes != null");
            IsTrue(item.Likes.UserLikes, "item.Likes.UserLikes");
            IsTrue(item.ViewsCount == 704, "item.ViewsCount == 704");
        }

        public static void TestMarketAlbum(MarketAlbum album)
        {
            IsNotNull(album, "album != null");
            IsTrue(album.Id == 1, "album.Id == 1");
            IsNotEmpty(album.Title, "album.Title");
            IsNotNull(album.UpdatedTime, "album.UpdatedTime != null");
            IsNotNull(album.Photo, "album.Photo != null");
            IsTrue(album.Photo.Id == 379131663, "album.Photo.Id == 379131663");
        }
    }
}