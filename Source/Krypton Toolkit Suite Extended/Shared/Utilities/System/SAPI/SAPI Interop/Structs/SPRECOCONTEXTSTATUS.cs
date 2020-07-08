using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPRECOCONTEXTSTATUS
    {
        internal SPINTERFERENCE eInterference;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        internal short[] szRequestTypeOfUI;

        internal uint dwReserved1;

        internal uint dwReserved2;
    }
}