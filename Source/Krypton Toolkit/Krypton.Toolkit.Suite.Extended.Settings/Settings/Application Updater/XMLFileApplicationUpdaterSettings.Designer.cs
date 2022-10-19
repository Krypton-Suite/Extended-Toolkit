﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    internal sealed partial class XMLFileApplicationUpdaterSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static XMLFileApplicationUpdaterSettings defaultInstance = ((XMLFileApplicationUpdaterSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new XMLFileApplicationUpdaterSettings())));
        
        public static XMLFileApplicationUpdaterSettings Default {
            get {
                return defaultInstance;
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
        public bool StartUpdateInstallationUponDownloadCompletion {
            get {
                return ((bool)(this["StartUpdateInstallationUponDownloadCompletion"]));
            }
            set {
                this["StartUpdateInstallationUponDownloadCompletion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime UpdatePackageBuildDate {
            get {
                return ((global::System.DateTime)(this["UpdatePackageBuildDate"]));
            }
            set {
                this["UpdatePackageBuildDate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime UpdatePackageReleaseDate {
            get {
                return ((global::System.DateTime)(this["UpdatePackageReleaseDate"]));
            }
            set {
                this["UpdatePackageReleaseDate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60")]
        public int InstallCountdown {
            get {
                return ((int)(this["InstallCountdown"]));
            }
            set {
                this["InstallCountdown"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public long UpdatePackageFileSize {
            get {
                return ((long)(this["UpdatePackageFileSize"]));
            }
            set {
                this["UpdatePackageFileSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ApplicationIdentifier {
            get {
                return ((string)(this["ApplicationIdentifier"]));
            }
            set {
                this["ApplicationIdentifier"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ChangelogServerURLDownloadLocation {
            get {
                return ((string)(this["ChangelogServerURLDownloadLocation"]));
            }
            set {
                this["ChangelogServerURLDownloadLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CheckSumFileURL {
            get {
                return ((string)(this["CheckSumFileURL"]));
            }
            set {
                this["CheckSumFileURL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string KnowledgebaseArticleNumber {
            get {
                return ((string)(this["KnowledgebaseArticleNumber"]));
            }
            set {
                this["KnowledgebaseArticleNumber"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string KnowledgebaseArticleNumberURL {
            get {
                return ((string)(this["KnowledgebaseArticleNumberURL"]));
            }
            set {
                this["KnowledgebaseArticleNumberURL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MD5CheckSum {
            get {
                return ((string)(this["MD5CheckSum"]));
            }
            set {
                this["MD5CheckSum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RIPEMD160CheckSum {
            get {
                return ((string)(this["RIPEMD160CheckSum"]));
            }
            set {
                this["RIPEMD160CheckSum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SHA1CheckSum {
            get {
                return ((string)(this["SHA1CheckSum"]));
            }
            set {
                this["SHA1CheckSum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SHA256CheckSum {
            get {
                return ((string)(this["SHA256CheckSum"]));
            }
            set {
                this["SHA256CheckSum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SHA384CheckSum {
            get {
                return ((string)(this["SHA384CheckSum"]));
            }
            set {
                this["SHA384CheckSum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SHA512CheckSum {
            get {
                return ((string)(this["SHA512CheckSum"]));
            }
            set {
                this["SHA512CheckSum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ServerApplicatonVersion {
            get {
                return ((string)(this["ServerApplicatonVersion"]));
            }
            set {
                this["ServerApplicatonVersion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpdatePackageType {
            get {
                return ((string)(this["UpdatePackageType"]));
            }
            set {
                this["UpdatePackageType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpdatePackageSeverity {
            get {
                return ((string)(this["UpdatePackageSeverity"]));
            }
            set {
                this["UpdatePackageSeverity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpdatePackageName {
            get {
                return ((string)(this["UpdatePackageName"]));
            }
            set {
                this["UpdatePackageName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpdatePackageServerURLDownloadLocation {
            get {
                return ((string)(this["UpdatePackageServerURLDownloadLocation"]));
            }
            set {
                this["UpdatePackageServerURLDownloadLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpdatePackageBuildString {
            get {
                return ((string)(this["UpdatePackageBuildString"]));
            }
            set {
                this["UpdatePackageBuildString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string VirusTotalScanURL {
            get {
                return ((string)(this["VirusTotalScanURL"]));
            }
            set {
                this["VirusTotalScanURL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpdatePackageDescription {
            get {
                return ((string)(this["UpdatePackageDescription"]));
            }
            set {
                this["UpdatePackageDescription"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string OptionalArguments {
            get {
                return ((string)(this["OptionalArguments"]));
            }
            set {
                this["OptionalArguments"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SpecialisedUpdateIconURL {
            get {
                return ((string)(this["SpecialisedUpdateIconURL"]));
            }
            set {
                this["SpecialisedUpdateIconURL"] = value;
            }
        }
    }
}
