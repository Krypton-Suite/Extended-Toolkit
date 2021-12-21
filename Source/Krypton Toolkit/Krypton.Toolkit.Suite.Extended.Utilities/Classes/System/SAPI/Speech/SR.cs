#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Resources;

namespace Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech
{
    internal static class SR
	{
		private static ResourceManager _resourceManager = new ResourceManager("System.Speech.ExceptionStringTable", typeof(SR).Assembly);

		internal static string Get(SRID id, params object[] args)
		{
			string text = _resourceManager.GetString(id.ToString());
			if (string.IsNullOrEmpty(text))
			{
				text = _resourceManager.GetString("Unavailable");
			}
			else if (args != null && args.Length != 0)
			{
				text = string.Format(CultureInfo.InvariantCulture, text, args);
			}
			return text;
		}
	}
}