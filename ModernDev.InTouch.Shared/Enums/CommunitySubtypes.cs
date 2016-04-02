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

using System.Diagnostics;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Public page subtypes.
    /// </summary>
    [DebuggerDisplay("CommunitySubtypes")]
    public enum CommunitySubtypes
    {
        /// <summary>
        /// Place or small business.
        /// </summary>
        PlaceOrSmallBusiness = 1,

        /// <summary>
        /// Company, organization or website.
        /// </summary>
        CompanyOrganizationOrWebsite = 2,

        /// <summary>
        /// Famous person or group of people.
        /// </summary>
        PersonOrGroupOfPeople = 3,

        /// <summary>
        /// Product or work of art.
        /// </summary>
        ProductOrArtWork = 4
    }
}