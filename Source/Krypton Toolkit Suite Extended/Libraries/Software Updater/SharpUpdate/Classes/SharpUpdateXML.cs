using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    /// <summary>
    /// Contains update information
    /// </summary>
    internal class SharpUpdateXML
    {
        private Version version;
        private List<SharpUpdateFileInfo> updateFiles;
        private string launchArgs;
        private string description;

        /// <summary>
        /// The update version #
        /// </summary>
        internal Version Version
        {
            get { return this.version; }
        }

        /// <summary>
        /// The description of the new version
        /// </summary>
        internal string Description
        {
            get { return description; }
            //set { description = value; }
        }

        /// <summary>
        /// All files that are available
        /// </summary>
        internal List<SharpUpdateFileInfo> UpdateFiles
        {
            get { return this.updateFiles; }
        }

        /// <summary>
        /// The arguments to pass to the updated application on startup
        /// </summary>
        internal string LaunchArgs
        {
            get { return this.launchArgs; }
        }

        /// <summary>
        /// Creates a new SharpUpdateXml object
        /// </summary>
        /// <param name="version">Application's current version</param>
        /// <param name="updateFiles">Application's update files</param>
        /// <param name="description">Update description</param>
        /// <param name="launchArgs">Application's launch arguments</param>
        internal SharpUpdateXML(Version version, List<SharpUpdateFileInfo> updateFiles, string description, string launchArgs)
        {
            this.version = version;
            this.updateFiles = updateFiles;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        /// <summary>
        /// Checks if update's version is newer than the old version
        /// </summary>
        /// <param name="version">Application's current version</param>
        /// <returns>True, if the update's version # is newer</returns>
        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }

        /// <summary>
        /// Chacks if all files, specified in update.xml are in given folder
        /// </summary>
        /// <param name="path">Path to the folder, where the files should be</param>
        /// <returns>True, if all files are there</returns>
        internal bool HasAllFiles(string path)
        {
            string realPath = path;
            if (!path.EndsWith("\\"))
                realPath += "\\";
            foreach (SharpUpdateFileInfo fi in this.updateFiles)
            {
                if (!File.Exists(realPath + fi.FileName))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the Uri to make sure file exist
        /// </summary>
        /// <param name="location">The Uri of the update.xml</param>
        /// <returns>True, if the file exists</returns>
        internal static bool ExistsOnServer(Uri location)
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

        /// <summary>
        /// Parses the update.xml into SharpUpdateXml object
        /// </summary>
        /// <param name="location">Uri of update.xml on server</param>
        /// <param name="appID">The application's ID</param>
        /// <returns>The SharpUpdateXml object with the data, or null of any errors</returns>
        internal static SharpUpdateXML Parse(Uri location, string appID)
        {
            Version version = null;
            string launchArgs = "", description = "";
            List<SharpUpdateFileInfo> files = new List<SharpUpdateFileInfo>();

            try
            {
                // Load the document
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);


                // Gets the appId's node with the update info
                // This allows you to store all program's update nodes in one file
                XmlNode updateNode = doc.DocumentElement.SelectSingleNode("//update[@appId='" + appID + "']");

                // If the node doesn't exist, there is no update
                if (updateNode == null)
                    return null;

                // Parse data
                version = Version.Parse(updateNode["version"].InnerText);

                //Read each file
                XmlNodeList fileNodes = updateNode.ChildNodes;
                foreach (XmlNode xn in fileNodes)
                {
                    if (xn.Name == "file")
                    {
                        files.Add(new SharpUpdateFileInfo(xn["url"].InnerText, xn["filename"].InnerText, xn["md5"].InnerText));
                    }
                }

                launchArgs = updateNode["launchArgs"].InnerText;
                description = updateNode["description"].InnerText;

                return new SharpUpdateXML(version, files, description, launchArgs);
            }
            catch
            { return null; }
        }
    }
}