namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	/// <filterpriority>2</filterpriority>
	[Flags]
	public enum DisplayAttributes
	{
		/// <summary />
		None = 0x0,
		/// <summary />
		ZeroTrailingSpaces = 0x2,
		/// <summary />
		OneTrailingSpace = 0x4,
		/// <summary />
		TwoTrailingSpaces = 0x8,
		/// <summary />
		ConsumeLeadingSpaces = 0x10
	}
}
