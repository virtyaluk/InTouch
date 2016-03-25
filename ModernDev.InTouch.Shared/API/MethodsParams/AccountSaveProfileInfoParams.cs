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

namespace ModernDev.InTouch
{
    /// <summary>
    /// An <see cref="AccountSaveProfileInfoParams"/> class describes a <see cref="AccountMethods.SaveProfileInfo"/> method params.
    /// </summary>
    public class AccountSaveProfileInfoParams : MethodParamsGroup
    {
        /// <summary>
        /// User first name.
        /// </summary>
        [MethodParam(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// User last name.
        /// </summary>
        [MethodParam(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// User maiden name (female only).
        /// </summary>
        [MethodParam(Name = "maiden_name")]
        public string MaidenName { get; set; }

        /// <summary>
        /// User screen name.
        /// </summary>
        [MethodParam(Name = "screen_nae")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Id of the name change request to be canceled. If this parameter is sent, all the others are ignored.
        /// </summary>
        [MethodParam(Name = "cancel_request_id")]
        public int CancelRequestId { get; set; }

        /// <summary>
        /// User sex.
        /// </summary>
        [MethodParam(Name = "sex")]
        public int Sex { get; set; }

        /// <summary>
        /// User relationship status.
        /// </summary>
        [MethodParam(Name = "relation")]
        public int Relation { get; set; }

        /// <summary>
        /// Id of the relationship partner.
        /// </summary>
        [MethodParam(Name = "relation_partner_id")]
        public int RelationPartnerId { get; set; }

        /// <summary>
        /// User birth date, format: DD.MM.YYYY.
        /// </summary>
        [MethodParam(Name = "bdate")]
        public string BDate { get; set; }

        /// <summary>
        /// Birth date visibility.
        /// </summary>
        [MethodParam(Name = "bdate_visibility")]
        public int BDateVisibility { get; set; }

        /// <summary>
        /// User's home town.
        /// </summary>
        [MethodParam(Name = "home_town")]
        public string HomeTown { get; set; }

        /// <summary>
        /// Id of user's country.
        /// </summary>
        [MethodParam(Name = "country_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// Id of user's city.
        /// </summary>
        [MethodParam(Name = "city_id")]
        public int CityId { get; set; }

        /// <summary>
        /// Profile status.
        /// </summary>
        [MethodParam(Name = "status")]
        public string Status { get; set; }
    }
}