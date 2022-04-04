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
    ///     Contains public extensions methods about AnimationPath class
    /// </summary>
    public static class PathExtensions
    {
        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static AnimationPath[] ContinueTo(this AnimationPath[] paths, float end, ulong duration)
        {
            return paths.Concat(new[] { new AnimationPath(paths.Last().End, end, duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static AnimationPath[] ContinueTo(this AnimationPath[] paths, float end, ulong duration,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new AnimationPath(paths.Last().End, end, duration, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static AnimationPath[] ContinueTo(this AnimationPath[] paths, float end, ulong duration, ulong delay)
        {
            return paths.Concat(new[] { new AnimationPath(paths.Last().End, end, duration, delay) }).ToArray();
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
        public static AnimationPath[] ContinueTo(this AnimationPath[] paths, float end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new AnimationPath(paths.Last().End, end, duration, delay, function) }).ToArray();
        }


        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static AnimationPath[] ContinueTo(this AnimationPath path, float end, ulong duration)
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
        public static AnimationPath[] ContinueTo(this AnimationPath path, float end, ulong duration, AnimationFunctions.Function function)
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
        public static AnimationPath[] ContinueTo(this AnimationPath path, float end, ulong duration, ulong delay)
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
        public static AnimationPath[] ContinueTo(this AnimationPath path, float end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }


        /// <summary>
        ///     Continue the path array with a new ones
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static AnimationPath[] ContinueTo(this AnimationPath[] paths, params AnimationPath[] newPaths)
        {
            return paths.Concat(newPaths).ToArray();
        }

        /// <summary>
        ///     Continue the path with a new ones
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static AnimationPath[] ContinueTo(this AnimationPath path, params AnimationPath[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        /// <summary>
        ///     Contains a single path in an array
        /// </summary>
        /// <param name="path">The path to add to the array</param>
        /// <returns>An array of paths including the new ones</returns>
        public static AnimationPath[] ToArray(this AnimationPath path)
        {
            return new[] { path };
        }
    }
}