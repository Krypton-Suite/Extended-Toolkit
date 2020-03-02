using Krypton.Toolkit.Extended.Base;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonRGBColourKnobControl : UserControl
    {
        #region Designer Code
        private KryptonKnobControl kknbGreen;
        private KryptonKnobControl kknbBlue;
        private KryptonRedValueLabel kryptonRedValueLabel1;
        private KryptonRedValueLabel klblRedValue;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private KryptonGreenValueLabel klblGreenValue;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonBlueValueLabel klblBlueValue;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonKnobControl kknbRed;

        private void InitializeComponent()
        {
            this.kknbRed = new KryptonKnobControl();
            this.kknbGreen = new KryptonKnobControl();
            this.kknbBlue = new KryptonKnobControl();
            this.kryptonRedValueLabel1 = new KryptonRedValueLabel();
            this.klblRedValue = new KryptonRedValueLabel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblBlueValue = new KryptonBlueValueLabel();
            this.kryptonBlueValueLabel1 = new KryptonBlueValueLabel();
            this.klblGreenValue = new KryptonGreenValueLabel();
            this.kryptonGreenValueLabel1 = new KryptonGreenValueLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kknbRed
            // 
            this.kknbRed.BackColor = System.Drawing.Color.Transparent;
            this.kknbRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbRed.LargeChange = 20;
            this.kknbRed.Location = new System.Drawing.Point(88, 23);
            this.kknbRed.Maximum = 255;
            this.kknbRed.Minimum = 0;
            this.kknbRed.Name = "kknbRed";
            this.kknbRed.ShowLargeScale = true;
            this.kknbRed.ShowSmallScale = false;
            this.kknbRed.Size = new System.Drawing.Size(110, 110);
            this.kknbRed.SizeLargeScaleMarker = 6;
            this.kknbRed.SizeSmallScaleMarker = 3;
            this.kknbRed.SmallChange = 5;
            this.kknbRed.TabIndex = 0;
            this.kknbRed.Value = 0;
            this.kknbRed.ValueChanged += new ValueChangedEventHandler(this.kknbRed_ValueChanged);
            // 
            // kknbGreen
            // 
            this.kknbGreen.BackColor = System.Drawing.Color.Transparent;
            this.kknbGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbGreen.LargeChange = 20;
            this.kknbGreen.Location = new System.Drawing.Point(88, 176);
            this.kknbGreen.Maximum = 255;
            this.kknbGreen.Minimum = 0;
            this.kknbGreen.Name = "kknbGreen";
            this.kknbGreen.ShowLargeScale = true;
            this.kknbGreen.ShowSmallScale = false;
            this.kknbGreen.Size = new System.Drawing.Size(110, 110);
            this.kknbGreen.SizeLargeScaleMarker = 6;
            this.kknbGreen.SizeSmallScaleMarker = 3;
            this.kknbGreen.SmallChange = 5;
            this.kknbGreen.TabIndex = 1;
            this.kknbGreen.Value = 0;
            this.kknbGreen.ValueChanged += new ValueChangedEventHandler(this.kknbGreen_ValueChanged);
            // 
            // kknbBlue
            // 
            this.kknbBlue.BackColor = System.Drawing.Color.Transparent;
            this.kknbBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbBlue.LargeChange = 20;
            this.kknbBlue.Location = new System.Drawing.Point(88, 329);
            this.kknbBlue.Maximum = 255;
            this.kknbBlue.Minimum = 0;
            this.kknbBlue.Name = "kknbBlue";
            this.kknbBlue.ShowLargeScale = true;
            this.kknbBlue.ShowSmallScale = false;
            this.kknbBlue.Size = new System.Drawing.Size(110, 110);
            this.kknbBlue.SizeLargeScaleMarker = 6;
            this.kknbBlue.SizeSmallScaleMarker = 3;
            this.kknbBlue.SmallChange = 5;
            this.kknbBlue.TabIndex = 2;
            this.kknbBlue.Value = 0;
            this.kknbBlue.ValueChanged += new ValueChangedEventHandler(this.kknbBlue_ValueChanged);
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(31, 67);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 255;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(42, 26);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.TabIndex = 13;
            this.kryptonRedValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.Values.Text = "Red";
            // 
            // klblRedValue
            // 
            this.klblRedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblRedValue.Location = new System.Drawing.Point(223, 67);
            this.klblRedValue.Name = "klblRedValue";
            this.klblRedValue.RedValue = 255;
            this.klblRedValue.Size = new System.Drawing.Size(33, 26);
            this.klblRedValue.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRedValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRedValue.TabIndex = 14;
            this.klblRedValue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRedValue.Values.Text = "{0}";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblBlueValue);
            this.kryptonPanel1.Controls.Add(this.kryptonBlueValueLabel1);
            this.kryptonPanel1.Controls.Add(this.klblGreenValue);
            this.kryptonPanel1.Controls.Add(this.kknbBlue);
            this.kryptonPanel1.Controls.Add(this.kknbGreen);
            this.kryptonPanel1.Controls.Add(this.kryptonGreenValueLabel1);
            this.kryptonPanel1.Controls.Add(this.kknbRed);
            this.kryptonPanel1.Controls.Add(this.klblRedValue);
            this.kryptonPanel1.Controls.Add(this.kryptonRedValueLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(301, 452);
            this.kryptonPanel1.TabIndex = 15;
            // 
            // klblBlueValue
            // 
            this.klblBlueValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblBlueValue.Location = new System.Drawing.Point(223, 371);
            this.klblBlueValue.Name = "klblBlueValue";
            this.klblBlueValue.RedValue = 255;
            this.klblBlueValue.Size = new System.Drawing.Size(33, 26);
            this.klblBlueValue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.TabIndex = 19;
            this.klblBlueValue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.Values.Text = "{0}";
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(27, 371);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.RedValue = 255;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(46, 26);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.TabIndex = 18;
            this.kryptonBlueValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.Values.Text = "Blue";
            // 
            // klblGreenValue
            // 
            this.klblGreenValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblGreenValue.Location = new System.Drawing.Point(223, 216);
            this.klblGreenValue.Name = "klblGreenValue";
            this.klblGreenValue.RedValue = 255;
            this.klblGreenValue.Size = new System.Drawing.Size(33, 26);
            this.klblGreenValue.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblGreenValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblGreenValue.TabIndex = 17;
            this.klblGreenValue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblGreenValue.Values.Text = "{0}";
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(15, 216);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.RedValue = 255;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(58, 26);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.TabIndex = 16;
            this.kryptonGreenValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.Values.Text = "Green";
            // 
            // KryptonRGBColourKnobControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonRGBColourKnobControl";
            this.Size = new System.Drawing.Size(301, 452);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _knobForeColour, _knobBackColour, _knobBorderColour, _knobColour, _knobTrackingColour, _colour;

        private IPalette _palette;
        #endregion

        #region Properties
        public Color KnobForeColour { get => _knobForeColour; set { _knobForeColour = value; Invalidate(); } }

        public Color KnobBackColour { get => _knobBackColour; set { _knobBackColour = value; Invalidate(); } }

        public Color KnobBorderColour { get => _knobBorderColour; set { _knobBorderColour = value; Invalidate(); } }

        public Color KnobColour { get => _knobColour; set { _knobColour = value; Invalidate(); } }

        public Color KnobTrackingColour { get => _knobTrackingColour; set { _knobTrackingColour = value; Invalidate(); } }

        public Color Colour { get => _colour; set { _colour = value; Invalidate(); } }
        #endregion

        #region Enumerations
        private enum ColourChannelLabel
        {
            BLUELABEL,
            GREENLABEL,
            REDLABEL
        }
        #endregion

        #region Constructors
        public KryptonRGBColourKnobControl()
        {
            InitializeComponent();

            KnobBackColour = kknbRed.KnobBackColour;

            KnobBorderColour = kknbRed.KnobBorderColour;

            KnobColour = kknbRed.KnobColour;

            KnobForeColour = kknbRed.ForeColor;

            KnobTrackingColour = kknbRed.MouseOverKnobColour;

            Colour = Color.Empty;
        }
        #endregion

        #region Event Handlers
        private void kknbRed_ValueChanged(object Sender)
        {
            AlterLabel(ColourChannelLabel.REDLABEL, kknbRed.Value);
        }

        private void kknbGreen_ValueChanged(object Sender)
        {
            AlterLabel(ColourChannelLabel.GREENLABEL, kknbGreen.Value);
        }

        private void kknbBlue_ValueChanged(object Sender)
        {
            AlterLabel(ColourChannelLabel.BLUELABEL, kknbBlue.Value);
        }
        #endregion

        #region Methods
        private void AlterLabel(ColourChannelLabel colourChannel, int value)
        {
            switch (colourChannel)
            {
                case ColourChannelLabel.BLUELABEL:
                    klblBlueValue.Text = value.ToString();
                    break;
                case ColourChannelLabel.GREENLABEL:
                    klblGreenValue.Text = value.ToString();
                    break;
                case ColourChannelLabel.REDLABEL:
                    klblRedValue.Text = value.ToString();
                    break;
            }
        }
        #endregion
    }
}