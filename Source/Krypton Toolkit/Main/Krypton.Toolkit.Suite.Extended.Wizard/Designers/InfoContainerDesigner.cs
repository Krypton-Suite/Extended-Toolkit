#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
	/// <summary>
	/// 
	/// </summary>
	public class InfoContainerDesigner : ParentControlDesigner
	{

		//		/// <summary>
		//		/// Prevents the grid from being drawn on the Wizard
		//		/// </summary>
		//		protected override bool DrawGrid
		//		{
		//			get { return false; }
		//		}

		/// <summary>
		/// Drops the BackgroundImage property
		/// </summary>
		/// <param name="properties">properties to remove BackGroundImage from</param>
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);
			if (properties.Contains("BackgroundImage") == true)
				properties.Remove("BackgroundImage");
		}

	}
}