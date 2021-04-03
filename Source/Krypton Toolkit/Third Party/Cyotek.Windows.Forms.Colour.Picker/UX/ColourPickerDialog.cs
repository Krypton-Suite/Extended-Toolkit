using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    [DefaultEvent("PreviewColourChanged"), DefaultProperty("Colour")]
    public class ColourPickerDialog : KryptonForm
    {
        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.colourWheel1 = new Cyotek.Windows.Forms.Colour.Picker.ColourWheel();
            this.colourEditor1 = new Cyotek.Windows.Forms.Colour.Picker.ColourEditor();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 300);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(619, 44);
            this.kpnlButtons.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(421, 7);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(517, 7);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.colourEditor1);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.colourWheel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(619, 297);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton1.Location = new System.Drawing.Point(12, 138);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton1.TabIndex = 3;
            this.kryptonButton1.Values.Image = global::Cyotek.Windows.Forms.Colour.Picker.Properties.Resources.palette_load;
            this.kryptonButton1.Values.Text = "";
            // 
            // colourWheel1
            // 
            this.colourWheel1.Location = new System.Drawing.Point(12, 12);
            this.colourWheel1.Name = "colourWheel1";
            this.colourWheel1.Size = new System.Drawing.Size(129, 120);
            this.colourWheel1.TabIndex = 0;
            // 
            // colourEditor1
            // 
            this.colourEditor1.Location = new System.Drawing.Point(166, 12);
            this.colourEditor1.Name = "colourEditor1";
            this.colourEditor1.Size = new System.Drawing.Size(211, 266);
            this.colourEditor1.TabIndex = 3;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton2.Location = new System.Drawing.Point(40, 138);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton2.TabIndex = 4;
            this.kryptonButton2.Values.Image = global::Cyotek.Windows.Forms.Colour.Picker.Properties.Resources.palette_save;
            this.kryptonButton2.Values.Text = "";
            // 
            // ColourPickerDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(619, 344);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourPickerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #region Constants

        private static readonly object _eventPreviewColourChanged = new object();

        #endregion

        #region Fields

        private Brush _textureBrush;
        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kryptonButton1;
        private ColourWheel colourWheel1;
        private ColourEditor colourEditor1;
        private KryptonButton kryptonButton2;
        private Color color;
        #endregion

        #region Properties
        public Color Colour
        {
            get => color; // { return colorEditorManager.Colour; }
            set => color = value; // { colorEditorManager.Colour = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAlphaChannel { get; set; }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler PreviewColourChanged
        {
            add { this.Events.AddHandler(_eventPreviewColourChanged, value); }
            remove { this.Events.RemoveHandler(_eventPreviewColourChanged, value); }
        }

        #endregion

        #region Constructors

        public ColourPickerDialog()
        {
            this.InitializeComponent();
            this.ShowAlphaChannel = true;
            this.Font = SystemFonts.DialogFont;
        }

        #endregion
    }
}