using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Represents the icon for the title bar
    /// </summary>
    public class InformationBoxTitleIcon
    {
        #region Attributes

        /// <summary>
        /// The title icon file
        /// </summary>
        private readonly Icon icon;

        #endregion Attributes

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationBoxTitleIcon"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public InformationBoxTitleIcon(string fileName)
        {
            this.icon = new Icon(fileName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationBoxTitleIcon"/> class.
        /// </summary>
        /// <param name="icon">The title icon.</param>
        public InformationBoxTitleIcon(Icon icon)
        {
            this.icon = icon;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <value>The title icon.</value>
        internal Icon Icon
        {
            get { return this.icon; }
        }

        #endregion Properties
    }
}