#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Forms;

/// <summary>
/// Chooses the fading speed of a <see cref="KryptonFormExtended"/>
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