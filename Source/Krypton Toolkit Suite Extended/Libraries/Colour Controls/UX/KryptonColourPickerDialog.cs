using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonColourPickerDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel2;
        private Base.KryptonOKDialogButton kdbtnOK;
        private System.Windows.Forms.Panel panel1;
        private Base.CircularPictureBox cpbColourPreview;
        private Base.KryptonCancelDialogButton kdbtnCancel;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kdbtnCancel = new Krypton.Toolkit.Extended.Base.KryptonCancelDialogButton();
            this.kdbtnOK = new Krypton.Toolkit.Extended.Base.KryptonOKDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cpbColourPreview = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kdbtnOK);
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 536);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(730, 49);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.cpbColourPreview);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(730, 536);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(628, 12);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.ParentWindow = this;
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 2;
            this.kdbtnCancel.Values.Text = "C&ancel";
            // 
            // kdbtnOK
            // 
            this.kdbtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kdbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbtnOK.Location = new System.Drawing.Point(532, 12);
            this.kdbtnOK.Name = "kdbtnOK";
            this.kdbtnOK.ParentWindow = this;
            this.kdbtnOK.Size = new System.Drawing.Size(90, 25);
            this.kdbtnOK.TabIndex = 2;
            this.kdbtnOK.Values.Text = "&OK";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 533);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 3);
            this.panel1.TabIndex = 2;
            // 
            // cpbColourPreview
            // 
            this.cpbColourPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpbColourPreview.BackColor = System.Drawing.SystemColors.Control;
            this.cpbColourPreview.Location = new System.Drawing.Point(590, 12);
            this.cpbColourPreview.Name = "cpbColourPreview";
            this.cpbColourPreview.Size = new System.Drawing.Size(128, 128);
            this.cpbColourPreview.TabIndex = 3;
            this.cpbColourPreview.TabStop = false;
            this.cpbColourPreview.ToolTipValues = null;
            // 
            // KryptonColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(730, 585);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonColourPickerDialog";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _colour;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set { _colour = value; } }
        #endregion
    }
}