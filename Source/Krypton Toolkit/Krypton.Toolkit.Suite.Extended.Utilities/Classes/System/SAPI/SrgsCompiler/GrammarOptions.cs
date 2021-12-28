#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    [Flags]
    internal enum GrammarOptions
    {
        KeyValuePairs = 0x0,
        MssV1 = 0x1,
        KeyValuePairSrgs = 0x2,
        IpaPhoneme = 0x4,
        W3cV1 = 0x8,
        STG = 0x10,
        TagFormat = 0xB,
        SemanticInterpretation = 0x9
    }
}