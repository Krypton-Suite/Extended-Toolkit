#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("BEAD311C-52FF-437f-9464-6B21054CA73D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRecoContext2
    {
        void SetGrammarOptions(SPGRAMMAROPTIONS eGrammarOptions);

        void Slot2();

        void SetAdaptationData2([MarshalAs(UnmanagedType.LPWStr)] string pAdaptationData, uint cch, [MarshalAs(UnmanagedType.LPWStr)] string pTopicName, SPADAPTATIONSETTINGS eSettings, SPADAPTATIONRELEVANCE eRelevance);
    }
}