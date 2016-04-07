using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using ModernDev.InTouch.Helpers;
using static ModernDev.InTouch.Helpers.Utils;

namespace ModernDev.InTouch
{
    public partial class InTouch
    {

        #region Methods
        
        /// <summary>
        /// Starts the authentication operation with a given settings.
        /// </summary>
        /// <param name="authSettings">Authorization settings</param>
        /// <param name="silentMode">Tells the web authentication broker to not render any UI.</param>
        /// <exception cref="InTouchException">Thrown when a HTTP error occurred or inner exceptions were caught.</exception>
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
