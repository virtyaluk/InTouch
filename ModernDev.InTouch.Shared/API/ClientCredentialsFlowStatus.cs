using System;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Represents a status of Client Credentials Flow authorization;
    /// </summary>
    public sealed class ClientCredentialsFlowStatus
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientCredentialsFlowStatus"/> class.
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="error"></param>
        /// <param name="errorDescription"></param>
        /// <param name="accessToken"></param>
        internal ClientCredentialsFlowStatus(bool isError, string error, string errorDescription, string accessToken)
        {
            IsError = isError;
            AccessToken = accessToken;
            Error = error;
            ErrorDescription = errorDescription;
            Date = DateTime.Now;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Error message, if any.
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// Error description, if any.
        /// </summary>
        public string ErrorDescription { get; private set; }

        /// <summary>
        /// Returns whether status has an error.
        /// </summary>
        public bool IsError { get; private set; }

        /// <summary>
        /// Service token.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Returns object creation date.
        /// </summary>
        public DateTime Date { get; private set; }

        #endregion
    }
}
