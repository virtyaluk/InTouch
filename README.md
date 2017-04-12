<h1 align="center"><img width="256" src="media/it-logo.png" alt="InTouch logo" style="clear: right;"><br/></h1>

[![Build status](https://ci.appveyor.com/api/projects/status/m3lbiphdft6bn059?svg=true)](https://ci.appveyor.com/project/virtyaluk/intouch) [![NuGet](https://img.shields.io/nuget/v/ModernDev.InTouch.svg?maxAge=7200)](https://www.nuget.org/packages/ModernDev.InTouch/) [![Join the chat at https://gitter.im/virtyaluk/InTouch](https://badges.gitter.im/virtyaluk/InTouch.svg)](https://gitter.im/virtyaluk/InTouch?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


**InTouch** - is a C# wrapper for [vk.com](https://vk.com/) API.

Be sure to check out official VK's **[:link:Quick start](https://new.vk.com/dev/main)** guide before you dive into **InTouch**.

Compatible with version **5.63** of **[:link:VK API](https://new.vk.com/dev/versions)**.

[:calendar: Changelog](CHANGELOG.md) &nbsp; [:ru: Документация на русском.](README.ru.md)


## :dvd: NuGet

```bash
PM> Install-Package ModernDev.InTouch
```

## :clipboard: Usage

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

## :mortar_board: API Reference

After you [:link:register](https://vk.com/editapp?act=create) an app, you'll get a unique **`ClientID`** and **`ClientSecret`**. These needed to perform user [:link:authorization](https://new.vk.com/dev/authentication) and to call several methods from [:link:Auth category](https://new.vk.com/dev/auth.signup). You may avoid using **`ClientID`** and **`ClientSecret`** if you do not intend to use *authorization* or methods from *Auth category*.

You may use one of following constructors to produce a new instance of `InTouch` class.

```csharp
new InTouch(int clientId, string clientSecret, bool throwExceptionOnResponseError = false,
    bool includeRawResponse = false);
```

```csharp
new InTouch(bool throwExceptionOnResponseError = false, bool includeRawResponse = false)
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

**:information_source: Note**: The current API session will be reset each time you change client data using **`SetApplicationSettings`** method.

### Authorization

In order to call most API methods, your application require user authorization.

Authorization may be performed using the **`Authorize`** method, which is available for *Windows Store Apps*. Otherwise, you need to implement your own authorization logic based on steps described in the [:link:official documentation](https://new.vk.com/dev/auth_mobile) and then set received data on *client* using the **`SetSessionData`** method.

**In case of Windows Store Apps**, you need to await the **`Authorize`** method which starts the *authentication operation* and shows *auth dialog* to the user. In case of success, auth data will be set to the client automatically, no need to take additional actions.

```csharp
async Task Authorize(AuthorizationSettings authSettings = null, bool silentMode = false);
```

##### Values:
 - **`silentMode`**: *Default:* `false`. Tells the web authentication broker to not render any UI.
 - **`authSettings`**: *Default:* `null`.  Authorization settings.

Where **`authSettings`** is an instance of class **`AuthorizationSettings`** which describes the next data structure:

```csharp
class AuthorizationSettings {
    // Authorization window appearance.
    AuthorizationDisplayTypes Display = AuthorizationDisplayTypes.Mobile,

    // Requested application access permissions.
    AccessPermissions Scope = AccessPermissions.None,

    // Whether the authorization dialog must revoke previously accessed application permissions.
    bool Revoke,

    // URL where access_token will be passed to.
    Uri RedirectUri = new Uri("https://oauth.vk.com/blank.html"),

    // Whether the app supports single sign-on (SSO).
    bool SSOEnabled,
}
```

**:information_source: Note**. VK API doesn't yet support **[SSO](https://en.wikipedia.org/wiki/Single_sign-on)**. There is a feature request submitted by me though. So auth dialog will be displayed each time the **`Authorize`** method would called.

Let's say we need to get access to user's *friends* and *private messages* through authorization on devices with large screen. In this case, we'll pass the next object as the first argument in **`Authorize`** method:

```csharp
await client.Authorize(new AuthorizationSettings {
    Display = AuthorizationDisplayTypes.Page,
    Scope = AccessPermissions.Friends | AccessPermissions.Messages
});
```

**In the case of custom authorization**, after the authorization completes you'll need to pass auth data to the **`SetSessionData`** method which takes 3 arguments.

```csharp
void SetSessionData(string accessToken, int userId, int sessionDuration = 20*60*60);
```

##### Values:
 - **`accessToken`**: Access key for API calls.
 - **`userId`**: The authorized user ID.
 - **`sessionDuration`**: `accessToken` lifetime specified in seconds so the *client* can notify that the token was expired through the **`AccessTokenExpired`** event.

After successful authorization, you can make API requests. There're a couple of methods not requiring authorization, though.

#### Community Token

A community token allows working with API on behalf of a group, event or public page. It can be used to answer the community messages.

**InTouch** offers **`GetClientCredentialsFlow`** method to get community token:

```csharp
async Task<ClientCredentialsFlowStatus> GetClientCredentialsFlow(int? clientId = null, string clientSecret = null);
```

In case of omitting *`clientId`* and *`clientSecret`* arguments, **InTouch** would try to use *`ClientId`* and *`ClientSecret`* properties on main class instance.

In case you already have *community token*, you can set it on main class instance manually using **`SetServiceToken`** method:

```csharp
void SetServiceToken(string serviceToken)
```

and later access using *`ServiceToken`* property.

### API Requests

All the methods are grouped by corresponding categories as they were presented in the [:link:official documentation](https://new.vk.com/dev/methods). So, for example, if you want to return a list of posts on a user's wall using [:link:wall.get](https://new.vk.com/dev/wall.get) method, you need to call **Get** method of **Wall** object on the main instance of **InTouch** class. Like so:

```csharp
await client.Wall.Get(new WallGetParams {
    Count = 10,
    Extended = true
});
```

:information_source: Oh, by the way, **InTouch** brings all the advantages of [:link:async programming](https://msdn.microsoft.com/en-us/library/hh191443.aspx). Which means there are only a couple of *non-async* methods and all the rest are *async*. So you need to **`await`** them.

#### Parameters transmissiton in API

Most of the methods have its own *parameters* that are described in the **docs**. If a method (like [:link:this one](https://new.vk.com/dev/wall.get)) takes more than **6** arguments then these arguments will be combined into the **one object**. Here's what that means.

The **wall.get** method takes next parameters: *owner_id*, *domain*, *offset*, *count*, *filter*, *extended*, *fields*.

But **InTouch** version of this method takes only **one** argument which is an instance of **`WallGetParams`** class and has the next structure:

```csharp
class WallGetParams {
    // User or community id.
    int OwnerId,

    // User or community screen name.
    string Domain,

    // True – returns only page owner's posts.
    bool OwnersOnly = false,

    // Count of posts to return.
    int Count = 20,

    // Results offset.
    int Offset = 0,

    // Show extended post info.
    bool Extended = false,

    // The list of additional fields for the profiles and groups that need to be returned.
    List<object> Fields = null,

    // Filter to apply.
    PostFilterTypes Filter = PostFilterTypes.All
}
```

And the [:link:wall.getById](https://new.vk.com/dev/wall.getById) method have short arguments list and thus has the next signature:

```csharp
async Task<Response<ItemsList<Post>>> GetById(List<string> posts, bool extended = false,
    int copyHistoryDepth = 2, List<object> fields = null);
```

:information_source: Keep in mind, **InTouch** would throw an exception if not all **required** parameters filled with data. *Optional* parameters may be omitted.

Each method has its own set of supported parameters but there are some common ones:

 - **DataLanguage** - determines the language for the data to be displayed on. For example country and city names. If you use a non-cyrillic language, cyrillic symbols will be transtiterated automatically.

```csharp
client.DataLanguage = Langs.English;
```

 - **AlowHttpsLinks** - allows to get https links for photos and other media. False – methods return http links.

```csharp
client.AlowHttpsLinks = true;
```

 - **TestMode** - allows to send requests from a native app without switching it on for all users.

```csharp
client.TestMode = false;
```

#### Response object

Calling to the API will always result in **`Response`** object which describes the next data structure:

```csharp
class Response<T> {
    // Response error (if any).
    ResponseError Error,

    // Response data (if any).
    T Data,

    // Whether the request response is error.
    bool IsError => Error != null,

    // Raw JSON response.
    string Raw
}
```

So, for example, retrieving friends list using [:link:friends.get](https://new.vk.com/dev/friends.get) method will result in **`Response<ItemsList<User>>`**, where **Data** property would be of type **`ItemsList<User>`**.

If API request resulted in *error* then the **Error** property would contain the error object describing the error code and the error message:

```csharp
class ResponseError: EventArgs {
    // Error code.
    int Code,

    // Error text.
    string Message,

    // Captcha identifier.
    string CaptchaSId,

    // A link to an image that will be shown to a user.
    string CaptchaImg,

    // Request parameters.
    Dictionary<string, string> RequestParams
}
```

There are few *options* using which you can control how **InTouch** handles response errors.

```csharp
// If set to true, then an exception will be thrown in case of response error,
// instead of passing an error object to the Response object.
client.ThrowExceptionOnResponseError = true;

// If set to true, then Response.Raw will be filled with raw JSON response string.
client.IncludeRawResponse  = true;

try {
    var audios = await client.Audios.Get(count: 10);

    OwnWayToAnalyzeRawResp(audios.Raw);
    FillAudiosList(audios.Data);
} catch (InTouchResponseErrorException ex) {
    MessageBox.Show(ex.ResponseError.Message);
}
```

#### Handling Authorization\Captcha errors.

Whenever API call gets **authorization failed** error or **captcha needed** error, **`AuthorizationFailed`** or **`CaptchaNeeded`** event will be fired accordingly. So there's no need to check response error on these two, you can simply subscribe to custom events and use custom logic whenever it's needed.

```csharp
client.AuthorizationFailed += OnAuthorizationFailed;

client.CaptchaNeeded += (s, error) => ShowCaptchaBox(error.CaptchaImg, error.CaptchaSId);
```

Moreover, there is an utility method that helps you to resend previously failed request with *captcha code*:

```csharp
async Task<Response<T>> SendCaptcha<T>(string captchaKey, ResponseError lastResponseError);
```

There is also an utility method called **`TrySendRequestAgain`** which is designed to resend previously failed request:

```csharp
async Task<Response<T>> TrySendRequestAgain<T>();
```

**:information_source: Note**: Keep in mind that custom events will occur only and only when the **`ThrowExceptionOnResponseError`** is set to `false`, which is the default value.

#### Limits and recommendations

> There can be maximum 3 requests to API methods per second from a client. 
>
> Maximum amount of server requests depends on the app's users amount. 
If an app has less than 10 000 users, 5 requests per second, up to 100 000 – 8 requests, up to 1 000 000 – 20 requests, 1 000 000+ – 35 requests. 
>
> If one of this limits is exceeded, the server will return following error: 'Too many requests per second'. 
>
> If your app's logic implies many requests in a row, check the execute method. 
>
> Except the frequency limits there are quantitative limits on calling the methods of the > same type. By obvious reasons we don't provide the exact limits info. 
>
> On excess of a quantitative limit access to a particular method will require captcha (see captcha_error). After that it may be temporarily limited (in this case the server doesn't answer on particular method's requests but easily processes any other requests).

### Other

#### Custom API request

You may want to get full control on what you send through the request. **InTouch** exposes **`Request`** method to send VK API requests. All the **InTouch** API methods are build on top of the one. The signature is next:

```csharp
async Task<Response<T>> Request<T>(string methodName, Dictionary<string, string> methodParams = null,
    bool isOpenMethod = false, string path = null);
```

##### Values:
 - **`methodName`** - The name of the method to call.
 - **`methodParams`** - Request parameters.
 - **`isOpenMethod`** - Indicates whether the method can be called without an `accessToken`.
 - **`path`** - Object's path to select the token from.

The next example shows how to get a list of user's friends using the **`Request`** method:

```csharp
var friends = await client.Request<ItemsList<User>>("friends.get", new Dictionary<string, string> {
    {"user_id", "16815310"},
    {"count", "10"},
    {"order", "name"}
});
```

#### Uploading Files

**InTouch** supports [:link:uploading files](https://new.vk.com/dev/upload_files) through API.

Next example demonstrates how to upload document to user's page.

```csharp
byte[] docFile = GetMyFile("cats.gif");

var uploadedDocs = await client.Docs.UploadDoc(docFile, "cats.gif", title: "my funny cat");

ShowUploadedDoc(uploadedDocs.Data[0]);
```

or how to update user's profile photo:

```csharp
byte[] newPhoto = GetMyFile("photo.jpg");

await client.Photos.UploadOwnerPhoto(newPhoto, "profile.jpg");
```

## :green_book: Platform Support

**InTouch** is compiled for *.NET 4.5*, *Portable Class Library* (Profile 111) and *.NET Standard 1.1*:
 - .NET 4.5
 - .NET Standard 1.1
 - ASP.NET Core 1.0
 - Windows 8+
 - Windows Phone 8.1+
 - Xamarin.Android
 - Xamarin.iOS
 - Xamarin.iOS (Classic)

## :green_book: License

[Licensed under the GPLv3 license.](https://github.com/virtyaluk/InTouch/blob/master/LICENSE)

Copyright (c) 2017 Bohdan Shtepan

---

> [modern-dev.com](http://modern-dev.com) &nbsp;&middot;&nbsp;
> GitHub [@virtyaluk](https://github.com/virtyaluk) &nbsp;&middot;&nbsp;
> Twitter [@virtyaluk](https://twitter.com/virtyaluk)
