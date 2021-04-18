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

namespace Microsoft.Windows.API.Code.Pack.Core
{
    internal enum WindowMessage
    {
        Null = 0x00,
        Create = 0x01,
        Destroy = 0x02,
        Move = 0x03,
        Size = 0x05,
        Activate = 0x06,
        SetFocus = 0x07,
        KillFocus = 0x08,
        Enable = 0x0A,
        SetRedraw = 0x0B,
        SetText = 0x0C,
        GetText = 0x0D,
        GetTextLength = 0x0E,
        Paint = 0x0F,
        Close = 0x10,
        QueryEndSession = 0x11,
        Quit = 0x12,
        QueryOpen = 0x13,
        EraseBackground = 0x14,
        SystemColorChange = 0x15,
        EndSession = 0x16,
        SystemError = 0x17,
        ShowWindow = 0x18,
        ControlColor = 0x19,
        WinIniChange = 0x1A,
        SettingChange = 0x1A,
        DevModeChange = 0x1B,
        ActivateApplication = 0x1C,
        FontChange = 0x1D,
        TimeChange = 0x1E,
        CancelMode = 0x1F,
        SetCursor = 0x20,
        MouseActivate = 0x21,
        ChildActivate = 0x22,
        QueueSync = 0x23,
        GetMinMaxInfo = 0x24,
        PaintIcon = 0x26,
        IconEraseBackground = 0x27,
        NextDialogControl = 0x28,
        SpoolerStatus = 0x2A,
        DrawItem = 0x2B,
        MeasureItem = 0x2C,
        DeleteItem = 0x2D,
        VKeyToItem = 0x2E,
        CharToItem = 0x2F,

        SetFont = 0x30,
        GetFont = 0x31,
        SetHotkey = 0x32,
        GetHotkey = 0x33,
        QueryDragIcon = 0x37,
        CompareItem = 0x39,
        Compacting = 0x41,
        WindowPositionChanging = 0x46,
        WindowPositionChanged = 0x47,
        Power = 0x48,
        CopyData = 0x4A,
        CancelJournal = 0x4B,
        Notify = 0x4E,
        InputLanguageChangeRequest = 0x50,
        InputLanguageChange = 0x51,
        TCard = 0x52,
        Help = 0x53,
        UserChanged = 0x54,
        NotifyFormat = 0x55,
        ContextMenu = 0x7B,
        StyleChanging = 0x7C,
        StyleChanged = 0x7D,
        DisplayChange = 0x7E,
        GetIcon = 0x7F,
        SetIcon = 0x80,

        NCCreate = 0x81,
        NCDestroy = 0x82,
        NCCalculateSize = 0x83,
        NCHitTest = 0x84,
        NCPaint = 0x85,
        NCActivate = 0x86,
        GetDialogCode = 0x87,
        NCMouseMove = 0xA0,
        NCLeftButtonDown = 0xA1,
        NCLeftButtonUp = 0xA2,
        NCLeftButtonDoubleClick = 0xA3,
        NCRightButtonDown = 0xA4,
        NCRightButtonUp = 0xA5,
        NCRightButtonDoubleClick = 0xA6,
        NCMiddleButtonDown = 0xA7,
        NCMiddleButtonUp = 0xA8,
        NCMiddleButtonDoubleClick = 0xA9,

        KeyFirst = 0x100,
        KeyDown = 0x100,
        KeyUp = 0x101,
        Char = 0x102,
        DeadChar = 0x103,
        SystemKeyDown = 0x104,
        SystemKeyUp = 0x105,
        SystemChar = 0x106,
        SystemDeadChar = 0x107,
        KeyLast = 0x108,

        IMEStartComposition = 0x10D,
        IMEEndComposition = 0x10E,
        IMEComposition = 0x10F,
        IMEKeyLast = 0x10F,

        InitializeDialog = 0x110,
        Command = 0x111,
        SystemCommand = 0x112,
        Timer = 0x113,
        HorizontalScroll = 0x114,
        VerticalScroll = 0x115,
        InitializeMenu = 0x116,
        InitializeMenuPopup = 0x117,
        MenuSelect = 0x11F,
        MenuChar = 0x120,
        EnterIdle = 0x121,

        CTLColorMessageBox = 0x132,
        CTLColorEdit = 0x133,
        CTLColorListbox = 0x134,
        CTLColorButton = 0x135,
        CTLColorDialog = 0x136,
        CTLColorScrollBar = 0x137,
        CTLColorStatic = 0x138,

        MouseFirst = 0x200,
        MouseMove = 0x200,
        LeftButtonDown = 0x201,
        LeftButtonUp = 0x202,
        LeftButtonDoubleClick = 0x203,
        RightButtonDown = 0x204,
        RightButtonUp = 0x205,
        RightButtonDoubleClick = 0x206,
        MiddleButtonDown = 0x207,
        MiddleButtonUp = 0x208,
        MiddleButtonDoubleClick = 0x209,
        MouseWheel = 0x20A,
        MouseHorizontalWheel = 0x20E,

        ParentNotify = 0x210,
        EnterMenuLoop = 0x211,
        ExitMenuLoop = 0x212,
        NextMenu = 0x213,
        Sizing = 0x214,
        CaptureChanged = 0x215,
        Moving = 0x216,
        PowerBroadcast = 0x218,
        DeviceChange = 0x219,

        MDICreate = 0x220,
        MDIDestroy = 0x221,
        MDIActivate = 0x222,
        MDIRestore = 0x223,
        MDINext = 0x224,
        MDIMaximize = 0x225,
        MDITile = 0x226,
        MDICascade = 0x227,
        MDIIconArrange = 0x228,
        MDIGetActive = 0x229,
        MDISetMenu = 0x230,
        EnterSizeMove = 0x231,
        ExitSizeMove = 0x232,
        DropFiles = 0x233,
        MDIRefreshMenu = 0x234,

        IMESetContext = 0x281,
        IMENotify = 0x282,
        IMEControl = 0x283,
        IMECompositionFull = 0x284,
        IMESelect = 0x285,
        IMEChar = 0x286,
        IMEKeyDown = 0x290,
        IMEKeyUp = 0x291,

        MouseHover = 0x2A1,
        NCMouseLeave = 0x2A2,
        MouseLeave = 0x2A3,

        Cut = 0x300,
        Copy = 0x301,
        Paste = 0x302,
        Clear = 0x303,
        Undo = 0x304,

        RenderFormat = 0x305,
        RenderAllFormats = 0x306,
        DestroyClipboard = 0x307,
        DrawClipbard = 0x308,
        PaintClipbard = 0x309,
        VerticalScrollClipBoard = 0x30A,
        SizeClipbard = 0x30B,
        AskClipboardFormatname = 0x30C,
        ChangeClipboardChain = 0x30D,
        HorizontalScrollClipboard = 0x30E,
        QueryNewPalette = 0x30F,
        PaletteIsChanging = 0x310,
        PaletteChanged = 0x311,

        Hotkey = 0x312,
        Print = 0x317,
        PrintClient = 0x318,

        HandHeldFirst = 0x358,
        HandHeldlast = 0x35F,
        PenWinFirst = 0x380,
        PenWinLast = 0x38F,
        CoalesceFirst = 0x390,
        CoalesceLast = 0x39F,
        DDE_First = 0x3E0,
        DDE_Initiate = 0x3E0,
        DDE_Terminate = 0x3E1,
        DDE_Advise = 0x3E2,
        DDE_Unadvise = 0x3E3,
        DDE_Ack = 0x3E4,
        DDE_Data = 0x3E5,
        DDE_Request = 0x3E6,
        DDE_Poke = 0x3E7,
        DDE_Execute = 0x3E8,
        DDE_Last = 0x3E8,

        User = 0x400,
        App = 0x8000,
    }
}