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
using System.Diagnostics;
using System.Runtime.Serialization;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="User"/> class describes a user profile.
    /// </summary>
    [DebuggerDisplay("User {FirstName} {LastName}")]
    [DataContract]
    public class User : UserContact, IProfileItem, IChatable, IFeedback, IStatusAudio
    {
        #region Properties

        /// <summary>
        /// User ID.
        /// </summary>
        [DataMember]
        [JsonProperty("uid")]
        public int UId { get; set; }

        /// <summary>
        /// User ID.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// User ID.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// First name. 
        /// </summary>
        [DataMember]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name. 
        /// </summary>
        [DataMember]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Returns if a profile is deleted or blocked.
        /// Gets the value <see cref="DeactivatedTypes.Deleted"/> or <see cref="DeactivatedTypes.Banned"/>.
        /// Keep in mind that in this case no additional fields are returned.
        /// </summary>
        [DataMember]
        [JsonProperty("deactivated")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeactivatedTypes? Deactivated { get; set; }

        /// <summary>
        /// Returns while operating without access_token
        /// if a user has set the "Who can see my profile on the Internet" → "Only VK users" privacy setting.
        /// Keep in mind that in this case no additional fields are returned.
        /// </summary>
        [DataMember]
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// Returns true if the profile is verified, false if not. 
        /// </summary>
        [DataMember]
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        /// <summary>
        /// Returns true if a current user is in the requested user's blacklist. 
        /// </summary>
        [DataMember]
        [JsonProperty("blacklisted")]
        public bool Blacklisted { get; set; }

        /// <summary>
        /// User sex.
        /// </summary>
        [DataMember]
        [JsonProperty("sex")]
        [JsonConverter(typeof(JsonStringToUserSexConverter))]
        public UserSex Sex { get; set; }

        /// <summary>
        /// User's date of birth.
        /// Returned as DD.MM.YYYY or DD.MM (if birth year is hidden).
        /// If the whole date is hidden, no field is returned. 
        /// </summary>
        [DataMember]
        [JsonProperty("bdate")]
        public string BDate { get; set; }

        /// <summary>
        /// User's city.
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public City City { get; set; }

        /// <summary>
        /// User's country.
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public Country Country { get; set; }

        /// <summary>
        /// User's home town.
        /// </summary>
        [DataMember]
        [JsonProperty("home_town")]
        public string HomeTown { get; set; }

        /// <summary>
        /// Returns URL of square photo of the user with 50 pixels in width.
        /// In case user does not have a photo, http://vk.com/images/camera_c.gif is returned. 
        /// </summary>
        [DataMember]
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }

        /// <summary>
        /// Returns URL of square photo of the user with 100 pixels in width.
        /// In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.  
        /// </summary>
        [DataMember]
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }

        /// <summary>
        /// Returns URL of user's photo with 200 pixels in width.
        /// In case user does not have a photo, http://vk.com/images/camera_a.gif is returned.  
        /// </summary>
        [DataMember]
        [JsonProperty("photo_200_orig")]
        public string Photo200Orig { get; set; }

        /// <summary>
        /// Returns URL of square photo of the user with 200 pixels in width.
        /// If the photo was uploaded long time ago, there can be no image of such size
        /// and in this case the reply will not include this field.  
        /// </summary>
        [DataMember]
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }

        /// <summary>
        /// Returns URL of user's photo with 400 pixels in width.
        /// If user does not have a photo of such size, reply will not include this field.  
        /// </summary>
        [DataMember]
        [JsonProperty("photo_400_orig")]
        public string Photo400Orig { get; set; }

        /// <summary>
        /// Returns URL of square photo of the user with maximum width.
        /// Can be returned a photo both 200 and 100 pixels in width.
        /// In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.  
        /// </summary>
        [DataMember]
        [JsonProperty("photo_max")]
        public string PhotoMax { get; set; }

        /// <summary>
        /// Returns URL of user's photo of maximum size.
        /// Can be returned a photo both 400 and 200 pixels in width.
        /// In case user does not have a photo, http://vk.com/images/camera_a.gif is returned.  
        /// </summary>
        [DataMember]
        [JsonProperty("photo_max_orig")]
        public string PhotoMaxOrig { get; set; }

        /// <summary>
        /// Information whether the user is online. Returned values: true — online, false — offline.
        /// If user utilizes a mobile application or site mobile version, it returns <see cref="OnlineMobile"/> additional
        /// field that includes true. With that, in case of application, <see cref="OnlineApp"/> additional field is returned
        /// with application ID. 
        /// </summary>
        [DataMember]
        [JsonProperty("online")]
        public bool Online { get; set; }

        /// <summary>
        /// Information about friend lists. Returns IDs of friend lists the user is member of.
        /// </summary>
        [DataMember]
        [JsonProperty("lists")]
        public List<int> Lists { get; set; }

        /// <summary>
        /// Page screen name. Returns a string with a page screen name (only subdomain is returned, like virtyaluk).
        /// If not set, "id'+uid is returned, e.g. id16815310.  
        /// </summary>
        [DataMember]
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// Information whether the user's mobile phone number is available. Returned values: true — available, otherwise false.
        /// We recommend you to use it prior to call of <see cref="SecureMethods.SendSMSNotification"/> method.  
        /// </summary>
        [DataMember]
        [JsonProperty("has_mobile")]
        public bool HasMobile { get; set; }

        /// <summary>
        /// Information about user's phone numbers.
        /// </summary>
        [DataMember]
        [JsonProperty("contacts")]
        public UserContacts Contacts { get; set; }

        /// <summary>
        /// Returns a website address from a user profile.
        /// </summary>
        [DataMember]
        [JsonProperty("site")]
        public string Site { get; set; }

        /// <summary>
        /// Information about user's higher education institution.
        /// </summary>
        [DataMember]
        [JsonProperty("education")]
        public UserEducation Education { get; set; }

        /// <summary>
        /// List of higher education institutions where user studied. Returns <see cref="Universities"/> list.
        /// with <see cref="University"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("universities")]
        public List<University> Universities { get; set; }

        /// <summary>
        /// List of schools where user studied in. Returns <see cref="Schools"/> array with <see cref="School"/> objects.
        /// </summary>
        [DataMember]
        [JsonProperty("schools")]
        public List<School> Schools { get; set; }

        /// <summary>
        /// User status. Returns a string with status text that is in the profile below user's name.
        /// </summary>
        [DataMember]
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Last visit date.
        /// </summary>
        [DataMember]
        [JsonProperty("last_seen")]
        public UserLastSeen LastSeen { get; set; }

        /// <summary>
        /// Number of user's followers.
        /// </summary>
        [DataMember]
        [JsonProperty("followers_count")]
        public int? FollowersCount { get; set; }
        
        /// <summary>
        /// Number of various objects the user has.
        /// </summary>
        [DataMember]
        [JsonProperty("counters")]
        public UserCounters Counters { get; set; }

        /// <summary>
        /// Current user's occupation.
        /// </summary>
        [DataMember]
        [JsonProperty("occupation")]
        public UserOccupation Occupation { get; set; }

        /// <summary>
        /// User nickname.
        /// </summary>
        [DataMember]
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// Current user's relatives list.
        /// </summary>
        [DataMember]
        [JsonProperty("relatives")]
        public List<Relative> Relatives { get; set; }

        /// <summary>
        /// User relationship status.
        /// </summary>
        [DataMember]
        [JsonProperty("relation")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RelationTypes? Relation { get; set; }

        /// <summary>
        /// Information from the "Personal views" section.
        /// </summary>
        [DataMember]
        [JsonProperty("personal")]
        public UserPersonal Personal { get; set; }

        /// <summary>
        /// User's skype.
        /// </summary>
        [DataMember]
        [JsonProperty("skype")]
        public string Skype { get; set; }

        /// <summary>
        /// User's facebook.
        /// </summary>
        [DataMember]
        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        /// <summary>
        /// User's twitter.
        /// </summary>
        [DataMember]
        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        /// <summary>
        /// User's livejournal.
        /// </summary>
        [DataMember]
        [JsonProperty("livejournal")]
        public string LiveJournal { get; set; }

        /// <summary>
        /// User's instagram.
        /// </summary>
        [DataMember]
        [JsonProperty("instagram")]
        public string Instagram { get; set; }

        /// <summary>
        /// External services with export configured (twitter, facebook, livejournal, instagram).
        /// </summary>
        [DataMember]
        [JsonProperty("exports")]
        public UserExports Exports { get; set; }

        /// <summary>
        /// Wall comments allowed(true — allowed, false — not allowed).
        /// </summary>
        [DataMember]
        [JsonProperty("wall_comments")]
        public bool WallCommentsAllowed { get; set; }

        /// <summary>
        /// Activities.
        /// </summary>
        [DataMember]
        [JsonProperty("activities")]
        public string Activities { get; set; }

        /// <summary>
        /// Interests.
        /// </summary>
        [DataMember]
        [JsonProperty("interests")]
        public string Interests { get; set; }

        /// <summary>
        /// Favorite music.
        /// </summary>
        [DataMember]
        [JsonProperty("music")]
        public string Music { get; set; }

        /// <summary>
        /// Favorite movies.
        /// </summary>
        [DataMember]
        [JsonProperty("movies")]
        public string Movies { get; set; }

        /// <summary>
        /// Favorite TV shows.
        /// </summary>
        [DataMember]
        [JsonProperty("tv")]
        public string TV { get; set; }

        /// <summary>
        /// Favorite books.
        /// </summary>
        [DataMember]
        [JsonProperty("books")]
        public string Books { get; set; }

        /// <summary>
        /// Favorite games.
        /// </summary>
        [DataMember]
        [JsonProperty("games")]
        public string Games { get; set; }

        /// <summary>
        /// User's "About me".
        /// </summary>
        [DataMember]
        [JsonProperty("about")]
        public string About { get; set; }

        /// <summary>
        /// Favorite quotes.
        /// </summary>
        [DataMember]
        [JsonProperty("quotes")]
        public string Quotes { get; set; }

        /// <summary>
        /// Can post on the wall: true – allowed, false — not allowed.
        /// </summary>
        [DataMember]
        [JsonProperty("can_post")]
        public bool CanPost { get; set; }

        /// <summary>
        /// Can see other users' posts on the wall: true – allowed, false — not allowed.
        /// </summary>
        [DataMember]
        [JsonProperty("can_see_all_posts")]
        public bool CanSeeAllPosts { get; set; }

        /// <summary>
        /// Can see other users' audio on the wall: true – allowed, false — not allowed.
        /// </summary>
        [DataMember]
        [JsonProperty("can_see_audio")]
        public bool CanSeeAudio { get; set; }

        /// <summary>
        /// Can write private messages to a current user: true – allowed, false — not allowed.
        /// </summary>
        [DataMember]
        [JsonProperty("can_write_private_message")]
        public bool CanWritePM { get; set; }

        /// <summary>
        /// User time zone. Returns only while requesting current user info.
        /// </summary>
        [DataMember]
        [JsonProperty("timezone")]
        public int? Timezone { get; set; }

        /// <summary>
        /// User page's screen name (subdomain).
        /// </summary>
        [DataMember]
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        #region Extra properties

        /// <summary>
        /// Returns true if user utilizes a mobile application or site mobile version.
        /// </summary>
        [DataMember]
        [JsonProperty("online_mobile")]
        public bool OnlineMobile { get; set; }

        [DataMember]
        [JsonProperty("online_app")]
        public int? OnlineApp { get; set; }

        [DataMember]
        [JsonProperty("found_with")]
        public string FoundWith { get; set; }

        [DataMember]
        [JsonProperty("to_id")]
        public int? ToId { get; set; }

        [DataMember]
        [JsonProperty("from_id")]
        public int? FromId { get; set; }

        /// <summary>
        /// A <see cref="Audio"/> object, which is set in status.
        /// </summary>
        [DataMember]
        [JsonProperty("status_audio")]
        public Audio StatusAudio { get; set; }

        #endregion
        #endregion
    }
}
