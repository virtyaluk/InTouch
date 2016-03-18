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
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.API;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="Group"/> class describes a community.
    /// </summary>
    [DebuggerDisplay("Group {ScreenName} {Name}")]
    [DataContract]
    public partial class Group : IProfileItem, IChatable
    {
        #region Properties

        /// <summary>
        /// Community ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("gid")]
        public int Id { get; set; }

        /// <summary>
        /// Community name. 
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Screen name of the community page (e.g. apiclub or club1). 
        /// </summary>
        [DataMember]
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Whether the community is closed. 
        /// </summary>
        [DataMember]
        [JsonProperty("is_closed")]
        [JsonConverter(typeof (StringEnumConverter))]
        public CommunityPrivacyTypes PrivacyType { get; set; }
        
        /// <summary>
        /// Returns if a community is added to blacklist or deleted.
        /// </summary>
        [DataMember]
        [JsonProperty("deactivated")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeactivatedTypes Deactivated { get; set; }

        /// <summary>
        /// Whether a user is the community manager.
        /// </summary>
        [DataMember]
        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// (If <see cref="IsAdmin"/> = true) Rights of the user.
        /// </summary>
        [DataMember]
        [JsonProperty("admin_level")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommunityAdminLevels AdminLevel { get; set; }

        /// <summary>
        /// Whether a user is a community member.
        /// </summary>
        [DataMember]
        [JsonProperty("is_member")]
        public bool IsMember { get; set; }
        
        /// <summary>
        /// Current user community member status.
        /// </summary>
        [DataMember]
        [JsonProperty("member_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MemberStatuses MemberStatus { get; set; }

        /// <summary>
        /// User ID that has sent an invitation to the community.
        /// </summary>
        [DataMember]
        [JsonProperty("invited_by")]
        public int InvitedBy { get; set; }

        /// <summary>
        /// Community type.
        /// </summary>
        [DataMember]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommunityTypes Type { get; set; }

        /// <summary>
        /// Returns true of a community has a photo. 
        /// </summary>
        [DataMember]
        [JsonProperty("has_photo")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool HasPhoto { get; set; }

        /// <summary>
        /// URL of the 50px-wide community logo. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo")]
        public string Photo { get; set; }

        /// <summary>
        /// URL of the 100px-wide community logo. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_medium")]
        public string PhotoMedium { get; set; }

        /// <summary>
        /// URL of the 200px-wide community logo. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_big")]
        public string PhotoBig { get; set; }

        #region Optional properties

        /// <summary>
        /// Information about blacklisting community.
        /// </summary>
        [DataMember]
        [JsonProperty("ban_info")]
        public BanInfo BainInfo { get; set; }

        /// <summary>
        /// ID of the city specified in information about community.
        /// Returns city ID that can be used to get its name using <see cref="Places.GetCityById"/> method.
        /// If city is not specified, "0" is returned. 
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public int CityId { get; set; }

        /// <summary>
        /// ID of the country specified in information about community.
        /// Returns country ID that can be used to get its name using <see cref="Places.GetCountryById"/> method.
        /// If country is not specified, 0 is returned.  
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public int CountryId { get; set; }

        /// <summary>
        /// ID of the location specified in information about community.
        /// </summary>
        [DataMember]
        [JsonProperty("place")]
        public Place Place { get; set; }

        /// <summary>
        /// Community description text.
        /// </summary>
        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Name of the home wiki-page of the community.
        /// </summary>
        [DataMember]
        [JsonProperty("wiki_page")]
        public string WikiPage { get; set; }

        /// <summary>
        /// Number of community members.
        /// </summary>
        [DataMember]
        [JsonProperty("members_count")]
        public int MembersCount { get; set; }

        /// <summary>
        /// Counters object with community counters
        /// </summary>
        [DataMember]
        [JsonProperty("counters")]
        public CommunityCounters Counters { get; set; }

        /// <summary>
        /// Returned only for meeting and contain start time of the meeting.  
        /// </summary>
        [DataMember]
        [JsonProperty("start_date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Returned only for meeting and contain end time of the meeting.
        /// </summary>
        [DataMember]
        [JsonProperty("end_date")]
        [JsonConverter(typeof(JsonNumberDateTimeConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Public date label/
        /// </summary>
        [DataMember]
        [JsonProperty("public_date_label")]
        public string PublicDateLabel { get; set; }

        /// <summary>
        /// Whether the current user can write a private message to the community
        /// </summary>
        [DataMember]
        [JsonProperty("can_message")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool CanMessage { get; set; }

        /// <summary>
        /// Whether the current user can post on the community's wall.
        /// </summary>
        [DataMember]
        [JsonProperty("can_post")]
        public bool CanPost { get; set; }

        /// <summary>
        /// Whether others' posts on the community's wall can be viewed.
        /// </summary>
        [DataMember]
        [JsonProperty("can_see_all_posts")]
        public bool CanSeeAllPosts { get; set; }

        /// <summary>
        /// Whether the current user can upload a doc to the community.
        /// </summary>
        [DataMember]
        [JsonProperty("can_upload_doc")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool CanUploadDoc { get; set; }

        /// <summary>
        /// Whether the current user can upload a video to the community.
        /// </summary>
        [DataMember]
        [JsonProperty("can_upload_video")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool CanUploadVideo { get; set; }

        /// <summary>
        /// Whether the current user can create a topic in the community.
        /// </summary>
        [DataMember]
        [JsonProperty("can_create_topic")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool CanCreateTopic { get; set; }

        /// <summary>
        /// Returns the public page status bar. For groups, a string value is returned whether the group is public or not;
        /// for events — start date.  
        /// </summary>
        [DataMember]
        [JsonProperty("activity")]
        public string Activity { get; set; }

        /// <summary>
        /// Group status. Returns a string with status text that is on the group page below its name.
        /// </summary>
        [DataMember]
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Information from public page contact module.
        /// </summary>
        [DataMember]
        [JsonProperty("contacts")]
        public string Contacts { get; set; }

        /// <summary>
        /// Community's "link" block.
        /// </summary>
        [DataMember]
        [JsonProperty("links")]
        public string Links { get; set; }

        /// <summary>
        /// Community's fixed post Id.
        /// </summary>
        [DataMember]
        [JsonProperty("fixed_post")]
        public int FixedPost { get; set; }

        /// <summary>
        /// Whether the community is verified or not.
        /// </summary>
        [DataMember]
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        /// <summary>
        /// The site from community's site block.
        /// </summary>
        [DataMember]
        [JsonProperty("site")]
        public string Site { get; set; }

        /// <summary>
        /// Community's main photo album.
        /// </summary>
        [DataMember]
        [JsonProperty("main_album_id")]
        public int MainAlbumId { get; set; }

        /// <summary>
        /// Whether the current user add the community to favorites.
        /// </summary>
        [DataMember]
        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }

        /// <summary>
        /// Whether the current user hidden the community from news feed.
        /// </summary>
        [DataMember]
        [JsonProperty("is_hidden_from_feed")]
        public bool IsHiddenFromFeed { get; set; }

        /// <summary>
        /// Community main section info.
        /// </summary>
        [DataMember]
        [JsonProperty("main_section")]
        public MainSections MainSection { get; set; }

        /// <summary>
        /// Community market info.
        /// </summary>
        [DataMember]
        [JsonProperty("market")]
        public Market Market { get; set; }

        #endregion
        #endregion
    }
}