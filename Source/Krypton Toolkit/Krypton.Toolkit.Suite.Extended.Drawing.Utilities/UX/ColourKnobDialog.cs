#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourKnobDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonPanel kryptonPanel2;
        private Controls.CircularPictureBox cpbxColourPreview;
        private CommonKryptonKnobControlEnhanced kKnobBlue;
        private CommonKryptonKnobControlEnhanced kKnobGreen;
        private CommonKryptonKnobControlEnhanced kKnobRed;
        private KryptonButton kbtnOk;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel6;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel kryptonLabel4;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.cpbxColourPreview = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.kKnobBlue = new Krypton.Toolkit.Suite.Extended.Common.CommonKryptonKnobControlEnhanced();
            this.kKnobGreen = new Krypton.Toolkit.Suite.Extended.Common.CommonKryptonKnobControlEnhanced();
            this.kKnobRed = new Krypton.Toolkit.Suite.Extended.Common.CommonKryptonKnobControlEnhanced();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 216);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(588, 45);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(393, 8);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(489, 8);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.cpbxColourPreview);
            this.kryptonPanel2.Controls.Add(this.kKnobBlue);
            this.kryptonPanel2.Controls.Add(this.kKnobGreen);
            this.kryptonPanel2.Controls.Add(this.kKnobRed);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(588, 216);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(205, 164);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(38, 21);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 9;
            this.kryptonLabel6.Values.Text = "255";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(363, 164);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(38, 21);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "255";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(43, 164);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(38, 21);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 7;
            this.kryptonLabel4.Values.Text = "255";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(199, 12);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(56, 21);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Green";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(361, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(44, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Blue";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(43, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(41, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Red";
            // 
            // cpbxColourPreview
            // 
            this.cpbxColourPreview.BackColor = System.Drawing.SystemColors.Control;
            this.cpbxColourPreview.Location = new System.Drawing.Point(465, 44);
            this.cpbxColourPreview.Name = "cpbxColourPreview";
            this.cpbxColourPreview.Size = new System.Drawing.Size(114, 114);
            this.cpbxColourPreview.TabIndex = 3;
            this.cpbxColourPreview.TabStop = false;
            // 
            // kKnobBlue
            // 
            this.kKnobBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kKnobBlue.EndAngle = 405F;
            this.kKnobBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kKnobBlue.KnobBackColour = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kKnobBlue.LargeChange = 5;
            this.kKnobBlue.Location = new System.Drawing.Point(328, 44);
            this.kKnobBlue.Maximum = 255;
            this.kKnobBlue.Minimum = 0;
            this.kKnobBlue.Name = "kKnobBlue";
            this.kKnobBlue.PointerColour = System.Drawing.Color.Blue;
            this.kKnobBlue.PointerStyle = Krypton.Toolkit.Suite.Extended.Common.CommonKryptonKnobControlEnhanced.KnobPointerStyles.CIRCLE;
            this.kKnobBlue.ScaleColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kKnobBlue.ScaleDivisions = 11;
            this.kKnobBlue.ScaleSubDivisions = 4;
            this.kKnobBlue.ScaleTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kKnobBlue.ShowLargeScale = true;
            this.kKnobBlue.ShowSmallScale = false;
            this.kKnobBlue.Size = new System.Drawing.Size(114, 114);
            this.kKnobBlue.SmallChange = 1;
            this.kKnobBlue.StartAngle = 135F;
            this.kKnobBlue.TabIndex = 2;
            this.kKnobBlue.Value = 0;
            this.kKnobBlue.ValueChanged += new Krypton.Toolkit.Suite.Extended.Common.ValueChangedEventHandler(this.kKnobBlue_ValueChanged);
            // 
            // kKnobGreen
            // 
            this.kKnobGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kKnobGreen.EndAngle = 405F;
            this.kKnobGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kKnobGreen.KnobBackColour = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kKnobGreen.LargeChange = 5;
            this.kKnobGreen.Location = new System.Drawing.Point(169, 44);
            this.kKnobGreen.Maximum = 255;
            this.kKnobGreen.Minimum = 0;
            this.kKnobGreen.Name = "kKnobGreen";
            this.kKnobGreen.PointerColour = System.Drawing.Color.Green;
            this.kKnobGreen.PointerStyle = Krypton.Toolkit.Suite.Extended.Common.CommonKryptonKnobControlEnhanced.KnobPointerStyles.CIRCLE;
            this.kKnobGreen.ScaleColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kKnobGreen.ScaleDivisions = 11;
            this.kKnobGreen.ScaleSubDivisions = 4;
            this.kKnobGreen.ScaleTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kKnobGreen.ShowLargeScale = true;
            this.kKnobGreen.ShowSmallScale = false;
            this.kKnobGreen.Size = new System.Drawing.Size(114, 114);
            this.kKnobGreen.SmallChange = 1;
            this.kKnobGreen.StartAngle = 135F;
            this.kKnobGreen.TabIndex = 1;
            this.kKnobGreen.Value = 0;
            this.kKnobGreen.ValueChanged += new Krypton.Toolkit.Suite.Extended.Common.ValueChangedEventHandler(this.kKnobGreen_ValueChanged);
            // 
            // kKnobRed
            // 
            this.kKnobRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kKnobRed.EndAngle = 405F;
            this.kKnobRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kKnobRed.KnobBackColour = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kKnobRed.LargeChange = 5;
            this.kKnobRed.Location = new System.Drawing.Point(12, 44);
            this.kKnobRed.Maximum = 255;
            this.kKnobRed.Minimum = 0;
            this.kKnobRed.Name = "kKnobRed";
            this.kKnobRed.PointerColour = System.Drawing.Color.Red;
            this.kKnobRed.PointerStyle = Krypton.Toolkit.Suite.Extended.Common.CommonKryptonKnobControlEnhanced.KnobPointerStyles.CIRCLE;
            this.kKnobRed.ScaleColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kKnobRed.ScaleDivisions = 11;
            this.kKnobRed.ScaleSubDivisions = 4;
            this.kKnobRed.ScaleTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kKnobRed.ShowLargeScale = true;
            this.kKnobRed.ShowSmallScale = false;
            this.kKnobRed.Size = new System.Drawing.Size(114, 114);
            this.kKnobRed.SmallChange = 1;
            this.kKnobRed.StartAngle = 135F;
            this.kKnobRed.TabIndex = 0;
            this.kKnobRed.Value = 0;
            this.kKnobRed.ValueChanged += new Krypton.Toolkit.Suite.Extended.Common.ValueChangedEventHandler(this.kKnobRed_ValueChanged);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(588, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // ColourKnobDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(588, 261);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourKnobDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ColourKnobDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColourPreview)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Custom Event
        public delegate void ColourGenerationEventHandler(ColourGenerationEventArgs e);

        public event ColourGenerationEventHandler GeneratedColour;

        public virtual void OnGeneratedColour(ColourGenerationEventArgs e) => GeneratedColour?.Invoke(e);
        #endregion

        private void ColourKnobDialog_Load(object sender, EventArgs e)
        {
            // TODO: DevelopmentUtilities.UnderConstruction(this);
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            ColourGenerationEventArgs colourGenerationEvent = new ColourGenerationEventArgs(255, (byte)kKnobRed.Value, (byte)kKnobGreen.Value, (byte)kKnobBlue.Value);

            OnGeneratedColour(colourGenerationEvent);
        }

        private void kKnobRed_ValueChanged(object sender, Common.KnobValueChangedEventArgs e)
        {

        }

        private void kKnobGreen_ValueChanged(object sender, Common.KnobValueChangedEventArgs e)
        {

        }

        private void kKnobBlue_ValueChanged(object sender, Common.KnobValueChangedEventArgs e)
        {

        }
    }
}