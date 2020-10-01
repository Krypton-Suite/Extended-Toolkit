using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    [Flags]
    internal enum SPCFGRULEATTRIBUTES
    {
        SPRAF_TopLevel = 0x1,
        SPRAF_Active = 0x2,
        SPRAF_Export = 0x4,
        SPRAF_Import = 0x8,
        SPRAF_Interpreter = 0x10,
        SPRAF_Dynamic = 0x20,
        SPRAF_Root = 0x40,
        SPRAF_AutoPause = 0x10000,
        SPRAF_UserDelimited = 0x20000
    }
}