#region Licence
/*
MICROSOFT SOFTWARE LICENSE TERMS
MICROSOFT WINDOWS API CODE PACK FOR MICROSOFT .NET FRAMEWORK
___________________________________________________
These license terms are an agreement between Microsoft Corporation (or based on where you live, one of its affiliates) and you. Please read them. They apply to the software named above, which includes the media on which you received it, if any. The terms also apply to any Microsoft
• updates,
• supplements,
• Internet-based services, and 
• support services
for this software, unless other terms accompany those items. If so, those terms apply.
_______________________________________________________________________________________
BY USING THE SOFTWARE, YOU ACCEPT THESE TERMS. IF YOU DO NOT ACCEPT THEM, DO NOT USE THE SOFTWARE.
If you comply with these license terms, you have the rights below.
1. INSTALLATION AND USE RIGHTS. 
• You may use any number of copies of the software to design, develop and test your programs that run on a Microsoft Windows operating system.
• This agreement gives you rights to the software only. Any rights to a Microsoft Windows operating system (such as testing pre-release versions of Windows in a live operating environment) are provided separately by the license terms for Windows.
2. ADDITIONAL LICENSING REQUIREMENTS AND/OR USE RIGHTS.
a. Distributable Code. You may modify, copy, and distribute the software, in source or compiled form, to run on a Microsoft Windows operating system.
ii. Distribution Requirements. If you distribute the software, you must
• require distributors and external end users to agree to terms that protect it at least as much as this agreement; 
• if you modify the software and distribute such modified files, include prominent notices in such modified files so that recipients know that they are not receiving the original software;
• display your valid copyright notice on your programs; and
• indemnify, defend, and hold harmless Microsoft from any claims, including attorneys’ fees, related to the distribution or use of your programs or to your modifications to the software.
iii. Distribution Restrictions. You may not
• alter any copyright, trademark or patent notice in the software; 
• use Microsoft’s trademarks in your programs’ names or in a way that suggests your programs come from or are endorsed by Microsoft; 
• include the software in malicious, deceptive or unlawful programs; or
• modify or distribute the source code of the software so that any part of it becomes subject to an Excluded License. An Excluded License is one that requires, as a condition of use, modification or distribution, that
• the code be disclosed or distributed in source code form; or 
• others have the right to modify it.
3. SCOPE OF LICENSE. The software is licensed, not sold. This agreement only gives you some rights to use the software. Microsoft reserves all other rights. Unless applicable law gives you more rights despite this limitation, you may use the software only as expressly permitted in this agreement.
4. EXPORT RESTRICTIONS. The software is subject to United States export laws and regulations. You must comply with all domestic and international export laws and regulations that apply to the software. These laws include restrictions on destinations, end users and end use. For additional information, see <http://www.microsoft.com/exporting>.
5. SUPPORT SERVICES. Because this software is “as is,” we may not provide support services for it.
6. ENTIRE AGREEMENT. This agreement, and the terms for supplements, updates, Internet-based services and support services that you use, are the entire agreement for the software and support services.
7. APPLICABLE LAW.
a. United States. If you acquired the software in the United States, Washington state law governs the interpretation of this agreement and applies to claims for breach of it, regardless of conflict of laws principles. The laws of the state where you live govern all other claims, including claims under state consumer protection laws, unfair competition laws, and in tort.
b. Outside the United States. If you acquired the software in any other country, the laws of that country apply.
8. LEGAL EFFECT. This agreement describes certain legal rights. You may have other rights under the laws of your country. You may also have rights with respect to the party from whom you acquired the software. This agreement does not change your rights under the laws of your country if the laws of your country do not permit it to do so.
9. DISCLAIMER OF WARRANTY. THE SOFTWARE IS LICENSED “AS-IS.” YOU BEAR THE RISK OF USING IT. MICROSOFT GIVES NO EXPRESS WARRANTIES, GUARANTEES OR CONDITIONS. YOU MAY HAVE ADDITIONAL CONSUMER RIGHTS UNDER YOUR LOCAL LAWS WHICH THIS AGREEMENT CANNOT CHANGE. TO THE EXTENT PERMITTED UNDER YOUR LOCAL LAWS, MICROSOFT EXCLUDES THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
10. LIMITATION ON AND EXCLUSION OF REMEDIES AND DAMAGES. YOU CAN RECOVER FROM MICROSOFT AND ITS SUPPLIERS ONLY DIRECT DAMAGES UP TO U.S. $5.00. YOU CANNOT RECOVER ANY OTHER DAMAGES, INCLUDING CONSEQUENTIAL, LOST PROFITS, SPECIAL, INDIRECT OR INCIDENTAL DAMAGES.
This limitation applies to
• anything related to the software, services, content (including code) on third party Internet sites, or third party programs; and
• claims for breach of contract, breach of warranty, guarantee or condition, strict liability, negligence, or other tort to the extent permitted by applicable law.
It also applies even if Microsoft knew or should have known about the possibility of the damages. The above limitation or exclusion may not apply to you because your country may not allow the exclusion or limitation of incidental, consequential or other damages.
Please note: As this software is distributed in Quebec, Canada, some of the clauses in this agreement are provided below in French.
Remarque : Ce logiciel étant distribué au Québec, Canada, certaines des clauses dans ce contrat sont fournies ci-dessous en français.
EXONÉRATION DE GARANTIE. Le logiciel visé par une licence est offert « tel quel ». Toute utilisation de ce logiciel est à votre seule risque et péril. Microsoft n’accorde aucune autre garantie expresse. Vous pouvez bénéficier de droits additionnels en vertu du droit local sur la protection des consommateurs, que ce contrat ne peut modifier. La ou elles sont permises par le droit locale, les garanties implicites de qualité marchande, d’adéquation à un usage particulier et d’absence de contrefaçon sont exclues.
LIMITATION DES DOMMAGES-INTÉRÊTS ET EXCLUSION DE RESPONSABILITÉ POUR LES DOMMAGES. Vous pouvez obtenir de Microsoft et de ses fournisseurs une indemnisation en cas de dommages directs uniquement à hauteur de 5,00 $ US. Vous ne pouvez prétendre à aucune indemnisation pour les autres dommages, y compris les dommages spéciaux, indirects ou accessoires et pertes de bénéfices.
Cette limitation concerne :
• tout ce qui est relié au logiciel, aux services ou au contenu (y compris le code) figurant sur des sites Internet tiers ou dans des programmes tiers ; et
• les réclamations au titre de violation de contrat ou de garantie, ou au titre de responsabilité stricte, de négligence ou d’une autre faute dans la limite autorisée par la loi en vigueur.
Elle s’applique également, même si Microsoft connaissait ou devrait connaître l’éventualité d’un tel dommage. Si votre pays n’autorise pas l’exclusion ou la limitation de responsabilité pour les dommages indirects, accessoires ou de quelque nature que ce soit, il se peut que la limitation ou l’exclusion ci-dessus ne s’appliquera pas à votre égard.
EFFET JURIDIQUE. Le présent contrat décrit certains droits juridiques. Vous pourriez avoir d’autres droits prévus par les lois de votre pays. Le présent contrat ne modifie pas les droits que vous confèrent les lois de votre pays si celles-ci ne le permettent pas.
*/
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Windows.API.Code.Pack.Dialogs
{
    /// <summary>
    /// Wrappers for Native Methods and Structs.
    /// This type is intended for internal use only
    /// </summary>    
    internal static class CoreNativeMethods
    {
        #region General Definitions

        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread that created
        /// the specified window and returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>     
        [DllImport("user32.dll", CharSet = CharSet.Auto, PreserveSig = false, SetLastError = true)]
        public static extern void PostMessage(
            IntPtr windowHandle,
            WindowMessage message,
            IntPtr wparam,
            IntPtr lparam
        );

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>     
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
            IntPtr windowHandle,
            WindowMessage message,
            IntPtr wparam,
            IntPtr lparam
        );

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
            IntPtr windowHandle,
            uint message,
            IntPtr wparam,
            IntPtr lparam
        );

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
           IntPtr windowHandle,
           uint message,
           IntPtr wparam,
           [MarshalAs(UnmanagedType.LPWStr)] string lparam);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>
        public static IntPtr SendMessage(
            IntPtr windowHandle,
            uint message,
            int wparam,
            string lparam)
        {
            return SendMessage(windowHandle, message, (IntPtr)wparam, lparam);
        }

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
            IntPtr windowHandle,
            uint message,
            ref int wparam,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lparam);

        // Various helpers for forcing binding to proper 
        // version of Comctl32 (v6).
        [DllImport("kernel32.dll", SetLastError = true, ThrowOnUnmappableChar = true, BestFitMapping = false)]
        internal static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr graphicsObjectHandle);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int LoadString(
            IntPtr instanceHandle,
            int id,
            StringBuilder buffer,
            int bufferSize);

        [DllImport("Kernel32.dll", EntryPoint = "LocalFree")]
        internal static extern IntPtr LocalFree(ref Guid guid);

        /// <summary>
        /// Destroys an icon and frees any memory the icon occupied.
        /// </summary>
        /// <param name="hIcon">Handle to the icon to be destroyed. The icon must not be in use. </param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyIcon(IntPtr hIcon);

        #endregion

        #region Window Handling

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "DestroyWindow", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DestroyWindow(IntPtr handle);

        #endregion

        #region General Declarations

        // Various important window messages
        internal const int UserMessage = 0x0400;
        internal const int EnterIdleMessage = 0x0121;

        // FormatMessage constants and structs.
        internal const int FormatMessageFromSystem = 0x00001000;

        // App recovery and restart return codes
        internal const uint ResultFailed = 0x80004005;
        internal const uint ResultInvalidArgument = 0x80070057;
        internal const uint ResultFalse = 1;
        internal const uint ResultNotFound = 0x80070490;

        /// <summary>
        /// Gets the HiWord
        /// </summary>
        /// <param name="value">The value to get the hi word from.</param>
        /// <param name="size">Size</param>
        /// <returns>The upper half of the dword.</returns>        
        public static int GetHiWord(long value, int size)
        {
            return (short)(value >> size);
        }

        /// <summary>
        /// Gets the LoWord
        /// </summary>
        /// <param name="value">The value to get the low word from.</param>
        /// <returns>The lower half of the dword.</returns>
        public static int GetLoWord(long value)
        {
            return (short)(value & 0xFFFF);
        }

        #endregion

        #region GDI and DWM Declarations

        /// <summary>
        /// A Wrapper for a SIZE struct
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            private int width;
            private int height;

            /// <summary>
            /// Width
            /// </summary>
            public int Width { get { return width; } set { width = value; } }

            /// <summary>
            /// Height
            /// </summary>
            public int Height { get { return height; } set { height = value; } }
        };

        // Enable/disable non-client rendering based on window style.
        internal const int DWMNCRP_USEWINDOWSTYLE = 0;

        // Disabled non-client rendering; window style is ignored.
        internal const int DWMNCRP_DISABLED = 1;

        // Enabled non-client rendering; window style is ignored.
        internal const int DWMNCRP_ENABLED = 2;

        // Enable/disable non-client rendering Use DWMNCRP_* values.
        internal const int DWMWA_NCRENDERING_ENABLED = 1;

        // Non-client rendering policy.
        internal const int DWMWA_NCRENDERING_POLICY = 2;

        // Potentially enable/forcibly disable transitions 0 or 1.
        internal const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;

        #endregion

        #region Windows OS structs and consts

        internal const uint StatusAccessDenied = 0xC0000022;



        public delegate int WNDPROC(IntPtr hWnd,
            uint uMessage,
            IntPtr wParam,
            IntPtr lParam);

        #endregion
    }


}