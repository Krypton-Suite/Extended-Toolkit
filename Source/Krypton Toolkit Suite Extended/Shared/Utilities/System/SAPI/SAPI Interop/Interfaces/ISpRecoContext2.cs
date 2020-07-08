using System;
using System.Runtime.InteropServices;

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