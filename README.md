<h1 align="center"><img width="256" src="media/it-logo.png" alt="InTouch logo" style="clear: right;"><br/></h1>

[![Build status](https://ci.appveyor.com/api/projects/status/m3lbiphdft6bn059?svg=true)](https://ci.appveyor.com/project/virtyaluk/intouch) [![NuGet](https://img.shields.io/nuget/v/ModernDev.InTouch.svg?maxAge=3600)](https://www.nuget.org/packages/ModernDev.InTouch/) [![Join the chat at https://gitter.im/virtyaluk/InTouch](https://badges.gitter.im/virtyaluk/InTouch.svg)](https://gitter.im/virtyaluk/InTouch?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


**InTouch** - is a C# wrapper for [vk.com](https://vk.com/) API.
Be sure to check out official VK's **[Quick start](https://new.vk.com/dev/main)** guide before you dive into **InTouch**.

[:ru: Документация на русском.](README.ru.md)


## NuGet

```bash
PM> Install-Package ModernDev.InTouch
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

or even simpler:

```csharp
using (var client = new InTouch(12345, "super_secret"))
{
    await client.Authorize();

    var friends = await client.Friends.Get();
    // ...
}
```

## API Reference

After you [register](https://vk.com/editapp?act=create) an app, you'll get a unique **`ClientID`** and **`ClientSecret`**. These needed to perform user [authorization](https://new.vk.com/dev/authentication) and to call several methods from [Auth category](https://new.vk.com/dev/auth.signup). You may avoid using **`ClientID`** and **`ClientSecret`** if you do not intend to use *authorization* or methods from *Auth category*.

You may use one of following constructors to produce a new instance of `InTouch` class.

```csharp
new InTouch(int clientId, string clientSecret[, bool throwExceptionOnResponseError = false[,
    bool includeRawResponse = false]]);
```

```csharp
new InTouch([bool throwExceptionOnResponseError = false[, bool includeRawResponse = false]])
```

##### Values:

 - **`clientId`**: Your application ID.

 - **`clientSecret`**: Your application secret.
 - **`throwExceptionOnResponseError`**: *Default:* `false`. Whether the raw response string should be included in request response object.
 - **`includeRawResponse `**: *Default:* `false`. Whether the raw response string should be included in request response object.

You can also set client data after creating an instance of class just by using **`SetApplicationSettings`** class method.

```csharp
void SetApplicationSettings(int clientId, string clientSecret);
```

**Note**: The current API session will be reset each time you change client data using **`SetApplicationSettings`** method.

### Authorization

In order to call most API methods, your application require user authorization.

Authorization may be performed using the **`Authorize`** method, which is available for *Windows Store Apps*. Otherwise, you need to implement your own authorization logic based on steps described in the [official documentation](https://new.vk.com/dev/authentication) and then set received data on *client* using the **`SetSessionData`** method.

**In case of Windows Store Apps**, you need to await the **`Authorize`** method which starts the *authentication operation* and shows *auth dialog* to the user. In case of success, auth data will be set to the client automatically, no need to take additional actions.

```csharp
async Task Authorize([AuthorizationSettings authSettings = null[, bool silentMode = false]]);
```

##### Values:
 - **`silentMode`**: *Default:* `false`. Tells the web authentication broker to not render any UI.
 - **`authSettings`**: *Default:* `null`. Authorization settings.

**TODO:**...

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
