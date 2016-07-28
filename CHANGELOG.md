<h1 align="center"><img width="256" src="media/it-logo.png" alt="InTouch logo" style="clear: right;"><br/></h1>

[![Build status](https://ci.appveyor.com/api/projects/status/m3lbiphdft6bn059?svg=true)](https://ci.appveyor.com/project/virtyaluk/intouch) [![NuGet](https://img.shields.io/nuget/v/ModernDev.InTouch.svg?maxAge=7200)](https://www.nuget.org/packages/ModernDev.InTouch/) [![Join the chat at https://gitter.im/virtyaluk/InTouch](https://badges.gitter.im/virtyaluk/InTouch.svg)](https://gitter.im/virtyaluk/InTouch?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


**InTouch** - is a C# wrapper for [vk.com](https://vk.com/) API.

Compatible with version **5.53** of **[:link:VK API](https://new.vk.com/dev/versions)**.

[:uk: Readme](README.md) &nbsp; [:ru: Документация на русском.](README.ru.md)

# Changelog

## v1.0.15 (July 28, 2016)
- API aligned with latest version of VK API (5.53).
- Fixed AudioGenres.Speech enum value. @RomanGL in [#2](https://github.com/virtyaluk/InTouch/pull/2).
- AudioSearchParams.SearchOwn MethodParamAttribute.Name fix. @RomanGL in [#3](https://github.com/virtyaluk/InTouch/pull/3).
- Implemented ToString for Audio, Video, Doc, BaseAlbum and ResponseError. @RomanGL in [#4](https://github.com/virtyaluk/InTouch/pull/4).
- Fixed method mask in InTouch.Request<T>. @RomanGL in [#5](https://github.com/virtyaluk/InTouch/pull/5).
- Allows sessions with duration of `0`. @acedened in [#6](https://github.com/virtyaluk/InTouch/pull/6).
- APIVersion: type changed to string. @RomanGL in [#7](https://github.com/virtyaluk/InTouch/pull/7).

## v1.0.14 (April 30, 2016)

- Added new **messages.sendSticker** method.
- API aligned with latest version of VK API (5.52).
- Bug fixes and code improvements.

---

> [modern-dev.com](http://modern-dev.com) &nbsp;&middot;&nbsp;
> GitHub [@virtyaluk](https://github.com/virtyaluk) &nbsp;&middot;&nbsp;
> Twitter [@virtyaluk](https://twitter.com/virtyaluk)
