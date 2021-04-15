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
	/// Add outline action
	/// </summary>
	public class AddOutlineAction : OutlineAction
	{
		/// <summary>
		/// Create action to add outline
		/// </summary>
		/// <param name="rowOrColumn">Row or column to be added</param>
		/// <param name="start">Number of line to start add outline</param>
		/// <param name="count">Number of lines to be added into this outline</param>
		public AddOutlineAction(RowOrColumn rowOrColumn, int start, int count)
			: base(rowOrColumn, start, count)
		{
		}

		/// <summary>
		/// Do this action
		/// </summary>
		public override void Do()
		{
			if (this.Worksheet != null)
			{
				this.Worksheet.AddOutline(this.rowOrColumn, start, count);
			}
		}

		/// <summary>
		/// Undo this action
		/// </summary>
		public override void Undo()
		{
			if (this.Worksheet != null)
			{
				this.Worksheet.RemoveOutline(this.rowOrColumn, start, count);
			}
		}

		/// <summary>
		/// Get friendly name of this action
		/// </summary>
		/// <returns>Name of action</returns>
		public override string GetName()
		{
			return string.Format("Add {0} Outline, Start at {1}, Count: {2}",
				base.GetRowOrColumnDesc(), this.start, this.count);
		}
	}
}

#endif