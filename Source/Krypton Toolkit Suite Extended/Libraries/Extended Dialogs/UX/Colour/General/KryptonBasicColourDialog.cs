#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Drawing.Suite;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [DefaultEvent("SelectedColourChanged"), DefaultProperty("Colour")]
    public class KryptonBasicColourDialog : KryptonForm
    {
        #region Designer Code
        private KryptonAlphaValueLabel kryptonAlphaValueLabel1;
        private KryptonOKDialogButton kbtnOk;
        private KryptonCancelDialogButton kbtnCancel;
        private KryptonPanel kryptonPanel1;
        private KryptonBlueValueLabel klblBlueValue;
        private KryptonRedValueLabel klblRedValue;
        private CircularPictureBox cpbxColourPreview;
        private ColourWheelControl cwColourPicker;
        private System.Windows.Forms.Panel panel1;
        private ColourHexadecimalTextBox txtHexColour;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonPanel kpnlButtons;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonBasicColourDialog));
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.txtHexColour = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourHexadecimalTextBox();
            this.kryptonAlphaValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonAlphaValueLabel();
            this.kbtnOk = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblBlueValue = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonBlueValueLabel();
            this.klblRedValue = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonRedValueLabel();
            this.cpbxColourPreview = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cwColourPicker = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourWheelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonGreenValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonGreenValueLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.txtHexColour);
            this.kpnlButtons.Controls.Add(this.kryptonAlphaValueLabel1);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 200);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(506, 44);
            this.kpnlButtons.TabIndex = 0;
            // 
            // txtHexColour
            // 
            this.txtHexColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHexColour.Colour = System.Drawing.Color.Empty;
            this.txtHexColour.Hint = "000000";
            this.txtHexColour.Location = new System.Drawing.Point(172, 9);
            this.txtHexColour.MaxLength = 6;
            this.txtHexColour.Name = "txtHexColour";
            this.txtHexColour.Size = new System.Drawing.Size(100, 23);
            this.txtHexColour.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.txtHexColour.TabIndex = 3;
            this.txtHexColour.TextChanged += new System.EventHandler(this.txtHexColour_TextChanged);
            // 
            // kryptonAlphaValueLabel1
            // 
            this.kryptonAlphaValueLabel1.AlphaValue = 255;
            this.kryptonAlphaValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonAlphaValueLabel1.ExtraText = "Alpha Value";
            this.kryptonAlphaValueLabel1.Location = new System.Drawing.Point(12, 4);
            this.kryptonAlphaValueLabel1.Name = "kryptonAlphaValueLabel1";
            this.kryptonAlphaValueLabel1.ShowColon = false;
            this.kryptonAlphaValueLabel1.ShowCurrentColourValue = false;
            this.kryptonAlphaValueLabel1.Size = new System.Drawing.Size(110, 26);
            this.kryptonAlphaValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.TabIndex = 3;
            this.kryptonAlphaValueLabel1.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.Values.Text = "Alpha Value:";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(308, 7);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(404, 7);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGreenValueLabel1);
            this.kryptonPanel1.Controls.Add(this.klblBlueValue);
            this.kryptonPanel1.Controls.Add(this.klblRedValue);
            this.kryptonPanel1.Controls.Add(this.cpbxColourPreview);
            this.kryptonPanel1.Controls.Add(this.cwColourPicker);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(506, 200);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // klblBlueValue
            // 
            this.klblBlueValue.BlueValue = 255;
            this.klblBlueValue.ExtraText = "Blue";
            this.klblBlueValue.Location = new System.Drawing.Point(212, 111);
            this.klblBlueValue.Name = "klblBlueValue";
            this.klblBlueValue.ShowColon = false;
            this.klblBlueValue.ShowCurrentColourValue = true;
            this.klblBlueValue.Size = new System.Drawing.Size(79, 21);
            this.klblBlueValue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlueValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlueValue.TabIndex = 3;
            this.klblBlueValue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlueValue.UseAccessibleUI = false;
            this.klblBlueValue.Values.Text = "Blue: 255";
            // 
            // klblRedValue
            // 
            this.klblRedValue.ExtraText = "Red";
            this.klblRedValue.Location = new System.Drawing.Point(212, 49);
            this.klblRedValue.Name = "klblRedValue";
            this.klblRedValue.RedValue = 255;
            this.klblRedValue.ShowColon = false;
            this.klblRedValue.ShowCurrentColourValue = true;
            this.klblRedValue.Size = new System.Drawing.Size(76, 21);
            this.klblRedValue.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRedValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRedValue.TabIndex = 2;
            this.klblRedValue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRedValue.UseAccessibleUI = false;
            this.klblRedValue.Values.Text = "Red: 255";
            // 
            // cpbxColourPreview
            // 
            this.cpbxColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbxColourPreview.Location = new System.Drawing.Point(331, 12);
            this.cpbxColourPreview.Name = "cpbxColourPreview";
            this.cpbxColourPreview.Size = new System.Drawing.Size(163, 163);
            this.cpbxColourPreview.TabIndex = 1;
            this.cpbxColourPreview.TabStop = false;
            // 
            // cwColourPicker
            // 
            this.cwColourPicker.BackColor = System.Drawing.Color.Transparent;
            this.cwColourPicker.Location = new System.Drawing.Point(12, 12);
            this.cwColourPicker.Name = "cwColourPicker";
            this.cwColourPicker.Size = new System.Drawing.Size(163, 163);
            this.cwColourPicker.TabIndex = 0;
            this.cwColourPicker.ColourChanged += new System.EventHandler(this.cwColourPicker_ColourChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.ExtraText = "Green";
            this.kryptonGreenValueLabel1.GreenValue = 0;
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(212, 80);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.ShowColon = false;
            this.kryptonGreenValueLabel1.ShowCurrentColourValue = true;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(74, 21);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.TabIndex = 3;
            this.kryptonGreenValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.UseAccessibleUI = false;
            this.kryptonGreenValueLabel1.Values.Text = "Green: 0";
            // 
            // KryptonBasicColourDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(506, 244);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonBasicColourDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Colour Dialog";
            this.Load += new System.EventHandler(this.KryptonBasicColourDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColourPreview)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants
        private static readonly object _eventSelectedColourChanged = new object();
        #endregion

        #region Events
        [Category("Property Changed")]
        public event EventHandler SelectedColourChanged { add => Events.AddHandler(_eventSelectedColourChanged, value); remove => Events.RemoveHandler(_eventSelectedColourChanged, value); }
        #endregion

        #region Variables
        private Color _colour;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set { _colour = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonBasicColourDialog()
        {
            Invalidate();

            Colour = Color.Empty;
        }
        #endregion

        #region Virtuals
        protected virtual void OnSelectedColourChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventSelectedColourChanged];

            handler?.Invoke(this, e);
        }
        #endregion

        private void KryptonBasicColourDialog_Load(object sender, EventArgs e)
        {

        }

        private void cwColourPicker_ColourChanged(object sender, EventArgs e)
        {

        }

        private void txtHexColour_TextChanged(object sender, EventArgs e)
        {

        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}