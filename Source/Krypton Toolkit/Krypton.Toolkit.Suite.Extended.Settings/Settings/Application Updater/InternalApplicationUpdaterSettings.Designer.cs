﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Krypton.Toolkit.Suite.Extended.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
    internal sealed partial class InternalApplicationUpdaterSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static InternalApplicationUpdaterSettings defaultInstance = ((InternalApplicationUpdaterSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new InternalApplicationUpdaterSettings())));
        
        public static InternalApplicationUpdaterSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AlwaysUseUACElevation {
            get {
                return ((bool)(this["AlwaysUseUACElevation"]));
            }
            set {
                this["AlwaysUseUACElevation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool BetaFlag {
            get {
                return ((bool)(this["BetaFlag"]));
            }
            set {
                this["BetaFlag"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DisableAutomaticUpdates {
            get {
                return ((bool)(this["DisableAutomaticUpdates"]));
            }
            set {
                this["DisableAutomaticUpdates"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime DateOfLastCheck {
            get {
                return ((global::System.DateTime)(this["DateOfLastCheck"]));
            }
            set {
                this["DateOfLastCheck"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime DateOfNextCheck {
            get {
                return ((global::System.DateTime)(this["DateOfNextCheck"]));
            }
            set {
                this["DateOfNextCheck"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime DateOfLastUpdateInstallation {
            get {
                return ((global::System.DateTime)(this["DateOfLastUpdateInstallation"]));
            }
            set {
                this["DateOfLastUpdateInstallation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ApplicationName {
            get {
                return ((string)(this["ApplicationName"]));
            }
            set {
                this["ApplicationName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ApplicationIdentification {
            get {
                return ((string)(this["ApplicationIdentification"]));
            }
            set {
                this["ApplicationIdentification"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ApplicationPackageServerURL {
            get {
                return ((string)(this["ApplicationPackageServerURL"]));
            }
            set {
                this["ApplicationPackageServerURL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DestinationDownloadPath {
            get {
                return ((string)(this["DestinationDownloadPath"]));
            }
            set {
                this["DestinationDownloadPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string VersionXMLFileURL {
            get {
                return ((string)(this["VersionXMLFileURL"]));
            }
            set {
                this["VersionXMLFileURL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CurrentApplicationVersion {
            get {
                return ((string)(this["CurrentApplicationVersion"]));
            }
            set {
                this["CurrentApplicationVersion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ServerVersion {
            get {
                return ((string)(this["ServerVersion"]));
            }
            set {
                this["ServerVersion"] = value;
            }
        }
    }
}