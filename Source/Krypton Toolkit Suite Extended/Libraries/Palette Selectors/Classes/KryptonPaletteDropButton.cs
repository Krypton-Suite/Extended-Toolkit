#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public partial class KryptonPaletteDropButton : KryptonDropButton
    {
        #region Design Code
        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer _components;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new System.ComponentModel.Container();
            this.OverrideFocus.Content.DrawFocus = InheritBool.False;
            this.Values.Image = Properties.Resources.palette1;
            this.Values.Text = "Palette";
        }

        #endregion
        #endregion

        public KryptonPaletteDropButton()
        {
            InitializeComponent();
        }

        private KryptonPaletteContextMenu _contextMenu = new KryptonPaletteContextMenu();

        [Category("Appearance")]
        [DefaultValue("Palette")]
        [Description("Controls the text of the drop down button.")]
        public string ButtonText
        {
            get { return Values.Text; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Values.Text = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue(null)]
        [Description("The context menu to show when the user clicks the drop down.")]
        public override KryptonContextMenu KryptonContextMenu
        {
            get { return _contextMenu; }
            set
            {
                if (value == null)
                {
                    _contextMenu = new KryptonPaletteContextMenu();
                    return;
                }
                if (typeof(KryptonPaletteContextMenu) != value.GetType())
                {
                    throw new ArgumentException("Only instances of KryptonPaletteContextMenu can be assigned.");
                }
                _contextMenu = (KryptonPaletteContextMenu)value;
            }
        }

        [Category("Behavior")]
        [Description("Connects the palette selector to the KryptonManager of the parent form.")]
        [DefaultValue(null)]
        public KryptonManager KryptonManager
        {
            get
            {
                return KryptonContextMenu == null ? null : _contextMenu.KryptonManager;
            }
            set
            {
                if (KryptonContextMenu == null) KryptonContextMenu = new KryptonPaletteContextMenu();
                _contextMenu.KryptonManager = value;
            }
        }

        [Browsable(false)]
        public new string Text
        {
            get { return Values.Text; }
            set { Values.Text = value; }
        }
    }
}