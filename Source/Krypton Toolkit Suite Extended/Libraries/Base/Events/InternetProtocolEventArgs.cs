using System;
using System.Net;

namespace Krypton.Toolkit.Extended.Base
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