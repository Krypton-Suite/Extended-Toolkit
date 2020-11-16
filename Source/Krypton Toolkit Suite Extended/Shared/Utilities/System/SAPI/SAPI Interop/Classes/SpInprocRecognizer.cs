using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("41B89B6B-9399-11D2-9623-00C04F8EE628")]
    internal class SpInprocRecognizer
    {

#if WITH_USER_DEFINED_COM_CONSTRUCTOR
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern SpInprocRecognizer();
#endif


    }
}