namespace Krypton.Toolkit.Suite.Extended.Software.Updater.AutoUpdaterDotNET
{
    /// <summary>
    ///     Provides Custom Authentication header for web request.
    /// </summary>
    public class CustomAuthentication : IAuthentication
    {
        private string HttpRequestHeaderAuthorizationValue { get; }

        /// <summary>
        /// Initializes authorization header value for Custom Authentication
        /// </summary>
        /// <param name="httpRequestHeaderAuthorizationValue">Value to use as http request header authorization value</param>
        public CustomAuthentication(string httpRequestHeaderAuthorizationValue)
        {
            HttpRequestHeaderAuthorizationValue = httpRequestHeaderAuthorizationValue;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return HttpRequestHeaderAuthorizationValue;
        }
    }
}