using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
	[TypeLibType(16)]
	internal enum SPPARTOFSPEECH
	{
		SPPS_NotOverriden = -1,
		SPPS_Unknown = 0,
		SPPS_Noun = 0x1000,
		SPPS_Verb = 0x2000,
		SPPS_Modifier = 12288,
		SPPS_Function = 0x4000,
		SPPS_Interjection = 20480,
		SPPS_SuppressWord = 61440
	}
}
