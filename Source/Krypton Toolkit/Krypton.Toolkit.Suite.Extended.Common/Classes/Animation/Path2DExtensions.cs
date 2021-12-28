#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    ///     Contains public extensions methods about Path2D class
    /// </summary>
    public static class Path2DExtensions
    {
        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration, ulong delay)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration, delay) }).ToArray();
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
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration, delay, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration, function) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration, ulong delay)
        {
            return
                paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration, delay) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration, delay, function) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration)
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
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration,
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
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration, ulong delay)
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
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration, ulong delay,
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
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration)
        {
            return path.ToArray().ContinueTo(endX, endY, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, delay, function);
        }

        /// <summary>
        ///     Continue the path array with a new ones
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, params Path2D[] newPaths)
        {
            return paths.Concat(newPaths).ToArray();
        }

        /// <summary>
        ///     Continue the path with a new ones
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path2D[] ContinueTo(this Path2D path, params Path2D[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        /// <summary>
        ///     Contains a single path in an array
        /// </summary>
        /// <param name="path">The path to add to the array</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path2D[] ToArray(this Path2D path)
        {
            return new[] { path };
        }
    }
}