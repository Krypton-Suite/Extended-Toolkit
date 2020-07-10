using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("D9F6EE60-58C9-458B-88E1-2F908FD7F87C")]
    internal class SpDataKey
    {

#if WITH_USER_DEFINED_COM_CONSTRUCTOR
        [MethodImpl(MethodImplOptions.InternalCall)]
        // public extern SpDataKey();
#endif

    }
}