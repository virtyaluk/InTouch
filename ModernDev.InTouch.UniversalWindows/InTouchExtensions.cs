using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A set of extensions aimed to extend usage of the <see cref="InTouch"/> class.
    /// </summary>
    public static class InTouchExtensions
    {
        #region Fields

        private const string AuthUrl = "https://oauth.vk.com/authorize";

        #endregion

        #region Methods

        /// <summary>
        /// Starts the authentication operation with a given settings.
        /// </summary>
        /// <param name="this">Instance of <see cref="InTouch"/>.</param>
        /// <param name="authSettings">Authorization settings</param>
        /// <param name="silentMode">Tells the web authentication broker to not render any UI.</param>
        /// <exception cref="InTouchException">Thrown when a HTTP error occurred or inner exceptions were caught.</exception>
        /// <returns></returns>
        public static async Task Authorize(this InTouch @this, AuthorizationSettings authSettings = null, bool silentMode = false)
        {
            var ad = authSettings ?? new AuthorizationSettings();

            if (@this.ClientId == 0)
            {
                throw new NullReferenceException("ClientId cannot be null or empty");
            }

            var authParams = new Dictionary<string, object>
            {
                {"client_id", @this.ClientId},
                {"v", @this.APIVersion},
                {"scope", (int) ad.Scope},
                {"display", Utils.ToEnumString(ad.Display)},
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
                        Utils.ParseQueryString(webAuthResult.ResponseData.Substring(ad.RedirectUri.ToString().Length + 1));

                    @this.SetSessionData(responseData["access_token"], int.Parse(responseData["user_id"]),
                        int.Parse(responseData["expires_in"]));
                }
                else if (webAuthResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
                {
                    throw new InTouchException("A HTTP error occurred while attempting to contact the server.", webAuthResult.ResponseErrorDetail);
                }
                else
                {
                    throw new InTouchException("An error occurred while attempting to authorize.", webAuthResult.ResponseStatus);
                }
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while authenticating.", ex);
            }
        }

        #endregion
    }
}