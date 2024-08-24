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

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    ///     FPS limiter known values
    /// </summary>
    public enum FPSLimiterKnownValues
    {
        /// <summary>
        ///     Limits maximum frames per second to 10fps
        /// </summary>
        LimitTen = 10,

        /// <summary>
        ///     Limits maximum frames per second to 20fps
        /// </summary>
        LimitTwenty = 20,

        /// <summary>
        ///     Limits maximum frames per second to 30fps
        /// </summary>
        LimitThirty = 30,

        /// <summary>
        ///     Limits maximum frames per second to 60fps
        /// </summary>
        LimitSixty = 60,

        /// <summary>
        ///     Limits maximum frames per second to 100fps
        /// </summary>
        LimitOneHundred = 100,

        /// <summary>
        ///     Limits maximum frames per second to 200fps
        /// </summary>
        LimitTwoHundred = 200,

        /// <summary>
        ///     Adds no limit to the number of frames per second
        /// </summary>
        NoFPSLimit = -1
    }
}