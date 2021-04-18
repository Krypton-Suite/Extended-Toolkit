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

using Microsoft.Windows.API.Code.Pack.Dialogs.Resources;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.Windows.API.Code.Pack.Dialogs
{
    /// <summary>
    /// Encapsulates the native logic required to create, 
    /// configure, and show a TaskDialog, 
    /// via the TaskDialogIndirect() Win32 function.
    /// </summary>
    /// <remarks>A new instance of this class should 
    /// be created for each messagebox show, as
    /// the HWNDs for TaskDialogs do not remain constant 
    /// across calls to TaskDialogIndirect.
    /// </remarks>
    internal class NativeTaskDialog : IDisposable
    {
        private TaskDialogNativeMethods.TaskDialogConfiguration nativeDialogConfig;
        private NativeTaskDialogSettings settings;
        private IntPtr hWndDialog;
        private TaskDialog outerDialog;

        private IntPtr[] updatedStrings = new IntPtr[Enum.GetNames(typeof(TaskDialogNativeMethods.TaskDialogElements)).Length];
        private IntPtr buttonArray, radioButtonArray;

        // Flag tracks whether our first radio 
        // button click event has come through.
        private bool firstRadioButtonClicked = true;

        #region Constructors

        // Configuration is applied at dialog creation time.
        internal NativeTaskDialog(NativeTaskDialogSettings settings, TaskDialog outerDialog)
        {
            nativeDialogConfig = settings.NativeConfiguration;
            this.settings = settings;

            // Wireup dialog proc message loop for this instance.
            nativeDialogConfig.callback = new TaskDialogNativeMethods.TaskDialogCallback(DialogProc);

            ShowState = DialogShowState.PreShow;

            // Keep a reference to the outer shell, so we can notify.
            this.outerDialog = outerDialog;
        }

        #endregion

        #region Public Properties

        public DialogShowState ShowState { get; private set; }

        public int SelectedButtonId { get; private set; }

        public int SelectedRadioButtonId { get; private set; }

        public bool CheckBoxChecked { get; private set; }

        #endregion

        internal void NativeShow()
        {
            // Applies config struct and other settings, then
            // calls main Win32 function.
            if (settings == null)
            {
                throw new InvalidOperationException(LocalizedMessages.NativeTaskDialogConfigurationError);
            }

            // Do a last-minute parse of the various dialog control lists,  
            // and only allocate the memory at the last minute.

            MarshalDialogControlStructs();

            // Make the call and show the dialog.
            // NOTE: this call is BLOCKING, though the thread 
            // WILL re-enter via the DialogProc.
            try
            {
                ShowState = DialogShowState.Showing;

                int selectedButtonId;
                int selectedRadioButtonId;
                bool checkBoxChecked;

                // Here is the way we use "vanilla" P/Invoke to call TaskDialogIndirect().  
                HResult hresult = TaskDialogNativeMethods.TaskDialogIndirect(
                    nativeDialogConfig,
                    out selectedButtonId,
                    out selectedRadioButtonId,
                    out checkBoxChecked);

                if (CoreErrorHelper.Failed(hresult))
                {
                    string msg;
                    switch (hresult)
                    {
                        case HResult.InvalidArguments:
                            msg = LocalizedMessages.NativeTaskDialogInternalErrorArgs;
                            break;
                        case HResult.OutOfMemory:
                            msg = LocalizedMessages.NativeTaskDialogInternalErrorComplex;
                            break;
                        default:
                            msg = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                LocalizedMessages.NativeTaskDialogInternalErrorUnexpected,
                                hresult);
                            break;
                    }
                    Exception e = Marshal.GetExceptionForHR((int)hresult);
                    throw new Win32Exception(msg, e);
                }

                SelectedButtonId = selectedButtonId;
                SelectedRadioButtonId = selectedRadioButtonId;
                CheckBoxChecked = checkBoxChecked;
            }
            catch (EntryPointNotFoundException exc)
            {
                throw new NotSupportedException(LocalizedMessages.NativeTaskDialogVersionError, exc);
            }
            finally
            {
                ShowState = DialogShowState.Closed;
            }
        }

        // The new task dialog does not support the existing 
        // Win32 functions for closing (e.g. EndDialog()); instead,
        // a "click button" message is sent. In this case, we're 
        // abstracting out to say that the TaskDialog consumer can
        // simply call "Close" and we'll "click" the cancel button. 
        // Note that the cancel button doesn't actually
        // have to exist for this to work.
        internal void NativeClose(TaskDialogResult result)
        {
            ShowState = DialogShowState.Closing;

            int id;
            switch (result)
            {
                case TaskDialogResult.Close:
                    id = (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.Close;
                    break;
                case TaskDialogResult.CustomButtonClicked:
                    id = DialogsDefaults.MinimumDialogControlId; // custom buttons
                    break;
                case TaskDialogResult.No:
                    id = (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.No;
                    break;
                case TaskDialogResult.Ok:
                    id = (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.Ok;
                    break;
                case TaskDialogResult.Retry:
                    id = (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.Retry;
                    break;
                case TaskDialogResult.Yes:
                    id = (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.Yes;
                    break;
                default:
                    id = (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.Cancel;
                    break;
            }

            SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.ClickButton, id, 0);
        }

        #region Main Dialog Proc

        private int DialogProc(
            IntPtr windowHandle,
            uint message,
            IntPtr wparam,
            IntPtr lparam,
            IntPtr referenceData)
        {
            // Fetch the HWND - it may be the first time we're getting it.
            hWndDialog = windowHandle;

            // Big switch on the various notifications the 
            // dialog proc can get.
            switch ((TaskDialogNativeMethods.TaskDialogNotifications)message)
            {
                case TaskDialogNativeMethods.TaskDialogNotifications.Created:
                    int result = PerformDialogInitialization();
                    outerDialog.RaiseOpenedEvent();
                    return result;
                case TaskDialogNativeMethods.TaskDialogNotifications.ButtonClicked:
                    return HandleButtonClick((int)wparam);
                case TaskDialogNativeMethods.TaskDialogNotifications.RadioButtonClicked:
                    return HandleRadioButtonClick((int)wparam);
                case TaskDialogNativeMethods.TaskDialogNotifications.HyperlinkClicked:
                    return HandleHyperlinkClick(lparam);
                case TaskDialogNativeMethods.TaskDialogNotifications.Help:
                    return HandleHelpInvocation();
                case TaskDialogNativeMethods.TaskDialogNotifications.Timer:
                    return HandleTick((int)wparam);
                case TaskDialogNativeMethods.TaskDialogNotifications.Destroyed:
                    return PerformDialogCleanup();
                default:
                    break;
            }
            return (int)HResult.Ok;
        }

        // Once the task dialog HWND is open, we need to send 
        // additional messages to configure it.
        private int PerformDialogInitialization()
        {
            // Initialize Progress or Marquee Bar.
            if (IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions.ShowProgressBar))
            {
                UpdateProgressBarRange();

                // The order of the following is important - 
                // state is more important than value, 
                // and non-normal states turn off the bar value change 
                // animation, which is likely the intended
                // and preferable behavior.
                UpdateProgressBarState(settings.ProgressBarState);
                UpdateProgressBarValue(settings.ProgressBarValue);

                // Due to a bug that wasn't fixed in time for RTM of Vista,
                // second SendMessage is required if the state is non-Normal.
                UpdateProgressBarValue(settings.ProgressBarValue);
            }
            else if (IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions.ShowMarqueeProgressBar))
            {
                // TDM_SET_PROGRESS_BAR_MARQUEE is necessary 
                // to cause the marquee to start animating.
                // Note that this internal task dialog setting is 
                // round-tripped when the marquee is
                // is set to different states, so it never has to 
                // be touched/sent again.
                SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarMarquee, 1, 0);
                UpdateProgressBarState(settings.ProgressBarState);
            }

            if (settings.ElevatedButtons != null && settings.ElevatedButtons.Count > 0)
            {
                foreach (int id in settings.ElevatedButtons)
                {
                    UpdateElevationIcon(id, true);
                }
            }

            return CoreErrorHelper.Ignored;
        }

        private int HandleButtonClick(int id)
        {
            // First we raise a Click event, if there is a custom button
            // However, we implement Close() by sending a cancel button, so 
            // we don't want to raise a click event in response to that.
            if (ShowState != DialogShowState.Closing)
            {
                outerDialog.RaiseButtonClickEvent(id);
            }

            // Once that returns, we raise a Closing event for the dialog
            // The Win32 API handles button clicking-and-closing 
            // as an atomic action,
            // but it is more .NET friendly to split them up.
            // Unfortunately, we do NOT have the return values at this stage.
            if (id < DialogsDefaults.MinimumDialogControlId)
            {
                return outerDialog.RaiseClosingEvent(id);
            }

            // https://msdn.microsoft.com/en-us/library/windows/desktop/bb760542(v=vs.85).aspx
            // The return value is specific to the notification being processed.
            // When responding to a button click, your implementation should return S_FALSE
            // if the Task Dialog is not to close. Otherwise return S_OK.
            return ShowState == DialogShowState.Closing ? (int)HResult.Ok : (int)HResult.False;
        }

        private int HandleRadioButtonClick(int id)
        {
            // When the dialog sets the radio button to default, 
            // it (somewhat confusingly)issues a radio button clicked event
            //  - we mask that out - though ONLY if
            // we do have a default radio button
            if (firstRadioButtonClicked
                && !IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions.NoDefaultRadioButton))
            {
                firstRadioButtonClicked = false;
            }
            else
            {
                outerDialog.RaiseButtonClickEvent(id);
            }

            // Note: we don't raise Closing, as radio 
            // buttons are non-committing buttons
            return CoreErrorHelper.Ignored;
        }

        private int HandleHyperlinkClick(IntPtr href)
        {
            string link = Marshal.PtrToStringUni(href);
            outerDialog.RaiseHyperlinkClickEvent(link);

            return CoreErrorHelper.Ignored;
        }


        private int HandleTick(int ticks)
        {
            outerDialog.RaiseTickEvent(ticks);
            return CoreErrorHelper.Ignored;
        }

        private int HandleHelpInvocation()
        {
            outerDialog.RaiseHelpInvokedEvent();
            return CoreErrorHelper.Ignored;
        }

        // There should be little we need to do here, 
        // as the use of the NativeTaskDialog is
        // that it is instantiated for a single show, then disposed of.
        private int PerformDialogCleanup()
        {
            firstRadioButtonClicked = true;

            return CoreErrorHelper.Ignored;
        }

        #endregion

        #region Update members

        internal void UpdateProgressBarValue(int i)
        {
            AssertCurrentlyShowing();
            SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarPosition, i, 0);
        }

        internal void UpdateProgressBarRange(int? min = null, int? max = null)
        {
            AssertCurrentlyShowing();

            if (min.HasValue) settings.ProgressBarMinimum = min.Value;
            if (max.HasValue) settings.ProgressBarMaximum = max.Value;

            // Build range LPARAM - note it is in REVERSE intuitive order.
            long range = NativeTaskDialog.MakeLongLParam(
                settings.ProgressBarMaximum,
                settings.ProgressBarMinimum);

            SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarRange, 0, range);
        }

        internal void UpdateProgressBarState(TaskDialogProgressBarState state)
        {
            AssertCurrentlyShowing();
            SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarState, (int)state, 0);
        }

        internal void UpdateText(string text)
        {
            UpdateTextCore(text, TaskDialogNativeMethods.TaskDialogElements.Content);
        }

        internal void UpdateInstruction(string instruction)
        {
            UpdateTextCore(instruction, TaskDialogNativeMethods.TaskDialogElements.MainInstruction);
        }

        internal void UpdateFooterText(string footerText)
        {
            UpdateTextCore(footerText, TaskDialogNativeMethods.TaskDialogElements.Footer);
        }

        internal void UpdateExpandedText(string expandedText)
        {
            UpdateTextCore(expandedText, TaskDialogNativeMethods.TaskDialogElements.ExpandedInformation);
        }

        private void UpdateTextCore(string s, TaskDialogNativeMethods.TaskDialogElements element)
        {
            AssertCurrentlyShowing();

            FreeOldString(element);
            SendMessageHelper(
                TaskDialogNativeMethods.TaskDialogMessages.SetElementText,
                (int)element,
                (long)MakeNewString(s, element));
        }

        internal void UpdateMainIcon(TaskDialogStandardIcon mainIcon)
        {
            UpdateIconCore(mainIcon, TaskDialogNativeMethods.TaskDialogIconElement.Main);
        }

        internal void UpdateFooterIcon(TaskDialogStandardIcon footerIcon)
        {
            UpdateIconCore(footerIcon, TaskDialogNativeMethods.TaskDialogIconElement.Footer);
        }

        private void UpdateIconCore(TaskDialogStandardIcon icon, TaskDialogNativeMethods.TaskDialogIconElement element)
        {
            AssertCurrentlyShowing();
            SendMessageHelper(
                TaskDialogNativeMethods.TaskDialogMessages.UpdateIcon,
                (int)element,
                (long)icon);
        }

        internal void UpdateCheckBoxChecked(bool cbc)
        {
            AssertCurrentlyShowing();
            SendMessageHelper(
                TaskDialogNativeMethods.TaskDialogMessages.ClickVerification,
                (cbc ? 1 : 0),
                1);
        }

        internal void UpdateElevationIcon(int buttonId, bool showIcon)
        {
            AssertCurrentlyShowing();
            SendMessageHelper(
                TaskDialogNativeMethods.TaskDialogMessages.SetButtonElevationRequiredState,
                buttonId,
                Convert.ToInt32(showIcon));
        }

        internal void UpdateButtonEnabled(int buttonID, bool enabled)
        {
            AssertCurrentlyShowing();
            SendMessageHelper(
                TaskDialogNativeMethods.TaskDialogMessages.EnableButton, buttonID, enabled == true ? 1 : 0);
        }

        internal void UpdateRadioButtonEnabled(int buttonID, bool enabled)
        {
            AssertCurrentlyShowing();
            SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.EnableRadioButton,
                buttonID, enabled == true ? 1 : 0);
        }

        internal void AssertCurrentlyShowing()
        {
            Debug.Assert(ShowState == DialogShowState.Showing,
                "Update*() methods should only be called while native dialog is showing");
        }

        #endregion

        #region Helpers

        private int SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages message, int wparam, long lparam)
        {
            // Be sure to at least assert here - 
            // messages to invalid handles often just disappear silently
            Debug.Assert(hWndDialog != null, "HWND for dialog is null during SendMessage");

            return (int)CoreNativeMethods.SendMessage(
                hWndDialog,
                (uint)message,
                (IntPtr)wparam,
                new IntPtr(lparam));
        }

        private bool IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions flag)
        {
            return ((nativeDialogConfig.taskDialogFlags & flag) == flag);
        }

        // Allocates a new string on the unmanaged heap, 
        // and stores the pointer so we can free it later.

        private IntPtr MakeNewString(string text, TaskDialogNativeMethods.TaskDialogElements element)
        {
            IntPtr newStringPtr = Marshal.StringToHGlobalUni(text);
            updatedStrings[(int)element] = newStringPtr;
            return newStringPtr;
        }

        // Checks to see if the given element already has an 
        // updated string, and if so, 
        // frees it. This is done in preparation for a call to 
        // MakeNewString(), to prevent
        // leaks from multiple updates calls on the same element 
        // within a single native dialog lifetime.
        private void FreeOldString(TaskDialogNativeMethods.TaskDialogElements element)
        {
            int elementIndex = (int)element;
            if (updatedStrings[elementIndex] != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(updatedStrings[elementIndex]);
                updatedStrings[elementIndex] = IntPtr.Zero;
            }
        }

        // Based on the following defines in WinDef.h and WinUser.h:
        // #define MAKELPARAM(l, h) ((LPARAM)(DWORD)MAKELONG(l, h))
        // #define MAKELONG(a, b) ((LONG)(((WORD)(((DWORD_PTR)(a)) & 0xffff)) | ((DWORD)((WORD)(((DWORD_PTR)(b)) & 0xffff))) << 16))
        private static long MakeLongLParam(int a, int b)
        {
            return (a << 16) + b;
        }

        // Builds the actual configuration that the 
        // NativeTaskDialog (and underlying Win32 API)
        // expects, by parsing the various control lists, 
        // marshaling to the unmanaged heap, etc.
        private void MarshalDialogControlStructs()
        {
            if (settings.Buttons != null && settings.Buttons.Length > 0)
            {
                buttonArray = AllocateAndMarshalButtons(settings.Buttons);
                settings.NativeConfiguration.buttons = buttonArray;
                settings.NativeConfiguration.buttonCount = (uint)settings.Buttons.Length;
            }

            if (settings.RadioButtons != null && settings.RadioButtons.Length > 0)
            {
                radioButtonArray = AllocateAndMarshalButtons(settings.RadioButtons);
                settings.NativeConfiguration.radioButtons = radioButtonArray;
                settings.NativeConfiguration.radioButtonCount = (uint)settings.RadioButtons.Length;
            }
        }

        private static IntPtr AllocateAndMarshalButtons(TaskDialogNativeMethods.TaskDialogButton[] buttons)
        {
            int sizeOfButton = Marshal.SizeOf(typeof(TaskDialogNativeMethods.TaskDialogButton));
            IntPtr initialPtr = Marshal.AllocHGlobal(sizeOfButton * buttons.Length);
            IntPtr currentPtr = initialPtr;

            foreach (TaskDialogNativeMethods.TaskDialogButton button in buttons)
            {
                Marshal.StructureToPtr(button, currentPtr, false);
                currentPtr = new IntPtr(currentPtr.ToInt64() + sizeOfButton);
            }

            return initialPtr;
        }

        #endregion

        #region IDispose Pattern

        private bool disposed;

        // Finalizer and IDisposable implementation.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~NativeTaskDialog()
        {
            Dispose(false);
        }

        // Core disposing logic.
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;

                // Single biggest resource - make sure the dialog 
                // itself has been instructed to close.

                if (ShowState == DialogShowState.Showing)
                {
                    NativeClose(TaskDialogResult.Cancel);
                }

                // Clean up custom allocated strings that were updated
                // while the dialog was showing. Note that the strings
                // passed in the initial TaskDialogIndirect call will
                // be cleaned up automagically by the default 
                // marshalling logic.

                if (updatedStrings != null)
                {
                    for (int i = 0; i < updatedStrings.Length; i++)
                    {
                        if (updatedStrings[i] != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(updatedStrings[i]);
                            updatedStrings[i] = IntPtr.Zero;
                        }
                    }
                }

                // Clean up the button and radio button arrays, if any.
                if (buttonArray != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buttonArray);
                    buttonArray = IntPtr.Zero;
                }
                if (radioButtonArray != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(radioButtonArray);
                    radioButtonArray = IntPtr.Zero;
                }

                if (disposing)
                {
                    // Clean up managed resources - currently there are none
                    // that are interesting.
                }
            }
        }

        #endregion
    }
}