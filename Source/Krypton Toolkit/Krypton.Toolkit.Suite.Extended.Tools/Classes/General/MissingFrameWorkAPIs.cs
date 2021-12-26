#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.CompilerServices;

namespace Krypton.Toolkit.Suite.Extended.Tools
{
    public static class MissingFrameWorkAPIs
    {
        /// <summary>
        /// Optimised Framework independent replacement for string.IsNullOrWhitespace
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
#if NET35 || NET40
#else // NET45_OR_GREATER || CORE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static bool IsNullOrWhiteSpace(string value)
        {
            // https://github.com/dotnet/runtime/issues/4207
            // And do not allocate string from trim !

            if (value == null) return true;

            // ReSharper disable once ForCanBeConvertedToForeach
            // ReSharper disable once LoopCanBeConvertedToQuery - use optimisation from array bounds
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]))
                    return false;
            }

            return true;

        }
    }
}