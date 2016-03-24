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

using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Group profile fields.
    /// </summary>
    public enum GroupProfileFields
    {
        [EnumMember(Value = "id")]
        Id,

        [EnumMember(Value = "name")]
        Name,

        [EnumMember(Value = "screen_name")]
        ScreenName,

        [EnumMember(Value = "is_closed")]
        IsClosed,

        [EnumMember(Value = "deactivated")]
        Deactivated,

        [EnumMember(Value = "is_admin")]
        IsAdmin,

        [EnumMember(Value = "member_status")]
        MemberStatus,

        [EnumMember(Value = "invited_by")]
        InvitedBy,

        [EnumMember(Value = "type")]
        Type,

        [EnumMember(Value = "has_photo")]
        HasPhoto,

        [EnumMember(Value = "photo_50")]
        Photo50,

        [EnumMember(Value = "photo_100")]
        Photo100,

        [EnumMember(Value = "photo_200")]
        Photo200,

        [EnumMember(Value = "ban_info")]
        BabInfo,

        [EnumMember(Value = "city")]
        City,

        [EnumMember(Value = "country")]
        Country,

        [EnumMember(Value = "place")]
        Place,

        [EnumMember(Value = "description")]
        Description,

        [EnumMember(Value = "wiki_page")]
        WikiPage,

        [EnumMember(Value = "members_count")]
        MembersCount,

        [EnumMember(Value = "counters")]
        Counters,

        [EnumMember(Value = "start_date")]
        StartDate,

        [EnumMember(Value = "finish_date")]
        FinishDate,

        [EnumMember(Value = "public_date_label")]
        PublicDateLabel,

        [EnumMember(Value = "can_message")]
        CanMessage,

        [EnumMember(Value = "can_post")]
        CanPost,

        [EnumMember(Value = "can_see_all_posts")]
        CanSeeAllPosts,

        [EnumMember(Value = "can_upload_doc")]
        CanUploadDoc,

        [EnumMember(Value = "can_upload_video")]
        CanUploadVideo,

        [EnumMember(Value = "can_create_topic")]
        CanCreateTopic,

        [EnumMember(Value = "activity")]
        Activity,

        [EnumMember(Value = "status")]
        Status,

        [EnumMember(Value = "contracts")]
        Contacts,

        [EnumMember(Value = "links")]
        Links,

        [EnumMember(Value = "fixed_post")]
        FixedPost,

        [EnumMember(Value = "verified")]
        Verified,

        [EnumMember(Value = "site")]
        Site,

        [EnumMember(Value = "main_album_id")]
        MainAlbumId,

        [EnumMember(Value = "is_favorite")]
        IsFavorite,

        [EnumMember(Value = "is_hidden_from_feed")]
        IsHiddenFromFeed,

        [EnumMember(Value = "main_section")]
        MainSection,

        [EnumMember(Value = "market")]
        Market
    }
}