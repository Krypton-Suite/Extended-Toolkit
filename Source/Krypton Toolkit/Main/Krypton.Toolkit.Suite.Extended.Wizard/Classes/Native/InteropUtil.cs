#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static class InteropUtil
    {
        internal const int cbBuffer = 256;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static T ToStructure<T>(this IntPtr ptr) => (T)Marshal.PtrToStructure(ptr, typeof(T));

        public static IntPtr StructureToPtr<T>(this T value) where T : struct
        {
            var ret = Marshal.AllocHGlobal(Marshal.SizeOf(value));
            Marshal.StructureToPtr(value, ret, false);
            return ret;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void AllocString(ref IntPtr ptr, ref uint size)
        {
            FreeString(ref ptr, ref size);
            if (size == 0) size = cbBuffer;
            ptr = Marshal.AllocHGlobal(cbBuffer);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void FreeString(ref IntPtr ptr, ref uint size)
        {
            if (ptr == IntPtr.Zero) return;
            Marshal.FreeHGlobal(ptr);
            ptr = IntPtr.Zero;
            size = 0;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static string GetString(IntPtr pString) => Marshal.PtrToStringUni(pString);

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static bool SetString(ref IntPtr ptr, ref uint size, string value = null)
        {
            var s = GetString(ptr);
            if (value == string.Empty) value = null;
            if (string.CompareOrdinal(s, value) == 0) return false;
            FreeString(ref ptr, ref size);
            if (value == null) return true;
            ptr = Marshal.StringToHGlobalUni(value);
            size = (uint)value.Length + 1;
            return true;
        }

        /// <summary>
        /// Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.
        /// </summary>
        /// <typeparam name="TS">Type of native structure used by the C-style array.</typeparam>
        /// <typeparam name="T">Output type for the CLI array. <typeparamref name="TS"/> must be able to convert to <typeparamref name="T"/>.</typeparam>
        /// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
        /// <param name="count">The number of items in the native array.</param>
        /// <param name="prefixBytes">Bytes to skip before reading the array.</param>
        /// <returns>An array of type <typeparamref name="T"/> containing the converted elements of the native array.</returns>
        public static T[] ToArray<TS, T>(this IntPtr ptr, int count, int prefixBytes = 0) where TS : IConvertible
        {
            var ret = new T[count];
            var stSize = Marshal.SizeOf(typeof(TS));
            for (var i = 0; i < count; i++)
            {
                var val = ToStructure<TS>(Marshal.ReadIntPtr(ptr, prefixBytes + i * stSize));
                ret[i] = (T)Convert.ChangeType(val, typeof(T));
            }
            return ret;
        }

        /// <summary>
        /// Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.
        /// </summary>
        /// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
        /// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
        /// <param name="count">The number of items in the native array.</param>
        /// <param name="prefixBytes">Bytes to skip before reading the array.</param>
        /// <returns>An array of type <typeparamref name="T"/> containing the elements of the native array.</returns>
        public static T[] ToArray<T>(this IntPtr ptr, int count, int prefixBytes = 0)
        {
            var ret = new T[count];
            var stSize = Marshal.SizeOf(typeof(T));
            for (var i = 0; i < count; i++)
                ret[i] = ToStructure<T>(Marshal.ReadIntPtr(ptr, prefixBytes + i * stSize));
            return ret;
        }

        /// <summary>
        /// Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
        /// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
        /// <param name="count">The number of items in the native array.</param>
        /// <param name="prefixBytes">Bytes to skip before reading the array.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
        public static IEnumerable<T> ToIEnum<T>(this IntPtr ptr, int count, int prefixBytes = 0)
        {
            if (count == 0) yield break;
            var stSize = Marshal.SizeOf(typeof(T));
            for (var i = 0; i < count; i++)
                yield return ToStructure<T>(Marshal.ReadIntPtr(ptr, prefixBytes + i * stSize));
        }

        /// <summary>
        /// Converts an <see cref="IntPtr" /> to a structure. If pointer has no value, <c>null</c> is returned.
        /// </summary>
        /// <typeparam name="T">Type of the structure.</typeparam>
        /// <param name="ptr">The <see cref="IntPtr" /> that points to allocated memory holding a structure or <see cref="IntPtr.Zero"/>.</param>
        /// <returns>The converted structure or <c>null</c>.</returns>
        public static T? PtrToStructure<T>(this IntPtr ptr) where T : struct => ptr != IntPtr.Zero ? ptr.ToStructure<T>() : (T?)null;

        /// <summary>
        /// Converts a structure or null value to an <see cref="IntPtr" />. If memory has not been allocated for the <paramref name="ptr"/>, it will be via a call to <see cref="Marshal.AllocHGlobal(int)"/>.
        /// </summary>
        /// <typeparam name="T">Type of the structure.</typeparam>
        /// <param name="value">The structure to convert. If this value is <c>null</c>, <paramref name="ptr"/> will be set to <see cref="IntPtr.Zero"/> and memory will be released.</param>
        /// <param name="ptr">The <see cref="IntPtr" /> that will point to allocated memory holding the structure or <see cref="IntPtr.Zero"/>.</param>
        /// <param name="isEmpty">An optional predicate check to determine if the structure is non-essential and can be replaced with an empty pointer (<c>null</c>).</param>
        public static void StructureToPtr<T>(T? value, ref IntPtr ptr, Predicate<T> isEmpty = null) where T : struct
        {
            if (value == null || (isEmpty != null && isEmpty(value.Value)))
            {
                if (ptr == IntPtr.Zero) return;
                Marshal.FreeHGlobal(ptr);
                ptr = IntPtr.Zero;
            }
            else
            {
                if (ptr == IntPtr.Zero)
                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
                Marshal.StructureToPtr(value, ptr, false);
            }
        }
    }
}