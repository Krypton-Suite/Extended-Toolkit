#region MIT License
/*
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