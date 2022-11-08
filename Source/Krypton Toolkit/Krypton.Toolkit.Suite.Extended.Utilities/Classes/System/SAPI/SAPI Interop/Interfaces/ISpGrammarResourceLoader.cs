#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("B9AC5783-FCD0-4b21-B119-B4F8DA8FD2C3"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface ISpGrammarResourceLoader
    {
        [PreserveSig]
        int LoadResource(string bstrResourceUri, bool fAlwaysReload, out IStream pStream, ref string pbstrMIMEType, ref short pfModified, ref string pbstrRedirectUrl);

        string GetLocalCopy(Uri resourcePath, out string mimeType, out Uri redirectUrl);

        void ReleaseLocalCopy(string path);
    }
}