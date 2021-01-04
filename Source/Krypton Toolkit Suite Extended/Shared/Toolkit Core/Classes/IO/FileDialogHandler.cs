using Microsoft.WindowsAPICodePack.Dialogs;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class FileDialogHandler
    {
        #region Variables
        private CommonFileDialog _commonFileDialog;

        private CommonOpenFileDialog _openFileDialog;

        private CommonSaveFileDialog _saveFileDialog;
        #endregion

        #region Constructor
        public FileDialogHandler()
        {

        }
        #endregion

        #region Methods
        public static void CreateOpenFileDialog(string title, bool isFolderPicker, string initialDirectory, CommonFileDialogFilter filter, string fileName = "")
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.Title = title;

            cofd.IsFolderPicker = isFolderPicker;

            cofd.InitialDirectory = initialDirectory;

            cofd.Filters.Add(filter);

            FileDialogHandler fileDialogHandler = new FileDialogHandler();

            fileDialogHandler.SetOpenFileDialog(cofd);

            cofd.ShowDialog();
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the OpenFileDialog.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetOpenFileDialog(CommonOpenFileDialog value) => _openFileDialog = value;

        /// <summary>
        /// Gets the OpenFileDialog.
        /// </summary>
        /// <returns>The value of _openFileDialog.</returns>
        public CommonOpenFileDialog GetOpenFileDialog() => _openFileDialog;
        #endregion
    }
}