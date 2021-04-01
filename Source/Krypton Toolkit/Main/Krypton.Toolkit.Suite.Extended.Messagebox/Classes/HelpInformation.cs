using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    public class HelpInformation
    {
        #region Properties
        /// <summary>
        /// Gets the HelpFilePath property.
        /// </summary>
        public string HelpFilePath { get; }

        /// <summary>
        /// Gets the Keyword property.
        /// </summary>
        public string Keyword { get; }

        /// <summary>
        /// Gets the Navigator property.
        /// </summary>
        public HelpNavigator Navigator { get; }

        /// <summary>
        /// Gets the Param property.
        /// </summary>
        public object Param { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Initialize a new instance of the HelpInformation class.
        /// </summary>
        public HelpInformation()
        {
        }

        /// <summary>
        /// Initialize a new instance of the HelpInformation class.
        /// </summary>
        /// <param name="helpFilePath">Value for HelpFilePath.</param>
        public HelpInformation(string helpFilePath)
        {
            HelpFilePath = helpFilePath;
        }

        /// <summary>
        /// Initialize a new instance of the HelpInformation class.
        /// </summary>
        /// <param name="helpFilePath">Value for HelpFilePath.</param>
        /// <param name="keyword">Value for Keyword</param>
        public HelpInformation(string helpFilePath, string keyword)
        {
            HelpFilePath = helpFilePath;
            Keyword = keyword;
        }

        /// <summary>
        /// Initialize a new instance of the HelpInformation class.
        /// </summary>
        /// <param name="helpFilePath">Value for HelpFilePath.</param>
        /// <param name="navigator">Value for Navigator</param>
        public HelpInformation(string helpFilePath, HelpNavigator navigator)
        {
            HelpFilePath = helpFilePath;
            Navigator = navigator;
        }

        /// <summary>
        /// Initialize a new instance of the HelpInformation class.
        /// </summary>
        /// <param name="helpFilePath">Value for HelpFilePath.</param>
        /// <param name="navigator">Value for Navigator</param>
        /// <param name="param">Value for Param</param>
        public HelpInformation(string helpFilePath, HelpNavigator navigator, object param)
        {
            HelpFilePath = helpFilePath;
            Navigator = navigator;
            Param = param;
        }
        #endregion
    }
}