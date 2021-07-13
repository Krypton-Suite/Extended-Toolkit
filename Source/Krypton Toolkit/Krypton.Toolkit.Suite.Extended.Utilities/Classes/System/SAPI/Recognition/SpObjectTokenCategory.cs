#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities
{
	[ComImport]
	[Guid("A910187F-0C7A-45AC-92CC-59EDAFB77B53")]
	internal class SpObjectTokenCategory
	{

#if WITH_USER_DEFINED_COM_CONSTRUCTOR
        [MethodImpl(MethodImplOptionsCall)]
		public extern SpObjectTokenCategory();
#endif

    }
}
