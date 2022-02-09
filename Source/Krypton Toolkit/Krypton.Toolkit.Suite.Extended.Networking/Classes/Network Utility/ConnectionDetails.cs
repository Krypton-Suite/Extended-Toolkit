#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal class ConnectionDetails
    {
        private Dictionary<string, string> _appProtocolList;

        public ConnectionDetails()
        {
            _appProtocolList = new Dictionary<string, string>();
            _appProtocolList.Add("22", "SSH");
            _appProtocolList.Add("80", "HTTP");
            _appProtocolList.Add("443", "HTTPS");
            _appProtocolList.Add("445", "Active Directory, Windows shares");
        }

        public string LocalAddress { set; get; }

        public string LocalPort { set; get; }

        public string RemoteAddress { set; get; }

        public string RemotePort { set; get; }

        public string ApplicationProtocol
        {
            get
            {
                if (_appProtocolList.ContainsKey(RemotePort))
                {
                    return _appProtocolList[RemotePort];
                }
                return "";
            }
        }

        public string Protocol { set; get; }
    }
}