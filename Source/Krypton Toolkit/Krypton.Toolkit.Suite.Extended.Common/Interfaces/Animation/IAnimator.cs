#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Linq.Expressions;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    ///     The base interface for any Animator class, custom or build-in
    /// </summary>
    public interface IAnimator
    {
        /// <summary>
        ///     Gets the current status of the animation
        /// </summary>
        AnimatorStatus CurrentStatus { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        bool Repeat { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        bool ReverseRepeat { get; set; }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        void Play(object targetObject, string propertyName);

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        void Play(object targetObject, string propertyName, SafeInvoker endCallback);

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter);

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback);

        /// <summary>
        ///     Resume the animation from where it paused
        /// </summary>
        void Resume();

        /// <summary>
        ///     Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        void Stop();

        /// <summary>
        ///     Pause the animation
        /// </summary>
        void Pause();
    }
}