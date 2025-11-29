#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

using SpObjectToken = Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition.SpObjectToken;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.ObjectTokens;

internal class ObjectToken : RegistryDataKey, ISpObjectToken, ISpDataKey
{
    [ComImport]
    [Guid("5B559F40-E952-11D2-BB91-00C04F8EE6C0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface ISpObjectWithToken
    {
        [PreserveSig]
        int SetObjectToken(ISpObjectToken pToken);

        [PreserveSig]
        int GetObjectToken(IntPtr ppToken);
    }

    private const string sGenerateFileNameSpecifier = "{0}";

    private const string SPTOKENVALUE_CLSID = "CLSID";

    private ISpObjectToken _sapiObjectToken;

    private bool _disposeSapiObjectToken;

    private RegistryDataKey _attributes;

    internal RegistryDataKey Attributes
    {
        get
        {
            if (_attributes == null)
            {
                return _attributes = OpenKey("Attributes");
            }
            return _attributes;
        }
    }

    internal ISpObjectToken SAPIToken => _sapiObjectToken;

    internal string Age
    {
        get
        {
            string value;
            if (Attributes == null || !Attributes.TryGetString("Age", out value))
            {
                return string.Empty;
            }
            return value;
        }
    }

    internal string Gender
    {
        get
        {
            string value;
            if (Attributes == null || !Attributes.TryGetString("Gender", out value))
            {
                return string.Empty;
            }
            return value;
        }
    }

    internal CultureInfo Culture
    {
        get
        {
            CultureInfo result = null;
            string value;
            if (Attributes.TryGetString("Language", out value))
            {
                result = SapiAttributeParser.GetCultureInfoFromLanguageString(value);
            }
            return result;
        }
    }

    internal string Description
    {
        get
        {
            string value = string.Empty;
            string valueName = string.Format(CultureInfo.InvariantCulture, "{0:x}", [
                CultureInfo.CurrentUICulture.LCID
            ]);
            if (!TryGetString(valueName, out value))
            {
                TryGetString(null, out value);
            }
            return value;
        }
    }

    protected ObjectToken(ISpObjectToken sapiObjectToken, bool disposeSapiToken)
        : base(sapiObjectToken)
    {
        if (sapiObjectToken == null)
        {
            throw new ArgumentNullException("sapiObjectToken");
        }
        _sapiObjectToken = sapiObjectToken;
        _disposeSapiObjectToken = disposeSapiToken;
    }

    internal static ObjectToken Open(ISpObjectToken sapiObjectToken)
    {
        return new ObjectToken(sapiObjectToken, false);
    }

    internal static ObjectToken Open(string sCategoryId, string sTokenId, bool fCreateIfNotExist)
    {
        ISpObjectToken spObjectToken = (ISpObjectToken)new SpObjectToken();
        try
        {
            spObjectToken.SetId(sCategoryId, sTokenId, fCreateIfNotExist);
        }
        catch (Exception)
        {
            Marshal.ReleaseComObject(spObjectToken);
            return null;
        }
        return new ObjectToken(spObjectToken, true);
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing)
            {
                if (_disposeSapiObjectToken && _sapiObjectToken != null)
                {
                    Marshal.ReleaseComObject(_sapiObjectToken);
                    _sapiObjectToken = null;
                }
                if (_attributes != null)
                {
                    _attributes.Dispose();
                    _attributes = null;
                }
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    public override bool Equals(object obj)
    {
        ObjectToken objectToken = obj as ObjectToken;
        if (objectToken != null)
        {
            return string.Compare(base.Id, objectToken.Id, StringComparison.OrdinalIgnoreCase) == 0;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.Id.GetHashCode();
    }

    internal string TokenName()
    {
        string value = string.Empty;
        if (Attributes != null)
        {
            Attributes.TryGetString("Name", out value);
            if (string.IsNullOrEmpty(value))
            {
                TryGetString(null, out value);
            }
        }
        return value;
    }

    public void SetId([MarshalAs(UnmanagedType.LPWStr)] string pszCategoryId, [MarshalAs(UnmanagedType.LPWStr)] string pszTokenId, [MarshalAs(UnmanagedType.Bool)] bool fCreateIfNotExist)
    {
        throw new NotImplementedException();
    }

    public void GetId([MarshalAs(UnmanagedType.LPWStr)] out IntPtr ppszCoMemTokenId)
    {
        ppszCoMemTokenId = Marshal.StringToCoTaskMemUni(base.Id);
    }

    public void Slot15()
    {
        throw new NotImplementedException();
    }

    public void Slot16()
    {
        throw new NotImplementedException();
    }

    public void Slot17()
    {
        throw new NotImplementedException();
    }

    public void Slot18()
    {
        throw new NotImplementedException();
    }

    public void Slot19()
    {
        throw new NotImplementedException();
    }

    public void Slot20()
    {
        throw new NotImplementedException();
    }

    public void Slot21()
    {
        throw new NotImplementedException();
    }

    public void MatchesAttributes([MarshalAs(UnmanagedType.LPWStr)] string pszAttributes, [MarshalAs(UnmanagedType.Bool)] out bool pfMatches)
    {
        throw new NotImplementedException();
    }

    internal bool MatchesAttributes(string[] sAttributes)
    {
        bool flag = true;
        foreach (string valueName in sAttributes)
        {
            flag &= HasValue(valueName) || (Attributes != null && Attributes.HasValue(valueName));
            if (!flag)
            {
                break;
            }
        }
        return flag;
    }

    internal T CreateObjectFromToken<T>(string name)
    {
        T val = default(T);
        string value;
        if (!TryGetString(name, out value))
        {
            throw new ArgumentException(SR.Get(SRID.TokenCannotCreateInstance));
        }
        try
        {
            Type typeFromCLSID = Type.GetTypeFromCLSID(new Guid(value));
            val = (T)Activator.CreateInstance(typeFromCLSID);
            ISpObjectWithToken spObjectWithToken = val as ISpObjectWithToken;
            if (spObjectWithToken == null)
            {
                return val;
            }
            int num = spObjectWithToken.SetObjectToken(this);
            if (num < 0)
            {
                throw new ArgumentException(SR.Get(SRID.TokenCannotCreateInstance));
            }
            return val;
        }
        catch (Exception ex)
        {
            if (ex is MissingMethodException or TypeLoadException or FileLoadException or FileNotFoundException or MethodAccessException or MemberAccessException or TargetInvocationException or InvalidComObjectException or NotSupportedException or FormatException)
            {
                throw new ArgumentException(SR.Get(SRID.TokenCannotCreateInstance));
            }
            throw;
        }
    }
}