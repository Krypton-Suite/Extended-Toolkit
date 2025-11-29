#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace Krypton.Toolkit.Suite.Extended.Core;

public class FileDialogHandler
{
    #region Variables
    private CommonFileDialog _commonFileDialog;

    private CommonOpenFileDialog _commonOpenFileDialog;

    private CommonSaveFileDialog _commonSaveFileDialog;

    private KryptonFolderBrowserDialog _kryptonFolderBrowserDialog;

    private KryptonOpenFileDialog _kryptonOpenFileDialog;

    private KryptonSaveFileDialog _kryptonSaveFileDialog;

    private FolderBrowserDialog _folderBrowserDialog;

    private OpenFileDialog _openFileDialog;

    private SaveFileDialog _saveFileDialog;

    #endregion

    #region Constructor
    public FileDialogHandler()
    {

    }
    #endregion

    #region Methods

    /// <summary>Creates the open file dialog.</summary>
    /// <param name="title">The title.</param>
    /// <param name="isFolderPicker">if set to <c>true</c> [is folder picker]. (Only use if you are using the <see cref="FileDialogType.WindowsAPICodePack"/> type.)</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="fileDialogType">Type of the file dialog.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="filter">The filter.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">fileDialogType - null</exception>
    public static void CreateOpenFileDialog(string title, bool isFolderPicker, string initialDirectory, FileDialogType fileDialogType = FileDialogType.Standard, string? filters = null, CommonFileDialogFilter? filter = null)
    {
        switch (fileDialogType)
        {
            case FileDialogType.Krypton:
                KryptonOpenFileDialog openFileDialog = new();

                openFileDialog.Title = title;

                openFileDialog.InitialDirectory = initialDirectory;

                if (!string.IsNullOrEmpty(filters))
                {
                    openFileDialog.Filter = filters;
                }

                FileDialogHandler fdh = new();

                fdh.SetKryptonOpenFileDialog(openFileDialog);

                openFileDialog.ShowDialog();
                break;
            case FileDialogType.Standard:
                break;
            case FileDialogType.WindowsAPICodePack:
                CommonOpenFileDialog cofd = new();

                cofd.Title = title;

                cofd.IsFolderPicker = isFolderPicker;

                cofd.InitialDirectory = initialDirectory;

                if (filter != null)
                {
                    cofd.Filters.Add(filter);
                }

                FileDialogHandler fileDialogHandler = new();

                fileDialogHandler.SetCommonOpenFileDialog(cofd);

                cofd.ShowDialog();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileDialogType), fileDialogType, null);
        }
    }

    /// <summary>Creates a save file dialog.</summary>
    /// <param name="title">The title.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="filter">The filter.</param>
    public static void CreateSaveFileDialog(string title, string initialDirectory, CommonFileDialogFilter filter)
    {
        CommonSaveFileDialog csfd = new();

        csfd.Title = title;

        csfd.InitialDirectory = initialDirectory;

        csfd.Filters.Add(filter);

        FileDialogHandler fileDialogHandler = new();

        fileDialogHandler.SetCommonSaveFileDialog(csfd);

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
    private void SetCommonOpenFileDialog(CommonOpenFileDialog value) => _commonOpenFileDialog = value;

    /// <summary>
    /// Gets the OpenFileDialog.
    /// </summary>
    /// <returns>The value of _openFileDialog.</returns>
    public CommonOpenFileDialog GetCommonOpenFileDialog() => _commonOpenFileDialog;

    /// <summary>
    /// Sets the SaveFileDialog.
    /// </summary>
    /// <param name="value">The value.</param>
    public void SetCommonSaveFileDialog(CommonSaveFileDialog value) => _commonSaveFileDialog = value;

    /// <summary>
    /// Gets the SaveFileDialog.
    /// </summary>
    /// <returns>The value of _saveFileDialog.</returns>
    public CommonSaveFileDialog GetCommonSaveFileDialog() => _commonSaveFileDialog;

    public KryptonOpenFileDialog SetKryptonOpenFileDialog(KryptonOpenFileDialog value) => _kryptonOpenFileDialog = value;

    public KryptonOpenFileDialog GetKryptonOpenFileDialog() => _kryptonOpenFileDialog;

    public KryptonFolderBrowserDialog SeKryptonFolderBrowserDialog(KryptonFolderBrowserDialog dialog) => _kryptonFolderBrowserDialog = dialog;

    public KryptonFolderBrowserDialog GeKryptonFolderBrowserDialog() => _kryptonFolderBrowserDialog;

    #endregion
}