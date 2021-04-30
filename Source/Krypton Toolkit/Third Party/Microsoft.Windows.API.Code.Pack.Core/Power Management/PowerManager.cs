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
using System.ComponentModel;

namespace Microsoft.Windows.API.Code.Pack.Core
{
    /// <summary>
    /// Enables registration for 
    /// power-related event notifications and provides access to power settings.
    /// </summary>
    public static class PowerManager
    {
        private static bool? isMonitorOn;
        private static bool monitorRequired;
        private static bool requestBlockSleep;

        private static readonly object monitoronlock = new object();


        #region Notifications

        /// <summary>
        /// Raised each time the active power scheme changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler PowerPersonalityChanged
        {
            add
            {


                MessageManager.RegisterPowerEvent(
                    EventManager.PowerPersonalityChange, value);
            }

            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(
                    EventManager.PowerPersonalityChange, value);
            }
        }

        /// <summary>
        /// Raised when the power source changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler PowerSourceChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(
                    EventManager.PowerSourceChange, value);
            }

            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(
                    EventManager.PowerSourceChange, value);
            }
        }

        /// <summary>
        /// Raised when the remaining battery life changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler BatteryLifePercentChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(
                    EventManager.BatteryCapacityChange, value);
            }
            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(
                    EventManager.BatteryCapacityChange, value);
            }
        }

        /// <summary>
        /// Raised when the monitor status changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler IsMonitorOnChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(
                    EventManager.MonitorPowerStatus, value);
            }
            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(
                    EventManager.MonitorPowerStatus, value);
            }
        }

        /// <summary>
        /// Raised when the system will not be moving into an idle 
        /// state in the near future so applications should
        /// perform any tasks that 
        /// would otherwise prevent the computer from entering an idle state. 
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler SystemBusyChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(
                    EventManager.BackgroundTaskNotification, value);
            }
            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(
                    EventManager.BackgroundTaskNotification, value);
            }
        }
        #endregion

        /// <summary>
        /// Gets a snapshot of the current battery state.
        /// </summary>
        /// <returns>A <see cref="BatteryState"/> instance that represents 
        /// the state of the battery at the time this method was called.</returns>
        /// <exception cref="System.InvalidOperationException">The system does not have a battery.</exception>
        /// <exception cref="System.PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>        
        public static BatteryState GetCurrentBatteryState()
        {
            CoreHelpers.ThrowIfNotXP();
            return new BatteryState();
        }

        #region Power System Properties

        /// <summary>
        /// Gets or sets a value that indicates whether the monitor is 
        /// set to remain active.  
        /// </summary>
        /// <exception cref="T:System.PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have sufficient privileges to set this property.
        /// </exception>
        /// <remarks>This information is typically used by applications
        /// that display information but do not require 
        /// user interaction. For example, video playback applications.</remarks>
        /// <permission cref="T:System.Security.Permissions.SecurityPermission"> to set this property. Demand value: <see cref="F:System.Security.Permissions.SecurityAction.Demand"/>; Named Permission Sets: <b>FullTrust</b>.</permission>
        /// <value>A <see cref="System.Boolean"/> value. <b>True</b> if the monitor
        /// is required to remain on.</value>
        public static bool MonitorRequired
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();
                return monitorRequired;
            }
            [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            set
            {
                CoreHelpers.ThrowIfNotXP();

                if (value)
                {
                    PowerManager.SetThreadExecutionState(ExecutionStates.Continuous | ExecutionStates.DisplayRequired);
                }
                else
                {
                    PowerManager.SetThreadExecutionState(ExecutionStates.Continuous);
                }

                monitorRequired = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the system 
        /// is required to be in the working state.
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        /// <exception cref="System.Security.SecurityException">The caller does not have sufficient privileges to set this property.
        /// </exception>
        /// <permission cref="System.Security.Permissions.SecurityPermission"> to set this property. Demand value: <see cref="F:System.Security.Permissions.SecurityAction.Demand"/>; Named Permission Sets: <b>FullTrust</b>.</permission>
        /// <value>A <see cref="System.Boolean"/> value.</value>
        public static bool RequestBlockSleep
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();

                return requestBlockSleep;
            }
            [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            set
            {
                CoreHelpers.ThrowIfNotXP();

                if (value)
                    PowerManager.SetThreadExecutionState(ExecutionStates.Continuous | ExecutionStates.SystemRequired);
                else
                    PowerManager.SetThreadExecutionState(ExecutionStates.Continuous);

                requestBlockSleep = value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether a battery is present.  
        /// The battery can be a short term battery.
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        /// <value>A <see cref="System.Boolean"/> value.</value>
        public static bool IsBatteryPresent
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();

                return Power.GetSystemBatteryState().BatteryPresent;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the battery is a short term battery. 
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        /// <value>A <see cref="System.Boolean"/> value.</value>
        public static bool IsBatteryShortTerm
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();
                return Power.GetSystemPowerCapabilities().BatteriesAreShortTerm;
            }
        }

        /// <summary>
        /// Gets a value that indicates a UPS is present to prevent 
        /// sudden loss of power.
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        /// <value>A <see cref="System.Boolean"/> value.</value>
        public static bool IsUpsPresent
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();

                // Because the native method doesn't return the correct value for .UpsPresent,
                // use .BatteriesAreShortTerm and .SystemBatteriesPresent to check for UPS
                PowerManagementNativeMethods.SystemPowerCapabilities batt = Power.GetSystemPowerCapabilities();

                return (batt.BatteriesAreShortTerm && batt.SystemBatteriesPresent);
            }
        }

        /// <summary>
        /// Gets a value that indicates the current power scheme.  
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        /// <value>A <see cref="PowerPersonality"/> value.</value>
        public static PowerPersonality PowerPersonality
        {
            get
            {
                Guid guid;
                PowerManagementNativeMethods.PowerGetActiveScheme(IntPtr.Zero, out guid);

                try
                {
                    return PowerPersonalityGuids.GuidToEnum(guid);
                }
                finally
                {
                    CoreNativeMethods.LocalFree(ref guid);
                }
            }
        }



        /// <summary>
        /// Gets a value that indicates the remaining battery life 
        /// (as a percentage of the full battery charge). 
        /// This value is in the range 0-100, 
        /// where 0 is not charged and 100 is fully charged.  
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The system does not have a battery.</exception>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        /// <value>An <see cref="System.Int32"/> value.</value>
        public static int BatteryLifePercent
        {
            get
            {
                // Because of the way this value is being calculated, it should not be limited to granularity
                // as the data from the event (old way) was.
                CoreHelpers.ThrowIfNotVista();
                if (!Power.GetSystemBatteryState().BatteryPresent)
                    throw new InvalidOperationException(LocalizedMessages.PowerManagerBatteryNotPresent);

                var state = Power.GetSystemBatteryState();

                int percent = (int)Math.Round(((double)state.RemainingCapacity / state.MaxCapacity * 100), 0);
                return percent;
            }
        }

        /// <summary>
        /// Gets a value that indictates whether the monitor is on. 
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        /// <value>A <see cref="System.Boolean"/> value.</value>
        public static bool IsMonitorOn
        {
            get
            {
                CoreHelpers.ThrowIfNotVista();

                lock (monitoronlock)
                {
                    if (isMonitorOn == null)
                    {
                        EventHandler dummy = delegate (object sender, EventArgs args) { };
                        IsMonitorOnChanged += dummy;
                        // Wait until Windows updates the power source 
                        // (through RegisterPowerSettingNotification)
                        EventManager.monitorOnReset.WaitOne();
                    }
                }

                return (bool)isMonitorOn;
            }
            internal set { isMonitorOn = value; }
        }

        /// <summary>
        /// Gets the current power source.  
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        /// <value>A <see cref="PowerSource"/> value.</value>
        public static PowerSource PowerSource
        {
            get
            {
                CoreHelpers.ThrowIfNotVista();

                if (IsUpsPresent)
                {
                    return PowerSource.Ups;
                }

                if (!IsBatteryPresent || GetCurrentBatteryState().ACOnline)
                {
                    return PowerSource.AC;
                }

                return PowerSource.Battery;
            }
        }
        #endregion

        /// <summary>
        /// Allows an application to inform the system that it 
        /// is in use, thereby preventing the system from entering 
        /// the sleeping power state or turning off the display 
        /// while the application is running.
        /// </summary>
        /// <param name="executionStateOptions">The thread's execution requirements.</param>
        /// <exception cref="Win32Exception">Thrown if the SetThreadExecutionState call fails.</exception>
        public static void SetThreadExecutionState(ExecutionStates executionStateOptions)
        {
            ExecutionStates ret = PowerManagementNativeMethods.SetThreadExecutionState(executionStateOptions);
            if (ret == ExecutionStates.None)
            {
                throw new Win32Exception(LocalizedMessages.PowerExecutionStateFailed);
            }
        }

    }
}