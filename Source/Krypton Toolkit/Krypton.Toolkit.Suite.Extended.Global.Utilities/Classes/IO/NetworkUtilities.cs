#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities;

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
    public bool CheckInternetConnectionState(string? pingAddress = null)
    {
        bool isConnectionAlive = false;

        Ping? pinger = null;

        try
        {
            pinger = new Ping();

            if (pingAddress != null)
            {
                PingReply? reply = pinger.Send(pingAddress);

                if (reply != null)
                {
                    isConnectionAlive = reply.Status == IPStatus.Success;
                }
            }
        }
        catch (PingException ex)
        {
            if (globalMethods.CheckIfTargetPlatformIsSupported(true))
            {
                if (globalMethods.GetIsTargetPlatformSupported())
                {
                    DebugUtilities.NotImplemented(ex.ToString());
                }
                else
                {
                    DebugUtilities.NotImplemented(ex.ToString());
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
                    DebugUtilities.NotImplemented(ex.ToString());
                }
                else
                {
                    DebugUtilities.NotImplemented(ex.ToString());
                }
            }

            return false;
        }
    }
    #endregion
}