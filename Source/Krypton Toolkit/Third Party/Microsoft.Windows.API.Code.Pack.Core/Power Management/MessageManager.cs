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

using Microsoft.Windows.API.Code.Pack.Core.Resources;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Microsoft.Windows.API.Code.Pack.Core
{
    /// <summary>
    /// This class generates .NET events based on Windows messages.  
    /// The PowerRegWindow class processes the messages from Windows.
    /// </summary>
    internal static class MessageManager
    {
        private static object lockObject = new object();
        private static PowerRegWindow window;

        #region Internal static methods

        /// <summary>
        /// Registers a callback for a power event.
        /// </summary>
        /// <param name="eventId">Guid for the event.</param>
        /// <param name="eventToRegister">Event handler for the specified event.</param>
        internal static void RegisterPowerEvent(Guid eventId, EventHandler eventToRegister)
        {
            EnsureInitialized();
            window.RegisterPowerEvent(eventId, eventToRegister);
        }

        /// <summary>
        /// Unregisters an event handler for a power event.
        /// </summary>
        /// <param name="eventId">Guid for the event.</param>
        /// <param name="eventToUnregister">Event handler to unregister.</param>
        internal static void UnregisterPowerEvent(Guid eventId, EventHandler eventToUnregister)
        {
            EnsureInitialized();
            window.UnregisterPowerEvent(eventId, eventToUnregister);
        }

        #endregion

        /// <summary>
        /// Ensures that the hidden window is initialized and 
        /// listening for messages.
        /// </summary>
        private static void EnsureInitialized()
        {
            lock (lockObject)
            {
                if (window == null)
                {
                    // Create a new hidden window to listen
                    // for power management related window messages.
                    window = new PowerRegWindow();
                }
            }
        }

        /// <summary>
        /// Catch Windows messages and generates events for power specific
        /// messages.
        /// </summary>
        internal class PowerRegWindow : Form
        {
            private Hashtable eventList = new Hashtable();
            private ReaderWriterLock readerWriterLock = new ReaderWriterLock();

            internal PowerRegWindow()
                : base()
            {

            }

            #region Internal Methods

            /// <summary>
            /// Adds an event handler to call when Windows sends 
            /// a message for an event.
            /// </summary>
            /// <param name="eventId">Guid for the event.</param>
            /// <param name="eventToRegister">Event handler for the event.</param>
            internal void RegisterPowerEvent(Guid eventId, EventHandler eventToRegister)
            {
                readerWriterLock.AcquireWriterLock(Timeout.Infinite);
                if (!eventList.Contains(eventId))
                {
                    Power.RegisterPowerSettingNotification(this.Handle, eventId);
                    ArrayList newList = new ArrayList();
                    newList.Add(eventToRegister);
                    eventList.Add(eventId, newList);
                }
                else
                {
                    ArrayList currList = (ArrayList)eventList[eventId];
                    currList.Add(eventToRegister);
                }
                readerWriterLock.ReleaseWriterLock();
            }

            /// <summary>
            /// Removes an event handler.
            /// </summary>
            /// <param name="eventId">Guid for the event.</param>
            /// <param name="eventToUnregister">Event handler to remove.</param>
            /// <exception cref="InvalidOperationException">Cannot unregister 
            /// a function that is not registered.</exception>
            internal void UnregisterPowerEvent(Guid eventId, EventHandler eventToUnregister)
            {
                readerWriterLock.AcquireWriterLock(Timeout.Infinite);
                if (eventList.Contains(eventId))
                {
                    ArrayList currList = (ArrayList)eventList[eventId];
                    currList.Remove(eventToUnregister);
                }
                else
                {
                    throw new InvalidOperationException(LocalizedMessages.MessageManagerHandlerNotRegistered);
                }
                readerWriterLock.ReleaseWriterLock();
            }

            #endregion

            /// <summary>
            /// Executes any registered event handlers.
            /// </summary>
            /// <param name="eventHandlerList">ArrayList of event handlers.</param>            
            private static void ExecuteEvents(ArrayList eventHandlerList)
            {
                foreach (EventHandler handler in eventHandlerList)
                {
                    handler.Invoke(null, new EventArgs());
                }
            }

            /// <summary>
            /// This method is called when a Windows message 
            /// is sent to this window.
            /// The method calls the registered event handlers.
            /// </summary>
            protected override void WndProc(ref Message m)
            {
                // Make sure it is a Power Management message.
                if (m.Msg == PowerManagementNativeMethods.PowerBroadcastMessage &&
                    (int)m.WParam == PowerManagementNativeMethods.PowerSettingChangeMessage)
                {
                    PowerManagementNativeMethods.PowerBroadcastSetting ps =
                         (PowerManagementNativeMethods.PowerBroadcastSetting)Marshal.PtrToStructure(
                             m.LParam, typeof(PowerManagementNativeMethods.PowerBroadcastSetting));

                    IntPtr pData = new IntPtr(m.LParam.ToInt64() + Marshal.SizeOf(ps));
                    Guid currentEvent = ps.PowerSetting;

                    // IsMonitorOn
                    if (ps.PowerSetting == EventManager.MonitorPowerStatus &&
                        ps.DataLength == Marshal.SizeOf(typeof(Int32)))
                    {
                        Int32 monitorStatus = (Int32)Marshal.PtrToStructure(pData, typeof(Int32));
                        PowerManager.IsMonitorOn = monitorStatus != 0;
                        EventManager.monitorOnReset.Set();
                    }

                    if (!EventManager.IsMessageCaught(currentEvent))
                    {
                        ExecuteEvents((ArrayList)eventList[currentEvent]);
                    }
                }
                else
                    base.WndProc(ref m);

            }

        }
    }
}