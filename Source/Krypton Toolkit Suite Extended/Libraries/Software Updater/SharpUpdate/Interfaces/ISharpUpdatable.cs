using System;
using System.Drawing;
using System.Reflection;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    /// <summary>
    /// The interface that all applications need to implement in order to use SharpUpdate
    /// </summary>
    public interface ISharpUpdatable
    {
        /// <summary>
        /// The name of your application as you want it displayed on the update form
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// An identifier string to use to identify your application in the update.xml
        /// Should be the same as your appId in the update.xml
        /// </summary>
        string ApplicationID { get; }

        /// <summary>
        /// The current assembly
        /// </summary>
        Assembly ApplicationAssembly { get; }

        /// <summary>
        /// The application's icon to be displayed in the top left
        /// </summary>
        Icon ApplicationIcon { get; }

        /// <summary>
        /// The location of the update.xml on a server
        /// </summary>
        Uri UpdateXmlLocation { get; }

        /// <summary>
        /// The context of the program.
        /// For Windows Forms Applications, use 'this'
        /// Console Apps, reference System.Windows.Forms and return null.
        /// </summary>
        KryptonForm Context { get; }
    }
}