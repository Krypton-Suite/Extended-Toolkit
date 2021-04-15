#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Net;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class InternetProtocolEventArgs : EventArgs
    {
        private IPAddress _ipAdress;

        private string _iPAddress;

        public IPAddress IPAddress { get => _ipAdress; set => _ipAdress = value; }

        public string IPAddressString { get => _iPAddress; set => _iPAddress = value; }

        public InternetProtocolEventArgs(string ipAdress)
        {
            IPAddressString = ipAdress;
        }

        public InternetProtocolEventArgs(IPAddress ipAddress)
        {
            IPAddress = ipAddress;
        }

        public IPAddress TranslateIPAddress(string ipAddress) => IPAddress.Parse(ipAddress);

        public string TranslateIPAddress(IPAddress ipAddress) => ipAddress.ToString();
    }
}