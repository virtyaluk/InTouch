[![Build status](https://ci.appveyor.com/api/projects/status/m3lbiphdft6bn059?svg=true)](https://ci.appveyor.com/project/virtyaluk/intouch) [![Join the chat at https://gitter.im/virtyaluk/InTouch](https://badges.gitter.im/virtyaluk/InTouch.svg)](https://gitter.im/virtyaluk/InTouch?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


# InTouch

InTouch - is a C# wrapper for [vk.com](https://vk.com/) API.


## NuGet

```bash
TODO:
```

## Usage

```csharp
var clientId = 12345; // API client Id
var clientSecret = "super_secret"; // API client secret
var client = new InTouch(clientId, clientSecret);

// Authorization works only in Windows (and WinPhone) Store Apps
// otherwise you'll need to set received "access_token" manually
// using SetSessionData method.
await client.Authorize();

// Gets a list of a user's friends.
var friends = await client.Friends.Get();

if (friends.IsError == false)
{
    ShowFriendsList(friends.Data.Items.Where(friend => friend.Online));
}

client.Dispose();
```

or even simpler

```csharp
using (var client = new InTouch(12345, "super_secret"))
{
    await client.Authorize();

    var friends = await client.Friends.Get();
    // ...
}
```

## API docs

TODO: will be added soon

## Platform Support

InTouch is compiled for .NET 4.5, as well a Portable Class Library (Profile 111) supporting:
 - .NET 4.5
 - ASP.NET Core 1.0
 - Windows 8
 - Windows Phone 8.1
 - Xamarin.Android
 - Xamarin.iOS
 - Xamarin.iOS (Classic)

## Build / Release

Clone the repository and build `ModernDev.InTouch.sln` using MSBuild. NuGet package restore must be enabled.

If you fork the project, simply rename the `nuspec` file accordingly and it will be picked up by the release script.

## License

[Licensed under the GPLv3 license.](https://github.com/virtyaluk/InTouch/blob/master/LICENSE)
Copyright (c) 2016 Bohdan Shtepan

---

> [modern-dev.com](http://modern-dev.com) &nbsp;&middot;&nbsp;
> GitHub [@virtyaluk](https://github.com/virtyaluk) &nbsp;&middot;&nbsp;
> Twitter [@virtyaluk](https://twitter.com/virtyaluk)
