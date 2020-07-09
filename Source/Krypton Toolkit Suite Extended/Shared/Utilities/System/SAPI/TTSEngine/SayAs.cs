using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using System.Runtime.InteropServices;

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
