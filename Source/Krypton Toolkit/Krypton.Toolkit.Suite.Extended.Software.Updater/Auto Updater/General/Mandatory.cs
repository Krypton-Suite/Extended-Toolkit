namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{

    /// <summary>
    ///     Mandatory class to fetch the XML values related to Mandatory field.
    /// </summary>
    public class Mandatory
    {
        /// <summary>
        ///     Value of the Mandatory field.
        /// </summary>
        [XmlText]
        public bool Value { get; set; }

        /// <summary>
        ///     If this is set and 'Value' property is set to true then it will trigger the mandatory update only when current
        ///     installed version is less than value of this property.
        /// </summary>
        [XmlAttribute("minVersion")]
        public string MinimumVersion { get; set; }

        /// <summary>
        ///     Mode that should be used for this update.
        /// </summary>
        [XmlAttribute("mode")]
        public Mode UpdateMode { get; set; }
    }
}