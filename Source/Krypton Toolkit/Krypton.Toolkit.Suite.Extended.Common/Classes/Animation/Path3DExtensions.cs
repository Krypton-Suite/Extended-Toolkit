﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    ///     Contains public extensions methods about Path3D class
    /// </summary>
    public static class Path3DExtensions
    {
        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration, ulong delay)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration, delay) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration, delay, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[] { new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration, function) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration,
            ulong delay)
        {
            return
                paths.Concat(new[] { new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration, delay) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[]
                {new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration, delay, function)})
                    .ToArray();
        }


        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration)
        {
            return path.ToArray().ContinueTo(end, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(end, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration,
            ulong delay)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, delay, function);
        }


        /// <summary>
        ///     Continue the path array with a new ones
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, params Path3D[] newPaths)
        {
            return paths.Concat(newPaths).ToArray();
        }

        /// <summary>
        ///     Continue the path with a new ones
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path3D[] ContinueTo(this Path3D path, params Path3D[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        /// <summary>
        ///     Contains a single path in an array
        /// </summary>
        /// <param name="path">The path to add to the array</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path3D[] ToArray(this Path3D path)
        {
            return new[] { path };
        }
    }
}