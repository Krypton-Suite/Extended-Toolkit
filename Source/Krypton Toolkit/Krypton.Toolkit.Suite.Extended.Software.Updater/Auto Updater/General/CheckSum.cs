namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    ///     Checksum class to fetch the XML values for checksum.
    /// </summary>
    public class CheckSum
    {
        /// <summary>
        ///     Hash of the file.
        /// </summary>
        [XmlText]
        public string Value { get; set; }

        /// <summary>
        ///     Hash algorithm that generated the hash.
        /// </summary>
        [XmlAttribute("algorithm")]
        public string HashingAlgorithm { get; set; }
    }
}