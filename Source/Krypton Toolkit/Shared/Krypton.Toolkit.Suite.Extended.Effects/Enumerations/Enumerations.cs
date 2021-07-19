namespace Krypton.Toolkit.Suite.Extended.Effects
{
    public enum FadeDirection
    {
        IN = 0,
        OUT = 1
    }

    /// <summary>
    /// Chooses the fading speed of a <see cref="KryptonForm"/>
    /// </summary>
    public enum FadeSpeedChoice
    {
        /// <summary>
        /// Use the slowest fade speed possible
        /// </summary>
        Slowest = 0,
        /// <summary>
        /// Use the second slowest fade speed possible
        /// </summary>
        Slower = 1,
        /// <summary>
        /// Use the third slowest fade speed possible
        /// </summary>
        Slow = 2,
        /// <summary>
        /// Use a normal fade speed
        /// </summary>
        Normal = 3,
        /// <summary>
        /// Use a fast fading speed
        /// </summary>
        Fast = 4,
        /// <summary>
        /// Use a slightly faster fading speed
        /// </summary>
        Faster = 5,
        /// <summary>
        /// Use the fastest fading speed possible
        /// </summary>
        Fastest = 6,
        /// <summary>
        /// Define your own fading speed
        /// </summary>
        Custom = 7
    }
}