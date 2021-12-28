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
    /// Represents an object which can be observed by <see cref="IObserver"/> objects. 
    /// </summary>
    /// <remarks>
    /// The IObservable object is responsible for notifying the objects that observes 
    /// the object by calling the Notify method 
    /// </remarks>
    public interface IObservable
    {
        /// <summary>
        /// Contains the observers currently observing this object
        /// </summary>
        List<IObserver> Observers { get; }


        /// <summary>
        /// Notifies the observer in the available in the list <see cref="Observers"/>
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional arguments</param>
        void NotifyObservers(IObservable obj, string id, object arguments);
    }
}