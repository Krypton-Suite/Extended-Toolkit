#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core
{
    /// <summary>
    /// Item from a Sparkle AppCast file
    /// </summary>
    [Serializable]
    public class AppCastItem : IComparable<AppCastItem>
    {
        /// <summary>
        /// The application name
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// The installed version
        /// </summary>
        public string AppVersionInstalled { get; set; }
        /// <summary>
        /// The item title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The available version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Shortened version
        /// </summary>
        public string ShortVersion { get; set; }
        /// <summary>
        /// The release notes link
        /// </summary>
        public string ReleaseNotesLink { get; set; }
        /// <summary>
        /// The signature of the Release Notes file
        /// </summary>
        public string ReleaseNotesSignature { get; set; }
        /// <summary>
        /// The embedded description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The download link
        /// </summary>
        public string DownloadLink { get; set; }
        /// <summary>
        /// The signature of the download file
        /// </summary>
        public string DownloadSignature { get; set; }
        /// <summary>
        /// Date item was published
        /// </summary>
        public DateTime PublicationDate { get; set; }
        /// <summary>
        /// Whether the update was marked critical or not via sparkle:critical
        /// </summary>
        public bool IsCriticalUpdate { get; set; }
        /// <summary>
        /// Length of update set via sparkle:length (usually the # of bytes of the update)
        /// </summary>
        public long UpdateSize { get; set; }

        /// <summary>
        /// Operating system that this update applies to
        /// </summary>
        public string OperatingSystemString { get; set; }

        /// <summary>
        /// True if this update is a windows update; false otherwise.
        /// Acceptable OS strings are: "win" or "windows" (this is 
        /// checked with a case-insensitive check). If not specified,
        /// assumed to be a Windows update.
        /// </summary>
        public bool IsWindowsUpdate
        {
            get
            {
                if (OperatingSystemString != null)
                {
                    var lowercasedOS = OperatingSystemString.ToLower();
                    if (lowercasedOS is "win" or "windows")
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// MIME type for file as specified in the closure tag. Defaults to "application/octet-stream".
        /// </summary>
        public string MIMEType { get; set; }

        #region XML

        private const string ITEM_NODE = "item";
        private const string TITLE_NODE = "title";
        private const string ENCLOSURE_NODE = "enclosure";
        private const string RELEASE_NOTES_LINK_NODE = "releaseNotesLink";
        private const string DESCRIPTION_NODE = "description";
        private const string VERSION_ATTRIBUTE = "version";
        private const string SHORT_VERSION_ATTRIBUTE = "shortVersionString";
        private const string DSA_SIGNATURE_ATTRIBUTE = "dsaSignature";
        private const string ED25519_SIGNATURE_ATTRIBUTE = "edSignature";
        private const string SIGNATURE_ATTRIBUTE = "signature";
        private const string CRITICAL_ATTRIBUTE = "criticalUpdate";
        private const string OPERATING_SYSTEM_ATTRIBUTE = "os";
        private const string LENGTH_ATTRIBUTE = "length";
        private const string TYPE_ATTRIBUTE = "type";
        private const string URL_ATTRIBUTE = "url";
        private const string PUB_DATE_NODE = "pubDate";
        private const string DEFAULT_OPERATING_SYSTEM = "windows";
        private const string DEFAULT_TYPE = "application/octet-stream";

        /// <summary>
        /// Parse item Xml Node to AppCastItem
        /// </summary>
        /// <param name="installedVersion">Currently installed version</param>
        /// <param name="applicationName">Application name</param>
        /// <param name="castUrl">The url of the appcast</param>
        /// <param name="item">The item XML node</param>
        /// <param name="logWriter">logwriter instance</param>
        /// <returns>AppCastItem from Xml Node</returns>
        public static AppCastItem Parse(string installedVersion, string applicationName, string castUrl, XElement item, ILogger? logWriter)
        {

            var newAppCastItem = new AppCastItem()
            {
                AppVersionInstalled = installedVersion,
                AppName = applicationName,
                UpdateSize = 0,
                IsCriticalUpdate = false,
                OperatingSystemString = DEFAULT_OPERATING_SYSTEM,
                MIMEType = DEFAULT_TYPE
            };

            //title
            newAppCastItem.Title = item.Element(TITLE_NODE)?.Value ?? string.Empty;

            //release notes
            var releaseNotesElement = item.Element(XMLAppCast.SparkleNamespace + RELEASE_NOTES_LINK_NODE);
            newAppCastItem.ReleaseNotesSignature = releaseNotesElement?.Attribute(XMLAppCast.SparkleNamespace + SIGNATURE_ATTRIBUTE)?.Value ?? string.Empty;
            if (newAppCastItem.ReleaseNotesSignature == string.Empty)
            {
                newAppCastItem.ReleaseNotesSignature = releaseNotesElement?.Attribute(XMLAppCast.SparkleNamespace + DSA_SIGNATURE_ATTRIBUTE)?.Value ?? string.Empty;
            }
            if (newAppCastItem.ReleaseNotesSignature == string.Empty)
            {
                newAppCastItem.ReleaseNotesSignature = releaseNotesElement?.Attribute(XMLAppCast.SparkleNamespace + ED25519_SIGNATURE_ATTRIBUTE)?.Value ?? string.Empty;
            }
            newAppCastItem.ReleaseNotesLink = releaseNotesElement?.Value.Trim() ?? string.Empty;

            //description
            newAppCastItem.Description = item.Element(DESCRIPTION_NODE)?.Value.Trim() ?? string.Empty;

            //enclosure
            var enclosureElement = item.Element(ENCLOSURE_NODE) ?? item.Element(XMLAppCast.SparkleNamespace + ENCLOSURE_NODE);

            newAppCastItem.Version = enclosureElement?.Attribute(XMLAppCast.SparkleNamespace + VERSION_ATTRIBUTE)?.Value ?? string.Empty;
            newAppCastItem.ShortVersion = enclosureElement?.Attribute(XMLAppCast.SparkleNamespace + SHORT_VERSION_ATTRIBUTE)?.Value ?? string.Empty;
            newAppCastItem.DownloadLink = enclosureElement?.Attribute(URL_ATTRIBUTE)?.Value ?? string.Empty;
            if (!string.IsNullOrEmpty(newAppCastItem.DownloadLink) && !newAppCastItem.DownloadLink.Contains("/"))
            {
                // Download link contains only the filename -> complete with _castUrl
                newAppCastItem.DownloadLink = castUrl.Substring(0, castUrl.LastIndexOf('/') + 1) + newAppCastItem.DownloadLink;
            }

            newAppCastItem.DownloadSignature = enclosureElement?.Attribute(XMLAppCast.SparkleNamespace + SIGNATURE_ATTRIBUTE)?.Value ?? string.Empty;
            if (newAppCastItem.DownloadSignature == string.Empty)
            {
                newAppCastItem.DownloadSignature = enclosureElement?.Attribute(XMLAppCast.SparkleNamespace + DSA_SIGNATURE_ATTRIBUTE)?.Value ?? string.Empty;
            }
            if (newAppCastItem.DownloadSignature == string.Empty)
            {
                newAppCastItem.DownloadSignature = enclosureElement?.Attribute(XMLAppCast.SparkleNamespace + ED25519_SIGNATURE_ATTRIBUTE)?.Value ?? string.Empty;
            }
            string length = enclosureElement?.Attribute(LENGTH_ATTRIBUTE)?.Value ?? string.Empty;
            if (length != null)
            {
                if (long.TryParse(length, out var size))
                {
                    newAppCastItem.UpdateSize = size;
                }
                else
                {
                    newAppCastItem.UpdateSize = 0;
                }
            }
            bool isCritical = false;
            string critical = enclosureElement?.Attribute(XMLAppCast.SparkleNamespace + CRITICAL_ATTRIBUTE)?.Value ?? string.Empty;
            if (critical != null && critical == "true" || critical == "1")
            {
                isCritical = true;
            }
            newAppCastItem.IsCriticalUpdate = isCritical;

            newAppCastItem.OperatingSystemString = enclosureElement?.Attribute(XMLAppCast.SparkleNamespace + OPERATING_SYSTEM_ATTRIBUTE)?.Value ?? DEFAULT_OPERATING_SYSTEM;

            newAppCastItem.MIMEType = enclosureElement?.Attribute(TYPE_ATTRIBUTE)?.Value ?? DEFAULT_TYPE;

            //pub date
            var pubDateElement = item.Element(PUB_DATE_NODE);
            if (pubDateElement != null)
            {
                // "ddd, dd MMM yyyy HH:mm:ss zzz" => Standard date format
                //      e.g. "Sat, 26 Oct 2019 22:05:11 -05:00"
                // "ddd, dd MMM yyyy HH:mm:ss Z" => Check for MS AppCenter Sparkle date format which ends with GMT
                //      e.g. "Sat, 26 Oct 2019 22:05:11 GMT"
                // "ddd, dd MMM yyyy HH:mm:ss" => Standard date format with no timezone (fallback)
                //      e.g. "Sat, 26 Oct 2019 22:05:11"
                string[] formats = { "ddd, dd MMM yyyy HH:mm:ss zzz", "ddd, dd MMM yyyy HH:mm:ss Z",
                    "ddd, dd MMM yyyy HH:mm:ss", "ddd, dd MMM yyyy HH:mm:ss K" };
                string dt = pubDateElement.Value.Trim();
                if (DateTime.TryParseExact(dt, formats, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                {
                    logWriter?.PrintMessage("While parsing app cast item, converted '{0}' to {1}.", dt, dateValue);
                    newAppCastItem.PublicationDate = dateValue;
                }
                else
                {
                    logWriter?.PrintMessage("Cannot parse item's DateTime: {0}", dt);
                }
            }

            return newAppCastItem;
        }

        /// <summary>
        /// Create Xml node from this instance of AppCastItem
        /// </summary>
        /// <returns>An XML node</returns>
        public XElement GetXElement()
        {
            var item = new XElement(ITEM_NODE);

            item.Add(new XElement(TITLE_NODE) { Value = Title });

            if (!string.IsNullOrEmpty(ReleaseNotesLink))
            {
                var releaseNotes = new XElement(XMLAppCast.SparkleNamespace + RELEASE_NOTES_LINK_NODE) { Value = ReleaseNotesLink };
                if (!string.IsNullOrEmpty(ReleaseNotesSignature))
                {
                    releaseNotes.Add(new XAttribute(XMLAppCast.SparkleNamespace + SIGNATURE_ATTRIBUTE, ReleaseNotesSignature));
                }
                item.Add(releaseNotes);
            }

            if (!string.IsNullOrEmpty(Description))
            {
                item.Add(new XElement(DESCRIPTION_NODE) { Value = Description });
            }

            if (PublicationDate != DateTime.MinValue && PublicationDate != DateTime.MaxValue)
            {
                item.Add(new XElement(PUB_DATE_NODE) { Value = PublicationDate.ToString("ddd, dd MMM yyyy HH:mm:ss zzz", System.Globalization.CultureInfo.InvariantCulture) });
            }

            if (!string.IsNullOrEmpty(DownloadLink))
            {
                var enclosure = new XElement(ENCLOSURE_NODE);
                enclosure.Add(new XAttribute(URL_ATTRIBUTE, DownloadLink));
                enclosure.Add(new XAttribute(XMLAppCast.SparkleNamespace + VERSION_ATTRIBUTE, Version));

                if (!string.IsNullOrEmpty(ShortVersion))
                {
                    enclosure.Add(new XAttribute(XMLAppCast.SparkleNamespace + SHORT_VERSION_ATTRIBUTE, ShortVersion));
                }

                enclosure.Add(new XAttribute(LENGTH_ATTRIBUTE, UpdateSize));
                enclosure.Add(new XAttribute(XMLAppCast.SparkleNamespace + OPERATING_SYSTEM_ATTRIBUTE, OperatingSystemString ?? DEFAULT_OPERATING_SYSTEM));
                enclosure.Add(new XAttribute(TYPE_ATTRIBUTE, MIMEType ?? DEFAULT_TYPE));

                if (!string.IsNullOrEmpty(DownloadSignature))
                {
                    enclosure.Add(new XAttribute(XMLAppCast.SparkleNamespace + SIGNATURE_ATTRIBUTE, DownloadSignature));
                }
                item.Add(enclosure);
            }
            return item;
        }

        #endregion

        #region IComparable<AppCastItem> Members

        /// <summary>
        /// Compares this <see cref="AppCastItem"/> version to the version of another <see cref="AppCastItem"/>
        /// </summary>
        /// <param name="other">the other instance</param>
        /// <returns>-1, 0, 1 if this instance is less than, equal to, or greater than the <paramref name="other"/></returns>
        public int CompareTo(AppCastItem other)
        {
            if (!Version.Contains(".") || !other.Version.Contains("."))
            {
                return 0;
            }
            Version v1 = new Version(Version);
            Version v2 = new Version(other.Version);
            return v1.CompareTo(v2);
        }

        /// <summary>
        /// See if this this <see cref="AppCastItem"/> version equals the version of another <see cref="AppCastItem"/>.
        /// Also checks to make sure the application names match.
        /// </summary>
        /// <param name="obj">the instance to compare to</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is AppCastItem item))
            {
                return false;
            }
            if (ReferenceEquals(this, item))
            {
                return true;
            }
            return AppName.Equals(item.AppName) && CompareTo(item) == 0;
        }

        /// <summary>
        /// Derive hashcode from immutable variables
        /// </summary>
        /// <returns>the integer haschode of this app cast item</returns>
        public override int GetHashCode()
        {
            return Version.GetHashCode() * 17 + AppName.GetHashCode();
        }

        /// <summary>
        /// Check the equality of two <see cref="AppCastItem"/> instances
        /// </summary>
        /// <param name="left">first <see cref="AppCastItem"/> to compare</param>
        /// <param name="right">second <see cref="AppCastItem"/> to compare</param>
        /// <returns>True if items are the same; false otherwise</returns>
        public static bool operator ==(AppCastItem? left, AppCastItem? right)
        {
            if (left is null)
            {
                return right is null;
            }
            return left.Equals(right);
        }

        /// <summary>
        /// Check if two <see cref="AppCastItem"/> instances are different
        /// </summary>
        /// <param name="left">first <see cref="AppCastItem"/> to compare</param>
        /// <param name="right">second <see cref="AppCastItem"/> to compare</param>
        /// <returns>True if items are different; false if they are the same</returns>
        public static bool operator !=(AppCastItem? left, AppCastItem? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Less than comparison of version between two <see cref="AppCastItem"/> instances
        /// </summary>
        /// <param name="left">first <see cref="AppCastItem"/> to compare</param>
        /// <param name="right">second <see cref="AppCastItem"/> to compare</param>
        /// <returns>True if left version is less than right version; false otherwise</returns>
        public static bool operator <(AppCastItem? left, AppCastItem? right)
        {
            return left is null ? !(right is null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Less than or equal to comparison of version between two AppCastItem instances
        /// </summary>
        /// <param name="left">AppCastItem to compare</param>
        /// <param name="right">AppCastItem to compare</param>
        /// <returns>True if left version is less than or equal to right version</returns>
        public static bool operator <=(AppCastItem? left, AppCastItem right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Greater than comparison of version between two <see cref="AppCastItem"/> instances
        /// </summary>
        /// <param name="left">first <see cref="AppCastItem"/> to compare</param>
        /// <param name="right">second <see cref="AppCastItem"/> to compare</param>
        /// <returns>True if left version is greater than right version; false otherwise</returns>
        public static bool operator >(AppCastItem? left, AppCastItem right)
        {
            return !(left is null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Greater than or equal to comparison of version between two <see cref="AppCastItem"/> instances
        /// </summary>
        /// <param name="left">first <see cref="AppCastItem"/> to compare</param>
        /// <param name="right">second <see cref="AppCastItem"/> to compare</param>
        /// <returns>True if left version is greater than or equal to right version; false otherwise</returns>
        public static bool operator >=(AppCastItem? left, AppCastItem? right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }

        #endregion
    }
}