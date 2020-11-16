#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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