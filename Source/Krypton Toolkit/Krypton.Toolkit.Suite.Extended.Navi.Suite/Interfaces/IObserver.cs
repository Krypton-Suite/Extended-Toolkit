#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Represents an object which can observe other <see cref="IObservable"/> objects
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Handles the notification the <see cref="IObservable"/> sent. 
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional info</param>
        void Notify(IObservable obj, string id, object arguments);
    }
}