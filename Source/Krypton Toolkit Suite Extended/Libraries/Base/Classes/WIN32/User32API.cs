using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>
    /// Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
    /// </summary>
    public class User32API
	{
		/// <summary>
		/// Provides access to function required to delete handle. This method is used internally
		/// and is not required to be called separately.
		/// </summary>
		/// <param name="hIcon">Pointer to icon handle.</param>
		/// <returns>N/A</returns>
		[DllImport("User32.dll")]
		public static extern int DestroyIcon(IntPtr hIcon);
	}
}