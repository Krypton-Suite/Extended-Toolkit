#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public class SayAs
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        private string _interpretAs;

        [MarshalAs(UnmanagedType.LPWStr)]
        private string _format;

        [MarshalAs(UnmanagedType.LPWStr)]
        private string _detail;

        public string InterpretAs
        {
            get
            {
                return _interpretAs;
            }
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _interpretAs = value;
            }
        }

        public string Format
        {
            get
            {
                return _format;
            }
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _format = value;
            }
        }

        public string Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _detail = value;
            }
        }
    }
}
