namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    /// The type of hash to create
    /// </summary>
    internal enum HashType
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }

    public enum JobType
    {
        UPDATE,
        ADD,
        REMOVE
    }
}