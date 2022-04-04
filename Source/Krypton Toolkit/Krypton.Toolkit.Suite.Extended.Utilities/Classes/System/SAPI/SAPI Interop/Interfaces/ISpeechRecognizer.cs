#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("2D5F1C0C-BD75-4b08-9478-3B11FEA2586C"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface ISpeechRecognizer
    {
        object Slot1
        {
            get;
            set;
        }

        object Slot2
        {
            get;
            set;
        }

        object Slot3
        {
            get;
            set;
        }

        object Slot4
        {
            get;
            set;
        }

        object Slot5
        {
            get;
        }

        object Slot6
        {
            get;
            set;
        }

        object Slot7
        {
            get;
            set;
        }

        object Slot8
        {
            get;
        }

        [PreserveSig, DispId(9)]
        int EmulateRecognition(object TextElements, ref object ElementDisplayAttributes, int LanguageId);

        void Slot10();

        void Slot11();

        void Slot12();

        void Slot13();

        void Slot14();

        void Slot15();

        void Slot16();

        void Slot17();

        void Slot18();

        void Slot19();

        void Slot20();
    }
}