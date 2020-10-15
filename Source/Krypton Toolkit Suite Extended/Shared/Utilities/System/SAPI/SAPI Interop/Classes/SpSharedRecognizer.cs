using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("3BEE4890-4FE9-4A37-8C1E-5E7E12791C1F")]
    internal class SpSharedRecognizer
    {

#if WITH_USER_DEFINED_COM_CONSTRUCTOR
        [MethodImpl(MethodImplOptions.InternalCall)]
		public extern SpSharedRecognizer();
#endif

    }
}