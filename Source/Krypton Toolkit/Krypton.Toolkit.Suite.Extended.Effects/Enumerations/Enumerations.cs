#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
        /// Use the slowest fade speed possible. This is tied to the corresponding float value in <see cref="FadeSpeed"/>, which is 1.
        /// </summary>
        Slowest = 0,
        /// <summary>
        /// Use the second slowest fade speed possible. This is tied to the corresponding float value in <see cref="FadeSpeed"/>, which is 10.
        /// </summary>
        Slower = 1,
        /// <summary>
        /// Use the third slowest fade speed possible. This is tied to the corresponding float value in <see cref="FadeSpeed"/>, which is 25.
        /// </summary>
        Slow = 2,
        /// <summary>
        /// Use a normal fade speed. This is tied to the corresponding float value in <see cref="FadeSpeed"/>, which is 50.
        /// </summary>
        Normal = 3,
        /// <summary>
        /// Use a fast fading speed. This is tied to the corresponding float value in <see cref="FadeSpeed"/>, which is 60.
        /// </summary>
        Fast = 4,
        /// <summary>
        /// Use a slightly faster fading speed. This is tied to the corresponding float value in <see cref="FadeSpeed"/>, which is 75.
        /// </summary>
        Faster = 5,
        /// <summary>
        /// Use the fastest fading speed possible. This is tied to the corresponding float value in <see cref="FadeSpeed"/>, which is 100.
        /// </summary>
        Fastest = 6,
        /// <summary>
        /// Define your own fading speed.
        /// </summary>
        Custom = 7
    }
}