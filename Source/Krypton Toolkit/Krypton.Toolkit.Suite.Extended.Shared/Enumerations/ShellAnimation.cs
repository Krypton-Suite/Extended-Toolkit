#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Shared;

/// <summary>
/// Resource identifiers for default animations from shell32.dll.
/// </summary>
[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
public enum ShellAnimation
{
    /// <summary>
    /// An animation representing a file move.
    /// </summary>
    FileMove = 160,
    /// <summary>
    /// An animation representing a file copy.
    /// </summary>
    FileCopy = 161,
    /// <summary>
    /// An animation showing flying papers.
    /// </summary>
    FlyingPapers = 165,
    /// <summary>
    /// An animation showing a magnifying glass over a globe.
    /// </summary>
    SearchGlobe = 166,
    /// <summary>
    /// An animation representing a permanent delete.
    /// </summary>
    PermanentDelete = 164,
    /// <summary>
    /// An animation representing deleting an item from the recycle bin.
    /// </summary>
    FromRecycleBinDelete = 163,
    /// <summary>
    /// An animation representing a file move to the recycle bin.
    /// </summary>
    ToRecycleBinDelete = 162,
    /// <summary>
    /// An animation representing a search spanning the local computer.
    /// </summary>
    SearchComputer = 152,
    /// <summary>
    /// An animation representing a search in a document..
    /// </summary>
    SearchDocument = 151,
    /// <summary>
    /// An animation representing a search using a flashlight animation.
    /// </summary>
    SearchFlashlight = 150,
}