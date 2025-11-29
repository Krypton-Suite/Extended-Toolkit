#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.IO;

/// <summary>
/// Represents the method that is used to handle file selected event.
/// </summary>
/// <param name="sender"></param>
/// <param name="fse"></param>
public delegate void FileSelectedEventHandler(object sender, FileSelectEventArgs fse);


/// <summary>
/// Provides for FileSelect event.
/// </summary>
public class FileSelectEventArgs : EventArgs
{
    private string _fileName;

    /// <summary>
    /// Gets or sets the file name that trigered the event.
    /// </summary>
    public string FileName
    {
        get => _fileName;
        set => _fileName = FileName;
    }
    /// <summary>
    /// Initializes a new instance of the FileSelectEventArgs in order to provide
    /// data for FileSelected event.
    /// </summary>
    /// <param name="fileName"></param>
    public FileSelectEventArgs(string fileName)
    {
        _fileName = fileName;
    }

}