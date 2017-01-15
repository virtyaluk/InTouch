<h1 align="center"><img width="256" src="media/it-logo.png" alt="InTouch logo" style="clear: right;"><br/></h1>

[![Build status](https://ci.appveyor.com/api/projects/status/m3lbiphdft6bn059?svg=true)](https://ci.appveyor.com/project/virtyaluk/intouch) [![NuGet](https://img.shields.io/nuget/v/ModernDev.InTouch.svg?maxAge=7200)](https://www.nuget.org/packages/ModernDev.InTouch/) [![Join the chat at https://gitter.im/virtyaluk/InTouch](https://badges.gitter.im/virtyaluk/InTouch.svg)](https://gitter.im/virtyaluk/InTouch?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


**InTouch** - is a C# wrapper for [vk.com](https://vk.com/) API.

Compatible with version **5.62** of **[:link:VK API](https://new.vk.com/dev/versions)**.

[:uk: Readme](README.md) &nbsp; [:ru: Документация на русском.](README.ru.md)

# Changelog

## v1.0.26 (January 15, 2017)
- Adds [.NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/) **1.1** targeting project. [**@virtyaluk**](https://github.com/virtyaluk) in [#19](https://github.com/virtyaluk/InTouch/pull/19).

## v1.0.20 (January 15, 2017)
- API version **5.62**. [**@virtyaluk**](https://github.com/virtyaluk) in [#17](https://github.com/virtyaluk/InTouch/pull/17).
 - `Messages.gGetHistoryAttachments` method returns `MessageId` field.
 - `User` object has a new value of relationship status (8 — "in a civil union").
- API version **5.61**. [**@virtyaluk**](https://github.com/virtyaluk) in [#16](https://github.com/virtyaluk/InTouch/pull/16).
 - `Group` object contains new `Cover` field.
 - `Account.GetCounters` method takes a new value `FriendsSuggestions` in the `Filter` parameter.

## v1.0.19 (November 21, 2016)
- Adds 3 new methods: `DenyMessagesFromGroup`, `AllowMessagesFromGroup`, `IsMessagesFromGroupAllowed`. [**@virtyaluk**](https://github.com/virtyaluk) in [#13](https://github.com/virtyaluk/InTouch/pull/13).
- API version **5.59**. [**@virtyaluk**](https://github.com/virtyaluk) in [#14](https://github.com/virtyaluk/InTouch/pull/14).
 - `Group` object contains new `IsMessagesAllowed` field.
 - Two new events `MessageAllow` and `MessageDeny` has been added to Callback API. `Groups.SetCallbackSettings` method supports two new parameters and `Groups.GetCallbackSettings` returns two new fields respectively.
- API version **5.60**. [**@virtyaluk**](https://github.com/virtyaluk) in [#15](https://github.com/virtyaluk/InTouch/pull/15).
 - `Account.GetInfo` method returns an additional `TwoFactorAuthorizationRequired` field for accounts with 2FA.
 - `Button` field has a new structure for attachments with *Link* type.

## v1.0.18 (October 10, 2016)
- Groups Callback API. [**@virtyaluk**](https://github.com/virtyaluk) in [#10](https://github.com/virtyaluk/InTouch/pull/10).
- New `markAsImportantDialog` and `markAsAnsweredDialog` methods. [**@virtyaluk**](https://github.com/virtyaluk) in [#11](https://github.com/virtyaluk/InTouch/pull/11).
- New `Doc.Preview` properties. [**@virtyaluk**](https://github.com/virtyaluk) in [#12](https://github.com/virtyaluk/InTouch/pull/12).
- Code refactoring and improvements.
- New VK API version - 5.57.

## v1.0.15 (July 28, 2016)
- API aligned with latest version of VK API (5.53).
- Fixed AudioGenres.Speech enum value. [**@RomanGL**](https://githuv.com/RomanGL) in [#2](https://github.com/virtyaluk/InTouch/pull/2).
- AudioSearchParams.SearchOwn MethodParamAttribute.Name fix. [**@RomanGL**](https://githuv.com/RomanGL) in [#3](https://github.com/virtyaluk/InTouch/pull/3).
- Implemented ToString for Audio, Video, Doc, BaseAlbum and ResponseError. [**@RomanGL**](https://githuv.com/RomanGL) in [#4](https://github.com/virtyaluk/InTouch/pull/4).
- Fixed method mask in InTouch.Request<T>. [**@RomanGL**](https://githuv.com/RomanGL) in [#5](https://github.com/virtyaluk/InTouch/pull/5).
- Allows sessions with duration of `0`. [**@acedened**](https://github.com/acedened) in [#6](https://github.com/virtyaluk/InTouch/pull/6).
- APIVersion: type changed to string. [**@RomanGL**](https://githuv.com/RomanGL) in [#7](https://github.com/virtyaluk/InTouch/pull/7).

## v1.0.14 (April 30, 2016)

- Added new **messages.sendSticker** method.
- API aligned with latest version of VK API (5.52).
- Bug fixes and code improvements.

---

> [modern-dev.com](http://modern-dev.com) &nbsp;&middot;&nbsp;
> GitHub [@virtyaluk](https://github.com/virtyaluk) &nbsp;&middot;&nbsp;
> Twitter [@virtyaluk](https://twitter.com/virtyaluk)
