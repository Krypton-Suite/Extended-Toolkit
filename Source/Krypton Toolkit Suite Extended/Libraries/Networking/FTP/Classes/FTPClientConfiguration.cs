using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class FTPClientConfiguration
    {
        public int TimeoutSeconds { get; set; } = 120;
        public int? DisconnectTimeoutMilliseconds { get; set; } = 100;
        public int Port { get; set; } = Constants.FtpPort;
        public string Host { get; set; }
        public IPVersion IpVersion { get; set; } = IPVersion.IPV4;
        public FTPEncryption EncryptionType { get; set; } = FTPEncryption.NONE;
        public bool IgnoreCertificateErrors { get; set; } = true;
        public string Username { get; set; }
        public string Password { get; set; }
        public string BaseDirectory { get; set; } = "/";
        public FTPTransferMode Mode { get; set; } = FTPTransferMode.BINARY;
        public char ModeSecondType { get; set; } = '\0';

        public bool ShouldEncrypt => EncryptionType == FTPEncryption.EXPLICIT ||
                                     EncryptionType == FTPEncryption.IMPLICIT &&
                                     Port == Constants.FtpsPort;

        public X509CertificateCollection ClientCertificates { get; set; } = new X509CertificateCollection();
        public SslProtocols SslProtocols { get; set; } = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;
    }
}