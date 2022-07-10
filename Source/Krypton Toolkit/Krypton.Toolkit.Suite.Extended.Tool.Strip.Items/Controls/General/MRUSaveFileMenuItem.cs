﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolboxItem(false), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
    public class MRUSaveFileMenuItem : ToolStripMenuItem
    {
        #region Instance Fields

        private bool _useSystemDialogs;

        private Control _outputControl = null;

        private string _defaultText = "Sa&ve";

        private string _applicationName;

        private string _saveFileDialogTitle = "Save:";

        private string _rawFilterDisplayName;

        private string _rawExtensionList;

        private string _standardDialogFilter;

        private string _startingDirectory;

        private MRUMenuItem _parentMruMenuItem;

        private MostRecentlyUsedFileManager _recentlyUsedFileManager = null;

        #endregion

        #region Public
        /// <summary>Gets or sets a value indicating whether to use the native system dialogs over the Windows API CodePack types.</summary>
        /// <value> <c>true</c> if [use system dialogs]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Use the native system dialogs over the Windows API CodePack types.")]
        public bool UseSystemDialogs { get => _useSystemDialogs; set => _useSystemDialogs = value; }

        /// <summary>Gets or sets the control to load the file content text into.</summary>
        /// <value>The control to load the file content text into.</value>
        [DefaultValue(null), Description("The control to load the file content text into.")]
        public Control OutputControl { get => _outputControl; set => _outputControl = value; }

        /// <summary>Gets or sets the text displayed on the tool strip menu item.</summary>
        /// <value>The text displayed on the tool strip menu item.</value>
        [DefaultValue("Sa&ve"), Description("The text displayed on the tool strip menu item.")]
        public string DefaultText { get => _defaultText; set => _defaultText = value; }

        /// <summary>Gets or sets the name of the name of your application. This is used to store the MRU list in the Windows registry.</summary>
        /// <value>The name of the application.</value>
        [DefaultValue(null), Description("The name of your application. This is used to store the MRU list in the Windows registry.")]
        public string ApplicationName { get => _applicationName; set => _applicationName = value; }

        /// <summary>Gets or sets the save file dialog title.</summary>
        /// <value>The save file dialog title.</value>
        [DefaultValue("Save:"), Description("The title of the save file dialog.")]
        public string SaveFileDialogTitle { get => _saveFileDialogTitle; set => _saveFileDialogTitle = value; }

        /// <summary>Gets or sets the display name of the raw filter. Please refer to <see cref="CommonFileDialogFilter"/> documentation for more information.</summary>
        /// <value>The display name of the raw filter.</value>
        [DefaultValue(null), Description("The display name of the raw filter.")]
        public string RawFilterDisplayName { get => _rawFilterDisplayName; set => _rawFilterDisplayName = value; }

        /// <summary>Gets or sets the raw extension list. Please refer to <see cref="CommonFileDialogFilter"/> documentation for more information.</summary>
        /// <value>The raw extension list.</value>
        [DefaultValue(null), Description("The raw extension list.")]
        public string RawExtensionList { get => _rawExtensionList; set => _rawExtensionList = value; }

        [DefaultValue(null), Description("")]
        public string StandardDialogFilter { get => _standardDialogFilter; set => _standardDialogFilter = value; }

        /// <summary>Gets or sets the starting directory of the save file dialog.</summary>
        /// <value>The starting directory of the save file dialog.</value>
        [DefaultValue(Environment.SpecialFolder.MyDocuments), Description("The starting directory of the save file dialog.")]
        public string StartingDirectory { get => _startingDirectory; set => _startingDirectory = value; }

        /// <summary>Gets or sets the parent MRU menu item.</summary>
        /// <value>The parent MRU menu item.</value>
        [DefaultValue(null), Description("The parent MRU menu item.")]
        public MRUMenuItem ParentMRUMenuItem { get => _parentMruMenuItem; set => _parentMruMenuItem = value; }

        #endregion
    }
}
