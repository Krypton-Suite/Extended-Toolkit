﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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