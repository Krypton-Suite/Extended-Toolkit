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
    ///     The Path3D class is a representation of a line in a 3D plane and the
    ///     speed in which the animator plays it
    /// </summary>
    public class Path3D
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
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
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
            : this(
                new AnimationPath(startX, endX, duration, delay, function),
                new AnimationPath(startY, endY, duration, delay, function),
                new AnimationPath(startZ, endZ, duration, delay, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
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
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            ulong delay)
            : this(
                new AnimationPath(startX, endX, duration, delay),
                new AnimationPath(startY, endY, duration, delay),
                new AnimationPath(startZ, endZ, duration, delay))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
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
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            AnimationFunctions.Function function)
            : this(
                new AnimationPath(startX, endX, duration, function),
                new AnimationPath(startY, endY, duration, function),
                new AnimationPath(startZ, endZ, duration, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration)
            : this(new AnimationPath(startX, endX, duration), new AnimationPath(startY, endY, duration), new AnimationPath(startZ, endZ, duration))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
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
        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay, AnimationFunctions.Function function)
            : this(
                new AnimationPath(start.X, end.X, duration, delay, function),
                new AnimationPath(start.Y, end.Y, duration, delay, function),
                new AnimationPath(start.Z, end.Z, duration, delay, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
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
        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay)
            : this(
                new AnimationPath(start.X, end.X, duration, delay),
                new AnimationPath(start.Y, end.Y, duration, delay),
                new AnimationPath(start.Z, end.Z, duration, delay))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
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
        public Path3D(Float3D start, Float3D end, ulong duration, AnimationFunctions.Function function)
            : this(
                new AnimationPath(start.X, end.X, duration, function),
                new AnimationPath(start.Y, end.Y, duration, function),
                new AnimationPath(start.Z, end.Z, duration, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(Float3D start, Float3D end, ulong duration)
            : this(
                new AnimationPath(start.X, end.X, duration),
                new AnimationPath(start.Y, end.Y, duration),
                new AnimationPath(start.Z, end.Z, duration))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="x">
        ///     The horizontal path.
        /// </param>
        /// <param name="y">
        ///     The vertical path.
        /// </param>
        /// <param name="z">
        ///     The depth path.
        /// </param>
        public Path3D(AnimationPath x, AnimationPath y, AnimationPath z)
        {
            HorizontalPath = x;
            VerticalPath = y;
            DepthPath = z;
        }

        /// <summary>
        ///     Gets the horizontal path
        /// </summary>
        public AnimationPath HorizontalPath { get; }

        /// <summary>
        ///     Gets the vertical path
        /// </summary>
        public AnimationPath VerticalPath { get; }

        /// <summary>
        ///     Gets the depth path
        /// </summary>
        public AnimationPath DepthPath { get; }


        /// <summary>
        ///     Gets the starting point of the path
        /// </summary>
        public Float3D Start => new Float3D(HorizontalPath.Start, VerticalPath.Start, DepthPath.Start);


        /// <summary>
        ///     Gets the ending point of the path
        /// </summary>
        public Float3D End => new Float3D(HorizontalPath.End, VerticalPath.End, DepthPath.End);

        /// <summary>
        ///     Creates and returns a new <see cref="Path3D" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>
        ///     A new <see cref="AnimationPath" /> which is the reverse of the current <see cref="Path3D" />
        /// </returns>
        public Path3D Reverse()
        {
            return new Path3D(HorizontalPath.Reverse(), VerticalPath.Reverse(), DepthPath.Reverse());
        }
    }
}