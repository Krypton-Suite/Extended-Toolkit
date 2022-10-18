#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// A simple class to hold information on potential updates to a software product.
    /// </summary>
    public class UpdateInfo
    {
        /// <summary>
        /// Update availability.
        /// </summary>
        public UpdateStatus Status { get; set; }
        /// <summary>
        /// Any available updates for the product.
        /// </summary>
        public List<AppCastItem> Updates { get; set; }
        /// <summary>
        /// Constructor for SparkleUpdate when there are some updates available.
        /// </summary>
        public UpdateInfo(UpdateStatus status, List<AppCastItem> updates)
        {
            Status = status;
            Updates = updates;
        }
        /// <summary>
        /// Constructor for SparkleUpdate for when there aren't any updates available. Updates are automatically set to null.
        /// </summary>
        public UpdateInfo(UpdateStatus status)
        {
            Status = status;
            Updates = null;
        }
    }
}