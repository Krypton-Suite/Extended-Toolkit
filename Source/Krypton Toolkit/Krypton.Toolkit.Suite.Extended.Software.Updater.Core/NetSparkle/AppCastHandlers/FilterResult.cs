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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core
{
    /// <summary>
    /// Result of the filtering process.  
    /// </summary>
    public struct FilterResult
    {
        /// <summary>
        /// When true this indicates to NetSparkle that the highest AppCastItem in the FilteredAppCastItems list is the
        /// target for installation.  When false, the results of the FilteredAppCastItems are ignored completely (and can
        /// even be null). 
        /// </summary>
        public readonly bool _forceInstallOfLatestInFilteredList;
        /// <summary>
        /// The filtered list of AppCastItem objects.  This can be null if DetectVersionFromFilteredList is false,
        /// otherwise it must be a list of the valid AppCastItem instances that can be installed.  
        /// </summary>
        public readonly List<AppCastItem>? _filteredAppCastItems;

        /// <summary>
        /// Construct a filter result. 
        /// </summary>
        /// <param name="forceInstallOfLatestInFilteredList"></param>
        /// <param name="filteredAppCastItems"></param>
        public FilterResult(bool forceInstallOfLatestInFilteredList, List<AppCastItem>? filteredAppCastItems = null)
        {
            _forceInstallOfLatestInFilteredList = forceInstallOfLatestInFilteredList;
            _filteredAppCastItems = filteredAppCastItems;
        }
    }
}