using System;
using System.Net;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities
{
    /// <summary>
    /// Handles networking.
    /// </summary>
    public class NetworkUtilities
    {
        #region Variables
        private ExceptionHandler exceptionHandler = new ExceptionHandler();

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
        public void CheckInternetConnectionState(string pingAddress = null)
        {
            try
            {

            }
            catch (Exception ex)
            {
                if (globalMethods.CheckIfTargetPlatformIsSupported(true))
                {
                    if (globalMethods.GetIsTargetPlatformSupported())
                    {
                        ExceptionHandler.CaptureException(ex, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error, "NetworkUtilities", "CheckInternetConnectionState(string pingAddress = null)");
                    }
                    else
                    {

                    }
                }

                globalMethods.SetInternetConnectionState(false);
            }
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
                        ExceptionHandler.CaptureException(ex, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error, "NetworkUtilities", "ExistsOnServer(Uri fileLocation)");
                    }
                    else
                    {
                        ExceptionHandler.CaptureException(ex, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error, "NetworkUtilities", "ExistsOnServer(Uri fileLocation)");
                    }
                }

                return false;
            }
        }
        #endregion
    }
}