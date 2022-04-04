#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal static class ConvertTextFrag
    {
        private static readonly string[] _asSayAsFormat = new string[26]
        {
            "acronym",
            "address",
            "cardinal",
            "currency",
            "date",
            "date:d",
            "date:dm",
            "date:dmy",
            "date:m",
            "date:md",
            "date:mdy",
            "date:my",
            "date:ym",
            "date:ymd",
            "date:y",
            "digits",
            "name",
            "net",
            "net:email",
            "net:uri",
            "ordinal",
            "spellout",
            "telephone",
            "time",
            "time:hms12",
            "time:hms24"
        };

        private static readonly string[] _asContextFormat = new string[26]
        {
            "name",
            "address",
            "number_cardinal",
            "currency",
            "date_md",
            "date_dm",
            "date_dm",
            "date_dmy",
            "date_md",
            "date_md",
            "date_mdy",
            "date_my",
            "date_ym",
            "date_ymd",
            "date_year",
            "number_digit",
            "name",
            "web_url",
            "E-mail_address",
            "web_url",
            "number_ordinal",
            "",
            "phone_number",
            "time",
            "time",
            "time"
        };

        internal static bool ToSapi(List<TextFragment> ssmlFrags, ref GCHandle sapiFragLast)
        {
            bool flag = true;
            for (int num = ssmlFrags.Count - 1; num >= 0; num--)
            {
                TextFragment textFragment = ssmlFrags[num];
                if (textFragment.State.Action != TtsEngineAction.StartParagraph && textFragment.State.Action != TtsEngineAction.StartSentence)
                {
                    SPVTEXTFRAG sPVTEXTFRAG = new SPVTEXTFRAG();
                    sPVTEXTFRAG.gcNext = (flag ? default(GCHandle) : sapiFragLast);
                    sPVTEXTFRAG.pNext = (flag ? IntPtr.Zero : sapiFragLast.AddrOfPinnedObject());
                    sPVTEXTFRAG.gcText = GCHandle.Alloc(textFragment.TextToSpeak, GCHandleType.Pinned);
                    sPVTEXTFRAG.pTextStart = sPVTEXTFRAG.gcText.AddrOfPinnedObject();
                    sPVTEXTFRAG.ulTextSrcOffset = textFragment.TextOffset;
                    sPVTEXTFRAG.ulTextLen = textFragment.TextLength;
                    SPVSTATE state = default(SPVSTATE);
                    FragmentState state2 = textFragment.State;
                    state.eAction = (SPVACTIONS)state2.Action;
                    state.LangID = (short)state2.LangId;
                    state.EmphAdj = ((state2.Emphasis == 1) ? 1 : 0);
                    if (state2.Prosody != null)
                    {
                        state.RateAdj = SapiRate(state2.Prosody.Rate);
                        state.Volume = SapiVolume(state2.Prosody.Volume);
                        state.PitchAdj.MiddleAdj = SapiPitch(state2.Prosody.Pitch);
                    }
                    else
                    {
                        state.Volume = 100;
                    }
                    state.ePartOfSpeech = SPPARTOFSPEECH.SPPS_Unknown;
                    if (state.eAction == SPVACTIONS.SPVA_Silence)
                    {
                        state.SilenceMSecs = SapiSilence(state2.Duration, (EmphasisBreak)state2.Emphasis);
                    }
                    if (state2.Phoneme != null)
                    {
                        state.eAction = SPVACTIONS.SPVA_Pronounce;
                        sPVTEXTFRAG.gcPhoneme = GCHandle.Alloc(state2.Phoneme, GCHandleType.Pinned);
                        state.pPhoneIds = sPVTEXTFRAG.gcPhoneme.AddrOfPinnedObject();
                    }
                    else
                    {
                        sPVTEXTFRAG.gcPhoneme = default(GCHandle);
                        state.pPhoneIds = IntPtr.Zero;
                    }
                    if (state2.SayAs != null)
                    {
                        string format = state2.SayAs.Format;
                        string text;
                        switch (text = state2.SayAs.InterpretAs)
                        {
                            case "spellout":
                            case "spell-out":
                            case "characters":
                            case "letters":
                                state.eAction = SPVACTIONS.SPVA_SpellOut;
                                break;
                            case "time":
                            case "date":
                                if (!string.IsNullOrEmpty(format))
                                {
                                    text = text + ":" + format;
                                }
                                state.Context.pCategory = SapiCategory(sPVTEXTFRAG, text, null);
                                break;
                            default:
                                state.Context.pCategory = SapiCategory(sPVTEXTFRAG, text, format);
                                break;
                        }
                    }
                    sPVTEXTFRAG.State = state;
                    sapiFragLast = GCHandle.Alloc(sPVTEXTFRAG, GCHandleType.Pinned);
                    flag = false;
                }
            }
            return !flag;
        }

        private static IntPtr SapiCategory(SPVTEXTFRAG sapiFrag, string interpretAs, string format)
        {
            int num = Array.BinarySearch(_asSayAsFormat, interpretAs);
            string value = (num >= 0) ? _asContextFormat[num] : format;
            sapiFrag.gcSayAsCategory = GCHandle.Alloc(value, GCHandleType.Pinned);
            return sapiFrag.gcSayAsCategory.AddrOfPinnedObject();
        }

        internal static void FreeTextSegment(ref GCHandle fragment)
        {
            SPVTEXTFRAG sPVTEXTFRAG = (SPVTEXTFRAG)fragment.Target;
            if (sPVTEXTFRAG.gcNext.IsAllocated)
            {
                FreeTextSegment(ref sPVTEXTFRAG.gcNext);
            }
            if (sPVTEXTFRAG.gcPhoneme.IsAllocated)
            {
                sPVTEXTFRAG.gcPhoneme.Free();
            }
            if (sPVTEXTFRAG.gcSayAsCategory.IsAllocated)
            {
                sPVTEXTFRAG.gcSayAsCategory.Free();
            }
            sPVTEXTFRAG.gcText.Free();
            fragment.Free();
        }

        private static int SapiVolume(ProsodyNumber volume)
        {
            int num = 100;
            if (volume.SsmlAttributeId != int.MaxValue)
            {
                switch (volume.SsmlAttributeId)
                {
                    case -7:
                        num = 100;
                        break;
                    case -6:
                        num = 80;
                        break;
                    case -5:
                        num = 60;
                        break;
                    case -4:
                        num = 40;
                        break;
                    case -3:
                        num = 20;
                        break;
                    case -2:
                        num = 0;
                        break;
                }
                num = (int)((double)(volume.IsNumberPercent ? ((float)num * volume.Number) : volume.Number) + 0.5);
            }
            else
            {
                num = (int)((double)volume.Number + 0.5);
            }
            if (num > 100)
            {
                num = 100;
            }
            if (num < 0)
            {
                num = 0;
            }
            return num;
        }

        private static int SapiSilence(int duration, EmphasisBreak emphasis)
        {
            int num = 1000;
            if (duration > 0)
            {
                num = duration;
            }
            else
            {
                switch (emphasis)
                {
                    case EmphasisBreak.None:
                        num = 10;
                        break;
                    case EmphasisBreak.ExtraWeak:
                        num = 125;
                        break;
                    case EmphasisBreak.Weak:
                        num = 250;
                        break;
                    case EmphasisBreak.Medium:
                        num = 1000;
                        break;
                    case EmphasisBreak.Strong:
                        num = 1750;
                        break;
                    case EmphasisBreak.ExtraStrong:
                        num = 3000;
                        break;
                }
            }
            if (num < 0 || num > 65535)
            {
                num = 1000;
            }
            return num;
        }

        private static int SapiRate(ProsodyNumber rate)
        {
            int num = 0;
            if (rate.SsmlAttributeId != int.MaxValue)
            {
                switch (rate.SsmlAttributeId)
                {
                    case 1:
                        num = -9;
                        break;
                    case 2:
                        num = -4;
                        break;
                    case 4:
                        num = 4;
                        break;
                    case 5:
                        num = 9;
                        break;
                }
                num = (int)((double)(rate.IsNumberPercent ? ScaleNumber(rate.Number, num, 10) : num) + 0.5);
            }
            else
            {
                num = ScaleNumber(rate.Number, 0, 10);
            }
            if (num > 10)
            {
                num = 10;
            }
            if (num < -10)
            {
                num = -10;
            }
            return num;
        }

        private static int SapiPitch(ProsodyNumber pitch)
        {
            int num = 0;
            if (pitch.SsmlAttributeId != int.MaxValue)
            {
                switch (pitch.SsmlAttributeId)
                {
                    case 5:
                        num = 9;
                        break;
                    case 4:
                        num = 4;
                        break;
                    case 2:
                        num = -4;
                        break;
                    case 1:
                        num = -9;
                        break;
                }
                num = (int)((double)(pitch.IsNumberPercent ? ((float)num * pitch.Number) : pitch.Number) + 0.5);
            }
            if (num > 10)
            {
                num = 10;
            }
            if (num < -10)
            {
                num = -10;
            }
            return num;
        }

        private static int ScaleNumber(float value, int currentValue, int max)
        {
            int num = 0;
            if ((double)value >= 0.01)
            {
                num = (int)(Math.Log(value) / Math.Log(3.0) * (double)max + 0.5);
                num += currentValue;
                if (num > max)
                {
                    num = max;
                }
                else if (num < -max)
                {
                    num = -max;
                }
            }
            else
            {
                num = -max;
            }
            return num;
        }
    }
}