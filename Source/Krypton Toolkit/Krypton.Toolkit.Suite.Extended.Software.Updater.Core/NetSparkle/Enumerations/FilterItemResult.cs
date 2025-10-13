#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core;

/// <summary>
/// Provides the return values for the GetAvailableUpdates call on the IAppCastHandler. When an appcast is downloaded,
/// the IAppCastHandler will work out which AppCastItem instances match criteria for an update.  
/// </summary>
/// <seealso cref="IAppCastHandler.GetAvailableUpdates"/>
public enum FilterItemResult
{
    /// <summary>
    /// Indicates that the AppCastItem is a validate candidate for installation.
    /// </summary>
    Valid = 0,
    /// <summary>
    /// The AppCastItem is for a different operating system than this one, and must be ignored.
    /// </summary>
    NotThisPlatform = 1,
    /// <summary>
    /// The version indicated by the AppCastItem is less than or equal to the currently installed/running version.
    /// </summary>
    VersionIsOlderThanCurrent = 2,
    /// <summary>
    /// A signature is required to validate the item - but it's missing from the AppCastItem
    /// </summary>
    SignatureIsMissing = 3,
    /// <summary>
    /// Some other issue is going on with this AppCastItem that causes us not to want to use it.
    /// Use this FilterItemResult if it doens't fit into one of the other categories.
    /// </summary>
    SomeOtherProblem = 4,
}