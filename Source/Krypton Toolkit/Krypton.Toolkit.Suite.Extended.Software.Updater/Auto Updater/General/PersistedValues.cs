#region License

/**
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
 **/

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    ///     Provides way to serialize and deserialize AutoUpdater persisted values.
    /// </summary>
    [DataContract]
    public class PersistedValues
    {
        /// <summary>
        ///     Application version to be skipped.
        /// </summary>
        /// <remarks>The SetSkippedVersion function sets this property and calls the Save() method for making changes permanent.</remarks>
        [DataMember]
        public Version SkippedVersion { get; set; }

        /// <summary>
        ///     Date and time at which the user must be given again the possibility to upgrade the application.
        /// </summary>
        [DataMember]
        public DateTime? RemindLaterAt { get; set; }
    }
}