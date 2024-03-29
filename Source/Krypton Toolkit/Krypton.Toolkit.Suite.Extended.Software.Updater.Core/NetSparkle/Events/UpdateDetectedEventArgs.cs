﻿#region License

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
    /// Contains all information for the update detected event
    /// </summary>
    public class UpdateDetectedEventArgs : EventArgs
    {
        /// <summary>
        /// The next action to execute after the app user decides how to
        /// handle an update
        /// </summary>
        public NextUpdateAction NextAction { get; set; }
        /// <summary>
        /// The application configuration (stores data on last time updates were
        /// checked, etc.)
        /// </summary>
        public Configuration ApplicationConfig { get; set; }
        /// <summary>
        /// The latest available version in the app cast
        /// </summary>
        public AppCastItem LatestVersion { get; set; }

        /// <summary>
        /// All app cast items that were sent in the appcast
        /// </summary>
        public List<AppCastItem> AppCastItems { get; set; }
    }
}