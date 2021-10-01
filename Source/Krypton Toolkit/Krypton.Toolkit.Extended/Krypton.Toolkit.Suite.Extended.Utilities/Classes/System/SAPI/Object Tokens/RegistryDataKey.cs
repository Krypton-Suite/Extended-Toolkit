#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

using Microsoft.Win32;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.ObjectTokens
{
    internal class RegistryDataKey : ISpDataKey, IEnumerable<RegistryDataKey>, IEnumerable, IDisposable
    {
        internal enum SAPIErrorCodes
        {
            STG_E_FILENOTFOUND = -2147287038,
            SPERR_ALREADY_INITIALIZED = -2147201022,
            SPERR_UNSUPPORTED_FORMAT = -2147201021,
            SPERR_DEVICE_BUSY = -2147201018,
            SPERR_DEVICE_NOT_SUPPORTED = -2147201017,
            SPERR_DEVICE_NOT_ENABLED = -2147201016,
            SPERR_NO_DRIVER = -2147201015,
            SPERR_TOO_MANY_GRAMMARS = -2147200990,
            SPERR_INVALID_IMPORT = -2147200988,
            SPERR_AUDIO_BUFFER_OVERFLOW = -2147200977,
            SPERR_NO_AUDIO_DATA = -2147200976,
            SPERR_NO_MORE_ITEMS = -2147200967,
            SPERR_NOT_FOUND = -2147200966,
            SPERR_GENERIC_MMSYS_ERROR = -2147200964,
            SPERR_NOT_TOPLEVEL_RULE = -2147200940,
            SPERR_NOT_ACTIVE_SESSION = -2147200925,
            SPERR_SML_GENERATION_FAIL = -2147200921,
            SPERR_SHARED_ENGINE_DISABLED = -2147200906,
            SPERR_RECOGNIZER_NOT_FOUND = -2147200905,
            SPERR_AUDIO_NOT_FOUND = -2147200904,
            S_OK = 0,
            S_FALSE = 1,
            E_INVALIDARG = -2147024809,
            SP_NO_RULES_TO_ACTIVATE = 282747,
            ERROR_MORE_DATA = 20714
        }

        internal string _sKeyId;

        internal ISpDataKey _sapiRegKey;

        internal bool _disposeSapiKey;

        internal string Id => (string)_sKeyId.Clone();

        internal string Name
        {
            get
            {
                int num = _sKeyId.LastIndexOf('\\');
                return _sKeyId.Substring(num + 1);
            }
        }

        protected RegistryDataKey(string fullPath, IntPtr regHandle)
        {
            ISpRegDataKey spRegDataKey = (ISpRegDataKey)new SpDataKey();
            SAPIErrorCodes sAPIErrorCodes = (SAPIErrorCodes)spRegDataKey.SetKey(regHandle, false);
            if (sAPIErrorCodes != 0 && sAPIErrorCodes != SAPIErrorCodes.SPERR_ALREADY_INITIALIZED)
            {
                throw new InvalidOperationException();
            }
            _sapiRegKey = spRegDataKey;
            _sKeyId = fullPath;
            _disposeSapiKey = true;
        }

        protected RegistryDataKey(string fullPath, RegistryKey managedRegKey)
            : this(fullPath, HKEYfromRegKey(managedRegKey))
        {
        }

        protected RegistryDataKey(string fullPath, RegistryDataKey copyKey)
        {
            _sKeyId = fullPath;
            _sapiRegKey = copyKey._sapiRegKey;
            _disposeSapiKey = copyKey._disposeSapiKey;
        }

        protected RegistryDataKey(string fullPath, ISpDataKey copyKey, bool shouldDispose)
        {
            _sKeyId = fullPath;
            _sapiRegKey = copyKey;
            _disposeSapiKey = shouldDispose;
        }

        protected RegistryDataKey(ISpObjectToken sapiToken)
            : this(GetTokenIdFromToken(sapiToken), sapiToken, false)
        {
        }

        internal static RegistryDataKey Open(string registryPath, bool fCreateIfNotExist)
        {
            if (string.IsNullOrEmpty(registryPath))
            {
                return null;
            }
            registryPath = registryPath.Trim('\\');
            string firstKeyAndParseRemainder = GetFirstKeyAndParseRemainder(ref registryPath);
            IntPtr intPtr = RootHKEYFromRegPath(firstKeyAndParseRemainder);
            if (IntPtr.Zero == intPtr)
            {
                return null;
            }
            RegistryDataKey registryDataKey = new RegistryDataKey(firstKeyAndParseRemainder, intPtr);
            if (string.IsNullOrEmpty(registryPath))
            {
                return registryDataKey;
            }
            return OpenSubKey(registryDataKey, registryPath, fCreateIfNotExist);
        }

        internal static RegistryDataKey Create(string keyId, RegistryKey hkey)
        {
            return new RegistryDataKey(keyId, hkey);
        }

        private static RegistryDataKey OpenSubKey(RegistryDataKey baseKey, string registryPath, bool createIfNotExist)
        {
            if (string.IsNullOrEmpty(registryPath) || baseKey == null)
            {
                return null;
            }
            string firstKeyAndParseRemainder = GetFirstKeyAndParseRemainder(ref registryPath);
            RegistryDataKey registryDataKey = createIfNotExist ? baseKey.CreateKey(firstKeyAndParseRemainder) : baseKey.OpenKey(firstKeyAndParseRemainder);
            if (string.IsNullOrEmpty(registryPath))
            {
                return registryDataKey;
            }
            return OpenSubKey(registryDataKey, registryPath, createIfNotExist);
        }

        private static string GetTokenIdFromToken(ISpObjectToken sapiToken)
        {
            IntPtr ppszCoMemTokenId = IntPtr.Zero;
            try
            {
                sapiToken.GetId(out ppszCoMemTokenId);
                return Marshal.PtrToStringUni(ppszCoMemTokenId);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ppszCoMemTokenId);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [PreserveSig]
        public int SetData([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.SysUInt)] uint cbData, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data)
        {
            return _sapiRegKey.SetData(valueName, cbData, data);
        }

        [PreserveSig]
        public int GetData([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.SysUInt)] ref uint pcbData, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data)
        {
            return _sapiRegKey.GetData(valueName, ref pcbData, data);
        }

        [PreserveSig]
        public int SetStringValue([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            return _sapiRegKey.SetStringValue(valueName, value);
        }

        [PreserveSig]
        public int GetStringValue([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.LPWStr)] out string value)
        {
            return _sapiRegKey.GetStringValue(valueName, out value);
        }

        [PreserveSig]
        public int SetDWORD([MarshalAs(UnmanagedType.LPWStr)] string valueName, [MarshalAs(UnmanagedType.SysUInt)] uint value)
        {
            return _sapiRegKey.SetDWORD(valueName, value);
        }

        [PreserveSig]
        public int GetDWORD([MarshalAs(UnmanagedType.LPWStr)] string valueName, ref uint pdwValue)
        {
            return _sapiRegKey.GetDWORD(valueName, ref pdwValue);
        }

        [PreserveSig]
        public int OpenKey([MarshalAs(UnmanagedType.LPWStr)] string subKeyName, out ISpDataKey ppSubKey)
        {
            return _sapiRegKey.OpenKey(subKeyName, out ppSubKey);
        }

        [PreserveSig]
        public int CreateKey([MarshalAs(UnmanagedType.LPWStr)] string subKeyName, out ISpDataKey ppSubKey)
        {
            return _sapiRegKey.CreateKey(subKeyName, out ppSubKey);
        }

        [PreserveSig]
        public int DeleteKey([MarshalAs(UnmanagedType.LPWStr)] string subKeyName)
        {
            return _sapiRegKey.DeleteKey(subKeyName);
        }

        [PreserveSig]
        public int DeleteValue([MarshalAs(UnmanagedType.LPWStr)] string valueName)
        {
            return _sapiRegKey.DeleteValue(valueName);
        }

        [PreserveSig]
        public int EnumKeys(uint index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszSubKeyName)
        {
            return _sapiRegKey.EnumKeys(index, out ppszSubKeyName);
        }

        [PreserveSig]
        public int EnumValues(uint index, [MarshalAs(UnmanagedType.LPWStr)] out string valueName)
        {
            return _sapiRegKey.EnumValues(index, out valueName);
        }

        internal bool TryGetString(string valueName, out string value)
        {
            if (valueName == null)
            {
                valueName = string.Empty;
            }
            return GetStringValue(valueName, out value) == 0;
        }

        internal bool HasValue(string valueName)
        {
            uint pdwValue = 0u;
            byte[] data = new byte[0];
            string value;
            if (_sapiRegKey.GetStringValue(valueName, out value) != 0 && _sapiRegKey.GetDWORD(valueName, ref pdwValue) != 0)
            {
                return _sapiRegKey.GetData(valueName, ref pdwValue, data) == 0;
            }
            return true;
        }

        internal bool TryGetDWORD(string valueName, ref uint value)
        {
            if (string.IsNullOrEmpty(valueName))
            {
                return false;
            }
            return _sapiRegKey.GetDWORD(valueName, ref value) == 0;
        }

        internal RegistryDataKey OpenKey(string keyName)
        {
            Helpers.ThrowIfEmptyOrNull(keyName, "keyName");
            ISpDataKey ppSubKey;
            if (_sapiRegKey.OpenKey(keyName, out ppSubKey) != 0)
            {
                return null;
            }
            return new RegistryDataKey(_sKeyId + "\\" + keyName, ppSubKey, true);
        }

        internal RegistryDataKey CreateKey(string keyName)
        {
            Helpers.ThrowIfEmptyOrNull(keyName, "keyName");
            ISpDataKey ppSubKey;
            if (_sapiRegKey.CreateKey(keyName, out ppSubKey) != 0)
            {
                return null;
            }
            return new RegistryDataKey(_sKeyId + "\\" + keyName, ppSubKey, true);
        }

        internal string[] GetValueNames()
        {
            List<string> list = new List<string>();
            string valueName;
            for (uint num = 0u; _sapiRegKey.EnumValues(num, out valueName) == 0; num++)
            {
                list.Add(valueName);
            }
            return list.ToArray();
        }

        IEnumerator<RegistryDataKey> IEnumerable<RegistryDataKey>.GetEnumerator()
        {
            string ppszSubKeyName = string.Empty;
            for (uint i = 0u; _sapiRegKey.EnumKeys(i, out ppszSubKeyName) == 0; i++)
            {
                yield return CreateKey(ppszSubKeyName);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<RegistryDataKey>)this).GetEnumerator();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _sapiRegKey != null && _disposeSapiKey)
            {
                Marshal.ReleaseComObject(_sapiRegKey);
                _sapiRegKey = null;
            }
        }


        private static IntPtr HKEYfromRegKey(RegistryKey regKey)
        {
            Type typeFromHandle = typeof(RegistryKey);
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo field = typeFromHandle.GetField("hkey", bindingAttr);
            if (field == null)
                field = typeFromHandle.GetField("_hkey", bindingAttr);

            SafeHandle safeHandle = (SafeHandle)field.GetValue(regKey);
            return safeHandle.DangerousGetHandle();
        }

        private static IntPtr RootHKEYFromRegPath(string rootPath)
        {
            RegistryKey registryKey = RegKeyFromRootPath(rootPath);
            if (registryKey == null)
            {
                return IntPtr.Zero;
            }
            return HKEYfromRegKey(registryKey);
        }


        private static string GetFirstKeyAndParseRemainder(ref string registryPath)
        {
            int num = registryPath.IndexOf('\\');
            string result;
            if (num >= 0)
            {
                result = registryPath.Substring(0, num);
                registryPath = registryPath.Substring(num + 1, registryPath.Length - num - 1);
            }
            else
            {
                result = registryPath;
                registryPath = string.Empty;
            }
            return result;
        }

        private static RegistryKey RegKeyFromRootPath(string rootPath)
        {
            RegistryKey[] array = new RegistryKey[4]
            {
                Registry.ClassesRoot,
                Registry.LocalMachine,
                Registry.CurrentUser,
                Registry.CurrentConfig
            };
            RegistryKey[] array2 = array;
            foreach (RegistryKey registryKey in array2)
            {
                if (registryKey.Name.Equals(rootPath, StringComparison.OrdinalIgnoreCase))
                {
                    return registryKey;
                }
            }
            return null;
        }
    }
}