#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// A NetSparkle exception
    /// </summary>
    [Serializable]
    public class NetSparkleException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">exception message</param>
        public NetSparkleException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">serialization info</param>
        /// <param name="context">the context</param>
        protected NetSparkleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}