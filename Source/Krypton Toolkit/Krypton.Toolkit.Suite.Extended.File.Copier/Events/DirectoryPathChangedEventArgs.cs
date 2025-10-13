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

namespace Krypton.Toolkit.Suite.Extended.File.Copier;

public class DirectoryPathChangedEventArgs : EventArgs
{
    #region Properties
    /// <summary>Gets or sets the directory path.</summary>
    /// <value>The directory path.</value>
    public string DirectoryPath { get; set; }
    #endregion

    #region Constructor
    /// <summary>Initializes a new instance of the <see cref="DirectoryPathChangedEventArgs" /> class.</summary>
    /// <param name="directoryPath">The directory path.</param>
    public DirectoryPathChangedEventArgs(string directoryPath)
    {
        DirectoryPath = directoryPath;
    }
    #endregion

    #region Methods
    /// <summary>Gets the directory path.</summary>
    /// <returns>The full path of the selected directory.</returns>
    public string GetDirectoryPath() => Path.GetFullPath(DirectoryPath);
    #endregion
}