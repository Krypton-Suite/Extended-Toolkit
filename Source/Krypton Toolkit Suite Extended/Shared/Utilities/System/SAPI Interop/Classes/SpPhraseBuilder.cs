using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("777B6BBD-2FF2-11D3-88FE-00C04F8EF9B5")]
    internal class SpPhraseBuilder
    {

#if WITH_USER_DEFINED_COM_CONSTRUCTOR
        [MethodImpl(MethodImplOptions.InternalCall)]
		public extern SpPhraseBuilder();
#endif

    }
}