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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using ModernDev.InTouch.Helpers;
using Newtonsoft.Json.Linq;
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch
{
    public partial class InTouch : IDisposable
    {
        #region Fields

        private readonly HttpClient _apiClient;
        private HttpClient _fileClient;
        private readonly Uri _baseApiUri = new Uri("https://api.vk.com/");
        private const string AuthUrl = "https://oauth.vk.com/authorize";
        private string _dataLang = "en";

        #endregion

        #region Properties

        /// <summary>
        /// Your application ID.
        /// </summary>
        public int ClientId { get; private set; }

        /// <summary>
        /// Your application secret.
        /// </summary>
        public string ClientSecret { get; private set; }

        /// <summary>
        /// The used API version.
        /// </summary>
        public const double APIVersion = 5.45;

        /// <summary>
        /// Determines the language for the data to be displayed on.
        /// </summary>
        public Langs DataLanguage { get; set; } = Langs.English;

        /// <summary>
        /// Allows to send requests from a native app without switching it on for all users.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Allows to get <c>https</c> links for photos and other media.
        /// </summary>
        public bool AlowHttpsLinks { get; set; } = true;

        /// <summary>
        /// Determines whether exception should be thrown if request's response is error.
        /// </summary>
        public bool ThrowExceptionOnResponseError { get; set; }

        /// <summary>
        /// Determines whether the raw response string should be included in request response object.
        /// </summary>
        public bool IncludeRawResponse { get; set; }

        /// <summary>
        /// The current API session.
        /// </summary>
        public APISession Session { get; private set; }

        /// <summary>
        /// Methods for working with user's account data.
        /// </summary>
        public AccountMethods Account { get; private set; }

        /// <summary>
        /// Methods for working with users.
        /// </summary>
        public UsersMethods Users { get; private set; }


        /// <summary>
        /// Methods for working with user's text status.
        /// </summary>
        public StatusMethods Status { get; private set; }

        /// <summary>
        /// Methods for working with gifts.
        /// </summary>
        public GiftsMethods Gifts { get; set; }

        /// <summary>
        /// Methods for working with VK storage.
        /// </summary>
        public StorageMethods Storage { get; set; }

        /// <summary>
        /// Utility methods.
        /// </summary>
        public UtilsMethods Utils { get; set; }

        /// <summary>
        /// Methods for working with user's faves lists.
        /// </summary>
        public FaveMethods Fave { get; set; }

        /// <summary>
        /// Methods for working with user's docs.
        /// </summary>
        public DocsMethods Docs { get; set; }

        /// <summary>
        /// Methods for working with polls.
        /// </summary>
        public PollsMethods Polls { get; set; }

        /// <summary>
        /// Methods for working with likes.
        /// </summary>
        public LikesMethods Likes { get; set; }

        /// <summary>
        /// Auth methods.
        /// </summary>
        public AuthMethods Auth { get; set; }

        /// <summary>
        /// Methods for working with the wall.
        /// </summary>
        public WallMethods Wall { get; set; }

        /// <summary>
        /// Methods for working with photos.
        /// </summary>
        public PhotosMethods Photos { get; set; }

        /// <summary>
        /// Methods for working with friends.
        /// </summary>
        public FriendsMethods Friends { get; set; }

        /// <summary>
        /// Methods for working with videos.
        /// </summary>
        public VideoMethods Videos { get; set; }


        /// <summary>
        /// Methods for working with places.
        /// </summary>
        public PlacesMethods Places { get; set; }

        /// <summary>
        /// Methods for working with user's messages.
        /// </summary>
        public MessagesMethods Messages { get; set; }

        /// <summary>
        /// Methods for working with user's notifications.
        /// </summary>
        public NotificationsMethods Notifications { get; set; }

        /// <summary>
        /// Methods for working with newsfeed.
        /// </summary>
        public NewsfeedMethods Newsfeed { get; set; }

        /// <summary>
        /// Methods for working with VK open data.
        /// </summary>
        public DatabaseMethods Database { get; set; }

        /// <summary>
        /// Methods for working with audio files.
        /// </summary>
        public AudioMethods Audio { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InTouch"/> class.
        /// </summary>
        /// <param name="throwExceptionOnResponseError">Whether the raw response string should be included in request response object.</param>
        /// <param name="includeRawResponse">Whether the raw response string should be included in request response object.</param>
        public InTouch(bool throwExceptionOnResponseError = false, bool includeRawResponse = false)
        {
            _apiClient = new HttpClient
            {
                BaseAddress = _baseApiUri
            };

            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ThrowExceptionOnResponseError = throwExceptionOnResponseError;
            IncludeRawResponse = includeRawResponse;

            Account = new AccountMethods(this);
            Users = new UsersMethods(this);
            Status = new StatusMethods(this);
            Gifts = new GiftsMethods(this);
            Storage = new StorageMethods(this);
            Utils = new UtilsMethods(this);
            Fave = new FaveMethods(this);
            Docs = new DocsMethods(this);
            Polls = new PollsMethods(this);
            Likes = new LikesMethods(this);
            Auth = new AuthMethods(this);
            Wall = new WallMethods(this);
            Photos = new PhotosMethods(this);
            Friends = new FriendsMethods(this);
            Videos = new VideoMethods(this);
            Places = new PlacesMethods(this);
            Messages = new MessagesMethods(this);
            Notifications = new NotificationsMethods(this);
            Newsfeed = new NewsfeedMethods(this);
            Database = new DatabaseMethods(this);
            Audio = new AudioMethods(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InTouch"/> class with a specific <code>client_id</code> and <code>client_secret</code>.
        /// </summary>
        /// <param name="clientId">Your application ID.</param>
        /// <param name="clientSecret">Your application secret.</param>
        /// <param name="throwExceptionOnResponseError">Whether the raw response string should be included in request response object.</param>
        /// <param name="includeRawResponse">Whether the raw response string should be included in request response object.</param>
        public InTouch(int clientId, string clientSecret, bool throwExceptionOnResponseError = false,
            bool includeRawResponse = false) : this(throwExceptionOnResponseError, includeRawResponse)
        {
            SetApplicationSettings(clientId, clientSecret);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts the authentication operation with a given settings.
        /// </summary>
        /// <param name="authSettings">Authorization settings</param>
        /// <param name="silentMode">Tells the web authentication broker to not render any UI.</param>
        /// <exception cref="InTouchException">TODO:</exception>
        /// <returns></returns>
        public async Task Authorize(AuthorizationSettings authSettings = null, bool silentMode = false)
        {
            var ad = authSettings ?? new AuthorizationSettings();

            if (ClientId == 0)
            {
                throw new NullReferenceException("ClientId cannot be null or empty");
            }

            var authParams = new Dictionary<string, object>
            {
                {"client_id", ClientId},
                {"v", APIVersion},
                {"scope", (int) ad.Scope},
                {"display", ToEnumString(ad.Display)},
                {"response_type", "token"},
                {"revoke", ad.Revoke ? 1 : 0},
                {"redirect_uri", ad.RedirectUri},
                {"lang", "en"}
            };

            var authUrl = new Uri($"{AuthUrl}?{authParams.GetQueryString()}");
            var endUrl = new Uri($"{ad.RedirectUri}#access_token=");
            var wao = silentMode ? WebAuthenticationOptions.SilentMode : WebAuthenticationOptions.None;

            try
            {
                WebAuthenticationResult webAuthResult;

                if (ad.SSOEnabled)
                {
                    webAuthResult = await WebAuthenticationBroker.AuthenticateAsync(wao, authUrl);
                }
                else
                {
                    webAuthResult = await WebAuthenticationBroker.AuthenticateAsync(wao, authUrl, endUrl);
                }

                if (webAuthResult.ResponseStatus == WebAuthenticationStatus.Success)
                {
                    var responseData =
                        ParseQueryString(webAuthResult.ResponseData.Substring(ad.RedirectUri.ToString().Length + 1));

                    SetSessionData(responseData["access_token"], int.Parse(responseData["user_id"]),
                        int.Parse(responseData["expires_in"]));
                }
                else if (webAuthResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
                {
                    // TODO:
                    Debug.WriteLine($"HTTP error returned by AuthenticateAsync(): {webAuthResult.ResponseErrorDetail}");
                }
                else
                {
                    // TODO:
                    Debug.WriteLine($"Error returned by AuthenticateAsync(): {webAuthResult.ResponseStatus}");
                }
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while authenticating.", ex);
            }
        }

        /// <summary>
        /// Sets the App Id and Secret.
        /// </summary>
        /// <param name="appId">Your App Id.</param>
        /// <param name="appSecret">Your App Secret.</param>
        /// <exception cref="ArgumentNullException">Thrown when an <code>appSecret</code> is <code>null</code> or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when an <code>appId</code> is less than or equal to zero.</exception>
        public void SetApplicationSettings(int appId, string appSecret)
        {
            if (appId <= 0)
            {
                throw new ArgumentException("The value cannot be less than or equal to zero.", nameof(appId));
            }

            if (string.IsNullOrEmpty(appSecret))
            {
                throw new ArgumentNullException(nameof(appSecret), "Value cannot be null or empty.");
            }

            ClientId = appId;
            ClientSecret = appSecret;
        }

        /// <summary>
        /// Sets the session data.
        /// </summary>
        /// <param name="newSession">The new <see cref="APISession"/> instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <code>newSession</code> is <code>null</code>.</exception>
        public void SetSessionData(APISession newSession)
        {
            if (newSession == null)
            {
                throw new ArgumentNullException(nameof(newSession), "Value cannot be null.");
            }

            Session = newSession;
        }

        /// <summary>
        /// Sets the session data.
        /// </summary>
        /// <param name="accessToken">Access key for API calls.</param>
        /// <param name="userId">The authorized user ID.</param>
        /// <param name="sessionDuration"><see cref="APISession.AccessToken"/> life time specified in seconds.</param>
        /// <exception cref="ArgumentNullException">Thrown when an <code>accessToken</code> is <code>null</code> or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when an <code>userId</code> or a <code>sessionDuration</code> is less than or equal to zero.</exception>
        public void SetSessionData(string accessToken, int userId, int sessionDuration = 20*60*60)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken), "Value cannot be null or empty.");
            }

            if (userId <= 0)
            {
                throw new ArgumentException("The value cannot be less than or equal to zero.", nameof(userId));
            }

            if (sessionDuration <= 0)
            {
                throw new ArgumentException("The value cannot be less than or equal to zero.", nameof(sessionDuration));
            }

            SetSessionData(new APISession(accessToken, userId, sessionDuration));
        }

        /// <summary>
        /// Cancel all pending requests on this instance.
        /// </summary>
        public void CancelPendingRequests()
        {
            _apiClient.CancelPendingRequests();
        }

        /// <summary>
        /// Performs an asynchronous API call to the specific method with a given parameters.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Response{T}.Data"/> property.</typeparam>
        /// <param name="methodName">The name of the method to call.</param>
        /// <param name="methodParams">Request parameters.</param>
        /// <param name="isOpenMethod">Indicates whether the method can be called without <see cref="APISession.AccessToken"/>.</param>
        /// <param name="path">Object path to select the token.</param>
        /// <returns>Returns the result of API call.</returns>
        public async Task<Response<T>> Request<T>(string methodName, Dictionary<string, string> methodParams = null,
            bool isOpenMethod = false, string path = null)
        {
            var json = await Post($"method/{methodName}.json", NormalizeRequestParams(methodParams, isOpenMethod));

            return await Task.Run(() => ParseJsonReponse<T>(json, path));
        }

        /// <summary>
        /// A universal method for calling a sequence of other methods while saving and filtering interim results.
        /// <remarks>
        /// This method can also be used to get results of several unrelated requests.
        /// 
        /// This method supports arithmetical operations, arrays, lists, parseInt, parseDouble, concatenation (+), array filter by parameter (@.), creating arrays and lists ([X,Y]), and calling API methods. It does not support functions, logical connectives, loops, or conditions. 
        ///
        /// Referencing to array elements with results of some sort of method should be based on JSON structure, for example:
        /// <example>API.audio.search({"q":"Beatles","count":3})@.owner_id;</example>
        /// 
        /// But not on XML structure:
        /// <example>API.audio.search({"q":"Beatles","count":3})@.audio@.owner_id;</example>
        /// 
        /// Sample Values of the code Parameter
        /// 
        /// <example>return [API.isAppUser(), API.getAppFriends(), API.getUserBalance()];</example>
        /// <example>return {"user": API.isAppUser(), "friends": API.getAppFriends(), "balance": API.getUserBalance()};</example>
        /// </remarks>
        /// </summary>
        /// <param name="code">
        /// Algorithm code in <c>VKScript</c> - a format similar to <c>JavaScript</c> or <c>ActionScript</c> and assuming compatibility with <c>ECMAScript</c>.
        /// 
        /// Separate operators by semicolons. Terminate the algorithm with the command return <c>%expression%</c>.
        /// 
        /// Example:
        /// <example>
        /// // assigns the audio search result to variable a with these parameters 
        /// var a = API.audio.search({"q":"Beatles", "count":3}); 
        /// // assigns the list of found audio owners to variable b 
        /// var b = a@.owner_id; 
        /// // assigns profile data of owners from list b to variable c 
        /// var c = API.getProfiles({"uids":b}); 
        /// // returns a list of surnames from the owner data 
        /// return c@.last_name;
        /// </example>
        /// 
        /// The same can be shortened as:
        /// <example>return API.getProfiles({"uids": API.audio.search({"q": "Beatles", "count": 3})@.owner_id})@.last_name;</example>
        /// </param>
        /// <returns>Returns data requested by the algorithm.</returns>
        public async Task<Response<JObject>> Execute(string code)
            => await Request<JObject>("execute", new MethodParams {{"code", code, true}}.GetParams());

        public void Dispose()
        {
            _apiClient?.Dispose();
            _fileClient?.Dispose();
        }
        
        /// <summary>
        /// Uploads the file by given link.
        /// </summary>
        /// <param name="uploadServer">A link of upload server.</param>
        /// <param name="files">A dictionary of files to upload where: <c>Item1</c> - string param; <c>Item2</c> - file data; <c>Item3</c> - file name.</param>
        /// <param name="otherParams">A dictionary of additional parameters.</param>
        /// <returns>Returns request response message as a lain string.</returns>
        public async Task<string> UploadFile(string uploadServer, List<Tuple<string, byte[], string>> files,
            Dictionary<string, string> otherParams = null)
        {
            if (string.IsNullOrEmpty(uploadServer))
            {
                throw new ArgumentNullException(nameof(uploadServer));
            }

            if (_fileClient == null)
            {
                _fileClient = new HttpClient();
            }

            try
            {
                var multipartData = new MultipartFormDataContent();

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        multipartData.Add(new ByteArrayContent(file.Item2), file.Item1, file.Item3);
                    }
                }

                if (otherParams != null)
                {
                    foreach (var otherParam in otherParams.Where(kvp => !string.IsNullOrEmpty(kvp.Value)))
                    {
                        multipartData.Add(new StringContent(otherParam.Value), otherParam.Key);
                    }
                }

                var reqRes = await _fileClient.PostAsync(new Uri(uploadServer), multipartData);

                reqRes.EnsureSuccessStatusCode();

                var response = await reqRes.Content.ReadAsByteArrayAsync();

                return Encoding.UTF8.GetString(response);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading file.", ex);
            }
        }

        /// <summary>
        /// Parses upload server response.
        /// </summary>
        /// <typeparam name="T">Object type to deserialize into.</typeparam>
        /// <param name="json">Upload server response to parse.</param>
        /// <param name="path">JPath to select the token.</param>
        /// <returns>Returns deserialized object.</returns>
        public T ParseUploadServerResponse<T>(string json, string path = null)
        {
            try
            {
                var jObj = JObject.Parse(json);

                if (jObj["error"] != null)
                {
                    throw new InTouchResponseErrorException((string) jObj["error"]);
                }

                return string.IsNullOrEmpty(path) ? jObj.ToObject<T>() : jObj.SelectToken(path).ToObject<T>();
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while parsing upload server response", ex);
            }
        }

        #region Non-public methods

        protected Response<T> ParseJsonReponse<T>(string json, string path = null)
        {
            ResponseError errObj = null;
            var dataObj = default(T);

            try
            {
                var jObj = JObject.Parse(json);

                if (jObj["error"] != null)
                {
                    errObj = jObj["error"].ToObject<ResponseError>();

                    if (ThrowExceptionOnResponseError)
                    {
                        throw new InTouchResponseErrorException(errObj.Message, errObj);
                    }
                }
                else if (jObj["response"] != null)
                {
                    dataObj = !string.IsNullOrEmpty(path)
                        ? jObj["response"].SelectToken(path).ToObject<T>()
                        : jObj["response"].ToObject<T>();
                }
            }
            catch (Exception ex) when (ex.GetType() != typeof (InTouchException))
            {
                throw new InTouchException("An exception has occurred while parsing request response", ex);
            }

            return new Response<T>(errObj, dataObj, IncludeRawResponse ? json : null);
        }
        
        protected async Task<string> Post(string url, Dictionary<string, string> paramsDict)
        {
            try
            {
                var response = await _apiClient.PostAsync(url, new FormUrlEncodedContent(paramsDict));

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while processing the POST request.", ex);
            }
        }

        protected Dictionary<string, string> NormalizeRequestParams(Dictionary<string, string> reqParams = null,
            bool isOpenMethod = false)
        {
            var apiParams = reqParams ?? new Dictionary<string, string>();

            if (Session == null)
            {
                throw new NullReferenceException("The session is not set. You need to authorize to get the new session.");
            }

            if (!Session.IsAlive)
            {
                throw new InTouchException("The session is dead. You need to obtain new access token to perform API calls.");
            }

            if (!isOpenMethod && string.IsNullOrEmpty(Session?.AccessToken))
            {
                throw new NullReferenceException("AccessToken cannot be null or empty.");
            }

            apiParams["access_token"] = Session?.AccessToken;
            apiParams["v"] = $"{APIVersion}";
            apiParams["https"] = $"{(AlowHttpsLinks ? 1 : 0)}";

            if (TestMode)
            {
                apiParams["test_mode"] = "1";
            }

            apiParams["lang"] = DataLanguage == Langs.UsersCurrentLanguage ? _dataLang : ToEnumString(DataLanguage);

            return apiParams.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
        }

        #endregion

        #endregion
    }
}