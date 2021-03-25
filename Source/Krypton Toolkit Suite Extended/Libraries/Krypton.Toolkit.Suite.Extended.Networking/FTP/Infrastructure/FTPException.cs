using System;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class FTPException : Exception
    {
        public FTPException() { }

        public FTPException(string message) : base(message) { }

        public FTPException(string message, Exception innerException) : base(message, innerException) { }
    }
}