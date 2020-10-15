namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class FTPResponse
    {
        public FTPStatusCode FtpStatusCode { get; set; }

        public bool IsSuccess
        {
            get
            {
                int statusCode = (int)FtpStatusCode;
                return statusCode >= 100 && statusCode < 400;
            }
        }

        public string ResponseMessage { get; set; }
        public string[] Data { get; set; }
        public string Request { get; set; }

        public static FTPResponse EmptyResponse = new FTPResponse
        {
            ResponseMessage = "No response was received",
            FtpStatusCode = FTPStatusCode.UNDEFINED
        };
    }
}