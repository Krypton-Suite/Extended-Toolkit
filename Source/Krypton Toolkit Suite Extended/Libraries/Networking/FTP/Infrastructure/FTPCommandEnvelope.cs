namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class FTPCommandEnvelope
    {
        public FTPCommand FtpCommand { get; set; }
        public string Data { get; set; }

        public string GetCommandString()
        {
            string command = FtpCommand.ToString();

            return string.IsNullOrEmpty(Data)
                ? command
                : $"{command} {Data}";
        }
    }
}