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
    /// The class that holds all application's information
    /// </summary>
    public class SharpUpdateLocalAppInfo
    {
        /// <summary>
        /// The path of your application
        /// </summary>
        public string ApplicationPath { get; }

        /// <summary>
        /// The name of your application as you want it displayed on the update form
        /// </summary>
        public string ApplicationName { get; }

        /// <summary>
        /// The current assembly
        /// </summary>
        public Assembly ApplicationAssembly { get; }

        /// <summary>
        /// The application's icon to be displayed in the top left
        /// </summary>
        public Icon ApplicationIcon { get; }

        /// <summary>
        /// The context of the program.
        /// For Windows Forms Applications, use 'this'
        /// Console Apps, reference System.Windows.Forms and return null.
        /// </summary>
        public Form Context { get; }

        /// <summary>
        /// The version of your application
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Tag to distinguish types of updates
        /// </summary>
        public JobType Tag;

        public SharpUpdateLocalAppInfo(SharpUpdateXml job, Assembly ass, Form f)
        {
            ApplicationPath = job.FilePath;
            ApplicationName = Path.GetFileNameWithoutExtension(ApplicationPath);
            ApplicationAssembly = ass;
            ApplicationIcon = f.Icon;
            Context = f;
            Version = (job.Tag == JobType.UPDATE) ? ApplicationAssembly.GetName().Version : job.Version;
            Tag = job.Tag;
        }

        public SharpUpdateLocalAppInfo(SharpUpdateXml job)
        {
            ApplicationPath = job.FilePath;
            ApplicationName = Path.GetFileNameWithoutExtension(ApplicationPath);
            ApplicationAssembly = (job.Tag == JobType.UPDATE) ? Assembly.Load(ApplicationName) : null;
            ApplicationIcon = null;
            Context = null;
            Version = (job.Tag == JobType.UPDATE) ? ApplicationAssembly.GetName().Version : job.Version;
            Tag = job.Tag;
        }

        public void Print()
        {
            string head = "========== SharpUpdateLocalAppInfo ==========";
            string tail = "=============================================";
            string toPrint = string.Format("{0}\nJob type: {1}\nApplicationPath: {2}\nApplicationName: {3}\nAssemblyName: {4}\nFormName: {5}\nVersion: {6}\n{7}",
                head, Tag.ToString(), ApplicationPath == null ? "null" : ApplicationPath,
                ApplicationName == null ? "null" : ApplicationName,
                ApplicationAssembly == null ? "null" : ApplicationAssembly.FullName,
                Context == null ? "null" : Context.Name,
                Version == null ? "null" : Version.ToString(), tail);
            Console.WriteLine(toPrint);
        }
    }
}