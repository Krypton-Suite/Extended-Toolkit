#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal sealed class CfgGrammar
    {
        internal struct CfgHeader
        {
            internal Guid FormatId;

            internal Guid GrammarGUID;

            internal ushort langId;

            internal ushort pszGlobalTags;

            internal int cArcsInLargestState;

            internal StringBlob pszWords;

            internal StringBlob pszSymbols;

            internal CfgRule[] rules;

            internal CfgArc[] arcs;

            internal float[] weights;

            internal CfgSemanticTag[] tags;

            internal CfgScriptRef[] scripts;

            internal uint ulRootRuleIndex;

            internal GrammarOptions GrammarOptions;

            internal GrammarType GrammarMode;

            internal string BasePath;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class CfgSerializedHeader
        {
            internal uint ulTotalSerializedSize;

            internal Guid FormatId;

            internal Guid GrammarGUID;

            internal ushort LangID;

            internal ushort pszSemanticInterpretationGlobals;

            internal int cArcsInLargestState;

            internal int cchWords;

            internal int cWords;

            internal uint pszWords;

            internal int cchSymbols;

            internal uint pszSymbols;

            internal int cRules;

            internal uint pRules;

            internal int cArcs;

            internal uint pArcs;

            internal uint pWeights;

            internal int cTags;

            internal uint tags;

            internal uint ulReservered1;

            internal uint ulReservered2;

            internal int cScripts;

            internal uint pScripts;

            internal int cIL;

            internal uint pIL;

            internal int cPDB;

            internal uint pPDB;

            internal uint ulRootRuleIndex;

            internal GrammarOptions GrammarOptions;

            internal uint cBasePath;

            internal uint GrammarMode;

            internal uint ulReservered3;

            internal uint ulReservered4;

            internal CfgSerializedHeader()
            {
            }

            internal CfgSerializedHeader(Stream stream)
            {
                BinaryReader binaryReader = new BinaryReader(stream);
                ulTotalSerializedSize = binaryReader.ReadUInt32();
                if (ulTotalSerializedSize < 100 || ulTotalSerializedSize > int.MaxValue)
                {
                    XmlParser.ThrowSrgsException(SRID.UnsupportedFormat);
                }
                FormatId = new Guid(binaryReader.ReadBytes(16));
                if (FormatId != _SPGDF_ContextFree)
                {
                    XmlParser.ThrowSrgsException(SRID.UnsupportedFormat);
                }
                GrammarGUID = new Guid(binaryReader.ReadBytes(16));
                LangID = binaryReader.ReadUInt16();
                pszSemanticInterpretationGlobals = binaryReader.ReadUInt16();
                cArcsInLargestState = binaryReader.ReadInt32();
                cchWords = binaryReader.ReadInt32();
                cWords = binaryReader.ReadInt32();
                pszWords = binaryReader.ReadUInt32();
                if (pszWords < 100 || pszWords > ulTotalSerializedSize)
                {
                    XmlParser.ThrowSrgsException(SRID.UnsupportedFormat);
                }
                cchSymbols = binaryReader.ReadInt32();
                pszSymbols = binaryReader.ReadUInt32();
                cRules = binaryReader.ReadInt32();
                pRules = binaryReader.ReadUInt32();
                cArcs = binaryReader.ReadInt32();
                pArcs = binaryReader.ReadUInt32();
                pWeights = binaryReader.ReadUInt32();
                cTags = binaryReader.ReadInt32();
                tags = binaryReader.ReadUInt32();
                ulReservered1 = binaryReader.ReadUInt32();
                ulReservered2 = binaryReader.ReadUInt32();
                if (pszWords > 100)
                {
                    cScripts = binaryReader.ReadInt32();
                    pScripts = binaryReader.ReadUInt32();
                    cIL = binaryReader.ReadInt32();
                    pIL = binaryReader.ReadUInt32();
                    cPDB = binaryReader.ReadInt32();
                    pPDB = binaryReader.ReadUInt32();
                    ulRootRuleIndex = binaryReader.ReadUInt32();
                    GrammarOptions = (GrammarOptions)binaryReader.ReadUInt32();
                    cBasePath = binaryReader.ReadUInt32();
                    GrammarMode = binaryReader.ReadUInt32();
                    ulReservered3 = binaryReader.ReadUInt32();
                    ulReservered4 = binaryReader.ReadUInt32();
                }
            }

            internal static bool IsCfg(Stream stream, out int cfgLength)
            {
                cfgLength = 0;
                BinaryReader binaryReader = new BinaryReader(stream);
                uint num = binaryReader.ReadUInt32();
                if (num < 100 || num > int.MaxValue)
                {
                    return false;
                }
                Guid a = new Guid(binaryReader.ReadBytes(16));
                if (a != _SPGDF_ContextFree)
                {
                    return false;
                }
                cfgLength = (int)num;
                return true;
            }
        }

        internal class CfgProperty
        {
            internal string _pszName;

            internal uint _ulId;

            internal VarEnum _comType;

            internal object _comValue;
        }

        internal static Guid _SPGDF_ContextFree = new Guid(1306301037, 27879, 19904, 153, 167, 175, 158, 107, 106, 78, 145);

        internal const int INFINITE = -1;

        internal static readonly Rule SPRULETRANS_TEXTBUFFER = new Rule(-1);

        internal static readonly Rule SPRULETRANS_WILDCARD = new Rule(-2);

        internal static readonly Rule SPRULETRANS_DICTATION = new Rule(-3);

        internal const int SPTEXTBUFFERTRANSITION = 4194303;

        internal const int SPWILDCARDTRANSITION = 4194302;

        internal const int SPDICTATIONTRANSITION = 4194301;

        internal const int MAX_TRANSITIONS_COUNT = 256;

        internal const float DEFAULT_WEIGHT = 1f;

        internal const int SP_LOW_CONFIDENCE = -1;

        internal const int SP_NORMAL_CONFIDENCE = 0;

        internal const int SP_HIGH_CONFIDENCE = 1;

        private const int SP_SPCFGSERIALIZEDHEADER_500 = 100;

        private static uint _lastHandle;

        internal static uint NextHandle => ++_lastHandle;

        internal CfgGrammar()
        {
        }

        internal static CfgHeader ConvertCfgHeader(StreamMarshaler streamHelper)
        {
            CfgSerializedHeader cfgSerializedHeader = null;
            return ConvertCfgHeader(streamHelper, true, true, out cfgSerializedHeader);
        }

        internal static CfgHeader ConvertCfgHeader(StreamMarshaler streamHelper, bool includeAllGrammarData, bool loadSymbols, out CfgSerializedHeader cfgSerializedHeader)
        {
            cfgSerializedHeader = new CfgSerializedHeader(streamHelper.Stream);
            CfgHeader cfgHeader = default(CfgHeader);
            cfgHeader.FormatId = cfgSerializedHeader.FormatId;
            cfgHeader.GrammarGUID = cfgSerializedHeader.GrammarGUID;
            cfgHeader.langId = cfgSerializedHeader.LangID;
            cfgHeader.pszGlobalTags = cfgSerializedHeader.pszSemanticInterpretationGlobals;
            cfgHeader.cArcsInLargestState = cfgSerializedHeader.cArcsInLargestState;
            cfgHeader.rules = Load<CfgRule>(streamHelper, cfgSerializedHeader.pRules, cfgSerializedHeader.cRules);
            if (includeAllGrammarData || loadSymbols)
            {
                cfgHeader.pszSymbols = LoadStringBlob(streamHelper, cfgSerializedHeader.pszSymbols, cfgSerializedHeader.cchSymbols);
            }
            if (includeAllGrammarData)
            {
                cfgHeader.pszWords = LoadStringBlob(streamHelper, cfgSerializedHeader.pszWords, cfgSerializedHeader.cchWords);
                cfgHeader.arcs = Load<CfgArc>(streamHelper, cfgSerializedHeader.pArcs, cfgSerializedHeader.cArcs);
                cfgHeader.tags = Load<CfgSemanticTag>(streamHelper, cfgSerializedHeader.tags, cfgSerializedHeader.cTags);
                cfgHeader.weights = Load<float>(streamHelper, cfgSerializedHeader.pWeights, cfgSerializedHeader.cArcs);
            }
            if (cfgSerializedHeader.pszWords < Marshal.SizeOf(typeof(CfgSerializedHeader)))
            {
                cfgHeader.ulRootRuleIndex = uint.MaxValue;
                cfgHeader.GrammarOptions = GrammarOptions.KeyValuePairs;
                cfgHeader.BasePath = null;
                cfgHeader.GrammarMode = GrammarType.VoiceGrammar;
            }
            else
            {
                cfgHeader.ulRootRuleIndex = cfgSerializedHeader.ulRootRuleIndex;
                cfgHeader.GrammarOptions = cfgSerializedHeader.GrammarOptions;
                cfgHeader.GrammarMode = (GrammarType)cfgSerializedHeader.GrammarMode;
                if (includeAllGrammarData)
                {
                    cfgHeader.scripts = Load<CfgScriptRef>(streamHelper, cfgSerializedHeader.pScripts, cfgSerializedHeader.cScripts);
                }
                if (cfgSerializedHeader.cBasePath != 0)
                {
                    streamHelper.Stream.Position = (int)cfgSerializedHeader.pRules + cfgHeader.rules.Length * Marshal.SizeOf(typeof(CfgRule));
                    cfgHeader.BasePath = streamHelper.ReadNullTerminatedString();
                }
            }
            CheckValidCfgFormat(cfgSerializedHeader, cfgHeader, includeAllGrammarData);
            return cfgHeader;
        }

        internal static ScriptRef[] LoadScriptRefs(StreamMarshaler streamHelper, CfgSerializedHeader pFH)
        {
            if (pFH.FormatId != _SPGDF_ContextFree)
            {
                return null;
            }
            if (pFH.pszWords < Marshal.SizeOf(typeof(CfgSerializedHeader)))
            {
                return null;
            }
            StringBlob stringBlob = LoadStringBlob(streamHelper, pFH.pszSymbols, pFH.cchSymbols);
            CfgScriptRef[] array = Load<CfgScriptRef>(streamHelper, pFH.pScripts, pFH.cScripts);
            ScriptRef[] array2 = new ScriptRef[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                CfgScriptRef cfgScriptRef = array[i];
                array2[i] = new ScriptRef(stringBlob[cfgScriptRef._idRule], stringBlob[cfgScriptRef._idMethod], cfgScriptRef._method);
            }
            return array2;
        }

        internal static ScriptRef[] LoadIL(Stream stream)
        {
            using (StreamMarshaler streamMarshaler = new StreamMarshaler(stream))
            {
                CfgSerializedHeader cfgSerializedHeader = new CfgSerializedHeader();
                streamMarshaler.ReadStream(cfgSerializedHeader);
                return LoadScriptRefs(streamMarshaler, cfgSerializedHeader);
            }
        }

        internal static bool LoadIL(Stream stream, out byte[] assemblyContent, out byte[] assemblyDebugSymbols, out ScriptRef[] scripts)
        {
            assemblyContent = (assemblyDebugSymbols = null);
            scripts = null;
            using (StreamMarshaler streamMarshaler = new StreamMarshaler(stream))
            {
                CfgSerializedHeader cfgSerializedHeader = new CfgSerializedHeader();
                streamMarshaler.ReadStream(cfgSerializedHeader);
                scripts = LoadScriptRefs(streamMarshaler, cfgSerializedHeader);
                if (scripts == null)
                {
                    return false;
                }
                if (cfgSerializedHeader.cIL == 0)
                {
                    return false;
                }
                assemblyContent = Load<byte>(streamMarshaler, cfgSerializedHeader.pIL, cfgSerializedHeader.cIL);
                assemblyDebugSymbols = ((cfgSerializedHeader.cPDB > 0) ? Load<byte>(streamMarshaler, cfgSerializedHeader.pPDB, cfgSerializedHeader.cPDB) : null);
            }
            return true;
        }

        private static void CheckValidCfgFormat(CfgSerializedHeader pFH, CfgHeader header, bool includeAllGrammarData)
        {
            if (pFH.pszWords < 100)
            {
                XmlParser.ThrowSrgsException(SRID.UnsupportedFormat);
            }
            int start = (int)pFH.pszWords;
            CheckSetOffsets(pFH.pszWords, pFH.cchWords * 2, ref start, pFH.ulTotalSerializedSize);
            CheckSetOffsets(pFH.pszSymbols, pFH.cchSymbols * 2, ref start, pFH.ulTotalSerializedSize);
            if (pFH.cRules > 0)
            {
                CheckSetOffsets(pFH.pRules, pFH.cRules * Marshal.SizeOf(typeof(CfgRule)), ref start, pFH.ulTotalSerializedSize);
            }
            if (pFH.cArcs > 0)
            {
                CheckSetOffsets(pFH.pArcs, pFH.cArcs * Marshal.SizeOf(typeof(CfgArc)), ref start, pFH.ulTotalSerializedSize);
            }
            if (pFH.pWeights != 0)
            {
                CheckSetOffsets(pFH.pWeights, pFH.cArcs * Marshal.SizeOf(typeof(float)), ref start, pFH.ulTotalSerializedSize);
            }
            if (pFH.cTags > 0)
            {
                CheckSetOffsets(pFH.tags, pFH.cTags * Marshal.SizeOf(typeof(CfgSemanticTag)), ref start, pFH.ulTotalSerializedSize);
                if (includeAllGrammarData)
                {
                    for (int i = 0; i < header.tags.Length; i++)
                    {
                        int startArcIndex = (int)header.tags[i].StartArcIndex;
                        int endArcIndex = (int)header.tags[i].EndArcIndex;
                        int num = header.arcs.Length;
                        if (startArcIndex == 0 || startArcIndex >= num || endArcIndex == 0 || endArcIndex >= num || (header.tags[i].PropVariantType != 0 && header.tags[i].PropVariantType == VarEnum.VT_BSTR && header.tags[i].PropVariantType == VarEnum.VT_BOOL && header.tags[i].PropVariantType == VarEnum.VT_R8 && header.tags[i].PropVariantType == VarEnum.VT_I4))
                        {
                            XmlParser.ThrowSrgsException(SRID.UnsupportedFormat);
                        }
                    }
                }
            }
            if (pFH.cScripts > 0)
            {
                CheckSetOffsets(pFH.pScripts, pFH.cScripts * Marshal.SizeOf(typeof(CfgScriptRef)), ref start, pFH.ulTotalSerializedSize);
            }
            if (pFH.cIL > 0)
            {
                CheckSetOffsets(pFH.pIL, pFH.cIL * Marshal.SizeOf(typeof(byte)), ref start, pFH.ulTotalSerializedSize);
            }
            if (pFH.cPDB > 0)
            {
                CheckSetOffsets(pFH.pPDB, pFH.cPDB * Marshal.SizeOf(typeof(byte)), ref start, pFH.ulTotalSerializedSize);
            }
        }

        private static void CheckSetOffsets(uint offset, int size, ref int start, uint max)
        {
            if (offset < (uint)start || (start = (int)offset + size) > (int)max)
            {
                XmlParser.ThrowSrgsException(SRID.UnsupportedFormat);
            }
        }

        private static StringBlob LoadStringBlob(StreamMarshaler streamHelper, uint iPos, int c)
        {
            char[] array = new char[c];
            streamHelper.Position = iPos;
            streamHelper.ReadArrayChar(array, c);
            return new StringBlob(array);
        }

        private static T[] Load<T>(StreamMarshaler streamHelper, uint iPos, int c)
        {
            T[] array = null;
            array = new T[c];
            if (c > 0)
            {
                streamHelper.Position = iPos;
                streamHelper.ReadArray(array, c);
            }
            return array;
        }
    }
}