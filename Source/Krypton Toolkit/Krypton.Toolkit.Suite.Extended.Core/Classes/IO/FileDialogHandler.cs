#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

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
        //public static void CreateFileDialog(string title, bool isFolderPicker, string initialDirectory, CommonFileDialogFilter filter, string fileName = "")
        //{
        //    CommonFileDialog cfd = new CommonFileDialog()
        //}

        /// <summary>Creates a open file dialog.</summary>
        /// <param name="title">The title.</param>
        /// <param name="isFolderPicker">if set to <c>true</c> [is folder picker].</param>
        /// <param name="initialDirectory">The initial directory.</param>
        /// <param name="filter">The filter.</param>
        public static void CreateOpenFileDialog(string title, bool isFolderPicker, string initialDirectory, CommonFileDialogFilter filter)
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

        /// <summary>Creates a save file dialog.</summary>
        /// <param name="title">The title.</param>
        /// <param name="initialDirectory">The initial directory.</param>
        /// <param name="filter">The filter.</param>
        public static void CreateSaveFileDialog(string title, string initialDirectory, CommonFileDialogFilter filter)
        {
            CommonSaveFileDialog csfd = new CommonSaveFileDialog();

            csfd.Title = title;

            csfd.InitialDirectory = initialDirectory;

            csfd.Filters.Add(filter);

            FileDialogHandler fileDialogHandler = new FileDialogHandler();

            fileDialogHandler.SetSaveFileDialog(csfd);

            csfd.ShowDialog();
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the CommonFileDialog.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetCommonFileDialog(CommonFileDialog value) => _commonFileDialog = value;

        /// <summary>
        /// Gets the CommonFileDialog.
        /// </summary>
        /// <returns>The value of _commonFileDialog.</returns>
        public CommonFileDialog GetCommonFileDialog() => _commonFileDialog;

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

        /// <summary>
        /// Sets the SaveFileDialog.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetSaveFileDialog(CommonSaveFileDialog value) => _saveFileDialog = value;

        /// <summary>
        /// Gets the SaveFileDialog.
        /// </summary>
        /// <returns>The value of _saveFileDialog.</returns>
        public CommonSaveFileDialog GetSaveFileDialog() => _saveFileDialog;
        #endregion
    }
}