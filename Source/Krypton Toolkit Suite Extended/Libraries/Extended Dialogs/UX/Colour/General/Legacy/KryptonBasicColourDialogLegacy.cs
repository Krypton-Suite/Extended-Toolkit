using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Drawing.Suite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonBasicColourDialogLegacy : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonPanel kryptonPanel2;
        private ColourWheelControl cwColourSelector;
        private CircularPictureBox cpbSelectedColour;
        private KryptonBlueValueLabel kbvlBlue;
        private KryptonRedValueLabel krvlRed;
        private System.Windows.Forms.Panel panel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cwColourSelector = new ColourWheelControl();
            this.krvlRed = new KryptonRedValueLabel();
            this.kbvlBlue = new KryptonBlueValueLabel();
            this.cpbSelectedColour = new CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 433);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(767, 48);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(561, 8);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(94, 28);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.KbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(661, 8);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(94, 28);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.KbtnCancel_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.cpbSelectedColour);
            this.kryptonPanel2.Controls.Add(this.kbvlBlue);
            this.kryptonPanel2.Controls.Add(this.krvlRed);
            this.kryptonPanel2.Controls.Add(this.cwColourSelector);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(767, 433);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 3);
            this.panel1.TabIndex = 2;
            // 
            // cwColourSelector
            // 
            this.cwColourSelector.BackColor = System.Drawing.Color.Transparent;
            this.cwColourSelector.Location = new System.Drawing.Point(12, 12);
            this.cwColourSelector.Name = "cwColourSelector";
            this.cwColourSelector.Size = new System.Drawing.Size(337, 352);
            this.cwColourSelector.TabIndex = 3;
            this.cwColourSelector.ColourChanged += new System.EventHandler(this.CwColourSelector_ColourChanged);
            // 
            // krvlRed
            // 
            this.krvlRed.Location = new System.Drawing.Point(150, 384);
            this.krvlRed.Name = "krvlRed";
            this.krvlRed.RedValue = 255;
            this.krvlRed.Size = new System.Drawing.Size(94, 26);
            this.krvlRed.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.krvlRed.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.krvlRed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.krvlRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.krvlRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.krvlRed.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.krvlRed.TabIndex = 3;
            this.krvlRed.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.krvlRed.Values.Text = "Red Value: ";
            // 
            // kbvlBlue
            // 
            this.kbvlBlue.Location = new System.Drawing.Point(504, 384);
            this.kbvlBlue.Name = "kbvlBlue";
            this.kbvlBlue.BlueValue = 255;
            this.kbvlBlue.Size = new System.Drawing.Size(98, 26);
            this.kbvlBlue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kbvlBlue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kbvlBlue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kbvlBlue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kbvlBlue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kbvlBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kbvlBlue.TabIndex = 3;
            this.kbvlBlue.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kbvlBlue.Values.Text = "Blue Value: ";
            // 
            // cpbSelectedColour
            // 
            this.cpbSelectedColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbSelectedColour.Location = new System.Drawing.Point(410, 12);
            this.cpbSelectedColour.Name = "cpbSelectedColour";
            this.cpbSelectedColour.Size = new System.Drawing.Size(337, 352);
            this.cpbSelectedColour.TabIndex = 5;
            this.cpbSelectedColour.TabStop = false;
            this.cpbSelectedColour.MouseEnter += new System.EventHandler(this.CpbSelectedColour_MouseEnter);
            // 
            // KryptonBasicColourDialog
            // 
            this.ClientSize = new System.Drawing.Size(767, 481);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonBasicColourDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.KryptonBasicColourDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _colour;
        #endregion

        #region Property
        public Color Colour { get => _colour; set => _colour = value; }
        #endregion

        #region Constructor
        public KryptonBasicColourDialogLegacy()
        {
            InitializeComponent();
        }
        #endregion

        private void KryptonBasicColourDialog_Load(object sender, EventArgs e)
        {
            UpdateColourValues(cwColourSelector.Colour.R, cwColourSelector.Colour.G, cwColourSelector.Colour.B);
        }

        private void CwColourSelector_ColourChanged(object sender, EventArgs e)
        {
            UpdateColourValues(cwColourSelector.Colour.R, cwColourSelector.Colour.G, cwColourSelector.Colour.B);

            cpbSelectedColour.BackColor = cwColourSelector.Colour;

            Colour = cwColourSelector.Colour;
        }

        private void CpbSelectedColour_MouseEnter(object sender, EventArgs e)
        {

        }

        private void KbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void KbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #region Methods
        private void UpdateColourValues(int red, int green, int blue)
        {
            try
            {
                krvlRed.Text = $"Red Value: { red }";

                //kgvlGreen.Text = $"Green Value: { green }";

                kbvlBlue.Text = $"Blue Value: { blue }";
            }
            catch (Exception exc)
            {

                throw;
            }
        }
        #endregion
    }
}