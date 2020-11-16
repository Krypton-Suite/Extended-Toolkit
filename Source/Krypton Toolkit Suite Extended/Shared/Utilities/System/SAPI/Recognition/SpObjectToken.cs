using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	[ComImport]
	[Guid("EF411752-3736-4CB4-9C8C-8EF4CCB58EFE")]
	internal class SpObjectToken
	{

#if WITH_USER_DEFINED_COM_CONSTRUCTOR
        [MethodImpl(MethodImplOptions.InternalCall)]
		public extern SpObjectToken();
#endif

    }
}
