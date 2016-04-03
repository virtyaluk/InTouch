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

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="GroupsEditParams"/> class describes a <see cref="GroupsMethods.Edit"/> method params.
    /// </summary>
    public class GroupsEditParams : MethodParamsGroup
    {
        /// <summary>
        /// Community identifier.
        /// </summary>
        [MethodParam(Name = "group_id", IsRequired = true)]
        public int GroupId { get; set; }

        /// <summary>
        /// Community name.
        /// </summary>
        [MethodParam(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Community description.
        /// </summary>
        [MethodParam(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Community screen name.
        /// </summary>
        [MethodParam(Name = "screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Community type. Possible values:
        /// 0 – open;
        /// 1 – closed;
        /// 2 – private
        /// </summary>
        [MethodParam(Name = "access")]
        public int? AccessLevel { get; set; }

        /// <summary>
        /// Website that will be displayed in the community information field.
        /// </summary>
        [MethodParam(Name = "website")]
        public string Website { get; set; }

        /// <summary>
        /// Community subject. Possible values:
        /// 1 – auto/moto;
        /// 2 – activity holidays;
        /// 3 – business;
        /// 4 – pets;
        /// 5 – health;
        /// 6 – dating and communication;
        /// 7 – games;
        /// 8 – IT(computers and software);
        /// 9 – cinema;
        /// 10 – beauty and fashion;
        /// 11 – cooking;
        /// 12 – art and culture;
        /// 13 – literature;
        /// 14 – mobile services and Internet;
        /// 15 – music;
        /// 16 – science and technology;
        /// 17 – real estate;
        /// 18 – news and media;
        /// 19 – security;
        /// 20 – education;
        /// 21 – home and renovations;
        /// 22 – politics;
        /// 23 – food;
        /// 24 – industry;
        /// 25 – travel;
        /// 26 – work;
        /// 27 – entertainment;
        /// 28 – religion;
        /// 29 – family;
        /// 30 – sports;
        /// 31 – insurance;
        /// 32 – television;
        /// 33 – goods and services;
        /// 34 – hobbies;
        /// 35 – finance;
        /// 36 – photo;
        /// 37 – esoterics;
        /// 38 – electronics and appliances;
        /// 39 – erotic;
        /// 40 – humor;
        /// 41 – society, humanities;
        /// 42 – design and graphics.
        /// </summary>
        [MethodParam(Name = "subject")]
        public int? Subject { get; set; }

        /// <summary>
        /// Organizer email (for events).
        /// </summary>
        [MethodParam(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Organizer phone number (for events).
        /// </summary>
        [MethodParam(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// RSS feed address for import (available only to communities with special permission.
        /// </summary>
        [MethodParam(Name = "rss")]
        public string RSS { get; set; }

        /// <summary>
        /// Event start date in Unixtime format.
        /// </summary>
        [MethodParam(Name = "event_start_date")]
        public int? EventStartDage { get; set; }

        /// <summary>
        /// Event finish date in Unixtime format.
        /// </summary>
        [MethodParam(Name = "event_finish_date")]
        public int? EventFinishDate { get; set; }

        /// <summary>
        /// Organizer community id (for events only).
        /// </summary>
        [MethodParam(Name = "event_group_id")]
        public int? EventGroupId { get; set; }

        /// <summary>
        /// Public page category.
        /// </summary>
        [MethodParam(Name = "public_category")]
        public int? PublicCategory { get; set; }

        /// <summary>
        /// Public page subcategory.
        /// </summary>
        [MethodParam(Name = "public_subcategory")]
        public int? PublicSubcategory { get; set; }

        /// <summary>
        /// Founding date of a company or organization owning the community in "dd.mm.YYYY" format.
        /// </summary>
        [MethodParam(Name = "public_date")]
        public string PublicDate { get; set; }

        /// <summary>
        /// Wall settings. Possible values:
        /// 0 – disabled;
        /// 1 – open;
        /// 2 – limited(groups and events only);
        /// 3 – closed(groups and events only)
        /// </summary>
        [MethodParam(Name = "wall")]
        public int? Wall { get; set; }

        /// <summary>
        /// Board topics settings. Possible values:
        /// 0 – disabled;
        /// 1 – open;
        /// 2 – limited(for groups and events only).
        /// </summary>
        [MethodParam(Name = "topics")]
        public int? Topics { get; set; }

        /// <summary>
        /// Photos settings. Possible values:
        /// 0 – disabled;
        /// 1 – open;
        /// 2 – limited(for groups and events only).
        /// </summary>
        [MethodParam(Name = "photos")]
        public int? Photos { get; set; }

        /// <summary>
        /// Video settings. Possible values:
        /// 0 – disabled;
        /// 1 – open;
        /// 2 – limited(for groups and events only).
        /// </summary>
        [MethodParam(Name = "video")]
        public int? Video { get; set; }

        /// <summary>
        /// Audio settings. Possible values:
        /// 0 – disabled;
        /// 1 – open;
        /// 2 – limited(for groups and events only).
        /// </summary>
        [MethodParam(Name = "audio")]
        public int? Audio { get; set; }

        /// <summary>
        /// Links settings (for public pages only).
        /// </summary>
        [MethodParam(Name = "links")]
        public bool Links{ get; set; }

        /// <summary>
        /// Events settings (for public pages only).
        /// </summary>
        [MethodParam(Name = "events")]
        public bool Events { get; set; }

        /// <summary>
        /// Places settings (for public pages only). 
        /// </summary>
        [MethodParam(Name = "places")]
        public bool Places { get; set; }

        /// <summary>
        /// Contacts settings (for public pages only).
        /// </summary>
        [MethodParam(Name = "contacts")]
        public bool Contacts { get; set; }

        /// <summary>
        /// Documents settings. Possible values:
        /// 0 – disabled;
        /// 1 – open;
        /// 2 – limited(for groups and events only).
        /// </summary>
        [MethodParam(Name = "docs")]
        public int? Docs { get; set; }

        /// <summary>
        /// Wiki pages settings. Possible values:
        /// 0 – disabled;
        /// 1 – open;
        /// 2 – limited(for groups and events only).
        /// </summary>
        [MethodParam(Name = "wiki")]
        public int? Wiki { get; set; }

        /// <summary>
        /// Community messages.
        /// </summary>
        [MethodParam(Name = "messages")]
        public bool Messages { get; set; }

        /// <summary>
        /// Community age limits.
        /// </summary>
        [MethodParam(Name = "age_limits")]
        public int? AgeLimits { get; set; } = 1;

        /// <summary>
        /// Market settings.
        /// </summary>
        [MethodParam(Name = "market")]
        public bool Market { get; set; }

        /// <summary>
        /// Market comments settings.
        /// </summary>
        [MethodParam(Name = "market_comments")]
        public bool MarketComments { get; set; }

        /// <summary>
        /// Market delivery regions.
        /// </summary>
        [MethodParam(Name = "market_country")]
        public List<int> MarketCountry { get; set; }

        /// <summary>
        /// Market delivery cities (if only one country is specified).
        /// </summary>
        [MethodParam(Name = "market_city")]
        public List<int> MarketCity { get; set; }

        /// <summary>
        /// Market currency settings. Possible values:
        /// 643 – Russian rubles;
        /// 980 – Ukrainian hryvnia;
        /// 398 – Kazakh tenge;
        /// 978 – Euros;
        /// 840 – US dollars
        /// </summary>
        [MethodParam(Name = "market_currency")]
        public int? MarketCurrency { get; set; }

        /// <summary>
        /// Seller contact for market. Set 0 for community messages.
        /// </summary>
        [MethodParam(Name = "market_contact")]
        public string MarketContact { get; set; }

        /// <summary>
        /// Id of a wiki page with market description.
        /// </summary>
        [MethodParam(Name = "market_wiki")]
        public int? MarketWiki { get; set; }

        /// <summary>
        /// Obscene expressions filter in comments.
        /// </summary>
        [MethodParam(Name = "obscene_filter")]
        public int? ObsceneFilter { get; set; }

        /// <summary>
        /// Stopwords filter in comments.
        /// </summary>
        [MethodParam(Name = "obscene_stopwords")]
        public int? ObsceneStopwords { get; set; }

        /// <summary>
        /// Keywords for stopwords filter.
        /// </summary>
        [MethodParam(Name = "obscene_words")]
        public List<string> ObsceneWords { get; set; }
    }
}