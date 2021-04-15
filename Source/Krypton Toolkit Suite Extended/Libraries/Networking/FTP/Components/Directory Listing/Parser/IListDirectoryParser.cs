namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public interface IListDirectoryParser
    {
        bool Test(string testString);

        FTPNodeInformation Parse(string line);
    }
}