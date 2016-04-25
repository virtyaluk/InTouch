using System;

namespace ModernDev.InTouch
{
    public partial class APISession: IDisposable
    {
        #region Fields

        private bool _disposed;
        private System.Threading.Timer _timer;

        #endregion

        #region Destructor

        /// <summary>
        /// 
        /// </summary>
        ~APISession()
        {

            Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases all resources used by the current instance of <see cref="APISession"/>.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _timer.Dispose();
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the current instance of <see cref="APISession"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        partial void InitTimer()
        {
            _timer = new System.Threading.Timer(e => OnAccessTokenExpired(EventArgs.Empty), null, (int)TimeRemains.TotalSeconds,
                System.Threading.Timeout.Infinite);
        }

        #endregion
    }
}
