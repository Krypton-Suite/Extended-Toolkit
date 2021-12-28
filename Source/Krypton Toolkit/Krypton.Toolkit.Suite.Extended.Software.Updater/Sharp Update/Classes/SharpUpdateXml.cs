#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    /// <summary>
    /// Contains update information
    /// </summary>
    public class SharpUpdateXml
    {
        /// <summary>
        /// The update version #
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// The location of the update binary
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The file path of the binary
        /// for use on local computer
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// The MD5 of the update's binary
        /// </summary>
        public string MD5 { get; }

        /// <summary>
        /// The update's description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The arguments to pass to the updated application on startup
        /// </summary>
        public string LaunchArgs { get; }

        /// <summary>
        /// Tag to distinguish types of updates
        /// </summary>
        public JobType Tag;

        /// <summary>
        /// Creates a new SharpUpdateXml object
        /// </summary>
        public SharpUpdateXml(Version version, Uri uri, string filePath, string md5, string description, string launchArgs, JobType t)
        {
            Version = version;
            Uri = uri;
            FilePath = filePath;
            MD5 = md5;
            Description = description;
            LaunchArgs = launchArgs;
            Tag = t;
        }

        /// <summary>
        /// Checks if update's version is newer than the old version
        /// </summary>
        /// <param name="version">Application's current version</param>
        /// <returns>If the update's version # is newer</returns>
        public bool IsNewerThan(Version version)
        {
            return Version > version;
        }

        /// <summary>
        /// Checks the Uri to make sure file exist
        /// </summary>
        /// <param name="location">The Uri of the update.xml</param>
        /// <returns>If the file exists</returns>
        public static bool ExistsOnServer(Uri location)
        {
            if (location.ToString().StartsWith("file"))
            {
                return System.IO.File.Exists(location.LocalPath);
            }
            else
            {
                try
                {
                    // Request the update.xml
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                    // Read for response
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    resp.Close();

                    return resp.StatusCode == HttpStatusCode.OK;
                }
                catch { return false; }
            }
        }

        /// <summary>
        /// Parses the update.xml into SharpUpdateXml object
        /// </summary>
        /// <param name="location">Uri of update.xml on server</param>
        /// <returns>The SharpUpdateXml object with the data, or null of any errors</returns>
        public static SharpUpdateXml[] Parse(Uri location)
        {
            List<SharpUpdateXml> result = new List<SharpUpdateXml>();
            Version version = null;
            string url = "", filePath = "", md5 = "", description = "", launchArgs = "";

            try
            {
                // Load the document
                ServicePointManager.ServerCertificateValidationCallback = (s, ce, ch, ssl) => true;
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                // Gets the appId's node with the update info
                // This allows you to store all program's update nodes in one file
                // XmlNode updateNode = doc.DocumentElement.SelectSingleNode("//update[@appID='" + appID + "']");
                XmlNodeList updateNodes = doc.DocumentElement.SelectNodes("/sharpUpdate/update");
                foreach (XmlNode updateNode in updateNodes)
                {
                    // If the node doesn't exist, there is no update
                    if (updateNode == null)
                        return null;

                    // Parse data
                    version = Version.Parse(updateNode["version"].InnerText);
                    url = updateNode["url"].InnerText;
                    filePath = updateNode["filePath"].InnerText;
                    md5 = updateNode["md5"].InnerText;
                    description = updateNode["description"].InnerText;
                    launchArgs = updateNode["launchArgs"].InnerText;

                    result.Add(new SharpUpdateXml(version, new Uri(url), filePath, md5, description, launchArgs, JobType.UPDATE));
                }

                XmlNodeList addNodes = doc.DocumentElement.SelectNodes("/sharpUpdate/add");
                foreach (XmlNode addNode in addNodes)
                {
                    // If the node doesn't exist, there is no add
                    if (addNode == null)
                        return null;

                    // Parse data
                    version = Version.Parse(addNode["version"].InnerText);
                    url = addNode["url"].InnerText;
                    filePath = addNode["filePath"].InnerText;
                    md5 = addNode["md5"].InnerText;
                    description = addNode["description"].InnerText;
                    launchArgs = addNode["launchArgs"].InnerText;

                    result.Add(new SharpUpdateXml(version, new Uri(url), filePath, md5, description, launchArgs, JobType.ADD));
                }

                XmlNodeList removeNodes = doc.DocumentElement.SelectNodes("/sharpUpdate/remove");
                foreach (XmlNode removeNode in removeNodes)
                {
                    // If the node doesn't exist, there is no remove
                    if (removeNode == null)
                        return null;

                    // Parse data
                    filePath = removeNode["filePath"].InnerText;
                    description = removeNode["description"].InnerText;
                    launchArgs = removeNode["launchArgs"].InnerText;

                    result.Add(new SharpUpdateXml(null, null, filePath, null, description, launchArgs, JobType.REMOVE));
                }

                return result.ToArray();
            }
            catch { return null; }
        }
    }
}