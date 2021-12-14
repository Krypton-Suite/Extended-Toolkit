#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>The AnimationPath class is a representation of a line in a 1D plane and the speed in which the animator plays it.</summary>
    public class AnimationPath
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationPath" /> class.
        /// </summary>
        public AnimationPath() : this(default(float), default(float), default(ulong), 0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationPath" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public AnimationPath(float start, float end, ulong duration) : this(start, end, duration, 0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationPath" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public AnimationPath(float start, float end, ulong duration, AnimationFunctions.Function function)
            : this(start, end, duration, 0, function)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationPath" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public AnimationPath(float start, float end, ulong duration, ulong delay) : this(start, end, duration, delay, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationPath" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public AnimationPath(float start, float end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            Start = start;
            End = end;
            Function = function ?? AnimationFunctions.Linear;
            Duration = duration;
            Delay = delay;
        }

        /// <summary>
        ///     Gets the difference of starting and ending values
        /// </summary>
        public float Change => End - Start;

        /// <summary>
        ///     Gets or sets the starting delay
        /// </summary>
        public ulong Delay { get; set; }

        /// <summary>
        ///     Gets or sets the duration in milliseconds
        /// </summary>
        public ulong Duration { get; set; }

        /// <summary>
        ///     Gets or sets the ending value
        /// </summary>
        public float End { get; set; }

        /// <summary>
        ///     Gets or sets the animation function
        /// </summary>
        public AnimationFunctions.Function Function { get; set; }

        /// <summary>
        ///     Gets or sets the starting value
        /// </summary>
        public float Start { get; set; }

        /// <summary>
        ///     Creates and returns a new <see cref="AnimationPath" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>
        ///     A new <see cref="AnimationPath" /> which is the reverse of the current <see cref="AnimationPath" />
        /// </returns>
        public AnimationPath Reverse()
        {
            return new AnimationPath(End, Start, Duration, Delay, Function);
        }
    }
}