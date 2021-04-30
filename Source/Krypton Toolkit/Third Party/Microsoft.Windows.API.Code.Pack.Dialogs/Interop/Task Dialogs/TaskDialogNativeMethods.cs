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

namespace Microsoft.Windows.API.Code.Pack.Dialogs
{
    /// <summary>
    /// Internal class containing most native interop declarations used
    /// throughout the library.
    /// Functions that are not performance intensive belong in this class.
    /// </summary>

    internal static class TaskDialogNativeMethods
    {
        #region TaskDialog Definitions

        [DllImport("Comctl32.dll", SetLastError = true)]
        internal static extern HResult TaskDialogIndirect(
            [In] TaskDialogNativeMethods.TaskDialogConfiguration taskConfig,
            [Out] out int button,
            [Out] out int radioButton,
            [MarshalAs(UnmanagedType.Bool), Out] out bool verificationFlagChecked);

        // Main task dialog configuration struct.
        // NOTE: Packing must be set to 4 to make this work on 64-bit platforms.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal class TaskDialogConfiguration
        {
            internal uint size;
            internal IntPtr parentHandle;
            internal IntPtr instance;
            internal TaskDialogOptions taskDialogFlags;
            internal TaskDialogCommonButtons commonButtons;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string windowTitle;
            internal IconUnion mainIcon; // NOTE: 32-bit union field, holds pszMainIcon as well
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string mainInstruction;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string content;
            internal uint buttonCount;
            internal IntPtr buttons;           // Ptr to TASKDIALOG_BUTTON structs
            internal int defaultButtonIndex;
            internal uint radioButtonCount;
            internal IntPtr radioButtons;      // Ptr to TASKDIALOG_BUTTON structs
            internal int defaultRadioButtonIndex;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string verificationText;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string expandedInformation;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string expandedControlText;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string collapsedControlText;
            internal IconUnion footerIcon;  // NOTE: 32-bit union field, holds pszFooterIcon as well
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string footerText;
            internal TaskDialogCallback callback;
            internal IntPtr callbackData;
            internal uint width;
        }

        internal const int TaskDialogIdealWidth = 0;  // Value for TASKDIALOGCONFIG.cxWidth
        internal const int TaskDialogButtonShieldIcon = 1;

        // NOTE: We include a "spacer" so that the struct size varies on 
        // 64-bit architectures.
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
        internal struct IconUnion
        {
            internal IconUnion(IntPtr i)
            {
                mainIcon = i;
            }

            [FieldOffset(0)]
            private readonly IntPtr mainIcon;

            /// <summary>
            /// Gets the handle to the Icon
            /// </summary>
            public IntPtr MainIcon { get { return mainIcon; } }
        }

        // NOTE: Packing must be set to 4 to make this work on 64-bit platforms.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal struct TaskDialogButton
        {
            public TaskDialogButton(int buttonId, string text)
            {
                this.buttonId = buttonId;
                buttonText = text;
            }

            internal int buttonId;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string buttonText;
        }

        // Task Dialog - identifies common buttons.
        [Flags]
        internal enum TaskDialogCommonButtons
        {
            Ok = 0x0001, // selected control return value IDOK
            Yes = 0x0002, // selected control return value IDYES
            No = 0x0004, // selected control return value IDNO
            Cancel = 0x0008, // selected control return value IDCANCEL
            Retry = 0x0010, // selected control return value IDRETRY
            Close = 0x0020  // selected control return value IDCLOSE
        }

        // Identify button *return values* - note that, unfortunately, these are different
        // from the inbound button values.
        internal enum TaskDialogCommonButtonReturnIds
        {
            Ok = 1,
            Cancel = 2,
            Abort = 3,
            Retry = 4,
            Ignore = 5,
            Yes = 6,
            No = 7,
            Close = 8
        }

        internal enum TaskDialogElements
        {
            Content,
            ExpandedInformation,
            Footer,
            MainInstruction
        }

        internal enum TaskDialogIconElement
        {
            Main,
            Footer
        }

        // Task Dialog - flags
        [Flags]
        internal enum TaskDialogOptions
        {
            None = 0,
            EnableHyperlinks = 0x0001,
            UseMainIcon = 0x0002,
            UseFooterIcon = 0x0004,
            AllowCancel = 0x0008,
            UseCommandLinks = 0x0010,
            UseNoIconCommandLinks = 0x0020,
            ExpandFooterArea = 0x0040,
            ExpandedByDefault = 0x0080,
            CheckVerificationFlag = 0x0100,
            ShowProgressBar = 0x0200,
            ShowMarqueeProgressBar = 0x0400,
            UseCallbackTimer = 0x0800,
            PositionRelativeToWindow = 0x1000,
            RightToLeftLayout = 0x2000,
            NoDefaultRadioButton = 0x4000
        }

        internal enum TaskDialogMessages
        {
            NavigatePage = CoreNativeMethods.UserMessage + 101,
            ClickButton = CoreNativeMethods.UserMessage + 102, // wParam = Button ID
            SetMarqueeProgressBar = CoreNativeMethods.UserMessage + 103, // wParam = 0 (nonMarque) wParam != 0 (Marquee)
            SetProgressBarState = CoreNativeMethods.UserMessage + 104, // wParam = new progress state
            SetProgressBarRange = CoreNativeMethods.UserMessage + 105, // lParam = MAKELPARAM(nMinRange, nMaxRange)
            SetProgressBarPosition = CoreNativeMethods.UserMessage + 106, // wParam = new position
            SetProgressBarMarquee = CoreNativeMethods.UserMessage + 107, // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)
            SetElementText = CoreNativeMethods.UserMessage + 108, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            ClickRadioButton = CoreNativeMethods.UserMessage + 110, // wParam = Radio Button ID
            EnableButton = CoreNativeMethods.UserMessage + 111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
            EnableRadioButton = CoreNativeMethods.UserMessage + 112, // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID
            ClickVerification = CoreNativeMethods.UserMessage + 113, // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)
            UpdateElementText = CoreNativeMethods.UserMessage + 114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            SetButtonElevationRequiredState = CoreNativeMethods.UserMessage + 115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
            UpdateIcon = CoreNativeMethods.UserMessage + 116  // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
        }

        internal enum TaskDialogNotifications
        {
            Created = 0,
            Navigated = 1,
            ButtonClicked = 2,            // wParam = Button ID
            HyperlinkClicked = 3,         // lParam = (LPCWSTR)pszHREF
            Timer = 4,                     // wParam = Milliseconds since dialog created or timer reset
            Destroyed = 5,
            RadioButtonClicked = 6,      // wParam = Radio Button ID
            Constructed = 7,
            VerificationClicked = 8,      // wParam = 1 if checkbox checked, 0 if not, lParam is unused and always 0
            Help = 9,
            ExpandButtonClicked = 10    // wParam = 0 (dialog is now collapsed), wParam != 0 (dialog is now expanded)
        }

        // Used in the various SET_DEFAULT* TaskDialog messages
        internal const int NoDefaultButtonSpecified = 0;

        // Task Dialog config and related structs (for TaskDialogIndirect())
        internal delegate int TaskDialogCallback(
            IntPtr hwnd,
            uint message,
            IntPtr wparam,
            IntPtr lparam,
            IntPtr referenceData);

        internal enum ProgressBarState
        {
            Normal = 0x0001,
            Error = 0x0002,
            Paused = 0x0003
        }

        internal enum TaskDialogIcons
        {
            Warning = 65535,
            Error = 65534,
            Information = 65533,
            Shield = 65532
        }

        #endregion
    }
}