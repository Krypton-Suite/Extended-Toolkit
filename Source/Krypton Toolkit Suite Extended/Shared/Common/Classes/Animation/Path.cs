namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    ///     The Path class is a representation of a line in a 1D plane and the
    ///     speed in which the animator plays it
    /// </summary>
    public class Path
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        public Path() : this(default(float), default(float), default(ulong), 0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
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
        public Path(float start, float end, ulong duration) : this(start, end, duration, 0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
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
        public Path(float start, float end, ulong duration, AnimationFunctions.Function function)
            : this(start, end, duration, 0, function)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
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
        public Path(float start, float end, ulong duration, ulong delay) : this(start, end, duration, delay, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
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
        public Path(float start, float end, ulong duration, ulong delay, AnimationFunctions.Function function)
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
        ///     Creates and returns a new <see cref="Path" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>
        ///     A new <see cref="Path" /> which is the reverse of the current <see cref="Path" />
        /// </returns>
        public Path Reverse()
        {
            return new Path(End, Start, Duration, Delay, Function);
        }
    }
}