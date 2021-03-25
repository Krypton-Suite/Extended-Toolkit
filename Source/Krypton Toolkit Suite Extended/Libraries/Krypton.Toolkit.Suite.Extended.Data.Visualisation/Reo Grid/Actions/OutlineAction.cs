#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

#if OUTLINE
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
	/// <summary>
	/// Base class for all classes of single outline action
	/// </summary>
	public abstract class OutlineAction : BaseOutlineAction
	{
		internal int start;

		/// <summary>
		/// Number of line of start position to outilne
		/// </summary>
		public int Start { get { return this.start; } }

		internal int count;

		/// <summary>
		/// Number of lines does outline include
		/// </summary>
		public int Count { get { return this.count; } }

		/// <summary>
		/// Create base outline action instance
		/// </summary>
		/// <param name="rowOrColumn">Flag to specify row or column</param>
		/// <param name="start">Number of line to start add outline</param>
		/// <param name="count">Number of lines to be added into this outline</param>
		public OutlineAction(RowOrColumn rowOrColumn, int start, int count)
			: base(rowOrColumn)
		{
			this.start = start;
			this.count = count;
		}
	}
}

#endif