#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
	public class SkipInfo
	{
		private int _type;

		private int _count;

		public int Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				_count = value;
			}
		}

		internal SkipInfo(int type, int count)
		{
			_type = type;
			_count = count;
		}

		public SkipInfo()
		{
		}
	}
}
