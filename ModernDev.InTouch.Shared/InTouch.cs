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
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static ModernDev.InTouch.Helpers.Utils;

[assembly: InternalsVisibleTo("ModernDev.InTouch.Tests")]

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for working with vk.com API.
    /// </summary>
    public partial class InTouch : IDisposable
    {
        #region Fields
        
        private HttpClient _apiClient;
        private HttpClient _fileClient;
        private readonly Uri _baseApiUri = new Uri("https://api.vk.com/");
        private string _dataLang = "en";
        private bool _lastReqIsOpen;
        private string _lastReqPath;
        private Dictionary<string, string> _lastReqParams;
        private string _lastReqMethod;
        private readonly HttpMessageHandler _httpMessageHandler;
        private bool _disposed;

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
        public const string APIVersion = "5.52";

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
        public APISession Session { get; internal set; }

        /// <summary>
        /// Methods for working with user's account data.
        /// </summary>
        public AccountMethods Account { get; }

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
        public GiftsMethods Gifts { get; private set; }

        /// <summary>
        /// Methods for working with VK storage.
        /// </summary>
        public StorageMethods Storage { get; private set; }

        /// <summary>
        /// Utility methods.
        /// </summary>
        public UtilsMethods Utils { get; private set; }

        /// <summary>
        /// Methods for working with user's faves lists.
        /// </summary>
        public FaveMethods Fave { get; private set; }

        /// <summary>
        /// Methods for working with user's docs.
        /// </summary>
        public DocsMethods Docs { get; private set; }

        /// <summary>
        /// Methods for working with polls.
        /// </summary>
        public PollsMethods Polls { get; private set; }

        /// <summary>
        /// Methods for working with likes.
        /// </summary>
        public LikesMethods Likes { get; private set; }

        /// <summary>
        /// Auth methods.
        /// </summary>
        public AuthMethods Auth { get; private set; }

        /// <summary>
        /// Methods for working with the wall.
        /// </summary>
        public WallMethods Wall { get; private set; }

        /// <summary>
        /// Methods for working with photos.
        /// </summary>
        public PhotosMethods Photos { get; private set; }

        /// <summary>
        /// Methods for working with friends.
        /// </summary>
        public FriendsMethods Friends { get; private set; }

        /// <summary>
        /// Methods for working with videos.
        /// </summary>
        public VideoMethods Videos { get; private set; }


        /// <summary>
        /// Methods for working with places.
        /// </summary>
        public PlacesMethods Places { get; private set; }

        /// <summary>
        /// Methods for working with user's messages.
        /// </summary>
        public MessagesMethods Messages { get; private set; }

        /// <summary>
        /// Methods for working with user's notifications.
        /// </summary>
        public NotificationsMethods Notifications { get; private set; }

        /// <summary>
        /// Methods for working with newsfeed.
        /// </summary>
        public NewsfeedMethods Newsfeed { get; private set; }

        /// <summary>
        /// Methods for working with VK open data.
        /// </summary>
        public DatabaseMethods Database { get; private set; }

        /// <summary>
        /// Methods for working with audio files.
        /// </summary>
        public AudioMethods Audio { get; private set; }

        /// <summary>
        /// Methods for working with wiki pages.
        /// </summary>
        public PagesMethods Pages { get; private set; }

        /// <summary>
        /// Methods for working with communities.
        /// </summary>
        public GroupsMethods Groups { get; private set; }

        /// <summary>
        /// Methods for working with community's topics.
        /// </summary>
        public BoardMethods Board { get; private set; }

        /// <summary>
        /// Methods for working with user's notes.
        /// </summary>
        public NotesMethods Notes { get; private set; }

        /// <summary>
        /// Methods for working with statistics.
        /// </summary>
        public StatsMethods Stats { get; private set; }

        /// <summary>
        /// Methods for working with search system.
        /// </summary>
        public SearchMethods Search { get; private set; }

        /// <summary>
        /// Methods for working with market items.
        /// </summary>
        public MarketMethods Market { get; private set; }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when an authorization fails.
        /// </summary>
        public event EventHandler<ResponseError> AuthorizationFailed;

        /// <summary>
        /// Occurs when is need to enter captcha key.
        /// </summary>
        public event EventHandler<ResponseError> CaptchaNeeded;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InTouch"/> class.
        /// </summary>
        /// <param name="throwExceptionOnResponseError">Whether the raw response string should be included in request response object.</param>
        /// <param name="includeRawResponse">Whether the raw response string should be included in request response object.</param>
        public InTouch(bool throwExceptionOnResponseError = false, bool includeRawResponse = false)
        {
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
            Pages = new PagesMethods(this);
            Groups = new GroupsMethods(this);
            Board = new BoardMethods(this);
            Notes = new NotesMethods(this);
            Stats = new StatsMethods(this);
            Search = new SearchMethods(this);
            Market = new MarketMethods(this);

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new PrivateResolver()
            };
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
        
        internal InTouch(HttpMessageHandler httpMessageHandler, int clientId, string clientSecret,
            bool throwExceptionOnResponseError = false,
            bool includeRawResponse = false)
            : this(clientId, clientSecret, throwExceptionOnResponseError, includeRawResponse)
        {
            _httpMessageHandler = httpMessageHandler;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks whether the API session is alive.
        /// </summary>
        /// <returns>True if session alive.</returns>
        public async Task<bool> IsSessionAlive()
        {
            try
            {
                var accountInfo = await Account.GetInfo(new List<AccountInfoFields> {AccountInfoFields.Lang});

                if (accountInfo.IsError)
                {
                    return false;
                }

                _dataLang = accountInfo.Data.Lang.ToString();

                 return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to send request with data from the last request.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Response{T}.Data"/> property.</typeparam>
        /// <returns>Returns the result of API call.</returns>
        public async Task<Response<T>> TrySendRequestAgain<T>()
            => await Request<T>(_lastReqMethod, _lastReqParams, _lastReqIsOpen, _lastReqPath);

        /// <summary>
        /// Sends captcha code with given error object from the last request.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Response{T}.Data"/> property.</typeparam>
        /// <param name="captchaKey"></param>
        /// <param name="lastResponseError"><see cref="ResponseError"/> object from last call response object.</param>
        /// <param name="isOpen">Indicates whether the method can be called without <see cref="APISession.AccessToken"/>.</param>
        /// <param name="path">Object path to select the token.</param>
        /// <returns>Returns the result of API call.</returns>
        public async Task<Response<T>> SendCaptcha<T>(string captchaKey, ResponseError lastResponseError,
            bool isOpen = false, string path = null)
        {
            if (string.IsNullOrEmpty(captchaKey))
            {
                throw new ArgumentNullException(nameof(captchaKey));
            }

            if (string.IsNullOrEmpty(lastResponseError?.CaptchaSId))
            {
                throw new ArgumentNullException(nameof(lastResponseError));
            }

            var newParams = lastResponseError.RequestParams.Where(kvp => !kvp.Key.IsInSet("method", "oauth"))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            newParams["captcha_sid"] = lastResponseError.CaptchaSId;
            newParams["captcha_key"] = captchaKey;

            return await Request<T>(lastResponseError.RequestParams["method"], newParams, isOpen, path);
        }

        /// <summary>
        /// Sets the App Id and Secret.
        /// </summary>
        /// <param name="clientId">Your App Id.</param>
        /// <param name="clientSecret">Your App Secret.</param>
        /// <exception cref="ArgumentNullException">Thrown when an <code>appSecret</code> is <code>null</code> or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when an <code>clientId</code> is less than or equal to zero.</exception>
        public void SetApplicationSettings(int clientId, string clientSecret)
        {
            if (clientId <= 0)
            {
                throw new ArgumentException("The value cannot be less than or equal to zero.", nameof(clientId));
            }

            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException(nameof(clientSecret), "Value cannot be null or empty.");
            }

            if (ClientId == clientId && ClientSecret == clientSecret)
            {
                return;
            }

            ClientId = clientId;
            ClientSecret = clientSecret;
            Session = null;
        }

        /// <summary>
        /// Sets the session data.
        /// </summary>
        /// <param name="newSession">The new <see cref="APISession"/> instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when a <code>newSession</code> is <code>null</code>.</exception>
        internal void SetSessionData(APISession newSession)
        {
            if (newSession == null)
            {
                throw new ArgumentNullException(nameof(newSession), "Value cannot be null.");
            }

            if (Session != null)
            {
                Session.AccessTokenExpired -= AccessTokenExpired;
            }

            newSession.AccessTokenExpired += AccessTokenExpired;

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

            if (sessionDuration < 0)
            {
                throw new ArgumentException("The value cannot be less than zero.", nameof(sessionDuration));
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
            if (!isOpenMethod)
            {
                if (Session == null)
                {
                    throw new NullReferenceException("The session is not set. You need to authorize to get the new session.");
                }

                if (Session.IsExpired)
                {
                    throw new InTouchException(
                        "The session is dead. You need to obtain new access token to perform API calls.");
                }
            }

            if (_apiClient == null)
            {
                InitApiClient();
            }

            var normalizedParams = NormalizeRequestParams(methodParams, isOpenMethod);

            CacheReqData(methodName, normalizedParams, isOpenMethod, path);

            var json = await Post($"method/{methodName}.json", normalizedParams);

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

        /// <summary>
        /// Releases all resources used by the current instance of <see cref="InTouch"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// 
        /// </summary>
        ~InTouch()
        {
            Dispose(false);
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

                return Encoding.UTF8.GetString(response, 0, response.Length);
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
        internal T ParseUploadServerResponse<T>(string json, string path = null)
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
            catch (Exception ex) when (ex.GetType() != typeof (InTouchResponseErrorException))
            {
                throw new InTouchException("An exception has occurred while parsing upload server response", ex);
            }
        }

        #region Non-public methods

        private void CacheReqData(string methodName, Dictionary<string, string> rParams, bool isOpen, string path)
        {
            _lastReqIsOpen = isOpen;
            _lastReqPath = path;
            _lastReqParams = rParams;
            _lastReqMethod = methodName;
        }

        internal void InitApiClient()
        {
            _apiClient = _httpMessageHandler != null
                ? new HttpClient(_httpMessageHandler)
                : new HttpClient();

            _apiClient.BaseAddress = _baseApiUri;
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal Response<T> ParseJsonReponse<T>(string json, string path = null)
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

                    if (errObj.Code == 5)
                    {
                        OnAuthorizationFailed(errObj);
                    }

                    if (errObj.Code == 14)
                    {
                        OnCaptchaNeeded(errObj);
                    }
                }
                else if (jObj["response"] != null)
                {
                    dataObj = !string.IsNullOrEmpty(path)
                        ? jObj["response"].SelectToken(path).ToObject<T>()
                        : jObj["response"].ToObject<T>();
                }
            }
            catch (Exception ex)
                when (ex.GetType() != typeof (InTouchException) &&
                      ex.GetType() != typeof (InTouchResponseErrorException))
            {
                throw new InTouchException("An exception has occurred while parsing request response", ex);
            }

            return new Response<T>(errObj, dataObj, IncludeRawResponse ? json : null);
        }

        internal async Task<string> Post(string url, Dictionary<string, string> paramsDict)
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

        private Dictionary<string, string> NormalizeRequestParams(Dictionary<string, string> reqParams = null,
            bool isOpenMethod = false)
        {
            var apiParams = reqParams ?? new Dictionary<string, string>();

            apiParams["access_token"] = Session?.AccessToken ?? "";
            apiParams["v"] = $"{APIVersion}";
            apiParams["https"] = $"{(AlowHttpsLinks ? 1 : 0)}";

            if (TestMode)
            {
                apiParams["test_mode"] = "1";
            }

            apiParams["lang"] = DataLanguage == Langs.UsersCurrentLanguage ? _dataLang : ToEnumString(DataLanguage);

            return apiParams.ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.ToString());
        }

        private void AccessTokenExpired(object sender, EventArgs e) => OnAuthorizationFailed(null);

        private void OnAuthorizationFailed(ResponseError e) => AuthorizationFailed?.Invoke(this, e);
        private void OnCaptchaNeeded(ResponseError e) => CaptchaNeeded?.Invoke(this, e);

        /// <summary>
        /// Releases all resources used by the current instance of <see cref="InTouch"/>.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _apiClient?.Dispose();
                    _fileClient?.Dispose();
                }

                _disposed = true;
            }
        }

        #endregion

        #endregion
    }
}
