#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

#pragma warning disable 0108

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [ComImport, ComConversionLoss, InterfaceType((short)1), Guid("DCCFC162-2B38-11D2-B7EC-00C04F8F5D9A")]
    public interface IMLangFontLink2 : IMLangCodePages
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCharCodePages([In] ushort chSrc, out uint pdwCodePages);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStrCodePages([In] ref ushort pszSrc, [In] int cchSrc, [In] uint dwPriorityCodePages, out uint pdwCodePages, out int pcchCodePages);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CodePageToCodePages([In] uint uCodePage, out uint pdwCodePages);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CodePagesToCodePage([In] uint dwCodePages, [In] uint uDefaultCodePage, out uint puCodePage);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFontCodePages([In, ComAliasName("wireHDC")] ref _RemotableHandle hDC, [In, ComAliasName("wireHFONT")] ref _RemotableHandle hFont, out uint pdwCodePages);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ReleaseFont([In, ComAliasName("wireHFONT")] ref _RemotableHandle hFont);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResetFontMapping();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MapFont([In, ComAliasName("wireHDC")] ref _RemotableHandle hDC, [In] uint dwCodePages, [In] ushort chSrc, [Out, ComAliasName("wireHFONT")] IntPtr pFont);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFontUnicodeRanges([In, ComAliasName("wireHDC")] ref _RemotableHandle hDC, [In, Out] ref uint puiRanges, out tagUNICODERANGE pUranges);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetScriptFontInfo([In] byte sid, [In] uint dwFlags, [In, Out] ref uint puiFonts, out tagSCRIPFONTINFO pScriptFont);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CodePageToScriptID([In] uint uiCodePage, out byte pSid);
    }
}

#pragma warning restore 0108