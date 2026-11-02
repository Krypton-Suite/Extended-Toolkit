#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
internal class SPPHRASE
{
    internal uint cbSize;

    internal ushort LangID;

    internal ushort wReserved;

    internal ulong ullGrammarID;

    internal ulong ftStartTime;

    internal ulong ullAudioStreamPosition;

    internal uint ulAudioSizeBytes;

    internal uint ulRetainedSizeBytes;

    internal uint ulAudioSizeTime;

    internal SPPHRASERULE Rule;

    internal IntPtr pProperties;

    internal IntPtr pElements;

    internal uint cReplacements;

    internal IntPtr pReplacements;

    internal Guid SREngineID;

    internal uint ulSREnginePrivateDataSize;

    internal IntPtr pSREnginePrivateData;

    internal static ISpPhrase CreatePhraseFromText(string phrase, CultureInfo culture, out GCHandle[] memHandles, out IntPtr coMem)
    {
        string[] array = phrase.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        RecognizedWordUnit[] array2 = new RecognizedWordUnit[array.Length];
        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = new RecognizedWordUnit(null, 1f, null, array[i], DisplayAttributes.OneTrailingSpace, TimeSpan.Zero, TimeSpan.Zero);
        }
        return CreatePhraseFromWordUnits(array2, culture, out memHandles, out coMem);
    }

    internal static ISpPhrase CreatePhraseFromWordUnits(RecognizedWordUnit[] words, CultureInfo culture, out GCHandle[] memHandles, out IntPtr coMem)
    {
        SPPHRASEELEMENT[] array = new SPPHRASEELEMENT[words.Length];
        int num = Marshal.SizeOf(typeof(SPPHRASEELEMENT));
        List<GCHandle> list = [];
        coMem = Marshal.AllocCoTaskMem(num * array.Length);
        try
        {
            for (int i = 0; i < words.Length; i++)
            {
                RecognizedWordUnit recognizedWordUnit = words[i];
                array[i] = new SPPHRASEELEMENT();
                array[i].bDisplayAttributes = RecognizedWordUnit.DisplayAttributesToSapiAttributes(recognizedWordUnit.DisplayAttributes == DisplayAttributes.None ? DisplayAttributes.OneTrailingSpace : recognizedWordUnit.DisplayAttributes);
                array[i].SREngineConfidence = recognizedWordUnit.Confidence;
                array[i].ulAudioTimeOffset = (uint)(recognizedWordUnit._audioPosition.Ticks * 10000 / 10000);
                array[i].ulAudioSizeTime = (uint)(recognizedWordUnit._audioDuration.Ticks * 10000 / 10000);
                if (recognizedWordUnit.Text != null)
                {
                    GCHandle item = GCHandle.Alloc(recognizedWordUnit.Text, GCHandleType.Pinned);
                    list.Add(item);
                    array[i].pszDisplayText = item.AddrOfPinnedObject();
                }
                if (recognizedWordUnit.Text == null || recognizedWordUnit.LexicalForm != recognizedWordUnit.Text)
                {
                    GCHandle item2 = GCHandle.Alloc(recognizedWordUnit.LexicalForm, GCHandleType.Pinned);
                    list.Add(item2);
                    array[i].pszLexicalForm = item2.AddrOfPinnedObject();
                }
                else
                {
                    array[i].pszLexicalForm = array[i].pszDisplayText;
                }
                if (!string.IsNullOrEmpty(recognizedWordUnit.Pronunciation))
                {
                    GCHandle item3 = GCHandle.Alloc(recognizedWordUnit.Pronunciation, GCHandleType.Pinned);
                    list.Add(item3);
                    array[i].pszPronunciation = item3.AddrOfPinnedObject();
                }
                Marshal.StructureToPtr((object)array[i], new IntPtr((long)coMem + num * i), false);
            }
        }
        finally
        {
            memHandles = list.ToArray();
        }
        SPPHRASE sPPHRASE = new SPPHRASE();
        sPPHRASE.cbSize = (uint)Marshal.SizeOf(sPPHRASE.GetType());
        sPPHRASE.LangID = (ushort)culture.LCID;
        sPPHRASE.Rule = new SPPHRASERULE();
        sPPHRASE.Rule.ulCountOfElements = (uint)words.Length;
        sPPHRASE.pElements = coMem;
        SpPhraseBuilder spPhraseBuilder = new SpPhraseBuilder();
        ((ISpPhraseBuilder)spPhraseBuilder).InitFromPhrase(sPPHRASE);
        return (ISpPhrase)spPhraseBuilder;
    }
}