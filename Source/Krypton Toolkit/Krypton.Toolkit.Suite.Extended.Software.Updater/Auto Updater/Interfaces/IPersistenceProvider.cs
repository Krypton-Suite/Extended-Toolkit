#region License

/*
 * MIT License
 *
 * Copyright (c) 2012 - 2023 RBSoft
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
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    ///     Provides a mechanism for storing AutoUpdater state between sessions.
    /// </summary>
    public interface IPersistenceProvider
    {
        /// <summary>
        ///     Reads the flag indicating whether a specific version should be skipped or not.
        /// </summary>
        /// <returns>Returns a version to skip. If skip value is false or not present then it will return null.</returns>
        Version? GetSkippedVersion();

        /// <summary>
        ///     Reads the value containing the date and time at which the user must be given again the possibility to upgrade the
        ///     application.
        /// </summary>
        /// <returns>
        ///     Returns a DateTime value at which the user must be given again the possibility to upgrade the application. If
        ///     remind later value is not present then it will return null.
        /// </returns>
        DateTime? GetRemindLater();

        /// <summary>
        ///     Sets the values indicating the specific version that must be ignored by AutoUpdater.
        /// </summary>
        /// <param name="version">
        ///     Version code for the specific version that must be ignored. Set it to null if you don't want to
        ///     skip any version.
        /// </param>
        void SetSkippedVersion(Version? version);

        /// <summary>
        ///     Sets the date and time at which the user must be given again the possibility to upgrade the application.
        /// </summary>
        /// <param name="remindLaterAt">
        ///     Date and time at which the user must be given again the possibility to upgrade the
        ///     application.
        /// </param>
        void SetRemindLater(DateTime? remindLaterAt);
    }
}