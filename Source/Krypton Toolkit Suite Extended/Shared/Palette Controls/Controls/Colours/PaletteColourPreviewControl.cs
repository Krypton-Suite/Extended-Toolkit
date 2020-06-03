using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Palette.Controls
{
    [DefaultEvent("ColourValueChanged")]
    public class PaletteColourPreviewControl : UserControl
    {
        #region Designer Code
        private Panel panel1;
        private Panel panel2;
        private Panel panel9;
        private Panel panel4;
        private CircularPictureBox cbPreview;
        private KryptonLabelExtended klblHeader;

        private void InitializeComponent()
        {
            this.klblHeader = new KryptonLabelExtended();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbPreview = new CircularPictureBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // klblHeader
            // 
            this.klblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.klblHeader.Image = null;
            this.klblHeader.Location = new System.Drawing.Point(0, 0);
            this.klblHeader.LongTextTypeface = null;
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.Size = new System.Drawing.Size(149, 21);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHeader.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblHeader.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblHeader.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblHeader.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblHeader.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblHeader.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblHeader.TabIndex = 1;
            this.klblHeader.Values.Text = "Header Text";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(108, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(41, 69);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(41, 69);
            this.panel2.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(41, 80);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(67, 10);
            this.panel9.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.cbPreview);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(41, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(67, 59);
            this.panel4.TabIndex = 11;
            // 
            // cbPreview
            // 
            this.cbPreview.BackColor = System.Drawing.Color.White;
            this.cbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPreview.Location = new System.Drawing.Point(0, 0);
            this.cbPreview.Name = "cbPreview";
            this.cbPreview.Size = new System.Drawing.Size(67, 59);
            this.cbPreview.TabIndex = 0;
            this.cbPreview.TabStop = false;
            this.cbPreview.ToolTipValues = null;
            // 
            // PaletteColourPreviewControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.klblHeader);
            this.Name = "PaletteColourPreviewControl";
            this.Size = new System.Drawing.Size(149, 90);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private Color _colour;

        private string _headerText;
        #endregion

        #region Properties
        [Browsable(false)]
        public CircularPictureBox ColourPreviewBox { get => cbPreview; }

        public Color Colour
        {
            get => _colour;

            set
            {
                _colour = value;

                Invalidate();

                ColourValueChangedEventArgs e = new ColourValueChangedEventArgs(value);

                OnColourValueChanged(this, e);
            }
        }

        [DefaultValue("Dummy Text")]
        public string HeaderText { get => _headerText; set { _headerText = value; Invalidate(); } }

        //[DefaultValue(new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold))]
        public override Font Font { get => base.Font; set => base.Font = value; }
        #endregion

        #region Event
        public delegate void ColourValueChangedEventHandler(object sender, ColourValueChangedEventArgs e);

        public event ColourValueChangedEventHandler ColourValueChanged;

        protected virtual void OnColourValueChanged(object sender, ColourValueChangedEventArgs e) => ColourValueChanged?.Invoke(sender, e);
        #endregion

        #region Constructor
        public PaletteColourPreviewControl()
        {
            InitializeComponent();

            Colour = Color.Empty;

            HeaderText = "Dummy Text";

            Font = klblHeader.ShortTextTypeface;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            cbPreview.BackColor = Colour;

            klblHeader.Text = HeaderText;

            base.OnPaint(e);
        }
        #endregion
    }
}