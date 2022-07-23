#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities
{
    /// <summary>
    /// Handles networking.
    /// </summary>
    public class NetworkUtilities
    {
        #region Variables
        private GlobalMethods globalMethods = new GlobalMethods();
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="NetworkUtilities"/> class.
        /// </summary>
        public NetworkUtilities()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Checks the state of the Internet connection.
        /// </summary>
        /// <param name="pingAddress">The ping address.</param>
        public bool CheckInternetConnectionState(string pingAddress = null)
        {
            bool isConnectionAlive = false;

            Ping pinger = null;

            try
            {
                pinger = new Ping();

                PingReply reply = pinger.Send(pingAddress);

                isConnectionAlive = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                if (globalMethods.CheckIfTargetPlatformIsSupported(true))
                {
                    if (globalMethods.GetIsTargetPlatformSupported())
                    {
                        ExceptionCapture.CaptureException(ex, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error, "NetworkUtilities", "CheckInternetConnectionState(string pingAddress = null)");
                    }
                    else
                    {
                        ExceptionCapture.CaptureException(ex);
                    }
                }

                globalMethods.SetInternetConnectionState(false);
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            globalMethods.SetInternetConnectionState(isConnectionAlive);

            return isConnectionAlive;
        }

        /// <summary>
        /// Checks to see whether the specified file exists the on server.
        /// </summary>
        /// <param name="fileLocation">The file location.</param>
        /// <returns></returns>
        public bool ExistsOnServer(Uri fileLocation)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(fileLocation.AbsoluteUri);

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                webResponse.Close();

                return webResponse.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                if (globalMethods.CheckIfTargetPlatformIsSupported(true))
                {
                    if (globalMethods.GetIsTargetPlatformSupported())
                    {
                        ExceptionCapture.CaptureException(ex, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error, "NetworkUtilities", "ExistsOnServer(Uri fileLocation)");
                    }
                    else
                    {
                        ExceptionCapture.CaptureException(ex, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error, "NetworkUtilities", "ExistsOnServer(Uri fileLocation)");
                    }
                }

                return false;
            }
        }
        #endregion
    }
}