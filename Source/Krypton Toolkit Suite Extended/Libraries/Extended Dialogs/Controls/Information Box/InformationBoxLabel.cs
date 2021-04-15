#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Glass label
    /// </summary>
    [Category("Glass Components")]
    [DefaultProperty("Text")]
    [Description("Label with glass look and feel")]
    [ToolboxBitmap(typeof(Label))]
    public partial class InformationBoxLabel : Panel
    {
        #region Design Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.labelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.ForeColor = System.Drawing.Color.White;
            this.labelText.Location = new System.Drawing.Point(3, 6);
            this.labelText.Margin = new System.Windows.Forms.Padding(0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(205, 26);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Label de test";
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelText_MouseDown);
            this.labelText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelText_MouseMove);
            this.labelText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LabelText_MouseUp);
            // 
            // Label
            // 
            this.Controls.Add(this.labelText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(16, 16);
            this.Size = new System.Drawing.Size(209, 41);
            this.ForeColorChanged += new System.EventHandler(this.OnNewForeColor);
            this.EnabledChanged += new System.EventHandler(this.OnEnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        #endregion

        #region Attributes

        /// <summary>
        /// Fore color used for the disabled state
        /// </summary>
        private Color disabledForeColor = Color.Gray;

        /// <summary>
        /// Text alignment
        /// </summary>
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        public InformationBoxLabel()
        {
            this.InitializeComponent();
            this.DoubleBuffered = true;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the text color when the label is disabled
        /// </summary>
        /// <value>The color of the disabled fore.</value>
        [Category("Appearance"), Description("Defines the text color when the label is disabled")]
        public Color DisabledForeColor
        {
            get
            {
                return this.disabledForeColor;
            }

            set
            {
                this.disabledForeColor = value;
                this.RefreshLabelColor();
            }
        }

        /// <summary>
        /// Gets or sets the alignment of the text
        /// </summary>
        /// <value>The text align.</value>
        [Category("Appearance"), Description("Defines the alignment of the text")]
        public ContentAlignment TextAlign
        {
            get
            {
                return this.textAlign;
            }

            set
            {
                this.textAlign = value;
                this.labelText.TextAlign = this.textAlign;
                this.labelText.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the label text
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.String"></see>.</returns>
        [Category("Appearance"), Description("Defines the text of the label"), Browsable(true)]
        public override string Text
        {
            get
            {
                return this.labelText.Text;
            }

            set
            {
                this.labelText.Text = value;
                this.labelText.Invalidate();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the text forecolor
        /// </summary>
        private void RefreshLabelColor()
        {
            this.labelText.ForeColor = Enabled ? ForeColor : this.disabledForeColor;
            this.labelText.Invalidate();
        }

        #endregion Methods

        #region Event handlers

        /// <summary>
        /// When forecolor is changed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnNewForeColor(object sender, EventArgs e)
        {
            this.RefreshLabelColor();
        }

        /// <summary>
        /// When the 'Enabled' property is changed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnEnabledChanged(object sender, EventArgs e)
        {
            this.RefreshLabelColor();
            this.Invalidate();
        }

        #endregion Event handlers

        #region Event Copy

        /// <summary>
        /// Handles the MouseDown event of the labelText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LabelText_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        /// <summary>
        /// Handles the MouseMove event of the labelText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LabelText_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        /// <summary>
        /// Handles the MouseUp event of the labelText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LabelText_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        #endregion Event Copy
    }
}