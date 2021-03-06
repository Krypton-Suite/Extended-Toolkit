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

namespace Krypton.Toolkit.Suite.Extended.Settings
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
    internal sealed partial class GlobalBooleanSettings : global::System.Configuration.ApplicationSettingsBase
    {

        private static GlobalBooleanSettings defaultInstance = ((GlobalBooleanSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new GlobalBooleanSettings())));

        public static GlobalBooleanSettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutomaticallyUpdateColours
        {
            get
            {
                return ((bool)(this["AutomaticallyUpdateColours"]));
            }
            set
            {
                this["AutomaticallyUpdateColours"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DisableListItem
        {
            get
            {
                return ((bool)(this["DisableListItem"]));
            }
            set
            {
                this["DisableListItem"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool HidePropertiesPane
        {
            get
            {
                return ((bool)(this["HidePropertiesPane"]));
            }
            set
            {
                this["HidePropertiesPane"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsInBetaMode
        {
            get
            {
                return ((bool)(this["IsInBetaMode"]));
            }
            set
            {
                this["IsInBetaMode"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsInDeveloperMode
        {
            get
            {
                return ((bool)(this["IsInDeveloperMode"]));
            }
            set
            {
                this["IsInDeveloperMode"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool LoadColoursOnOpenPalette
        {
            get
            {
                return ((bool)(this["LoadColoursOnOpenPalette"]));
            }
            set
            {
                this["LoadColoursOnOpenPalette"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowBuildTag
        {
            get
            {
                return ((bool)(this["ShowBuildTag"]));
            }
            set
            {
                this["ShowBuildTag"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseCircularPictureBoxes
        {
            get
            {
                return ((bool)(this["UseCircularPictureBoxes"]));
            }
            set
            {
                this["UseCircularPictureBoxes"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UsePromptFeedback
        {
            get
            {
                return ((bool)(this["UsePromptFeedback"]));
            }
            set
            {
                this["UsePromptFeedback"] = value;
            }
        }
    }
}
