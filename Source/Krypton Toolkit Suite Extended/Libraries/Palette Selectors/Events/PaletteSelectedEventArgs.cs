using System;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
	public class PaletteSelectedEventArgs : EventArgs
	{

		public PaletteSelectedEventArgs(CustomPalette customPalette)
		{
			Name = customPalette.DisplayName;
			PaletteMode = PaletteModeManager.Custom;
			CustomPalette = customPalette;
		}

		public PaletteSelectedEventArgs(string name, PaletteModeManager mode)
		{
			Name = name;
			PaletteMode = mode;
			CustomPalette = null;
		}

		public PaletteModeManager PaletteMode;
		public CustomPalette CustomPalette;
		public string Name;
	}
}