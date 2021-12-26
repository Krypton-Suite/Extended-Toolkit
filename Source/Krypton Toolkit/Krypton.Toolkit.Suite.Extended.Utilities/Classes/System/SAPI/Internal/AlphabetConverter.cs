#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal class AlphabetConverter
    {
        internal class PhoneMapData
        {
            private class ConversionUnit
            {
                public string sapi;

                public string ups;

                public bool isDefault;
            }

            private Hashtable prefixSapiTable;

            private Hashtable prefixUpsTable;

            private ConversionUnit[] convertTable;

            internal PhoneMapData(Stream input)
            {
                using (BinaryReader binaryReader = new BinaryReader(input, Encoding.Unicode))
                {
                    int num = binaryReader.ReadInt32();
                    convertTable = new ConversionUnit[num];
                    for (int i = 0; i < num; i++)
                    {
                        convertTable[i] = new ConversionUnit();
                        convertTable[i].sapi = ReadPhoneString(binaryReader);
                        convertTable[i].ups = ReadPhoneString(binaryReader);
                        convertTable[i].isDefault = ((binaryReader.ReadInt32() != 0) ? true : false);
                    }
                    prefixSapiTable = InitializePrefix(true);
                    prefixUpsTable = InitializePrefix(false);
                }
            }

            internal bool IsPrefix(string prefix, bool isSapi)
            {
                if (isSapi)
                {
                    return prefixSapiTable.ContainsKey(prefix);
                }
                return prefixUpsTable.ContainsKey(prefix);
            }

            internal string ConvertPhoneme(string phoneme, bool isSapi)
            {
                ConversionUnit conversionUnit = (!isSapi) ? ((ConversionUnit)prefixUpsTable[phoneme]) : ((ConversionUnit)prefixSapiTable[phoneme]);
                if (conversionUnit == null)
                {
                    return null;
                }
                if (!isSapi)
                {
                    return conversionUnit.sapi;
                }
                return conversionUnit.ups;
            }

            private Hashtable InitializePrefix(bool isSapi)
            {
                Hashtable hashtable = Hashtable.Synchronized(new Hashtable());
                for (int i = 0; i < convertTable.Length; i++)
                {
                    string text = (!isSapi) ? convertTable[i].ups : convertTable[i].sapi;
                    for (int j = 0; j + 1 < text.Length; j++)
                    {
                        string key = text.Substring(0, j + 1);
                        if (!hashtable.ContainsKey(key))
                        {
                            hashtable[key] = null;
                        }
                    }
                    if (convertTable[i].isDefault || hashtable[text] == null)
                    {
                        hashtable[text] = convertTable[i];
                    }
                }
                return hashtable;
            }

            private static string ReadPhoneString(BinaryReader reader)
            {
                int num = reader.ReadInt16() / 2;
                char[] value = reader.ReadChars(num);
                return new string(value, 0, num - 1);
            }
        }

        private int _currentLangId;

        private PhoneMapData _phoneMap;

        private static int[] _langIds = new int[7]
        {
            2052,
            1028,
            1031,
            1033,
            1034,
            1036,
            1041
        };

        private static string[] _resourceNames = new string[7]
        {
            "upstable_chs.upsmap",
            "upstable_cht.upsmap",
            "upstable_deu.upsmap",
            "upstable_enu.upsmap",
            "upstable_esp.upsmap",
            "upstable_fra.upsmap",
            "upstable_jpn.upsmap"
        };

        private static PhoneMapData[] _phoneMaps = new PhoneMapData[7];

        private static object _staticLock = new object();

        internal AlphabetConverter(int langId)
        {
            _currentLangId = -1;
            SetLanguageId(langId);
        }

        internal char[] SapiToIpa(char[] phonemes)
        {
            return Convert(phonemes, true);
        }

        internal char[] IpaToSapi(char[] phonemes)
        {
            return Convert(phonemes, false);
        }

        internal bool IsPrefix(string phonemes, bool isSapi)
        {
            return _phoneMap.IsPrefix(phonemes, isSapi);
        }

        internal bool IsConvertibleUnit(string phonemes, bool isSapi)
        {
            return _phoneMap.ConvertPhoneme(phonemes, isSapi) != null;
        }

        internal int SetLanguageId(int langId)
        {
            if (langId < 0)
            {
                throw new ArgumentException(SR.Get(SRID.MustBeGreaterThanZero), "langId");
            }
            if (langId == _currentLangId)
            {
                return _currentLangId;
            }
            int currentLangId = _currentLangId;
            int i;
            for (i = 0; i < _langIds.Length && _langIds[i] != langId; i++)
            {
            }
            if (i == _langIds.Length)
            {
                _currentLangId = langId;
                _phoneMap = null;
                return currentLangId;
            }
            lock (_staticLock)
            {
                if (_phoneMaps[i] == null)
                {
                    _phoneMaps[i] = CreateMap(_resourceNames[i]);
                }
                _phoneMap = _phoneMaps[i];
                _currentLangId = langId;
                return currentLangId;
            }
        }

        private char[] Convert(char[] phonemes, bool isSapi)
        {
            if (_phoneMap == null || phonemes.Length == 0)
            {
                return (char[])phonemes.Clone();
            }
            StringBuilder stringBuilder = new StringBuilder();
            string text = new string(phonemes);
            string text2 = null;
            int i;
            int num = i = 0;
            int num2 = -1;
            for (; i < text.Length; i++)
            {
                string text3 = text.Substring(num, i - num + 1);
                if (_phoneMap.IsPrefix(text3, isSapi))
                {
                    string text4 = _phoneMap.ConvertPhoneme(text3, isSapi);
                    if (text4 != null)
                    {
                        text2 = text4;
                        num2 = i;
                    }
                    continue;
                }
                if (text2 == null)
                {
                    break;
                }
                stringBuilder.Append(text2);
                i = num2;
                num = num2 + 1;
                text2 = null;
            }
            if (text2 != null && num2 == phonemes.Length - 1)
            {
                stringBuilder.Append(text2);
                return stringBuilder.ToString().ToCharArray();
            }
            return null;
        }

        private PhoneMapData CreateMap(string resourceName)
        {
            Type t = typeof(SR);
            Assembly assembly = t.Assembly;

            Stream manifestResourceStream = assembly.GetManifestResourceStream(t.Namespace + "." + resourceName);
            if (manifestResourceStream == null)
            {
                throw new FileLoadException(SR.Get(SRID.CannotLoadResourceFromManifest, resourceName, assembly.FullName));
            }
            return new PhoneMapData(new BufferedStream(manifestResourceStream));
        }
    }
}